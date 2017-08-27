// ComComponent.cs
//
// Application that using COM Automation.
//
// (C) Datasim Education BV  2002-2004

using System;
using Word=Microsoft.Office.Interop.Word;

public class ComComponent
{
	// Object to pass as missing argument. Not the same as 'null'
	private static object objMissing=System.Reflection.Missing.Value;

	public static void Main(string[] args)
	{
		try
		{
			// Create instance of Word and show it
			Word.Application app=new Word.ApplicationClass();
			app.Visible=true;

			// Add document
			Word.Document doc=app.Documents.Add(ref objMissing, ref objMissing, ref objMissing, ref objMissing);
		
			// Set text of the document
			doc.Content.Text="Datasim Education BV";
		}
		catch(System.Runtime.InteropServices.COMException ex)
		{
			Console.WriteLine("HRESULT: {0}\n{1}", ex.ErrorCode, ex.Message);
		}
	}
}
