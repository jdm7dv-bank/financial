// UniformDistribution.hpp
//
// (C) Datasim Education BV  2009


#pragma once

#include <boost/math/distributions.hpp>

using namespace System;

namespace Wrapper 
{

	// Wrapper for the boost::math::uniform_distribution class
	// We use the .NET naming conventions instead of the original C++ name
	public ref class UniformDistribution
	{
	private:
		// The wrapped native class (only pointers to native classes can be a C++/CLI class datamember)
		boost::math::uniform_distribution<>* m_distribution;

	public:
		// Default constructor
		UniformDistribution();

		// Constructor with lower and upper value
		UniformDistribution(double lower, double upper);

		// Finaliser (called by garbage collector or destructor)
		!UniformDistribution();

		// Destructor (Dispose)
		~UniformDistribution();

		// Access the lower value
		property double Lower
		{
			// Get the lower value
			double get();
		}

		// Access the upper value
		property double Upper
		{
			// Get the upper value
			double get();
		}

		// Get the native object
		boost::math::uniform_distribution<>* GetNative();
	};
}
