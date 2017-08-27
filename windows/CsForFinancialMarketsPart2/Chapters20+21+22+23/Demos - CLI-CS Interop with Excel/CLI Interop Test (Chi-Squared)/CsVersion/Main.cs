// Main.cs
//
// (C) Datasim Education BV  2009

using System;

using Wrapper;

class MainClass
{
	static void Main(string[] args)
	{
		double x=0.25;
		int k=0;

		// Uniform distributions
		UniformDistribution myUniform=new UniformDistribution(0.0, 1.0);
		Console.WriteLine("Lower value: {0}, Upper value: {1}", myUniform.Lower, myUniform.Upper);

		Console.WriteLine("pdf of Uniform: {0}", BoostMath.Pdf(myUniform, x));
		Console.WriteLine("cdf of Uniform: {0}", BoostMath.Cdf(myUniform, x));
		Console.WriteLine();

		// Bernoulli distributions
		BernoulliDistribution myBernoulli=new BernoulliDistribution(0.4);
		Console.WriteLine("Probability of success: {0}", myBernoulli.SuccessFraction());
	
		Console.WriteLine("pdf of Bernoulli: {0}", BoostMath.Pdf(myBernoulli, k));
		Console.WriteLine("cdf of Bernoulli: {0}", BoostMath.Cdf(myBernoulli, k));
		Console.WriteLine();

		// Chi squared distributions
		ChiSquaredDistribution myChiSquared=new ChiSquaredDistribution(0.4);

		Console.WriteLine("pdf of ChiSquared: {0}", BoostMath.Pdf(myChiSquared, 2));
		Console.WriteLine("cdf of ChiSquared: {0}", BoostMath.Cdf(myChiSquared, 2));
		Console.WriteLine();

		// Non central chi squared distributions
		NonCentralChiSquaredDistribution myNonCentralChiSquared=new NonCentralChiSquaredDistribution(2, 2);

		Console.WriteLine("pdf of NonCentralChiSquared: {0}", BoostMath.Pdf(myNonCentralChiSquared, 2));
		Console.WriteLine("cdf of NonCentralChiSquared: {0}", BoostMath.Cdf(myNonCentralChiSquared, 2));
		Console.WriteLine();

	}
}
