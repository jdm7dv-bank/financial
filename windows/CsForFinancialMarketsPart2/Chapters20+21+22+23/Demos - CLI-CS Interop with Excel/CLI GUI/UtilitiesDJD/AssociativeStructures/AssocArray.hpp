// AssocArray.hpp
//
// Associative array class. In this case we access elements by 
// using non-integral indices. This is potentially a very useful class
// and it can be used in many financial applications.
// 
// This class is essentially an Adaptor class from an STL map.
//
// (C) Datasim Component Technology 1999-2009

#ifndef AssocArray_hpp
#define AssocArray_hpp

#include "UtilitiesDJD/VectorsAndMatrices/Array.cpp"
#include "UtilitiesDJD/AssociativeStructures/AssocArrayMechanisms.hpp" // inline code
#include "UtilitiesDJD/DataStructures/Set.cpp"
#include <map>
using namespace std;

template <typename AI = string, typename V = double, typename Type = long> class AssocArray
{ // Note that the first index is the value and second index is 
  // 'associative' key

private: 
	map<AI,V> str;	// The list of associative values, e.g. strings
		
	// Redundant information for performance
	Set<AI> keys;

public:
	// Constructors & destructor
	AssocArray();
	AssocArray(const AssocArray<AI, V, Type>& arr2);
	// Construct the map from a list of names and 1 value
	AssocArray(const Set<AI>& names, const V& val);
	AssocArray(const Set<AI>& names, const V& startIndex, const V& increment); // Generare array of values
	AssocArray(const VectorCollectionGenerator<V, Type>& keyGenerator,  const Array<V, long>& val);
	AssocArray(const Set<AI>& names, const Array<V, long>& val);
	~AssocArray();

	AssocArray<AI, V, Type>& operator = (const AssocArray<AI, V, Type>& ass2);

	// New overloaded indexing operator
	virtual V& operator [] (const AI& index);	// Subscripting operator


	typedef typename map<AI,V>::iterator iterator;
	typedef typename map<AI,V>::const_iterator const_iterator;

	// Iterator functions
    iterator begin();				// Return iterator at begin of assoc array
	const_iterator begin() const;	// Return const iterator at begin of assoc array
	iterator end();					// Return iterator after end of assoc array
    const_iterator end() const;		// Return const iterator after end of assoc array

	// Selectors
	long Size() const;
	const Set<AI>& Keys() const;

};


#endif	// AssocArray_hpp