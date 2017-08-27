// LatticeMechanisms.cpp
//
// Testing the Latice class (basis for binomial and trinomial
// trees)
//
// In this version we have one class for both binomial and trinomial
// trees.
//
// (C) Datasim Education BV 2003-2006
//

#ifndef LatticeMechanisms_CPP
#define LatticeMechanisms_CPP


#include "Lattice.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/Matrix.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/MatrixMechanisms.cpp"

#include <iostream>
using namespace std;


template <class V, class I, int NumberNodes> void print(const Lattice<V, I, NumberNodes>& source)
{
	
	for (I j = source.MinIndex(); j <= source.MaxIndex(); j++)
	{

		cout << "\nBranch Number " << j << ": [";
		for (I i = source[j].MinIndex(); i <= source[j].MaxIndex(); i++)
		{
			cout << source[j][i] << ", ";
	
		}

		cout << "]";
			
	}

}



#endif