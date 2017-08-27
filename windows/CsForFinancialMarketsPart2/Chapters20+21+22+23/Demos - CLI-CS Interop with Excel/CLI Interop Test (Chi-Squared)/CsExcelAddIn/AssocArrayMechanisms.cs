// AssocArrayMechanisms.cs
//
// Utility functions for associative arrays. Many data types
// are concrte (we work a lot with long and double).
//
// 2009-1-8 DD kick-off,inline code
// 2009-3-18 DD C# version
//
// (C) Datasim Education BV 2009-2010
//

using System;

// Assembling related data for set and array generation
internal struct VectorCollectionGenerator<Numeric>
	// 1d array, heterogeneous
{
	public Numeric Start;						// The lowest or highest value
	public Numeric Increment;	    		    // Relative distance between values (+ or - possible)
	public int Size;							// Number of elements to be generated
}

internal struct MatrixCollectionGenerator <Numeric>
		// 2d matrix
{
	public VectorCollectionGenerator<Numeric> rowGenerator;
	public VectorCollectionGenerator<Numeric> columnGenerator;

}

internal class SetCreator
{
	// Functions for sets
	public static Set<double> CreateSet(double start, double increment, int size)
	{
		Set<double> result=new Set<double>();

		double current=start;
		for (int j=1; j<=size; ++j)
		{
			result.Insert(current);
			current=current+increment;
		}

		return result;
	}

	public static Set<int> CreateSet(int start, int increment, int size)
	{
		Set<int> result=new Set<int>();

		int current=start;
		for (int j=1; j<=size; ++j)
		{
			result.Insert(current);
			current=current+increment;
		}

		return result;
	}

	public static Set<double> CreateSet(VectorCollectionGenerator<double> gen)
	{
		Set<double> result=new Set<double>();

		double current=gen.Start;
		for (int j=1; j<=gen.Size; ++j)
		{
			result.Insert(current);
			current+=gen.Increment;
		}

		return result;
	}

	public static Set<int> CreateSet(VectorCollectionGenerator<int> gen)
	{
		Set<int> result=new Set<int>();

		int current=gen.Start;
		for (int j=1; j<=gen.Size; ++j)
		{
			result.Insert(current);
			current+=gen.Increment;
		}

		return result;
	}
}

// Some functions for testing

internal class Potpourri
{
    public static void func(ref double x)
    {
        x = x * 3.0;
    }

}

