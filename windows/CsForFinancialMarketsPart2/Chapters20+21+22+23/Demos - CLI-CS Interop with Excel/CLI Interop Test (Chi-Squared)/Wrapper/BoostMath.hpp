// BoostMath.hpp
//
// (C) Datasim Education BV  2009


#pragma once

#include "UniformDistribution.hpp"
#include "BernoulliDistribution.hpp"
#include "ChiSquaredDistribution.hpp"
#include "NonCentralChiSquaredDistribution.hpp"

#include <boost/math/distributions.hpp>

using namespace System;

namespace Wrapper 
{

	// Wrapper for the boost::math::uniform_ditribution class
	// We use the .NET naming conventions instead of the original C++ name
	public ref class BoostMath
	{
	private:

	public:
		// Because boost cdf, pdf etc. work with templates, we need to have overloads
		// for each type we pass to these functions. 
		// In CLR we can not use templates, generics or base classes for this. (GetNative() can't return a base class since there is none)


		static double Cdf(UniformDistribution^ distribution, double x);
		static double Cdf(BernoulliDistribution^ distribution, double x);
		static double Cdf(ChiSquaredDistribution^ distribution, double x);
		static double Cdf(NonCentralChiSquaredDistribution^ distribution, double x);

		static double Pdf(UniformDistribution^ distribution, double x);
		static double Pdf(BernoulliDistribution^ distribution, double x);
		static double Pdf(ChiSquaredDistribution^ distribution, double x);
		static double Pdf(NonCentralChiSquaredDistribution^ distribution, double x);

		static double Quantile(UniformDistribution^ distribution, double x);
		static double Quantile(BernoulliDistribution^ distribution, double x);
		static double Quantile(ChiSquaredDistribution^ distribution, double x);
		static double Quantile(NonCentralChiSquaredDistribution^ distribution, double x);
	};
}
