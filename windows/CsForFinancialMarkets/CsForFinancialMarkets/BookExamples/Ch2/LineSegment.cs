// LineSegment.cs
//
// (Finite) line segments in 2 dimensions. This class represents an undirected
// line segment.
// The functionality is basic. If you wish to get more functions then convert the
// line segment to a vector or to a line and use their respective member functions.
//
// This is a good example of Composition (a line segment consists of two points() 
// the Delegation principle. For example, the member fucntion that calculates the 
// length of a line is implemented as the distance function between the line's end
// points.
//
// (C) Datasim BV 1995-2010
//

public struct LineSegment
{
	private Point startPoint;	
	private Point endPoint;		 


	// Constructors
	public LineSegment(Point p1, Point p2);	// Line with end Points [p1, p2]
	public LineSegment(LineSegment l); 				// Copy constructor

	// Accesssing functions
	Point start();							
	Point end();								

	// Modifiers
	void start(Point pt);					// Set Point pt1
	void end(Point pt);						// Set Point pt2

	// Arithemetic
	double length();							// Length of line

	// Interaction with Points
	Point MidPoint();							// MidPoint of line segment
}



