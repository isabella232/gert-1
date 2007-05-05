using System;
using System.Reflection;

public class Dummy
{
	public int? x {
		set {
			_x = value;
		}
		get {
			return _x;
		}
	}
		
	int? _x;

	public Dummy () {}
}

public class EntryPoint
{
	static int Main ()
	{
		int? dummy_x;
		PropertyInfo p;
		
		Dummy dummy = new Dummy ();
		dummy.x = null;
		p = dummy.GetType ().GetProperty ("x");
		dummy_x = (int?) p.GetValue (dummy, null);

		if (dummy_x != null)
			return 1;

		dummy_x = 8;
		p.SetValue (dummy, dummy_x, null );
		dummy_x = (int?) p.GetValue (dummy, null);
		if (dummy_x != 8)
			return 2;

		return 0;
	}
}
