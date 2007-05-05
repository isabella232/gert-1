using System;
using System.Collections.Generic;
using System.Diagnostics;
using Scea.Collections;

public class EntryPoint
{
	static void Main ()
	{
		Multimap<Type, string> map = new Multimap<Type, string> ();
		map.Add (typeof (int), "int");
		IEnumerable<string> strings = map [typeof (int)];
		strings.GetEnumerator ();
	}
}
