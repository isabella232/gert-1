using System;
using System.Diagnostics;

class Program
{
	[Conditional ("DEBUG")]
	static void NonTemplate (string line)
	{
		throw new Exception ("NT");
	}

#if NET_2_0
	[Conditional ("DEBUG")]
	static void Template<T> (T instance, string line)
	{
		throw new Exception ("T");
	}
#endif

	static void Main (string [] args)
	{
		NonTemplate ("shouldn't see this");
#if NET_2_0
		Template (true, "or this");
#endif
	}
}
