// testRelation.cpp
//
// Testing Relation class. This can be seen as a UNIVERSAL
// MEDIATOR.
//
// (C) Datasim Education BV 2004-2006
//

#include <iostream>
#include <string>
#include <set>
using namespace std;

#include "Relation.cpp"

template <class T> void print(const Set<T>& l, const string& name)
{  // Print the contents of a Set. Notice the presence of a constant iterator.
	
	cout << endl << name << ", size of set is " << l.Size() << "\n[ ";

	set<T>::const_iterator i;

	for (i = l.begin(); i != l.end(); ++i)
	{
			cout << *i << " ";

	}

	cout << "]\n";
}

template <class T> void print(const multiset<T>& l, const string& name)
{  // Print the contents of a multiset. Notice the presence of a constant iterator.
	
	cout << endl << name << ", size of set is " << l.size() << "\n[ ";

	multiset<T>::const_iterator i;

	for (i = l.begin(); i != l.end(); ++i)
	{
			cout << *i << ", ";

	}

	cout << "]\n";
}
template <class D, class R>
	void print(const Relation<D,R>& r)
{
	Relation<D,R>::const_iterator i = r.begin();

	while (i != r.end())
	{ 
			cout << "[" << (*i).first << "," << (*i).second << "]";
			i++;
	}
	
	cout << endl;

}

int main()
{

	Set<char> s1;
	s1.Insert('1');
	s1.Insert('2');
	s1.Insert('3');
	s1.Insert('4');
	s1.Insert('5');
	s1.Insert('7');

	Set<char> s2;
	s2.Insert('X');
	s2.Insert('Y');
	s2.Insert('Z');
	s2.Insert('N');	
	s2.Insert('D');

	Relation<char, char> r(s1, s2);

	r.addRelation('1', 'X');
	r.addRelation('1', 'Z'); 
	r.addRelation('1', 'D');
	r.addRelation('1', 'Y');
	r.addRelation('1', 'Y');
	r.addRelation('2', 'X');
	r.addRelation('2', 'X');
	r.addRelation('2', 'X');
	r.addRelation('2', 'X');
	r.addRelation('7', 'X');
	r.addRelation('3', 'Y');
	r.addRelation('3', 'Z');
	r.addRelation('2', 'X');
	r.addRelation('7', 'N');
	r.addRelation('9', 'N');


	print(r);

	Set<char> answer = r.range('1');
	print(answer, string("Range Extraction"));
	multiset<char> answerA = r.MultiSetRange('1');
	print(answerA, string("Range Extraction"));

	Set<char> answer2 = r.domain('X');
	print(answer2, string("Domain Extraction"));
	multiset<char> answerB = r.MultiSetDomain('X');
	print(answerB, string("Domain Extraction"));

	// Creating a dictionary from other languages to English

	return 0;
}
