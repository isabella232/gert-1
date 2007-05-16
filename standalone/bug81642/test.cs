using System;
using System.Collections;

class Program
{
	static void Main (string [] args)
	{
		int num = 5000000;
		Hashtable table = new Hashtable ();
		for (int i = 0; i < num; ++i) {
			Object obj = new Object ();
			table.Add (obj, obj);
		}
	}
}
