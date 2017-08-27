namespace CsExcelAddIn
{
	using System;
	using System.Collections.Generic;
	using Extensibility;
	using System.Runtime.InteropServices;

	using Office=Microsoft.Office.Core;
	using Excel=Microsoft.Office.Interop.Excel;

	using Wrapper;

	#region Read me for Add-in installation and setup information.
	// When run, the Add-in wizard prepared the registry for the Add-in.
	// At a later time, if the Add-in becomes unavailable for reasons such as:
	//   1) You moved this project to a computer other than which is was originally created on.
	//   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
	//   3) Registry corruption.
	// you will need to re-register the Add-in by building the CsExcelAddInSetup project, 
	// right click the project in the Solution Explorer, then choose install.
	#endregion

	/// <summary>
	/// Interface that defines methods that are callable from VBA.
	/// </summary>
	[GuidAttribute("E24AA65F-8416-4d98-8627-4AC83756209A")]
	public interface IConnect
	{
		/// <summary>
		/// Create a new sheet with the Chi-Squared calculation.
		/// </summary>
		/// <param name="rowStart">The row start value.</param>
		/// <param name="rowIncrement">The row increment value.</param>
		/// <param name="rows">The number of rows.</param>
		/// <param name="columnStart">The column start value.</param>
		/// <param name="columnIncrement">The column increment.</param>
		/// <param name="columns">The number of columns.</param>
		/// <param name="quantileX">The quantile x-value used in the calculation.</param>
		/// <param name="sheetName">The name of the sheet to create.</param>
		void CreateChiSquaredSheet(double rowStart, double rowIncrement, int rows, double columnStart, double columnIncrement, int columns, double quantileX, string sheetName);
	}

	/// <summary>
	/// The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("32BBE261-6FE4-4A11-940E-4B864AE0D121"), ProgId("CsExcelAddIn.Connect")]
	public class Connect: Object, Extensibility.IDTExtensibility2, IConnect
	{
		// Variables
		private Excel.Application m_xl;
		private Office.COMAddIn m_cai;
		private Office.CommandBarButton m_menuItem;

		// Constants for menu.
		private const string c_menuName="Tools";													// The menu to add a menu item to
		private const string c_menuItemCaption="Chi-Squared distribution in C# calling native C++";	// The caption of the new menu item
		private const string c_menuItemKey="ChiSquared";											// The key for the new menu item

		/// <summary>
		///	Implements the constructor for the Add-in object.
		///	Place your initialization code within this method.
		/// </summary>
		public Connect()
		{
		}

		/// <summary>
		/// Implements the OnConnection method of the IDTExtensibility2 interface.
		/// Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
		{
			// Store reference to the Excel application
			// Exit if host application is not Excel
			m_xl = application as Excel.Application;
			if (m_xl==null) return;

			// If addInInst is the same object as myself then I was loaded as Automation add-in instead of COM add-in.
			if (addInInst!=this)
			{
				// Attach myself to the add-in object
				// In that way I can call functions of this object from
				// VBA using the add-ins collection
				m_cai=addInInst as Office.COMAddIn; 
				m_cai.Object=this;

				// Install the menu item and event handler
				m_menuItem=AddInUtils.AddMenuItem(m_xl, m_cai, c_menuName, c_menuItemCaption, c_menuItemKey);
				m_menuItem.Click+=new Office._CommandBarButtonEvents_ClickEventHandler(ChiSquaredClick);
			}
		}

		/// <summary>
		/// Implements the OnDisconnection method of the IDTExtensibility2 interface.
		/// Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom)
		{
			// Remove the menu
			AddInUtils.RemoveMenuItem(m_xl, disconnectMode, c_menuName, c_menuItemCaption);
		}

		/// <summary>
		/// Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		/// Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom)
		{
		}

		/// <summary>
		/// Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		/// Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom)
		{
		}

		/// <summary>
		/// Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		/// Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom)
		{
		}

		/// <summary>
		/// The event handler called when there was a click on our menu item.
		/// </summary>
		/// <param name="button">The command bar button that genereted the event.</param>
		/// <param name="CancelDefault">?</param>
		private void ChiSquaredClick(Office.CommandBarButton button, ref bool CancelDefault)
		{
			// Call the create function with default values
			(this as IConnect).CreateChiSquaredSheet(2.0, 1.0, 9, 2.0, 2.0, 5, 0.05, "NCCQT");
		}

		/// <summary>
		/// Create a new sheet with the Chi-Squared calculation.
		/// </summary>
		/// <param name="rowStart">The row start value.</param>
		/// <param name="rowIncrement">The row increment value.</param>
		/// <param name="rows">The number of rows.</param>
		/// <param name="columnStart">The column start value.</param>
		/// <param name="columnIncrement">The column increment.</param>
		/// <param name="columns">The number of columns.</param>
		/// <param name="quantileX">The quantile x-value used in the calculation.</param>
		/// <param name="sheetName">The name of the sheet to create.</param>
		void IConnect.CreateChiSquaredSheet(double rowStart, double rowIncrement, int rows, double columnStart, double columnIncrement, int columns, double quantileX, string sheetName)
		{
			// Create row indices
			VectorCollectionGenerator<double> dofRows=new VectorCollectionGenerator<double>();
			dofRows.Start=rowStart;
			dofRows.Increment=rowIncrement;
			dofRows.Size=rows;
			Set<double> dofSet=SetCreator.CreateSet(dofRows);

			// Create column indices
			VectorCollectionGenerator<double> nonCentralParameterColumns=new VectorCollectionGenerator<double>();
			nonCentralParameterColumns.Start=columnStart;
			nonCentralParameterColumns.Increment=columnIncrement;
			nonCentralParameterColumns.Size=columns;
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
					cs=BoostMath.Quantile(new ChiSquaredDistribution(r1), quantileX);
					mat[r, c]=BoostMath.Cdf(new NonCentralChiSquaredDistribution(r1, c1), cs);
					c1+=incrementColumn;
				}
				r1+=incrementRow;
			}

			// Make it into an associative matrix and send it to Excel
			AssocMatrix<double, double, double> myAssocMat=new AssocMatrix<double, double, double>(dofSet, nonCentralParameterSet, mat);
			AddInUtils.ExportAssocMatrixToExcel(m_xl, myAssocMat, sheetName);
		}
	}
}