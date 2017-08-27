// AssocArray.cpp
//
// Associative array class. In this case we access elements by 
// using non-integral indices.
// This is a proof-of-concept (POC) class.
//
// Last modification dates:
//
//	16 August 2003 DD kick off
//	12 January 2004 DD some new member functions
//	2006-3-24 DD use Set as control; must implement exceptions
//	2009-1-8 DD update, more functionality
//
// (C) Datasim Component Technology 1999-2009

#ifndef AssocArray_cpp
#define AssocArray_cpp

#include "AssocArray.hpp"
#include "AssocArrayMechanisms.hpp" // inline code
#include <iostream>
using namespace std;

template <typename AI, typename V, typename Type> 
	AssocArray<AI, V, Type>::AssocArray()
{

	str = map<AI,V>();
	keys = Set<AI>();
}

template <typename AI, typename V, typename Type> 
	AssocArray<AI, V, Type>::AssocArray(const AssocArray<AI, V, Type>& arr2)
{

	str = arr2.str;
	keys = arr2.keys;
}



// Construct the map from a list of names and a REPEATED val


template <typename AI, typename V, typename Type> 
	AssocArray<AI, V, Type>::AssocArray(const Set<AI>& names, const V& val)
{

	Set<AI>::const_iterator it;
	for (it = names.begin(); it != names.end(); it++)
	{
		str.insert(pair<AI,V>(*it, val));

	}

	keys = names;
}

template <typename AI, typename V, typename Type> 
	 AssocArray<AI, V, Type>::AssocArray(const Set<AI>& names, const V& startIndex, const V& increment)
	 { // Generate array of values


	Set<AI>::const_iterator it;
	V current = startIndex;
	for (it = names.Begin(); it != names.End(); it++)
	{
		str.insert(pair<AI,V>(*it, current));
		current += increment;

	}

	keys = names;
}

template <typename AI, typename V, typename Type> 
	AssocArray<AI, V, Type>::AssocArray(const Set<AI>& names, const Array<V, long>& valArray)
{

	// PREC: number of elements in Set == size of array
	long index = valArray.MinIndex();
	Set<AI>::const_iterator it;
	for (it = names.Begin(); it != names.End(); it++)
	{
		str.insert(pair<AI,V>(*it, valArray[index++]));

	}

	keys = names;
}

template <typename AI, typename V, typename Type> 
	AssocArray<AI, V, Type>::AssocArray(const VectorCollectionGenerator<V, Type>& keyGenerator, const Array<V, long>& valArray)
{

	// PREC: number of elements in Set == size of array
	long index = valArray.MinIndex();
	Set<AI>::const_iterator it;
	for (it = names.Begin(); it != names.End(); it++)
	{
		str.insert(pair<AI,V>(*it, valArray[index++]));

	}

	keys = createSet(keyGenerator);
}

template <typename AI, typename V, typename Type> 
	AssocArray<AI, V, Type>::~AssocArray()
{

	str = map<AI,V>();
	keys = Set<AI>();
}

template <typename AI, typename V, typename Type> 
	AssocArray<AI, V, Type>& AssocArray<AI, V, Type>::operator = (const AssocArray<AI, V, Type>& ass2)
{
	if (&ass2 == this)
		return *this;


	 str = ass2.str;

	// Use copy algorithm to copy the maps
//	copy(ass2.str.begin(), ass2.end(), str.begin());
	
	keys = ass2.keys;

	return *this;

}


// New overloaded indexing operator
template <typename AI, typename V, typename Type> 
	V& AssocArray<AI, V, Type>::operator [] (const AI& index)
{

	return str[index];


}


// Iterator functions
template <typename AI, typename V, typename Type> typename
AssocArray<AI, V, Type>::iterator AssocArray<AI, V, Type>::begin()
{ // Return iterator at begin of composite

	return str.begin();
}

template <typename AI, typename V, typename Type> typename
	AssocArray<AI, V, Type>::const_iterator AssocArray<AI, V, Type>::begin() const
{ // Return const iterator at begin of composite

	return str.begin();
}

template <typename AI, typename V, typename Type> typename
	AssocArray<AI, V, Type>::iterator AssocArray<AI, V, Type>::end()
{ // Return iterator after end of composite

	return str.end();
}

template <typename AI, typename V, typename Type> typename
	 AssocArray<AI, V, Type>::const_iterator AssocArray<AI, V, Type>::end() const
{ // Return const iterator after end of composite

	return str.end();
}

template <typename AI, typename V, typename Type>
	long AssocArray<AI, V, Type>::Size() const 
{ 
	return str.size(); 
}

template <typename AI, typename V, typename Type> 
	const Set<AI>& AssocArray<AI, V, Type>::Keys() const 
{ 
	return keys; 
}		


#endif	// AssocArray_cpp