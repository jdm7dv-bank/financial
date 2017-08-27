// testExcelLikeMatrix.cpp
//
// Testing associative matrices by simulating
// Excel spreadsheets.
//
// (C) Datasim Education BV 2003-2009
//

#include "AssocArray.cpp"
#include "AssocMatrix.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/Array.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/ArrayMechanisms.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/NumericMatrix.cpp"
#include <string>
using namespace std;

template <typename Key1, typename Key2, typename Value>
	void print(const AssocMatrix<Key1, Key2, Value>& assMat)
{

	// Iterating in the map
	AssocMatrix<Key1, Key2, Value>::const_iterator iter = assMat.begin();


	while (iter != assMat.end())
	{
		cout << "\nRow " << (*iter).first << ", ";
		
		for (long i = assMat.mat->MinRowIndex(); i <= assMat.mat->MaxRowIndex(); ++i)
		{
			print(assMat.mat->Row(i));
		}
			iter++;
	}

	cout << endl;
}
int main()
{

		// Create the row indices
		Set<string> names;
		names.Insert("A");
		names.Insert("B");
		names.Insert("C");
		names.Insert("D");

		// Create the column indices
		Set<long> columns;
		long startRow = 3;
		columns.Insert(startRow);
		columns.Insert(startRow + 1);
		columns.Insert(startRow + 2);

		// Create the embedded numeric matrix of appropriate dimensions
		NumericMatrix<double, long> myMatrix(names.Size(), columns.Size());

		// Fill in the values (this is just one way, there are others...)
		for (long c = myMatrix.MinColumnIndex(); c <= myMatrix.MaxColumnIndex(); ++c)
		{
			for (long r = myMatrix.MinRowIndex(); r <= myMatrix.MaxRowIndex(); ++r) 
			{
					myMatrix(r,c) = double(c);
						
			}
		}

	// Now create the associative matrix
	AssocMatrix<string, long, double> myAssocMat(names, columns, myMatrix);
	print(myAssocMat);
	
	cout << "Single cell: " << myAssocMat(string("C"), 5) << endl;

	return 0;
}
