// ChiSquaredDistribution.cpp
//
// (C) Datasim Education BV  2009


#include "stdafx.h"

#include "ChiSquaredDistribution.hpp"

namespace Wrapper
{
	// Default constructor
	ChiSquaredDistribution::ChiSquaredDistribution()
	{
		m_distribution=new boost::math::chi_squared_distribution<>(0);
	}

	// Constructor with value
	ChiSquaredDistribution::ChiSquaredDistribution(double value)
	{
		m_distribution=new boost::math::chi_squared_distribution<>(value);
	}

	// Finaliser (called by garbage collector or destructor)
	ChiSquaredDistribution::!ChiSquaredDistribution()
	{
		delete m_distribution;
	}

	// Destructor (Dispose)
	ChiSquaredDistribution::~ChiSquaredDistribution()
	{
		// Call finaliser
		this->!ChiSquaredDistribution();
	}

	// Get the native object
	boost::math::chi_squared_distribution<>* ChiSquaredDistribution::GetNative()
	{
		return m_distribution;
	}

}

