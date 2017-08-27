// Main.cs
//
// (C) Datasim Education BV  2009

using System;

using Wrapper;

class MainClass
{
	static void Main(string[] args)
	{

		// Create row indices
		VectorCollectionGenerator<double> dofRows=new VectorCollectionGenerator<double>();
		dofRows.Start=2.0;
		dofRows.Increment=1.0;
		dofRows.Size=9;
		Set<double> dofSet=SetCreator.CreateSet(dofRows);

		// Create column indices
		VectorCollectionGenerator<double> nonCentralParameterColumns=new VectorCollectionGenerator<double>();
		nonCentralParameterColumns.Start=2.0;
		nonCentralParameterColumns.Increment=2.0;
		nonCentralParameterColumns.Size=5;
		Set<double> nonCentralParameterSet=SetCreator.CreateSet(nonCentralParameterColumns);

		double r1=dofRows.Start;
		double c1=nonCentralParameterColumns.Start;

		int nRows=dofRows.Size;
		int nColumns=nonCentralParameterColumns.Size;
		double incrementRow=dofRows.Increment;
		double incrementColumn=nonCentralParameterColumns.Increment;
		double cs;

		// Make the matrix and fill it
		NumericMatrix<double> mat=new NumericMatrix<double>(nRows, nColumns);
		for (int r=mat.MinRowIndex; r<=mat.MaxRowIndex; ++r)
		{
			c1=nonCentralParameterColumns.Start;
			for (int c=mat.MinColumnIndex; c<=mat.MaxColumnIndex; ++c)
			{
				cs=BoostMath.Quantile(new ChiSquaredDistribution(r1), 0.05);
				mat[r, c]=BoostMath.Cdf(new NonCentralChiSquaredDistribution(r1, c1), cs);
				c1+=incrementColumn;
			}
			r1+=incrementRow;
		}

		// Make it into an associative matrix and print it
		AssocMatrix<double, double, double> myAssocMat=new AssocMatrix<double,double,double>(dofSet, nonCentralParameterSet, mat);
		Print(myAssocMat);

		// Send associative matrix to Excel
		ExcelMechanisms excel=new ExcelMechanisms();
		excel.printAssocMatrixInExcel(myAssocMat, "NCCQT");
	}

	static void Print<TKey1, TKey2, TV>(AssocMatrix<TKey1, TKey2, TV> m)
	{
		// Print the column values
		Console.Write("{0, 10}", "");
		foreach (TKey2 key in m.ColumnKeys) Console.Write("{0, 10}", key);
		Console.WriteLine();

		System.Collections.Generic.IEnumerator<TKey1> rowsEnum=m.RowKeys.GetEnumerator();
		// Print the rows and columns
		for (int row=m.mat.MinRowIndex; row<=m.mat.MaxRowIndex; row++)
		{
			rowsEnum.MoveNext();
			Console.Write("Row: {0, -5}", rowsEnum.Current);
			for (int column=m.mat.MinColumnIndex; column<=m.mat.MaxColumnIndex; column++)
			{
				Console.Write("{0, 10:f6}", m[row, column]);
			}
			Console.WriteLine();
		}
	}
}