using System;
using System.Collections;

class Program
{
	static void Main ()
	{
		string filename = "ee";
		if (filename != "ee") {
			try {
				stream = "bb";
			} finally {
			}
		}
	}
}

public class class1
{
	public void function ()
	{
	}
}

public class class2
{
	public void function ()
	{
	}
}

public class Test
{
	ArrayList list1;
	ArrayList list2;

	public void TestFunction ()
	{
		list1 = new ArrayList ();
		list2 = new ArrayList ();

		int i = 0;
		if (i == 0) {
			foreach (class1 c1 in list1) {
				c1.function ();
			}
			foreach (class2 c2 in list2) {
				c1.function ();
			}
		}
	}
}
