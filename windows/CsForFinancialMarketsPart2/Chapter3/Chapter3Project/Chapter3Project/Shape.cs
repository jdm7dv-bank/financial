using System;

// Shape base class
public abstract class Shape
{
	// Default constructor
	public Shape()
	{
	}

	// Copy constructor
	public Shape(Shape source)
	{
	}

	// Destructor
	~Shape()
	{
	}

	// Return descriptive string.
	public override string ToString()
	{
		return "Shape";
	}

	// Abstract function to draw the shape, no implementation
	public abstract void Draw();

	// No implementation of ICloneable.Clone() but own abstract clone method directly returning Shape.
	// Derived classes can implement ICloneable.Clone().
	public abstract Shape Clone();
}