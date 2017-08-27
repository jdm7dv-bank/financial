// Relation.hpp
//
// Generic classes that model N:N, N:1 and 1:1
// relationships. These classes have a myriad of
// applications.
//
// We define a class that maps elements of one Set S1
// to another set S2. You can create N:N, N:1 and 1:1 
// relationships between objects. The only restriction 
// is that the elements in the relation should be elements
// of the Domain Set or Range Set.
//
// We note that it is possible to access all r in R for a 
// given d in D as well as all d in D for a given r in R.
//
// The class 'Set' is an encapsulation of STL 'set' and is easier
// to understand
//
// (C) Datasim Education BV 2004-2008
//


#ifndef Relation_hpp
#define Relation_hpp

#include "Set.cpp"
#include <set>
#include <map>		// Includes both map and multimap
using namespace std;

template <class D, class R> class Relation
{ // Classes representing mappings from D to R
private:

	// 'Control' information
	Set<D> s1;			// Domain Set
	Set<R> s2;			// Range Set

	// Information about the mapping itself. These two
	// multimaps must be kept consistent
	multimap<D, R> f;		// The mapping itself
	multimap<R, D> finv;	// The inverse mapping

public:
	// Essential members
	Relation();		
	Relation (const Set<D>& domainSet, const Set<R>& rangeSet);
	Relation(const Relation<D,R>& r2);


	// Building and breaking the Relation
	// The set element in the relations
	void addDomainElement(const D& d);	// Add d to Domain Set (no link)
	void addRangeElement(const R& r);	// Add r to Range Set (no link)
	void removeDomainElement(const D& d);	// Remove d and all links
	void removeRangeElement(const R& r);	// Remove r and all links

	// Define relationship between EXISTING elements
	void addRelation(const D& d, const R& r);	// 
	void removeRelation(const D& d);	// Remove between d and ALL r
	void ClearAll();					// Break all links and sets
	void ClearLinks();					// Break links only, sets remain


	// Iterator functions (going from D direction)
	typedef typename multimap<D, R>::iterator iterator;
	typedef typename multimap<D, R>::const_iterator const_iterator;

	iterator begin();				// Return iterator at begin of relation
	const_iterator begin() const;	// Return const iterator at begin of relation
	iterator end();					// Return iterator after end of relation
	const_iterator end() const;		// Return const iterator after end of relation

	// Iterator functions (going from R direction)
	typedef typename multimap<R, D>::iterator iteratorInv;
	typedef typename multimap<R, D>::const_iterator const_iteratorInv;

	iteratorInv beginInv();				// Return iterator at begin of relation
	const_iteratorInv beginInv() const;	// Return const iterator at begin of relation
	iteratorInv endInv();					// Return iterator after end of relation
	const_iteratorInv endInv() const;		// Return const iterator after end of relation


	// Selectors
	const Set<D>& DomainSet();
	const Set<R>& RangeSet();
	
	// No duplicates will be printed
	Set<R> range(const D& d) const;						// Set of r for a d
	Set<D> domain(const R& r) const;					// Set of d for an r

	// Now duplicates
	multiset<R> MultiSetRange(const D& d) const;		// Multiset of r for a d
	multiset<D> MultiSetDomain(const R& r) const;		// Multiset of d for an r

	bool inDomain(const D& d) const;	// Is an element in domain?
	bool inRange(const D& r) const;		// Is an element in range?

	virtual ~Relation();
	Relation<D,R>& operator = (const Relation<D,R>& r2);

};


#endif

