// TestNonCentralChiSquared.cpp
//
// Test of noncentral chi^2 distribution (boost 1.36!!!). Once you understand
// the member functions and global functions for 1 kind of distribitions it becomes
// very easy to apply them to other kinds of distributions.
//
// Contents:
//
//	1. Statistcal properties of some distributions
//	2. Create a table of power of a test using non central chi^2, similar to boost except
//  we store all the data in an 1) normal matrix, 2) associative matrix. The advantage of approach
//  2 is that we can index using specific values of the degrees of freedom and non centrality parameter.
//
//	DJD, based on adaption of code in Chapter 3.
//
//	2009-1-8 DD creating look up tables
//
// (C) Datasim Education BV 2009
//

#include <boost/math/distributions/non_central_chi_squared.hpp> // for NC chi_squared_distribution
#include <boost/math/special_functions/cbrt.hpp>				// for chi_squared_distribution
#include <boost/math/distributions.hpp>							// For non-member functions of distributions

#include <boost/math/distributions/chi_squared.hpp> 
#include <boost/math/distributions/poisson.hpp>

#include "UtilitiesDJD/AssociativeStructures/AssocArray.cpp"
#include "UtilitiesDJD/AssociativeStructures/AssocMatrix.cpp"

#include "UtilitiesDJD/CompileTimeVectorsAndMatrices/VectorSpace.cpp"
#include "UtilitiesDJD/CompileTimeVectorsAndMatrices/VectorSpaceMechanisms.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/Vector.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/NumericMatrix.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/ArrayMechanisms.cpp"
#include "UtilitiesDJD/ExcelDriver/ExcelMechanisms.hpp"
#include "UtilitiesDJD/Geometry/Range.cpp"
#include "UtilitiesDJD/BitsAndPieces/StringConversions.hpp"
#include "UtilitiesDJD/ExceptionClasses/DatasimException.hpp"
#include "UtilitiesDJD/ExceptionClasses/DatasimException.hpp"
#include "UtilitiesDJD/RNG/UniformGenerator.hpp"
#include "UtilitiesDJD/RNG/NormalGenerator.hpp"


#include <iostream>
using namespace std;

template <typename Key1, typename Key2, typename Value>
	void print(const AssocMatrix<Key1, Key2, Value>& assMat)
{

	// Iterating in the map
	AssocMatrix<Key1, Key2, Value>::const_iterator iter = assMat.begin();


	
	for (long i = assMat.mat->MinRowIndex(); i <= assMat.mat->MaxRowIndex(); ++i)
	{
		cout << "Row " << (*iter).first << ":  ";
		for (long j = assMat.mat->MinColumnIndex(); j <= assMat.mat->MaxColumnIndex(); ++j)
		{
			cout << std::setprecision(3) << (*assMat.mat)(i,j) << ", ";
		}
		cout << endl;iter++;
	}
	
	cout << endl;
}

int main()
{

	// Significance level
	double level = 0.05;
	double cs;			// Temporary variable for chi^2 distribution

	// Now create the row and column indices
	VectorCollectionGenerator<double, double> dofRows; // Degrees of freedom
	dofRows.Start = 2.0;
	dofRows.Increment = 1.0;
	dofRows.Size = 9;
	Set<double> dofSet = createSet<double>(dofRows);

	VectorCollectionGenerator<double, double> nonCentralParameterColumns; // non cen parameter
	nonCentralParameterColumns.Start = 2.0;
	nonCentralParameterColumns.Increment = 2.0;
	nonCentralParameterColumns.Size = 5;
	Set<double> nonCentralParameterSet = createSet<double>(nonCentralParameterColumns);


	// Start values for rows and columns
	double r1 = dofRows.Start;
	double c1 = nonCentralParameterColumns.Start;

	// Lookup table dimensions
	long NRows = dofRows.Size;								// Degrees of freedom
	long NColumns = nonCentralParameterColumns.Size;		// Non-centrality parameter
	double incrementRow = dofRows.Increment;
	double incrementColumn = nonCentralParameterColumns.Increment;

	NumericMatrix<double, long> mat(NRows, NColumns);
	using namespace boost::math; // For convenience
	// Basic case, no associativity
	for (long r = mat.MinRowIndex(); r <= mat.MaxRowIndex(); ++r)
	{	
		c1 = nonCentralParameterColumns.Start;
		for (long c = mat.MinColumnIndex(); c <= mat.MaxColumnIndex(); ++c)
		{
//		 cs = quantile(complement(chi_squared(r1), 0.05));
//		 mat(r,c)=cdf(complement(non_central_chi_squared(r1,c1),cs));
//		 c1 += incrementColumn;
		 cs = quantile(chi_squared(r1), 0.05);
		 mat(r,c)=cdf(non_central_chi_squared(r1,c1),cs);
		 c1 += incrementColumn;
		}

		r1 += incrementRow;
	}

	// Now create the associative matrix
	AssocMatrix<double, double, double> myAssocMat(dofSet, nonCentralParameterSet, mat);
	print(myAssocMat);

	printAssocMatrixInExcel(myAssocMat, string("NCCQT"));

    return 0;
}