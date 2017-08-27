// AddInUtils.cs
//
// Utility functions for working with COM add-ins.
//
// (C) Datasim Education BV  2009

using System;
using Extensibility;
using System.Collections.Generic;

using Office=Microsoft.Office.Core;
using Excel=Microsoft.Office.Interop.Excel;


/// <summary>
/// Utility functions for working with COM add-ins.
/// </summary>
internal static class AddInUtils
{
	/// <summary>
	/// Add a menu item to a certain root menu.
	/// </summary>
	/// <param name="xl">The Excel application to add a menu to.</param>
	/// <param name="addin">The add-in object to use.</param>
	/// <param name="menuName">The name of the root menu to add an item to.</param>
	/// <param name="menuItemCaption">The new menu item text.</param>
	/// <param name="menuItemKey">The new menu item key.</param>
	/// <returns>The added command button (menu).</returns>
 	public static Office.CommandBarButton AddMenuItem(Excel.Application xl, Office.COMAddIn addin, string menuName, string menuItemCaption, string menuItemKey)
	{
		Office.CommandBar cmdBar;
		Office.CommandBarButton button;

		// Get the "menuName" dropdown menu
		cmdBar=xl.CommandBars[menuName];

		// If not found then we can't add an item to it
		if (cmdBar==null) return null;

		// Try to get the "menuItemKey" menu item
		button=cmdBar.FindControl(Type.Missing, Type.Missing, menuItemKey, Type.Missing, Type.Missing) as Office.CommandBarButton;

		// If not found, add it
		if (button==null)
		{
			// Add new button
			button=cmdBar.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, menuItemKey, Type.Missing, Type.Missing) as Office.CommandBarButton;

			// Set button's Caption, Tag, Style, and OnAction properties.
			button.Caption=menuItemCaption;
			button.Tag=menuItemKey;
			button.Style=Office.MsoButtonStyle.msoButtonCaption;

			// Use add-in argument to return reference to this add-in.
			button.OnAction="!<" + addin.ProgId + ">";
		}

		// Return the created button
		return button;
	}


	/// <summary>
	/// Remove the installed menu item.
	/// </summary>
	/// <param name="xl">The Excel application to remove the menu from.</param>
	/// <param name="disconnectMode">The reason the menu item should be removed.</param>
	/// <param name="menuName">The name of the menu where the menu item was added.</param>
	/// <param name="menuItemCaption">The caption of the menu item to remove.</param>
	public static void RemoveMenuItem(Excel.Application xl, Extensibility.ext_DisconnectMode disconnectMode, string menuName, string menuItemCaption)
	{
		// If user unloaded add-in, remove button. Otherwise, add-in is
		// being unloaded because application is closing; in that case,
		// leave button as is.
		if (disconnectMode==Extensibility.ext_DisconnectMode.ext_dm_UserClosed)
		{
			// Delete custom command bar button.
			xl.CommandBars[menuName].Controls[menuItemCaption].Delete(Type.Missing);
		}
	}

	/// <summary>
	/// Print a two-dimensional associative array (typically, one time level);
	/// </summary>
	/// <typeparam name="R">The type of the row indexer.</typeparam>
	/// <typeparam name="C">The type of the column indexer.</typeparam>
	/// <typeparam name="T">The type of the data.</typeparam>
	/// <param name="xl">The Excel application to export the associative matrix to.</param>
	/// <param name="matrix">The matrix to send to Excel.</param>
	/// <param name="sheetName">The name of the Excel sheet to create.</param>
	public static void ExportAssocMatrixToExcel<R, C, T>(Excel.Application xl, AssocMatrix<R, C, T> matrix, string sheetName)
	{
		List<string> rowlabels=new List<string>();
		List<string> columnlabels=new List<string>();

		// Create the row and column annotations
		foreach (KeyValuePair<R, int> value in matrix.r) rowlabels.Add(value.Key.ToString());
		foreach (KeyValuePair<C, int> value in matrix.c) columnlabels.Add(value.Key.ToString());

		// Add the matrix for row and column labels
		ExportMatrixToExcel(xl, sheetName, matrix.mat, rowlabels, columnlabels);
	}

	/// <summary>
	/// Add Matrix to the spreadsheet with row and column labels.
	/// </summary>
	/// <typeparam name="T">The type of the data.</typeparam>
	/// <param name="xl">The Excel application to export the matrix to.</param>
	/// <param name="sheetName">The name of the Excel sheet to add.</param>
	/// <param name="matrix">The matrix to send to Excel.</param>
	/// <param name="rowLabels">The row labels.</param>
	/// <param name="columnLabels">The column labels.</param>
	public static void ExportMatrixToExcel<T>(Excel.Application xl, string sheetName, NumericMatrix<T> matrix, List<string> rowLabels, List<string> columnLabels)
	{
		try
		{
			// Check label count vs. matrix.
			if (matrix.Columns != columnLabels.Count) throw (new IndexOutOfRangeException("Count mismatch between # matrix columns and # column labels"));
			if (matrix.Rows != rowLabels.Count) throw (new IndexOutOfRangeException("Count mismatch between # matrix rows and # row labels"));

			// Add sheet
			Excel.Workbook workbook;
			Excel.Worksheet sheet;
			if (xl.ActiveWorkbook==null)
			{
				workbook=xl.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
				sheet=workbook.ActiveSheet as Excel.Worksheet;
			}
			else
			{
				workbook=xl.ActiveWorkbook;
				sheet=workbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing) as Excel.Worksheet;
			}

			// Set the name of the sheet
			try
			{
				sheet.Name=sheetName;
			}
			catch (System.Runtime.InteropServices.COMException)
			{
				// Ignore COM expetion when the name of the sheet already excists
			}

			// Current indices in spreadsheet
			long sheetRow;
			long sheetColumn;

			// Add column labels starting at column 2.
			sheetRow=1; sheetColumn=2;
			for (int i=0; i!=columnLabels.Count; i++)
			{
				(sheet.Cells[sheetRow, sheetColumn] as Excel.Range).Value2=columnLabels[i];
				sheetColumn++;
			}

			// Add row labels + values.
			sheetRow++; sheetColumn=1;
			int labelIndex=0;
			for (int iRow=matrix.MinRowIndex; iRow<=matrix.MaxRowIndex; iRow++)
			{
				// Add row label
				(sheet.Cells[sheetRow, sheetColumn++] as Excel.Range).Value2=rowLabels[labelIndex++];

				// Add row values
				for (int iColumn=matrix.MinColumnIndex; iColumn<=matrix.MaxColumnIndex; iColumn++)
				{
					(sheet.Cells[sheetRow, sheetColumn++] as Excel.Range).Value2=matrix[iRow, iColumn];
				}

				// Next row, reset column
				sheetRow++;
				sheetColumn=1;
			}

		}
		catch (IndexOutOfRangeException e)
		{
			// Ignore exception
		}
	}


}

