using System;
using System.Collections.Generic;

class Program
{
	static int Main (string [] args)
	{
		IList<object> list = new object [] { "foo", "bar" };
		try {
			string [] array = (string []) list;
			if (array == null) {
			}
			return 1;
		} catch (InvalidCastException) {
			return 0;
		}
	}
}
