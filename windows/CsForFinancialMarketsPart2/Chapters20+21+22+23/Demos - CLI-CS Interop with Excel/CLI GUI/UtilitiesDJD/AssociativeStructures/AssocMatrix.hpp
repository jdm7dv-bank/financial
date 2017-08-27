// AssocMatrix.hpp
//
// Associative matrix class. In this case we access elements by 
// using non-integral indices. This is potentially a very useful class
// and it can be used in many financial applications.
// 
// The elements of the matrix are numeric because we usually work with 
// spreadsheet applications.
//
// (C) Datasim Component Technology 1999-2009

#ifndef AssocMatrix_hpp
#define AssocMatrix_hpp

#include "UtilitiesDJD/VectorsAndMatrices/NumericMatrix.cpp"
#include "UtilitiesDJD/AssociativeStructures/AssocArray.cpp"
#include "UtilitiesDJD/DataStructures/Set.cpp"
using namespace std;

// Spreadsheet-like stuff
template <class AI1, class AI2> 
		struct SpreadSheetVertex
{
		AI1 first;
		AI2 second;
};		

template <class AI1, class AI2>
		struct SpreadSheetRange
{

		SpreadSheetVertex<AI1, AI2> upperLeft;
		SpreadSheetVertex<AI1, AI2> lowerRight;

};

////////////////////////////////////////////////////////////////////////////////////////////////

template <typename AI1 = string, typename AI2 = string, typename V = double> class AssocMatrix
{ // Note that the first index is the value and second indices are 
  // 'associative' key

public: // For performance and convenience
		
		// The essential data
		NumericMatrix<V, long>* mat;// The real data
private:
		AssocArray<AI1, long> r;	// Rows
		AssocArray<AI2, long> c;	// Columns

public:
		// Redundant information for performance
		Set<AI1> keysRows;
		Set<AI2> keysColumns;

public:
	// Constructors & destructor
	AssocMatrix();
	AssocMatrix(const AssocMatrix<AI1, AI2,V>& arr2);

	// Create assoc matrix with matrix data and 'generators' of rows and columns
	AssocMatrix(const V & rowStart, const V& columnStart, NumericMatrix<V, long>& matrix);
	// Construct the map from a list of names and values
	AssocMatrix(const Set<AI1>& Rnames, const Set<AI2>& Cnames, 
									 NumericMatrix<V, long>& matrix);

	AssocMatrix<AI1, AI2,V>& operator = (const AssocMatrix<AI1, AI2,V>& ass2);

	// New overloaded indexing operator
	virtual V& operator () (const AI1& index1, const AI2& index2);

	// Modifiers
	// Change values in some range
	void modify(const SpreadSheetRange<AI1, AI2>& range, void (*f)(V& cellValue));

	// Selectors; inline for convenience and readability
	long Size() const { return str.size(); }
	NumericMatrix<V, long> extract(const SpreadSheetRange<AI1, AI2>& range);

	// Return copies of keys
	Set<AI1>& RowKeys();	
	const Set<AI2>& ColumnKeys() const;	
	NumericMatrix<V, long>* Data();


	typedef typename AssocArray<AI1,long>::iterator iterator;
	typedef typename AssocArray<AI1, long>::const_iterator const_iterator;

	// Iterator functions
    iterator begin();				// Return iterator at begin of assoc matrix
	const_iterator begin() const;	// Return const iterator at begin of assoc matrix
	iterator end();					// Return iterator after end of assoc matrix
    const_iterator end() const;		// Return const iterator after end of assoc matrix

};


#endif	// AssocMatrix_hpp