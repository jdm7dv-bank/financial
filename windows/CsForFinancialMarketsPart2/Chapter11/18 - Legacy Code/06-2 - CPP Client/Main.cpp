// Main.cpp
//
// Example program that calculates: f(x)=a.x^2+b.x+c
// It uses a GUI written in C# to get the input parameters and to display the results.
//
// (C) Datasim Education BV  2009

#include "stdafx.h"
#include <iostream>
#include <vector>

using namespace System::Collections::Generic;

template <typename T>
std::vector<T> CreateValues(T min, T max, T step)
{
	// Calculate the number of elements
	int count=(int)((max-min)/step)+1;

	// Create the vector to store the values
	std::vector<T> values(count);

	// Create the values
	for (int i=0; i<count; i++)	values[i]=min+step*i;

	// Return the vector with values
	return values;
}



int main()
{
	// The parameters for the quadratic equation
	double a=0.5;
	double b=2.0;
	double c=-5.0;
	double xMin=-10.0;
	double xMax=10.0;
	double step=1.0;

	while (true)
	{
		// Create and show the input dialog box
		CS_GUI::InputForm^ inputForm=gcnew CS_GUI::InputForm(a, b, c, xMin, xMax, step);
		if (inputForm->ShowDialog()==System::Windows::Forms::DialogResult::Cancel) return 0;

		// Retrieve the inputted parameters from the input dialog box
		inputForm->GetParameters(a, b, c, xMin, xMax, step); 

		// Create a vector with the x-values
		std::vector<double> xValues=CreateValues(xMin, xMax, step);
		int size=xValues.size();

		// Create a vector for the y-values
		std::vector<double> yValues(size);

		// Calculate the y-value of the quadratic equation for each x-value
		for (int i=0; i<size; i++)
		{
			double x=xValues[i];
			yValues[i]=a*x*x + b*x + c;
		}

		// Create .NET arrays for passing them to the results form
		array<double>^ xarr=gcnew array<double>(size);
		array<double>^ yarr=gcnew array<double>(size);

		// Copy vectors to .NET array
		for (int i=0; i<size; i++) xarr[i]=xValues[i];
		for (int i=0; i<size; i++) yarr[i]=yValues[i];

		// Show the results
		// Due to a bug in Visual Studio 2005, the safe_cast<> is needed to pass an array as IEnumberable.
		// With Visual Studio 2008, the safe_cast<> can be left out.
		CS_GUI::ResultsForm^ resultsForm=gcnew CS_GUI::ResultsForm(a, b, c, safe_cast<IEnumerable<double>^>(xarr), safe_cast<IEnumerable<double>^>(yarr));
		resultsForm->ShowDialog();
	}
}