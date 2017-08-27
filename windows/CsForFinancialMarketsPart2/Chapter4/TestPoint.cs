using System;

public class TestPoint
{
	public static void Main()
	{
		Point p=new Point(1.0, 3.0);		// Create Point
		
		// Test ICloneable
		Shape sc1=new Point(1.4, 1.2);		// Create Point
//		Shape sc2=new Point(sc1);			// Illegal. Tries to call Point(Shape)
		Shape sc3=(Shape)sc1.Clone();		// OK. Copy of sc1 created (Point.Clone() called)

		Console.WriteLine(sc1);
		Console.WriteLine(sc3);
	//	((Point)sc1).X=10;					// Change coordinate to see if it is really a copy
		Console.WriteLine(sc1);
		Console.WriteLine(sc3);
	}
}