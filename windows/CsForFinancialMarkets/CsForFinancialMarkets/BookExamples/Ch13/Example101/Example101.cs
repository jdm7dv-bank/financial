﻿// ---------------------------------------------------------------------------------------------
// IMPORTANT DISCLAIMER:
// The code is for demonstration purposes only, it comes with NO WARRANTY AND GUARANTEE.
// No liability is accepted by the Author with respect any kind of damage caused by any use
// of the code under any circumstances.
// Any market parameters used are not real data but have been created to clarify the exercises 
// and should not be viewed as actual market data.
//
// Example101.cs
// Author Andrea Germani
// Copyright (C) 2012. All right reserved
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Based on Datasim interpolators
public class InterpolatorExample101
{
    public static void Main()
    {       
        Example101();
    }

    // 13.12.1	The 101 Example, from A to Z
    public static void Example101()
    {
        // My excel mechanism
        ExcelMechanisms exl = new ExcelMechanisms();

        // I Create initial t and r arrays.
        Vector<double> t = new Vector<double>(new double[] { 0.1, 1, 4, 9, 20, 30 }, 0);
        Vector<double> r = new Vector<double>(new double[] { 0.081, 0.07, 0.044, 0.07, 0.04, 0.03 }, 0);

        // Compute log df
        Vector<double> logDF = new Vector<double>(r.Size, r.MinIndex);
        for (int n = logDF.MinIndex; n <= logDF.MaxIndex; ++n)
        {
            logDF[n] = Math.Log(Math.Exp(-t[n] * r[n]));
        }
        // exl.printOneExcel<double>(t, logDF, "logDF", "time", "logDF", "logDF");

        // II Hyman interpolator 
        HymanHermiteInterpolator_V4 myInterpolatorH
                        = new HymanHermiteInterpolator_V4(t, logDF);

        // Create the abscissa values f (hard-coded for the moment)
        int M = 299;
        Vector<double> term = new Vector<double>(M, 1);
        term[term.MinIndex] = 0.1;
        double step = 0.1;
        for (int j = term.MinIndex + 1; j <= term.MaxIndex; j++)
        {
            term[j] = term[j - 1] + step;
        }

        // III Compute interpolated values
        Vector<double> interpolatedlogDFH = myInterpolatorH.Curve(term);
        // exl.printOneExcel<double>(term, interpolatedlogDFH,
        //                "Hyman cubic", "time", "int logDF", "int logDF");

        // IV Compute continuously compounded risk free rate from the ZCB Z(0,t),
        // using equation (3)Hagan and West (2008).
        Vector<double> rCompounded = new Vector<double>(interpolatedlogDFH.Size,
                       interpolatedlogDFH.MinIndex);

        for (int j = rCompounded.MinIndex; j <= rCompounded.MaxIndex; j++)
        {
            rCompounded[j] = -interpolatedlogDFH[j] / term[j];
        }
        exl.printOneExcel<double>(term, rCompounded,
        "RCompound Hyman Cubic", "time", "r continuously comp.", "r cont");

        // V Compute discrete forward rates using equation (6) from Hagan and West (2008)
        Vector<double> f = new Vector<double>(rCompounded.Size,
                            rCompounded.MinIndex);
        f[f.MinIndex] = 0.081;

        for (int j = f.MinIndex + 1; j <= rCompounded.MaxIndex; j++)
        {
            f[j] = (rCompounded[j] * term[j] - rCompounded[j - 1]
                        * term[j - 1]) / (term[j] - term[j - 1]);
        }
        exl.printOneExcel<double>(term, f, "Hyman Cubic", "time", "discrete forward", "dis fwd");
    }
}