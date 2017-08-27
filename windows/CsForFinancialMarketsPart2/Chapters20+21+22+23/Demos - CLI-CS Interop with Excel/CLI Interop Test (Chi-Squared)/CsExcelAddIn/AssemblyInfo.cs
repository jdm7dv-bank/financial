using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle("Chi-Squared Excel Add-in")]
[assembly: AssemblyDescription("Chi-Squared Excel Add-in written in C#/C++/CLI")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Datasim Education BV")]
[assembly: AssemblyProduct("Chi-Squared Excel Add-in")]
[assembly: AssemblyCopyright("(C) Datasim Education BV  2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Revision
//      Build Number
//
// You can specify all the value or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion("1.0.*")]

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified - the assembly cannot be signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. 
//   (*) If the key file and a key name attributes are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP - that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the file is installed into the CSP and used.
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]

// The assembly must have a fixed GUID. Else a VBA client can't find the 
// early binding information anymore after a re-compilation.
// But giving a fixed GUID, causes the setup project to give a warning:
// Unable to create registration information for file named 'CsExcelAddIn.tlb'
// But this seems not to influence correct installation on a client machine.
[assembly: GuidAttribute("940444FA-090C-4df4-A269-044A1AE8CB47")]
