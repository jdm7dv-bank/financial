// ManagedWrapper.hpp
//
// C++/CLI wrapper class for a native C++ class

#pragma once

#include "NativeClass.hpp"

using namespace System;

// ManagedWrapper has similar interface as the native class that it wraps
public ref class ManagedWrapper
{
private:
	// The embedded native class (only pointers to native classes can be a C++/CLI class datamember)
	NativeClass* m_nativeClass;		

public:
	// Default constructor
	ManagedWrapper()
	{
		// Create native class instance
		m_nativeClass=new NativeClass();
	}

	// Constructor with data
	ManagedWrapper(int data)
	{
		// Create native class instance with data
		m_nativeClass=new NativeClass(data);
	}

	// Copy constructor
	ManagedWrapper(ManagedWrapper^ source)
	{
		// Copy native class instance
		m_nativeClass=new NativeClass(*source->m_nativeClass);
	}

	// Finaliser (called by the garbage collector or destructor)
	!ManagedWrapper()
	{
		// Delete the native class instance
		delete m_nativeClass;
	}

	// Destructor (Dispose)
	~ManagedWrapper()
	{
		// Call finaliser
		this->!ManagedWrapper();
	}

	// Get- and set data as property
	property int Data
	{
		int get() { return m_nativeClass->GetData(); }
		void set(int data) { m_nativeClass->SetData(data); }
	}

	// Get- and set string as property
	property String^ Str
	{
		String^ get()
		{
			return gcnew String(m_nativeClass->GetString().c_str());

			// Alternative method
			//return System::Runtime::InteropServices::Marshal::PtrToStringAnsi(IntPtr((void*)m_nativeClass->GetString().c_str()));
		}

		void set(String^ str)
		{
			// Convert to temporary char*
			IntPtr chars=System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str);
			char* pChars=static_cast<char*>(chars.ToPointer());

			// Create STL string from char*
			m_nativeClass->SetString(std::string(pChars));

			// Delete temporary char*
			System::Runtime::InteropServices::Marshal::FreeHGlobal(chars);
		}
	}
};
