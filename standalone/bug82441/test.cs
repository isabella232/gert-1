using System;

class Program
{
	static int Main ()
	{
		Program bla = new Program ();
		object obj = new object ();
		String str = "test";
		bla.BuildNode (bla, bla, ref str, ref obj, ref obj);
		if (str != "test(1)")
			return 1;
		return 0;
	}

	public void BuildNode (object treeBuilder, object dataObject, ref string label, ref object icon, ref object closedIcon)
	{
		label += "(" + 1 + ")";
	}
}
