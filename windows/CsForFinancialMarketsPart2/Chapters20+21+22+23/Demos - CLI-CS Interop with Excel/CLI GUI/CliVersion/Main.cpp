// Main.cpp
//
// (C) Datasim Education BV  2009

#include "stdafx.h"
#include <iostream>

#include "ExtendedOption.hpp"
#include "ExtendedOptionPresentation.hpp"
#include "UtilitiesDJD/Geometry/Range.cpp"

using namespace std;

// Create a form with initial values from a option
CsGUI::InputForm^ CreateInputForm(const ExtendedOption& option)
{
	CsGUI::InputForm^ frm=gcnew CsGUI::InputForm(option.r, option.sig, option.K, option.T, option.U, option.b, (option.otyp=="P")?CsGUI::OptionType::Put:CsGUI::OptionType::Call);
	return frm;
}

// Transfer the GUI values to the option
void TransferOptionParameters(CsGUI::InputForm^ form, ExtendedOption& option)
{
	option.r=form->r;
	option.sig=form->sig;
	option.K=form->K;
	option.T=form->T;
	option.U=form->U;
	option.b=form->b;
	if (form->OptionType==CsGUI::OptionType::Call) option.otyp="C";
	else option.otyp="P";
}

int main()
{
	double q = 0.0;		// Dividend yield
	double percentageMovement;
	bool outputToExcel;

	// Create extended option
	ExtendedOption indexOption;
	indexOption.otyp = "P";
	indexOption.K = 100.0;
	indexOption.T = 1.0;
	indexOption.r = 0.05;
	indexOption.sig = 0.20;
	indexOption.b = indexOption.r - q;

	// Edit the option parameters
	CsGUI::InputForm^ inputForm=CreateInputForm(indexOption);
	if (inputForm->ShowDialog()==System::Windows::Forms::DialogResult::Cancel) return 0;
	TransferOptionParameters(inputForm, indexOption);
	outputToExcel=inputForm->OutputToExcel;
	percentageMovement=inputForm->PercentageMovement;

	// Range is from 0.0 to 200 with 200 steps
	Range<double> extent(0.0, 200.0);
	long numberSteps = 200;

	if (outputToExcel) cout<<"Output to excel."<<endl;
	else cout<<"No output to excel"<<endl;

	// Make presentation object
	ExtendedOptionPresentation myPresent(indexOption, extent, numberSteps, percentageMovement);

	// Make the C# results form
	CsGUI::ResultsForm^ resultsForm=gcnew CsGUI::ResultsForm();
	
	// Array with option value types to process
	OptionValueType optionValueTypes[]={Value, Delta, Gamma, Vega, Theta, Rho, Coc, Elasticity};
	int options=8;

	// Export the option value types as specified in the array with value types
	for (int i=0; i<options; i++) myPresent.ProcessOptionValueType(optionValueTypes[i], resultsForm, outputToExcel);

	// Show the results form
	if (resultsForm!=nullptr) resultsForm->ShowDialog();

	return 0;
}
