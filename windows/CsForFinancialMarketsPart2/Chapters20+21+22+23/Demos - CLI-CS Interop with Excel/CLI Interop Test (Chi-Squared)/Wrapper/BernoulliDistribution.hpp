// BernoulliDistribution.hpp
//
// (C) Datasim Education BV  2009

#pragma once

#include <boost/math/distributions.hpp>

using namespace System;

namespace Wrapper 
{
	// Wrapper for the boost::math::bernoulli_distribution class
	// We use the .NET naming conventions instead of the original C++ name
	public ref class BernoulliDistribution
	{
	private:
		// The wrapped native class (only pointers to native classes can be a C++/CLI class datamember)
		boost::math::bernoulli_distribution<>* m_distribution;

	public:
		// Default constructor
		BernoulliDistribution();

		// Constructor with value
		BernoulliDistribution(double value);

		// Finaliser (called by garbage collector or destructor)
		!BernoulliDistribution();

		// Destructor (Dispose)
		~BernoulliDistribution();

		// Get the success fraction
		double SuccessFraction();

		// Get the native object
		boost::math::bernoulli_distribution<>* GetNative();
	};
}
