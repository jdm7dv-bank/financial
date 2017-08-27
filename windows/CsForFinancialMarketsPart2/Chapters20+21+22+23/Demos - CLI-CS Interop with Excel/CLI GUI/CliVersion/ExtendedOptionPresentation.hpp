// ExtendedOptionPresentation.hpp
//
// (C) Datasim Education BV 2009

#ifndef ExtendedOptionPresentation_HPP
#define ExtendedOptionPresentation_HPP

#include "ExtendedOption.hpp"
#include "UtilitiesDJD/ExcelDriver/Excelmechanisms.hpp"
#include "UtilitiesDJD/VectorsAndMatrices/ArrayMechanisms.cpp"
#include "UtilitiesDJD/VectorsAndMatrices/Vector.cpp"
#include "UtilitiesDJD/Geometry/Range.cpp"

// This class display 1 line graph in Excel
// (Get it working)

enum OptionValueType {Value, Delta, Gamma, Vega, Theta, Rho, Coc, Elasticity};

class ExtendedOptionPresentation
{
private:

	ExtendedOption* m_option;		// The option to use
	Vector<double, long> m_xValues;	// Vector with x-values
	double	m_percentageMovement;	// percentage movement for the elasticity

	// Private default constructor
	ExtendedOptionPresentation() {}

public:
	// Construtor with the option to use and the range
	ExtendedOptionPresentation(ExtendedOption& option, const Range<double>& extent, long numberOfSteps, double percentageMovement)
	{
		// Store the option
		m_option=&option;

		// Create array with x-values
		m_xValues=extent.mesh(numberOfSteps);

		// Store the percentage movement for the elasticity
		m_percentageMovement=percentageMovement;
	}

	// Calculate the option for the specified option value type
	Vector<double, long> Calculate(OptionValueType yval)
	{
		// Contains value at end-points
		Vector<double, long> result(m_xValues.Size(), 1);

		// Calculate the value
		if (yval==Value)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Price(m_xValues[j]);
			}
		}

		// Calculate the delta
		if (yval==Delta)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Delta(m_xValues[j]);
			}
		}

		// Calculate the gamma
		if (yval==Gamma)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Gamma(m_xValues[j]);
			}
		}

		// Calculate the vega
		if (yval==Vega)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Vega(m_xValues[j]);
			}
		}

		// Calculate the theta
		if (yval==Theta)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Theta(m_xValues[j]);
			}
		}

		// Calculate the rho
		if (yval==Rho)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Rho(m_xValues[j]);
			}
		}

		// Calculate the coc
		if (yval==Coc)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Rho(m_xValues[j]);
			}
		}

		// Calculate the elasticity
		if (yval==Elasticity)
		{
			for (int j=m_xValues.MinIndex(); j<=m_xValues.MaxIndex(); j++)
			{
				result[j] = m_option->Elasticity(m_percentageMovement, m_xValues[j]);
			}
		}

		// Return the vector with results
		return result;
	}

	// Get the string description of the option value type used
	string GetDescription(OptionValueType yval)
	{
		// The result text
		string text("Unknown");

		if (yval==Value)		text="Value";
		if (yval==Delta)		text="Delta";
		if (yval==Gamma)		text="Gamma";
		if (yval==Vega)			text="Vega";
		if (yval==Theta)		text="Theta";
		if (yval==Rho)			text="Rho";
		if (yval==Coc)			text="Coc";
		if (yval==Elasticity)	text="Elasticity";

		return text;
	}

	// Process an option value type
	void ProcessOptionValueType(OptionValueType yval, CsGUI::ResultsForm^ resultsForm, bool outputToExcel)
	{
		// Get the description of the option value type
		string name(GetDescription(yval));

		// Calculate the option values
		Vector<double, long> yValues=Calculate(yval);

		// Optionally send the values to Excel
		if (outputToExcel) printOneExcel(m_xValues, yValues, name);

		// Add a chart to the results form
		if (resultsForm!=nullptr)
		{
			int j;

			// Create .NET arrays for passing them to the form
			array<double>^ xarr=gcnew array<double>(m_xValues.Size());
			array<double>^ yarr=gcnew array<double>(yValues.Size());

			// Copy vectors to .NET array
			j=0; for (int i=m_xValues.MinIndex(); i<=m_xValues.MaxIndex(); i++) xarr[j++]=m_xValues[i];
			j=0; for (int i=yValues.MinIndex(); i<=yValues.MaxIndex(); i++) yarr[j++]=yValues[i];

			// Add a chart
			resultsForm->AddChart(xarr, yarr, gcnew System::String(name.c_str()), gcnew System::String("S"), gcnew System::String(name.c_str()));
		}
	}

};

#endif