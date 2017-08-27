using System;

public class TestPoint
{
	public static void Main()
	{
		Console.WriteLine(Point.GetPoints());	// Prints 1 (The static origin point)

		Point p1=new Point();					// Create point
		Console.WriteLine(Point.GetPoints());	// Prints 2

		// Remove object
		p1=null;
        
        // Force start of garbage collection
        GC.Collect();

		// Wait for garbage collection
		while (Point.GetPoints()==2) 
		{
			Console.WriteLine("Waiting, it can take a while");
		}

		Console.WriteLine(Point.GetPoints());	// Prints 1. p1 garbage collected
	}
}
