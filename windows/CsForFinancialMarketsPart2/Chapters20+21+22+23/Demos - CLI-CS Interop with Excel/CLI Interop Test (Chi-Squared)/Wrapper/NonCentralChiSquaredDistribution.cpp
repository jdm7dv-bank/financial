// NonCentralChiSquaredDistribution.cpp
//
// (C) Datasim Education BV  2009


#include "stdafx.h"

#include "NonCentralChiSquaredDistribution.hpp"

namespace Wrapper
{
	// Default constructor
	NonCentralChiSquaredDistribution::NonCentralChiSquaredDistribution()
	{
		m_distribution=new boost::math::non_central_chi_squared_distribution<>(0, 1);
	}

	// Constructor with lower and upper value
	NonCentralChiSquaredDistribution::NonCentralChiSquaredDistribution(double df, double lambda)
	{
		m_distribution=new boost::math::non_central_chi_squared_distribution<>(df, lambda);
	}

	// Finaliser (called by garbage collector or destructor)
	NonCentralChiSquaredDistribution::!NonCentralChiSquaredDistribution()
	{
		delete m_distribution;
	}

	// Destructor (Dispose)
	NonCentralChiSquaredDistribution::~NonCentralChiSquaredDistribution()
	{
		// Call finaliser
		this->!NonCentralChiSquaredDistribution();
	}

	// Get the native object
	boost::math::non_central_chi_squared_distribution<>* NonCentralChiSquaredDistribution::GetNative()
	{
		return m_distribution;
	}

}

