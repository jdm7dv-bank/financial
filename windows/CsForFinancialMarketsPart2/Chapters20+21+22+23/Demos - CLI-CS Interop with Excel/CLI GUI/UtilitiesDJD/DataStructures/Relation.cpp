// Relation.cpp
//
// Generic classes that model N:N, N:1 and 1:1
// relationships. These classes have a myriad of
// applications.
//
//	Last modification dates:
//
//	DD 2004-5-8 Kick-off
//	DD 2004-5-20 Programming the methods in class
//	DD 2004-5-23 removed 2 functions (now in mechanisms)
//	DD 2004-7-4 Review + some more functions
//	DD 2004-8-19 Inverse multimap
//			- constructor changes
//			- inverse iterators
//			- use of template member functions
//			- adding and removeing elements (2 hours)
//  DD 2008-1-10 for MC/C++
//
// (C) Datasim Education BV 2004-2008
//

#ifndef Relation_cpp
#define Relation_cpp

#include "Relation.hpp"

// Essential members
template <class D, class R> 
Relation<D,R>::Relation()	
{

	s1 = Set<D>();
	s2 = Set<R>();
	f = multimap<D,R>();
	finv = multimap<R, D>();

}


template <class D, class R> Relation<D,R>::Relation (const Set<D>& domainSet, const Set<R>& rangeSet)
{
	s1 = domainSet;
	s2 = rangeSet;
	f = multimap<D,R>();
	finv = multimap<R, D>();

}

template <class D, class R> 
Relation<D,R>::Relation(const Relation& r2)
{

	s1 = r2.s1;
	s2 = r2.s2;
	f = r2.f;
	finv = r2.finv;
}

template <class D, class R> 
Relation<D,R>::~Relation()
{

}

template <class D, class R> 
Relation<D,R>& Relation<D,R>::operator = (const Relation<D,R>& r2)
{
	if (this == &r2)
		return *this;

	s1 = r2.s1;
	s2 = r2.s2;
	f = r2.f;
	finv = r2.finv;


	return *this;

}


// Building and breaking the Relation
// The set element in the relations
template <class D, class R> 
void Relation<D,R>::addDomainElement(const D& d)
{

	s1.Insert(d);
}


template <class D, class R> 
void Relation<D,R>::addRangeElement(const R& r)
{

	s2.Insert(r);
}


template <class D, class R> 
void Relation<D,R>::removeDomainElement(const D& d)
{
	// Remove all references to Domain element d ??
	f.erase(d);

	// Remove all references in inverse map

	multimap<R, D>::iterator it, it2;

	it2 = finv.begin();
	it = it2;

L1:
	{
		if ((*it).second == d)
		{
			it2 = finv.erase(it);	
			it = it2;
		}
		else
		{
			it++;
		}

		if (it != finv.end())
			goto L1;

	}


	s1.Remove(d);

}

template <class D, class R> 
void Relation<D,R>::removeRangeElement(const R& r)
{
	// Remove all references to Range element r
	finv.erase(r);
	
	// Remove all references in forward map
	multimap<D,R>::iterator it, it2;

	it2 = f.begin();
	it = it2;
L1:
	{
		if ((*it).second == r)
		{
			it2 = f.erase(it);	
			it = it2;
		}
		else
		{
			it++;
		}

		if (it != f.end())
			goto L1;

	}

	s2.Remove(r);

}

// Define relationship between elements
template <class D, class R> 
void Relation<D,R>::addRelation(const D& d, const R& r)
{
	// Prec: d and r must be in the sets
	if (s1.Contains(d) == false)
		return;
	if (s2.Contains(r) == false)
		return;

	// Add a link between d and r
	pair<D, R> p;
	p.first = d;
	p.second = r;
	f.insert(p);

	// Add a link between r and d
	pair<R, D> pinv;
	pinv.first = r;
	pinv.second = d;
	finv.insert(pinv);

}

template <class D, class R> 
void Relation<D,R>::removeRelation(const D& d)
{

	// Remove link between d and ALL r ??
	f.erase(d);
}


