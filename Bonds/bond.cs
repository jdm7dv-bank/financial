using System;
using System.Linq;
using System.Collections;

public class Bonds
{

public void PresentValue()
{
	// My bond defined as collection of pair (time, cash flows)
	var Bond = new[]
	{
		new { Time = 1.0 , CashFlow = 5.0 },
		new { Time = 1.5 , CashFlow = 5.0 },
		new { Time = 2.0 , CashFlow = 105.0 }
	};
	foreach(var item in Bond)
	{
    		Console.WriteLine(item.ToString());
	}		
	
	// Define my discount (lambda) function: standard continuous compounding
	Func<double, double, double> CalcDF = (t, r) => Math.Exp(-r * t);
	// Continuous rate, 5% as example
	double rate = 0.05;
	// Present value of each cash flow
	
	var PvCashFlows = from p in Bond

	
	select new { Time = p.Time,CashFlow = p.CashFlow * CalcDF(p.Time, rate) };
	
	
	foreach(var items in PvCashFlows)
        {
                Console.WriteLine(items.ToString());
        }

	Console.WriteLine("\nSum of PV of cash flows = {0}",
	PvCashFlows.Sum(p => p.CashFlow));
}
}

public class TestClass
{
	public static void Main()
	{
		Bonds b1 = new Bonds();
		b1.PresentValue();
	}
}
