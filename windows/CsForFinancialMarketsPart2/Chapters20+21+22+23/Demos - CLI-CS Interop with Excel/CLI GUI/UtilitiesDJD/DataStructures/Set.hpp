// Set.hpp
//
// C++ template class that implements the concept of
// a mathematical set.
// This class is composed of an STL set and uses Information
// Hiding.
//
// (C) Datasim Education BV 2004-2008

#ifndef Set_HPP
#define Set_HPP

#include <set>
#include <list>
using namespace std;

template <class V> class SetThing {};

template <class V> class Set : public SetThing<V>
{
private:
		set<V> s;

public:
		// Iterator functions; Navigating in a set
		typedef typename set<V>::iterator iterator;
		typedef typename set<V>::const_iterator const_iterator;

public:
		// Constructors
		Set();						// Empty set
		Set(const set<V>& stlSet);	// Create a Set from STL set
		Set(const Set<V>& s2);		// Copy constructor
		// Construct a set from V that has STL-compatible iterators
		Set(const list<V>& con);	// From an STL list
		Set<V> operator = (const Set<V>& s2);
		virtual ~Set();

		// Standard set operations from High School
		template <class V>
			friend Set<V> Intersection(const Set<V>& s1, const Set<V>& s2);
		Set<V> operator ^ (const Set<V>& s2);	// Intersection

		template <class V>
			friend Set<V> Union(const Set<V>& s1, const Set<V>& s2);
		Set<V> operator + (const Set<V>& s2);	// Union

		template <class V>
			friend Set<V> Difference(const Set<V>& s1, const Set<V>& s2);
		Set<V> operator - (const Set<V>& s2);	// Difference

		template <class V>
			friend Set<V> SymmetricDifference(const Set<V>& s1, const Set<V>& s2);
		Set<V> operator % (const Set<V>& s2);	// Symmetric Difference

		// Template member functions inline 
		template <class V2> 
			Set<pair<V, V2> > CartesianProduct(const Set<V2>& s2);

		// Cartesian product using '*'
		template <class V2> 
		Set<pair<V, V2> > operator * (const Set<V2>& s2);
		
		iterator begin();				// Return iterator at begin of set
		const_iterator begin() const;	// Return const iterator at begin of set
		iterator end();					// Return iterator after end of set
		const_iterator end() const;		// Return const iterator after end of set

		// Operations on a single set
		long Size() const;				// Number of elements	
		void Insert(const V& v);		// Insert an element
		void InsertElement(const V& v);		// Insert an element
	//	void Insert(const Set<V>& v);	// Insert another set
		void Remove(const V& v);		// Remove an element
		void Replace(const V& Old, const V& New);	// Replace old by new
		void Clear();					// Remove all elements
		bool Contains(const V& v) const;			// Is v in set?
		bool Empty() const;				// Contains no elements

		// Using 'clever' operators
		void operator + (const V& v);	// Insert an element
		void operator - (const V& v);	// Remove an element

		// Relations between sets (s1 == *this)
		bool Subset(const Set<V>& s2) const;	// s1 a subset of s2?
		bool Superset(const Set<V>& s2) const;	// s1 a superset of s2?
		bool Intersects(const Set<V>& s2) const;	// s1 and s2 have common elements?
	

};

#endif