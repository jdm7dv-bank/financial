// TestAssocArray.cpp
//
// Testing associative arrays
//
// (C) Datasim Education BV 2003-2009
//

#include "AssocArray.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/Array.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/ArrayMechanisms.cpp"
#include "UtilitiesDJD/DateAndTime/DatasimDate.hpp"

//#include "AssocArrayMechanisms.hpp" // inline code

#include <string>
using namespace std;

template <typename T> void print(const Set<T>& l, const string& name)
{  // Print the contents of a Set. Notice the presence of a constant iterator.
	
	cout << endl << name << ", size of set is " << l.Size() << "\n[ ";

	set<T>::const_iterator i;

	for (i = l.Begin(); i != l.End(); ++i)
	{
			cout << *i << " ";

	}

	cout << "]\n";
}

template <class Key, class Value>
	void print(const AssocArray<Key, Value>& assArr)
{

	// Iterating in the map
	AssocArray<Key, Value>::const_iterator i = assArr.begin();

	while (i != assArr.end())
	{
			cout << (*i).first << ", " << ((*i).second) << endl;
			
			i++;
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
//	print(myAssocArray);


	// Test other functions
	AssocArray<string, double> myAssocArray2(myAssocArray);
//	print(myAssocArray2);

	AssocArray<string, double> myAssocArray3 = myAssocArray;
//	print<string, double>(myAssocArray3);

	AssocArray<string, double> myAssocArray4(names, 3.14);
//	print<string, double>(myAssocArray4);

	// Creating assoc array from a set of keys and array values

	// 1. Using numbers
	double start = 2.0;
	double increment = 2.0;
	long size = 10;
	Set<double> mySet = createSet<double>(start, increment, size);
	print(mySet, "Set");
	// 2. Using Structs
	VectorCollectionGenerator<double, double> OneD;
	OneD.Start = 2.0;
	OneD.Increment = 2.0;
	OneD.Size = 10;
	Set<double> mySet2 = createSet<double>(OneD);
	print(mySet2, "Set2");

	Array<long, long> myArray2(size, 1, 2); myArray2[2] = 44;
	AssocArray<double, long> myAssocArray5(mySet2, myArray2);
	map<double, string> m;
//	print<long, long>(myAssocArray5);

	// Array based on start index and offset
	double start2 = 2.0;
	double increment2 = -1.7;
	AssocArray<string, double> myAssocArray6(names, start2, increment2);
	print(myAssocArray6);

	// Working with dates
	VectorCollectionGenerator<DatasimDate, int> dateFlow;
	dateFlow.Start = DatasimDate(); // today
	dateFlow.Increment = 30;
	dateFlow.Size = 12;

	Set<DatasimDate> dateSet = createSet<DatasimDate, int>(dateFlow);
	print(dateSet, "Date flow");

	return 0;
}
