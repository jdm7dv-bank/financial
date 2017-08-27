// AssocMatrix.cpp
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
//	2006-3-25 DD copy from ass array
//	2009-1-8 DD update for new applications
//
// (C) Datasim Component Technology 1999-2009

#ifndef AssocMatrix_cpp
#define AssocMatrix_cpp

#include "AssocMatrix.hpp"
#include <iostream>
using namespace std;

template <class AI1, class AI2, class V> 
	AssocMatrix<AI1, AI2,V>::AssocMatrix()
{

	cout << "init";

	mat = 0;
	r = AssocArray<AI1, long> ();
	c = AssocArray<AI2, long> ();
	keysRows = Set<AI1>();
	keysColumns = Set<AI2>();
}

template <class AI1, class AI2, class V> 
	AssocMatrix<AI1, AI2,V>::AssocMatrix(const AssocMatrix<AI1, AI2,V>& mat2)
{

	mat = mat2.mat;
	r = mat2.r; c = mat2.c;
	keysRows = mat2.keysRows;
	keysColumns = mat2.keysColumns;

}



// Construct the map from a list of names and a REPEATED val

template <class AI1, class AI2, class V> 
AssocMatrix<AI1, AI2,V>::AssocMatrix(const V & rowStart, const V& columnStart,  NumericMatrix<V, long>& matrix) 
						
{

	// Must build the associative arrays, they have the same values as the
	// indices in the matrix

	VectorCollectionGenerator<V, long> rowGenerator;
	rowGenerator.Start = rowStart;
	rowGenerator.Increment = 1;
	rowGenerator.Size = matrix.Rows();

	VectorCollectionGenerator<double, long> columnGenerator;
	columnGenerator.Start = columnStart;
	columnGenerator.Increment = 1;
	columnGenerator.Size = matrix.Columns();

	mat = &matrix;

	keysRows = createSet(rowGenerator);
	keysColumns = createSet(columnGenerator);

	// Build rows
	long start = mat->MinRowIndex();
	Set<AI1>::const_iterator it; // Size == size of matrix
	r = AssocArray<AI1, long> (keysRows,start);

	for (it = keysRows.Begin(); it != keysRows.End(); it++)
	{
			r[*it] = start;
			start++;
	}

	// Build columns
	start = mat->MinColumnIndex();
	Set<AI2>::const_iterator itc; // Size == size of matrix
	c = AssocArray<AI2, long> (keysColumns,start);

	for (itc = keysColumns.Begin(); itc != keysColumns.End(); itc++)
	{
			
			c[*itc] = start;
			start++;
	}

	// NO EXCEPTION HANDLING AT THE MOMENT
	//print(c);
}

template <class AI1, class AI2, class V> 
AssocMatrix<AI1, AI2,V>::AssocMatrix(const Set<AI1>& Rnames, const Set<AI2>& Cnames,
								NumericMatrix<V, long>& matrix) 
			: keysRows(Rnames), keysColumns(Cnames)
{

	// Must build the associative arrays, they have the same values as the
	// indices in the matrix

	mat = &matrix;

	// Build rows
	long start = mat->MinRowIndex();
	Set<AI1>::const_iterator it; // Size == size of matrix
	r = AssocArray<AI1, long> (keysRows,start);

	for (it = keysRows.begin(); it != keysRows.end(); it++)
	{
			r[*it] = start;
			start++;
	}

	// Build columns
	start = mat->MinColumnIndex();
	Set<AI2>::const_iterator itc; // Size == size of matrix
	c = AssocArray<AI2, long> (keysColumns,start);

	for (itc = keysColumns.begin(); itc != keysColumns.end(); itc++)
	{
			
			c[*itc] = start;
			start++;
	}

	// NO EXCEPTION HANDLING AT THE MOMENT
	//print(c);
}