template <class D, class R> 
void Relation<D,R>::ClearAll()
{ // Break all links and set elements

	f.erase(f.begin(), f.end());
	finv.erase(finv.begin(), finv.end());
	s1.Clear();
	s2.Clear();

	f.clear(); finv.clear();
}

template <class D, class R> 
void Relation<D,R>::ClearLinks()
{ // Break all links

	f.erase(f.begin(), f.end());
	finv.erase(finv.begin(), finv.end());

}

// Selectors
template <class D, class R> 
const Set<D>& Relation<D,R>::DomainSet()
{
	return s1;
}

template <class D, class R> 
const Set<R>& Relation<D,R>::RangeSet()
{
	return s2;
}

template <class D, class R> 
	Set<R> Relation<D,R>::range(const D& d) const
{ // Set of r for a d

	Set<R> result;

	pair<multimap<D,R>::const_iterator, multimap<D,R>::const_iterator> p = 
          f.equal_range(d);

  
 	multimap<D,R>::const_iterator it;

	for (it = p.first; it != p.second; ++it)
	{
		
		result.Insert((*it).second);
	}
	
	return result;
}



template <class D, class R> 
	Set<D> Relation<D,R>::domain(const R& r) const
{ // Set of d for an r

	Set<D> result;

	pair<multimap<R,D>::const_iterator, multimap<R,D>::const_iterator> 
		p = finv.equal_range(r);

   	multimap<R,D>::const_iterator it;

	for (it = p.first; it != p.second; ++it)
	{
		
		result.Insert((*it).second);
	}

	return result;
}

template <class D, class R> 
	multiset<R> Relation<D,R>::MultiSetRange(const D& d) const
{ // Multiset of r for a d

	multiset<R> result;

	pair<multimap<D,R>::const_iterator, multimap<D,R>::const_iterator> 
		p = f.equal_range(d);

  
 	multimap<D,R>::const_iterator it;

	for (it = p.first; it != p.second; ++it)
	{
		
		result.insert((*it).second);
	}
	
	return result;
}



template <class D, class R> 
	multiset<D> Relation<D,R>::MultiSetDomain(const R& r) const
{ // Multiset of d for an r

	multiset<D> result;

	
	pair<multimap<R,D>::const_iterator, multimap<R,D>::const_iterator> 
		p = finv.equal_range(r);

  
 	multimap<R,D>::const_iterator it;

	for (it = p.first; it != p.second; ++it)
	{
		
		result.insert((*it).second);
	}

	return result;
}

template <class D, class R> 
bool Relation<D,R>::inDomain(const D& d) const
{ // Is an element in domain?

	return s1.Contains(d);
}

template <class D, class R> 
bool Relation<D,R>::inRange(const D& r) const
{ // Is an element in range?

	return s2.Contains(r);

}


// Iterator functions	
template <class D, class R> typename
	Relation<D,R>::iterator Relation<D,R>::begin()		
{ // Return iterator at begin of relation

	return f.begin();
}

template <class D, class R> typename
	Relation<D,R>::const_iterator Relation<D,R>::begin() const	
{ // Return const iterator at begin of relation

	return f.begin();

}

template <class D, class R> typename
	Relation<D,R>::iterator Relation<D,R>::end()
{ // Return iterator after end of relation

	return f.end();

}

template <class D, class R> typename
	Relation<D,R>::const_iterator Relation<D,R>::end() const		
{ // Return const iterator after end of relation

	return f.end();

}

// Iterator functions(Inverse)
template <class D, class R> typename
	Relation<D,R>::iteratorInv Relation<D,R>::beginInv()		
{ // Return iterator at begin of relation

	return finv.begin();
}

template <class D, class R> typename
	Relation<D,R>::const_iteratorInv Relation<D,R>::beginInv() const	
{ // Return const iterator at begin of relation

	return finv.begin();

}

template <class D, class R> typename
	Relation<D,R>::iteratorInv Relation<D,R>::endInv()
{ // Return iterator after end of relation

	return finv.end();

}

template <class D, class R> typename
	Relation<D,R>::const_iteratorInv Relation<D,R>::endInv() const		
{ // Return const iterator after end of relation

	return finv.end();

}


#endif

