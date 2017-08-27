// BoostMath.cpp
//
// (C) Datasim Education BV  2009


#include "stdafx.h"

#include "BoostMath.hpp"

namespace Wrapper
{

	// Cdf

	double BoostMath::Cdf(UniformDistribution^ distribution, double x)
	{
		return boost::math::cdf(*distribution->GetNative(), x);
	}

	double BoostMath::Cdf(BernoulliDistribution^ distribution, double x)
	{
		return boost::math::cdf(*distribution->GetNative(), x);
	}

	double BoostMath::Cdf(ChiSquaredDistribution^ distribution, double x)
	{
		return boost::math::cdf(*distribution->GetNative(), x);
	}

	double BoostMath::Cdf(NonCentralChiSquaredDistribution^ distribution, double x)
	{
		return boost::math::cdf(*distribution->GetNative(), x);
	}


	// Pdf

	double BoostMath::Pdf(UniformDistribution^ distribution, double x)
	{
		return boost::math::pdf(*distribution->GetNative(), x);
	}

	double BoostMath::Pdf(BernoulliDistribution^ distribution, double x)
	{
		return boost::math::pdf(*distribution->GetNative(), x);
	}

	double BoostMath::Pdf(ChiSquaredDistribution^ distribution, double x)
	{
		return boost::math::pdf(*distribution->GetNative(), x);
	}

	double BoostMath::Pdf(NonCentralChiSquaredDistribution^ distribution, double x)
	{
		return boost::math::pdf(*distribution->GetNative(), x);
	}


	// Quantile 

	double BoostMath::Quantile(UniformDistribution^ distribution, double x)
	{
		return boost::math::quantile(*distribution->GetNative(), x);
	}

	double BoostMath::Quantile(BernoulliDistribution^ distribution, double x)
	{
		return boost::math::quantile(*distribution->GetNative(), x);
	}

	double BoostMath::Quantile(ChiSquaredDistribution^ distribution, double x)
	{
		return boost::math::quantile(*distribution->GetNative(), x);
	}

	double BoostMath::Quantile(NonCentralChiSquaredDistribution^ distribution, double x)
	{
		return boost::math::quantile(*distribution->GetNative(), x);
	}

}