// UniformDistribution.cpp
//
// (C) Datasim Education BV  2009


#include "stdafx.h"

#include "UniformDistribution.hpp"

namespace Wrapper
{
	// Default constructor
	UniformDistribution::UniformDistribution()
	{
		m_distribution=new boost::math::uniform_distribution<>();
	}

	// Constructor with lower and upper value
	UniformDistribution::UniformDistribution(double lower, double upper)
	{
		m_distribution=new boost::math::uniform_distribution<>(lower, upper);
	}

	// Finaliser (called by garbage collector or destructor)
	UniformDistribution::!UniformDistribution()
	{
		delete m_distribution;
	}

	// Destructor (Dispose)
	UniformDistribution::~UniformDistribution()
	{
		// Call finaliser
		this->!UniformDistribution();
	}

	// Get the lower value
	double UniformDistribution::Lower::get()
	{
		return m_distribution->lower();
	}

	// Get the upper value
	double UniformDistribution::Upper::get()
	{
		return m_distribution->upper();
	}

	// Get the native object
	boost::math::uniform_distribution<>* UniformDistribution::GetNative()
	{
		return m_distribution;
	}

}

