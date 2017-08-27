// GenericConstraints.cs
//
// Using generic constraints.
//
// (C) Datasim Education BV 2012
//
using System;

public class C
{
}

public interface InterfaceA
{
    void doit();
}

public class GenericClass<T1, T2>
    where T1 : C, InterfaceA
    where T2 : new()
{
}


