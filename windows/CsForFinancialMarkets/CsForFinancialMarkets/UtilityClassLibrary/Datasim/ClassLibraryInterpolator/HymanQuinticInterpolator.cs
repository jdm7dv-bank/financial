﻿
using System;
using System.Collections.Generic;
using System.Linq;


public class HymanQuinticInterpolator : BaseOneDimensionalInterpolator
{
     // Vectors of size n
    Vector<double> xarr;         // x values
    Vector<double> yarr;         // y values

     // Redundant arrays of size n-1
    Vector<double> h;            // h[i] = x[i+1] - x[i]
    Vector<double> delta;        // S[i] = (f[i+1] - f[i]) / h[i]

    Vector<double> d;            // Approximation to f' at mesh points
    Vector<double> dd;           // Approximation to f'' at mesh points

    int n;                       // Number of data points

    public override int findAbscissa(double xvar)
    {  // Will give index of LHS value <= x. Very simple algorithm
         // Value in range [1,n-1]!!!

        for (int j = 1; j < n; j++)
        {
            if (xarr[j] <= xvar && xvar <= xarr[j + 1])
            {
                return j;
            }

        }
         // Then x is in the interval [j, j+1].

        return 999;
    }

    public void init()
    {
         // The local mesh spacing
        h = new Vector<double>(n - 1, 1);
        for (int i = 1; i <= n - 1; ++i)
        {
            h[i] = xarr[i + 1] - xarr[i];  // Hyman's Delta x[i + 1/2]
        }


         // Slope of the linear interpolant between the data points.
         // N.B. Hyman page 647, MUST BE defined at end points
        delta = new Vector<double>(n + 1, 0);
        for (int i = 1; i <= n - 1; ++i)
        {
            delta[i] = (yarr[i + 1] - yarr[i]) / h[i];  // Hyman's S[i + 1/2]
        }

         // Endpoint values Hyman page 647, paragraph 4 text
        delta[0] = delta[1];
        delta[n] = delta[n - 1];

         // I NOT use the Meng Tian eq. (2) to calculate/approximate derivatives.
        d = new Vector<double>(n, 1);
        dd = new Vector<double>(n, 1);
        for (int i = 2; i <= n - 1; ++i)
        {
             //   d[i] = 0.0;
             //   if (delta[i - 1] != 0.0 && delta[i] != 0.0)
            {
                 // d[i] = (h[i] * delta[i - 1] + h[i - 1] * delta[i]) / (h[i] + h[i - 1]);
            }

        }

         // KRUGER APPROX.
        for (int j = 2; j <= n - 1; ++j)
        {


            if (delta[j - 1] * delta[j] < 0.0)
            {
                d[j] = 0.0;
            }
            else
            {
                d[j] = 2.0 / (1.0 / delta[j - 1] + 1.0 / delta[j]);
            }
        }


        d[1] = (3.0 * delta[1] - d[2]) / 2.0;
        d[n] = (3.0 * delta[n - 1] - d[n - 1]) / 2.0;


        for (int j = 2; j <= n - 1; ++j)
        {

             //     dd[j] = ((yarr[j+1]-yarr[j]/h[j]) - (yarr[j]-yarr[j-1]/h[j-1]) )/ (0.5*h[j] + 0.5*h[j-1]);
            dd[j] = (d[j] - d[j - 1]) / (0.5 * (h[j] + h[j - 1]));

        }

        ModifyDerivatives();


    }

    public HymanQuinticInterpolator() { }

    public HymanQuinticInterpolator(Vector<double> abscissa, Vector<double> RHS)
    {

        n = abscissa.Length;

         // BUG FIX
        int startIndex = 1;
        xarr = new Vector<double>(n, startIndex);
        yarr = new Vector<double>(n, startIndex);

        for (int i = 1; i <= n; ++i)
        {
            xarr[i] = abscissa[i - 1];
        }

        for (int i = 1; i <= n; ++i)
        {
            yarr[i] = RHS[i - 1];
        }

        init();
    }


    public HymanQuinticInterpolator(double[] abscissa, double[] RHS)
    {

        n = abscissa.Length;

        int startIndex = 1;
        xarr = new Vector<double>(n, startIndex);
        yarr = new Vector<double>(n, startIndex);

        for (int i = 1; i <= n; ++i)
        {
            xarr[i] = abscissa[i - 1];
        }

        for (int i = 1; i <= n; ++i)
        {
            yarr[i] = RHS[i - 1];
        }

        init();
    }

