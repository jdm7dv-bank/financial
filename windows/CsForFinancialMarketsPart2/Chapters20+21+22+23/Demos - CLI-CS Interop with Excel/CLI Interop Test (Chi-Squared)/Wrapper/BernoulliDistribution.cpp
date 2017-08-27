// BernoulliDistribution.cpp
//
// (C) Datasim Education BV  2009


#include "stdafx.h"

#include "BernoulliDistribution.hpp"

namespace Wrapper
{
	// Default constructor
	BernoulliDistribution::BernoulliDistribution()
	{
		m_distribution=new boost::math::bernoulli_distribution<>();
	}

	// Constructor with value
	BernoulliDistribution::BernoulliDistribution(double value)
	{
		m_distribution=new boost::math::bernoulli_distribution<>(value);
	}

	// Finaliser (called by garbage collector or destructor)
	BernoulliDistribution::!BernoulliDistribution()
	{
		delete m_distribution;
	}

	// Destructor (Dispose)
	BernoulliDistribution::~BernoulliDistribution()
	{
		// Call finaliser
		this->!BernoulliDistribution();
	}

	// Get the success fraction
	double BernoulliDistribution::SuccessFraction()
	{
		return m_distribution->success_fraction();
	}

	// Get the native object
	boost::math::bernoulli_distribution<>* BernoulliDistribution::GetNative()
	{
		return m_distribution;
	}

}

