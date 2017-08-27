// matrixsolvermechanisms.cpp
//
// Classes and functions for solving linear systems of equations 
// (doubleal linear algebra).
//
// Modification Dates:
//
//	DD 2003-1-14 First code (tridiagonal)
//	DD 2003-1-16 DD small corrections: still to code 2 member functions
//	DD 2003-8-2 LU decomposition of tridiagonal systems; 2 functions
//	(Boolean checks added)
//  DD 2003-8-5 Matrix iterative solvers (Jacobi, Gauss Seidel)
//	DD 2003-8-21 Debugging and good testing
//	DD 2003-9-1 Debugging Jacobi
//	DD 2004-4-10 New implementation using the Template Method pattern
//	DD 2004-4-11 Implement PSOR as a derived class. Lots of reuse
//  DD 2005-10-6 LU version for C++ Intro book. Optimised, no copy of arrays
//  DD 2005-10-15 Function to test diagonal dominance
//	DD 2006-1-10 Clean up cout stuff
//  DD 2008-12-15 ported to C#
//  DD 2010-4-8 update and new methods; performance; AND it's generic now
//  DD 2010-4-13 arbitrary start index
//
// (C) Datasim Education BV 2003-2010
//

using System;

public class LUTridiagonalSolver
{ // Solve tridiagonal matrix equation

    // Defining arrays (input)
    private Vector<double> a;	// The lower-diagonal array [1..J]
    private Vector<double> b;	// The diagonal array [1..J] "baseline array"
    private Vector<double> c;	// The upper-diagonal array [1..J]
    private Vector<double> r;	// The right-hand side of the equation Au = r [1..J]

    // Work arrays

    // Coefficients of Lower and Upper matrices: A = LU
    // V2 use of Templated static vectors, but we must be careful
    private Vector<double> beta;	// Range [1..J]
    private Vector<double> gamma;	// Range [1..J-1]

    // Solutions of temporary and final problems
    private Vector<double> z;		// Range [1..J]
    private Vector<double> u;		// Range [1..J]

    private int Size;
    private int SI;                 // Start index
    private int MI;                 // Work variable

    private void InitWorkArrays()
    { // Initialise the arrays in the Thomas algorithm

        beta = new Vector<double>(Size, SI);
        gamma = new Vector<double>(Size - 1, SI);

        z = new Vector<double>(Size, SI);
        u = new Vector<double>(Size, SI);
    }


   public LUTridiagonalSolver(Vector<double> lower, Vector<double> diagonal, Vector<double> upper, Vector<double> RHS)
    {
        // Arrays are referenced
        Size = diagonal.Size;
        SI = diagonal.MinIndex;
        MI = diagonal.MaxIndex;

        a = lower;
        b = diagonal;
        c = upper;
        r = RHS;

        InitWorkArrays();

        Console.WriteLine(Size);
        Console.WriteLine(SI);
        Console.WriteLine(MI);
    }

    public LUTridiagonalSolver(LUTridiagonalSolver source)
    {
        Size = source.Size;
        SI = source.b.MinIndex;
        MI = source.b.MaxIndex;

        // Deep copy of input arrays
        a = new Vector<double>(source.a);
        b = new Vector<double>(source.b);
        c = new Vector<double>(source.c);
        r = new Vector<double>(source.r);

        InitWorkArrays();    
    }

    
    private void calculateBetaGamma()
    { // Calculate beta and gamma

     
        beta[SI] = b[SI];
        gamma[SI] = c[SI] / beta[SI];
        for (int j = SI+1; j <= MI - 1; j++)
        {
            beta[j] = b[j] - (a[j] * gamma[j - 1]);
            gamma[j] = c[j] / beta[j];
        }

        beta[MI] = b[MI] - (a[MI] * gamma[MI - 1]);
    }

    private void calculateZU()
    { // Calculate z and u

        // Forward direction
        z[SI] = r[SI] / beta[SI];

        for (int j = SI+1; j <= MI; j++)
        {
            z[j] = (r[j] - (a[j] * z[j - 1])) / beta[j];

        }

        // Backward direction
        u[MI] = z[MI];

        for (int i = MI - 1; i >= SI; i--)
        {
            u[i] = z[i] - (gamma[i] * u[i + 1]);

        }
      }

    // Calculate the solution to Au = r
    public Vector<double> solve()
    {
        calculateBetaGamma();		// Calculate beta and gamma
        calculateZU();				// Calculate z and u

        return u;
    }
    
    public bool DiagonallyDominant()
    { // Are the diagonal values larger than sum of off-diagonal element in
      // absolute value?

	if (Math.Abs(b[SI]) < Math.Abs(c[SI]))
        return false;

	if (Math.Abs(b[MI]) < Math.Abs(a[MI]))
		return false;

	for (int j = SI+1; j <= MI-1; j++)
	{
		if (Math.Abs(b[j]) < Math.Abs(a[j]) + Math.Abs(c[j]) )
			return false;
	}

    return true;
    }
    
    public bool ZMatrix()
    { // Are off-diagonal elements <= 0?

        if (0.0 < c[SI])
            return false;

        if (0.0 < a[MI])
            return false;
    
        for (int j = SI+1; j < MI-1; j++)
        {
            if (a[j] > 0.0 | c[j] > 0.0)
                return false;
        }
        return true;
    }

    public bool MMatrix()
    { // M == Z matrix and diagonal elements are positive

  
        for (int j = SI; j <= MI; j++)
        {
            if (b[j] <= 0.0)
                return false;
        }

        return ZMatrix();
    }

    private bool checkArrays(Vector<double> v1, Vector<double> v2)
    {
        return (v1.MinIndex == v2.MinIndex && v1.MaxIndex == v2.MaxIndex);
    }

    public bool CheckArrayAlignments()
    { // The arrays a,b,c and r must have same start and end indices

        if (checkArrays(b, a) == false)
            return false;

        if (checkArrays(b, c) == false)
            return false;

        if (checkArrays(b, r) == false)
            return false;

        return true;
       
    }


}