    public override void Ini(IEnumerable<double> abscissa, IEnumerable<double> RHS)
    {
        n = abscissa.Count();

        int startIndex = 1;
        xarr = new Vector<double>(n, startIndex);
        yarr = new Vector<double>(n, startIndex);

        for (int i = 1; i <= n; ++i)
        {
            xarr[i] = abscissa.ElementAt(i - 1);
        }

        for (int i = 1; i <= n; ++i)
        {
            yarr[i] = RHS.ElementAt(i - 1);
        }

        init();
    }


    bool SameSign(double a, double b, double c, double d)
    {
         // Heavy-handed but it works
        if (a * b < 0.0)
            return false;

        if (a * c < 0.0)
            return false;

        if (a * d < 0.0)
            return false;

        if (b * c < 0.0)
            return false;

        if (b * d < 0.0)
            return false;

        if (c * d < 0.0)
            return false;


        return true;
    }



    void ModifyDerivatives()
    {  // Hyman 89.

        double pm, pu, pd;
        double M, sign;
        double correction;


        sign = Math.Sign(d[1]);
        if (sign == Math.Sign(delta[1]))
        {
            correction = sign * Math.Min(Math.Abs(d[1]), 3.0 * Math.Abs(delta[1]));
        }
        else
        {
            correction = 0.0;
        }

        if (correction != d[1])
        {
            d[1] = correction;
        }

        sign = Math.Sign(d[n]);
        if (sign == Math.Sign(delta[n - 1]))
        {
            correction = sign * Math.Min(Math.Abs(d[n]), 3.0 * Math.Abs(delta[n - 1]));
        }
        else
        {
            correction = 0.0;
        }

        if (correction != d[n])
        {
            d[n] = correction;
        }


        for (int j = 2; j <= n - 1; ++j)
        {
            pm = (delta[j - 1] * h[j] + delta[j] * h[j - 1]) / (h[j] + h[j - 1]);
            M = 3.0 * Math.Min(Math.Min(Math.Abs(delta[j - 1]), Math.Abs(delta[j])), Math.Abs(pm));

             // Console.WriteLine(j);
            if (j > 2)
            {

                pd = (delta[j - 1] * (2.0 * h[j - 1] + h[j - 2]) - delta[j - 2] * h[j - 1]) / (h[j - 2] + h[j - 1]);
                if (SameSign(pm, pd, delta[j - 1] - delta[j - 2], delta[j] - delta[j - 1]) == true)
                {
                    M = Math.Max(M, 1.5 * Math.Min(Math.Abs(pm), Math.Abs(pd)));
                }
            }

            if (j < n - 1)
            {

                pu = (delta[j] * (2.0 * h[j] + h[j + 1]) - delta[j + 1] * h[j]) / (h[j] + h[j + 1]);
                if (SameSign(-pm, -pu, delta[j] - delta[j - 1], delta[j + 1] - delta[j]) == true)
                {
                    M = Math.Max(M, 1.5 * Math.Min(Math.Abs(pm), Math.Abs(pu)));
                }
            }

            sign = Math.Sign(d[j]);
            if (sign == Math.Sign(pm))
            {
                correction = sign * Math.Min(Math.Abs(d[j]), M);
            }
            else
            {
                correction = 0.0;
            }

            if (correction != d[j])
            {
                d[j] = correction;
            }
        }

    }


    public override double Solve(double x)
    {
         // Equation (2.1) of Hyman

         // Find which interval [x[i], x[i+1]] is in. 1 <= i <= n-1
        int i = findAbscissa(x);
         // Console.WriteLine("Index {0}", i);


        double del = (x - xarr[i]);
        double del2 = del * del;
        double del3 = del * del * del;

        double del4 = del * del * del * del;
        double del5 = del * del * del * del * del;


         // (2.1) Hyman
        double c0 = yarr[i];
        double c1 = d[i];
        double c2 = dd[i] / 2.0;
        double c3 = (dd[i + 1] - 3.0 * dd[i]) / (2.0 * h[i]) + 2.0 * (5.0 * delta[i] - 3.0 * d[i] - 2.0 * d[i + 1]) / (h[i] * h[i]);
        double c4 = (3.0 * dd[i] - 2.0 * dd[i + 1]) / (2.0 * h[i] * h[i]) + (8.0 * d[i] + 7.0 * d[i + 1] - 15.0 * delta[i]) / (h[i] * h[i] * h[i]);
        double c5 = (dd[i + 1] - dd[i]) / (2.0 * h[i] * h[i] * h[i]) + 3.0 * (2.0 * delta[i] - d[i + 1] - d[i]) / (h[i] * h[i] * h[i] * h[i]);


        return c0 + c1 * del + c2 * del2 + c3 * del3 + c4 * del4 + c5 * del5;

    }



}