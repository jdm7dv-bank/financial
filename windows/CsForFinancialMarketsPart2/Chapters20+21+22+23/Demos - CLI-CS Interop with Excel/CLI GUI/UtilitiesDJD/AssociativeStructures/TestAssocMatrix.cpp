// testAssocMatrix.cpp
//
// Testing associative arrays
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
		cout << "Row " << (*iter).first << ", ";
		
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

	Set<string> names;
	names.Insert("A1");
	names.Insert("A2");
	names.Insert("A3");
	names.Insert("A4");


	double defaultValue(0.0);

	AssocArray<string, double> myAssocArray(names, defaultValue);
	//print(myAssocArray);
	myAssocArray["A4"] = 99.99;
	//print(myAssocArray);


	// Test other functions
	AssocArray<string, double> myAssocArray2(myAssocArray);
	//print(myAssocArray2);

	AssocMatrix<string, double, string> myMat;
	AssocMatrix<string, double, string> myMatcopy = myMat;

	NumericMatrix<double, long> mat1(names.Size(), names.Size());
	AssocMatrix<string, string, double> myMat2(names, names, mat1);

	// Creating associative matrices in less hard-coded ways
	VectorCollectionGenerator<double, double> rowScheme;
	rowScheme.Start = 2.0;
	rowScheme.Increment = 2.0;
	rowScheme.Size = 10;

	VectorCollectionGenerator<double, double> columnScheme;
	columnScheme.Start = 2.0;
	columnScheme.Increment = 1.0;
	columnScheme.Size = 10;

	AssocMatrix<double, double> assMat(2.0, 2.0, mat1);
	print(assMat);

	//print(assMat.mat->Row(1));

	return 0;
}
