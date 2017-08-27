// NativeClass.hpp
//
// (C) Datasim Education BV  2006

#ifndef NativeClass_hpp
#define NativeClass_hpp

#include <string>

// A native class
class NativeClass
{
private:
	int m_data;
	std::string m_string;

public:

	// Default constructor
	NativeClass()
	{
		m_data=0;
	}

	// Constructor with data
	NativeClass(int data)
	{
		m_data=data;
	}

	// Copy constructor
	NativeClass(const NativeClass& source)
	{
		m_data=source.m_data;
	}

	// Get data
	int GetData()
	{
		return m_data;
	}

	// Set data
	void SetData(int data)
	{
		m_data=data;
	}

	// Get string
	std::string GetString()
	{
		return m_string;
	}

	// Set string
	void SetString(std::string str)
	{
		m_string=str;
	}
};

#endif