// Client.cs
//
// C# client application for native C++ code via C++/CLI wrapper.
//
// (C) Datasim Education BV  2006

using System;

public class MainClass
{
	public static void Main()
	{
		ManagedWrapper mw1=new ManagedWrapper();
		ManagedWrapper mw2=new ManagedWrapper(10);
		ManagedWrapper mw3=new ManagedWrapper(14);

		Console.WriteLine("mw1: {0}", mw1.Data);
		Console.WriteLine("mw2: {0}", mw2.Data);
		Console.WriteLine("mw3: {0}", mw3.Data);

		mw1.Data = 99;
		Console.WriteLine("mw1 changed: {0}", mw1.Data);

		// Strings
		mw1.Str="Hello World";
		Console.WriteLine("mw1 string: {0}", mw1.Str);
		mw1.Str="Hello to you too";
		Console.WriteLine("mw1 string: {0}", mw1.Str);

	}
}
