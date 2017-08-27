// ShapeVisitor.cs
//
// Abstract base class for shape visitors.
// The visitor can be used to extend the functionality of
// the shape hierarchy such as output drivers, transformation drivers, etc.
// Can be used in combination with Composites.
//
// (C) Datasim Education BV  2001-2013

public abstract class ShapeVisitor
{
	// Default constructor
	public ShapeVisitor()
	{
	}

	// Copy constructor
	public ShapeVisitor(ShapeVisitor source)
	{
	}

	// Visit point.
	public abstract void Visit(Point p);


}