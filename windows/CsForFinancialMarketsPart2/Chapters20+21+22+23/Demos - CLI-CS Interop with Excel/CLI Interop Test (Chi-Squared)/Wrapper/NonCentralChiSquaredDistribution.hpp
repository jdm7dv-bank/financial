// NonCentralChiSquaredDistribution.hpp
//
// (C) Datasim Education BV  2009


#pragma once

#include <boost/math/distributions.hpp>

using namespace System;

namespace Wrapper 
{

	// Wrapper for the boost::math::non_central_chi_squared_ditribution class
	// We use the .NET naming conventions instead of the original C++ name
	public ref class NonCentralChiSquaredDistribution
	{
	private:
		// The wrapped native class (only pointers to native classes can be a C++/CLI class datamember)
		boost::math::non_central_chi_squared_distribution<>* m_distribution;

	public:
		// Default constructor
		NonCentralChiSquaredDistribution();

		// Constructor with lower and upper value
		NonCentralChiSquaredDistribution(double df, double lambda);

		// Finaliser (called by garbage collector or destructor)
		!NonCentralChiSquaredDistribution();

		// Destructor (Dispose)
		~NonCentralChiSquaredDistribution();

		// Get the native object
		boost::math::non_central_chi_squared_distribution<>* GetNative();
	};
}
