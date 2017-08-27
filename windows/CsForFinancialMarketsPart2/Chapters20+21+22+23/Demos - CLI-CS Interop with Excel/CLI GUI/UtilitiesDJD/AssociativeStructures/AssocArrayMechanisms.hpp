// AssocArrayMechanisms.hpp
//
// Utility functions for associative arrays. Many data types
// are concrte (we work a lot with long and double).
//
// 2009-1-8 DD kick-off,inline code
//
// (C) Datasim Education BV 2009
//

#ifndef AssocArrayMechanisms_HPP
#define AssocArrayMechanisms_HPP

#include "UtilitiesDJD/DataStructures/Set.cpp"
#include "UtilitiesDJD/AssociativeStructures/AssocArray.cpp"

// Assembling related data for set and array generation

template <typename Numeric, typename Type>
	struct VectorCollectionGenerator	// 1d array, heterogeneous
{
	Numeric Start;						// The lowest or highest value
	Type Increment;						// Relative distance between values (+ or - possible)
	long Size;							// Number of elements to be generated
};

template <typename Numeric, typename Type>
	struct MatrixCollectionGenerator	// 2d matrix
{
	VectorCollectionGenerator<Numeric, Type> rowGenerator;
	VectorCollectionGenerator<Numeric, Type> columnGenerator;

};

// Functions for sets
template <typename Numeric, typename Type>
	Set<Numeric> createSet(Numeric start, Type increment, long Size)
{
	Set<Numeric> result;

	Numeric current = start;

	for (long j = 1; j <= Size; ++j)
	{
		result.Insert(current);
		current += increment;
	}

	return result;
}

template <typename Numeric, typename Type>
	Set<Numeric> createSet(const VectorCollectionGenerator<Numeric, Type>& gen)
{
	Set<Numeric> result;

	Numeric current = gen.Start;

	for (long j = 1; j <= gen.Size; ++j)
	{
		result.Insert(current);
		current += gen.Increment;
	}

	return result;
}


#endif