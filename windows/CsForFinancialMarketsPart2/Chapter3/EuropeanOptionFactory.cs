// EuropeanOptionFactory.cs
//
// Classes for creating Eurpean Options. This is
// a Factory Method pattern.
//
// (C) Datasim Education BV 2005-2010

using System;

public interface IOptionFactory
{ // An interface consists of abstract methods

		Option create();
}

public class ConsoleEuropeanOptionFactory: IOptionFactory
{
	
		public Option create()
		{
			Console.Write( "\n*** Parameters for option object ***\n");

            double r;		// Interest rate
            double sig;	    // Volatility
            double K;		// Strike price
            double T;		// Expiry date
            double b;		// Cost of carry

            string type;	// Option name (call, put)


		    Console.Write( "Strike: ");
			K = Convert.ToDouble(Console.ReadLine());

			Console.Write( "Volatility: ");
			sig = Convert.ToDouble(Console.ReadLine());

			Console.Write( "Interest rate: ");
			r = Convert.ToDouble(Console.ReadLine());

            Console.Write( "Cost of carry: ");
			b = Convert.ToDouble(Console.ReadLine());

			Console.Write( "Expiry date: ");
			T = Convert.ToDouble(Console.ReadLine());

			Console.Write( "1. Call, 2. Put: ");
			type = Convert.ToString(Console.ReadLine());

           /* public double r;		// Interest rate
            public double sig;	    // Volatility
            public double K;		// Strike price
            public double T;		// Expiry date
            public double b;		// Cost of carry

            public string otyp;	    // Option name (call, put)*/


            Option opt = new Option();
            opt.otyp = type;
            opt.T = T;
            opt.K = K;
            opt.b = b;
            opt.r = r;
            opt.sig = sig;

			return opt;
		}
}





