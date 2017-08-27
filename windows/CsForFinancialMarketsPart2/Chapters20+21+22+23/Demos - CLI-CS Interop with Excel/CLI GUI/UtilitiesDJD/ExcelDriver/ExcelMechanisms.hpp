// ExcelMechanisms.hpp
//
// Useful functions for use with Excel.
//
// (C) Datasim Education BV 2005-2009
//

#ifndef ExcelMechanisms_HPP
#define ExcelMechanisms_HPP

#include "UtilitiesDJD/VectorsAndMatrices/Vector.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/NumericMatrix.cpp"
#include "UtilitiesDJD/Geometry/Tensor.cpp"
#include "UtilitiesDJD/BitsAndPieces/StringConversions.hpp"
#include "UtilitiesDJD/AssociativeStructures/AssocMatrix.cpp"
#include <string>
#include <list>
using namespace std;

#include "boost/function.hpp"


// Print one line graph
void printOneExcel(const Vector<double, long>& x,						
					const Vector<double, long>& functionResult,
					const std::string& title = string("Title"), 
					const std::string& horizontal = string("X"), 
					const std::string& vertical = string("Y"),
					const std::string& legend = string("*"));

// Print two line graphs for comparison
void printPairExcel(const Vector<double, long>& x,						
					const Vector<double, long>& Arr1, const Vector<double, long>& Arr2,
					const std::string& title = string("Title"), 
					const std::string& horizontal = string("X"), 
					const std::string& vertical = string("Y"),
					const std::string& legend = string("*"));

// Print multiple lines on one graph
void printInExcel(const Vector<double, long>& x,						// X array
					const list<std::string>& labels,							// Names of each vector
					const list<Vector<double, long> >& functionResult,	// The list of Y values
					const std::string& title = string("Title"),
					const std::string& horizontal = string("X"), 
					const std::string& vertical = string("Y"));

// Print a matrix as cell
void printMatrixInExcel(const NumericMatrix<double, long>& matrix,
				 const Vector<double, long>& xarr, const Vector<double, long>& yarr, 
				 const std::string& SheetName = string("Matrix"));

void printAssocMatrixInExcel(AssocMatrix<double, double, double>& matrix, const std::string& SheetName = string("AssocMatrix"));

// Print a matrix's rows as line graphs
void printMatrixChartsInExcel(int freq, const NumericMatrix<double, long>& matrix,
				 const Vector<double, long>& rowAarr, const Vector<double, long>& colArr,
				 const std::string& SheetName = string("Matrix"));

// Print an array of matrices
void printTensorInExcel(const Tensor<double, long>& tensor, long freq = 1);

// Print each matrix in tensor with associated row/column labels
void printTensorInExcel(const Tensor<double, long>& tensor,
						const Vector<double, long>& xarr, const Vector<double, long>& yarr, 
						const std::string& SheetName = string("Tensor"), long freq = 1);

// Print the vector that is the difference of two vectors
void printDifferenceInExcel(const Vector<double, long>& x,	const Vector<double, long>& y1,					
					const Vector<double, long>& y2,
					const std::string& title = string("Difference"), 
					const std::string& horizontal = string("X Values"), 
					const std::string& vertical = string("Y Values"),
					const std::string& legend = string("*"), long freq = 1);

// Differences of two matrices
void printMatrixDifferenceInExcel(const NumericMatrix<double, long>& matrix1,
						const NumericMatrix<double, long>& matrix2,
				 const Vector<double, long>& xarr, const Vector<double, long>& yarr, 
				 const std::string& SheetName = string("Matrix"));
	// Print discrete values of a continuous function on interval [A,B]
	void printDiscreteFunctionValues(double (*f) (double x), double A, double B,long nSteps, 
						const std::string& title, 
						const std::string& horizontal, 	const std::string& vertical,
						const std::string& legend);

	void printDiscreteFunctionValues(const boost::function<double (double)>& f, double A, double B,long nSteps, 
						const std::string& title, 
						const std::string& horizontal, 	const std::string& vertical,
						const std::string& legend);
	void printDiscreteFunctionValues(double (*f) (double x, double y), double A, double B,long xSteps, 
																		double C, double D,long ySteps, 
						const std::string& title, 
						const std::string& horizontal, 	const std::string& vertical,
						const std::string& legend);

#endif