// Change values in some range
template <class AI1, class AI2, class V> 
void AssocMatrix<AI1, AI2,V>::modify(const SpreadSheetRange<AI1, AI2>& range, void (*f)(V& cellValue))
{

	// Objective is to iterate in a range and apply a function to each 
	// element in that range

		AI1 rmin = range.upperLeft.first;
		AI2 cmin = range.upperLeft.second;

		AI1 rmax = range.lowerRight.first;
		AI2 cmax = range.lowerRight.second;

		cout << rmin << ",r  " << rmax << endl;

		long Rmin = r[rmin]; long Rmax = r[rmax];
		long Cmin = c[cmin]; long Cmax = c[cmax];

		cout << Rmin << ", " << Rmax << endl;
		cout << Cmin << ", " << Cmax << endl;

		// Now must find the integer indices corresponding to these

		for (long ri = Rmin; ri <= Rmax; ri++)
		{
			for (long ci = Cmin; ci <= Cmax; ci++)
			{
				cout << ri << ", " << ci;

				f((*mat)(ri,ci));
			}
		}

}

template <class AI1, class AI2, class V> 
	NumericMatrix<V, long> AssocMatrix<AI1, AI2,V>::extract(const SpreadSheetRange<AI1, AI2>& range)
{

	// Slice a matrix
	AI1 rmin = range.upperLeft.first;
		AI2 cmin = range.upperLeft.second;

		AI1 rmax = range.lowerRight.first;
		AI2 cmax = range.lowerRight.second;

		cout << rmin << ",r  " << rmax << endl;

		long Rmin = r[rmin]; long Rmax = r[rmax];
		long Cmin = c[cmin]; long Cmax = c[cmax];

		cout << Rmin << ", " << Rmax << endl;
		cout << Cmin << ", " << Cmax << endl;

		int d;
		cin >> d;

		// Now must find the integer indices corresponding to these
		NumericMatrix<V, long> result(Rmax-Rmin+1, Cmax-Cmin+1, Rmin, Cmin);

		for (long ri = Rmin; ri <= Rmax; ri++)
		{
			for (long ci = Cmin; ci <= Cmax; ci++)
			{
					result(ri, ci) = (*mat)(ri, ci);
			}
		}

		return result;

}




template <class AI1, class AI2, class V> 
	AssocMatrix<AI1, AI2,V>& AssocMatrix<AI1, AI2,V>::operator = (const AssocMatrix<AI1, AI2,V>& mat2)
{
	(if &mat == this)
		return *this;

	mat = mat2.mat;
	r = mat2.r; c = mat2.c;
	keysRows = mat2.keysRows; keysColumns = mat2.keysColumns;
	
	return *this;

}



// New overloaded indexing operator
template <class AI1, class AI2, class V>
	V& AssocMatrix<AI1, AI2,V>::operator () (const AI1& index1, const AI2& index2)
{

	long rowIndex = r[index1];
	long colIndex = c[index2];

	return (*mat)(rowIndex, colIndex);
}

// Return copies of keys
template <class AI1, class AI2, class V> 
	 Set<AI1>& AssocMatrix<AI1, AI2,V>::RowKeys() 
{
	return keysRows;
} 

template <class AI1, class AI2, class V>
	 const Set<AI2>& AssocMatrix<AI1, AI2,V>::ColumnKeys() const
{
	return keysColumns;
}
template <class AI1, class AI2, class V>
	NumericMatrix<V, long>* AssocMatrix<AI1, AI2,V>::Data()
{
	return mat;
}

// Iterator functions
template <class AI1, class AI2, class V> typename
AssocMatrix<AI1, AI2,V>::iterator AssocMatrix<AI1, AI2,V>::begin()
{ // Return iterator at begin 

	return r.begin();
}

template <class AI1, class AI2, class V> typename
AssocMatrix<AI1, AI2,V>::const_iterator AssocMatrix<AI1, AI2,V>::begin() const
{ // Return const iterator at begin 

	return r.begin();
}

template <class AI1, class AI2, class V> typename
AssocMatrix<AI1, AI2,V>::iterator AssocMatrix<AI1, AI2,V>::end()
{ // Return iterator after end 

	return r.end();
}

template <class AI1, class AI2, class V> typename
AssocMatrix<AI1, AI2,V>::const_iterator AssocMatrix<AI1, AI2,V>::end() const
{ // Return const iterator after end 

	return r.end();
}


#endif	// AssocMatrix_cpp