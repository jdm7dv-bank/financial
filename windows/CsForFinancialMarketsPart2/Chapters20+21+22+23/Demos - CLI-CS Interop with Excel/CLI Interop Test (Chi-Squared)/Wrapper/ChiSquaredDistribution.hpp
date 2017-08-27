// ChiSquaredDistribution.hpp
//
// (C) Datasim Education BV  2009


#pragma once

#include <boost/math/distributions.hpp>

using namespace System;

namespace Wrapper 
{
	// Wrapper for the boost::math::chi_squared_distribution class
	// We use the .NET naming conventions instead of the original C++ name
	public ref class ChiSquaredDistribution
	{
	private:
		// The wrapped native class (only pointers to native classes can be a C++/CLI class datamember)
		boost::math::chi_squared_distribution<>* m_distribution;

	public:
		// Default constructor
		ChiSquaredDistribution();

		// Constructor with value
		ChiSquaredDistribution(double value);

		// Finaliser (called by garbage collector or destructor)
		!ChiSquaredDistribution();

		// Destructor (Dispose)
		~ChiSquaredDistribution();

		// Get the native object
		boost::math::chi_squared_distribution<>* GetNative();
	};
}
