using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
	[MyAttribute (typeof (IList<string>))]
	public IList<string> MyField1 = new List <string> ();

	[MyAttribute (typeof (IList<Program>))]
	public IList<Program> MyField2 = new List <Program> ();

	static int Main ()
	{
		FieldInfo fi;
		object [] attrs;
		MyAttribute myAttr;

		fi = typeof (Program).GetField ("MyField1");
		attrs = fi.GetCustomAttributes (true);

		if (attrs.Length != 1)
			return 1;

		myAttr = (MyAttribute) attrs [0];
		if (myAttr.Type != typeof (IList<string>))
			return 2;

		fi = typeof (Program).GetField ("MyField2");
		attrs = fi.GetCustomAttributes (true);

		if (attrs.Length != 1)
			return 3;

		myAttr = (MyAttribute) attrs [0];
		if (myAttr.Type != typeof (IList<Program>))
			return 4;

		return 0;
	}
}

public class MyAttribute : Attribute
{
	public MyAttribute (Type type)
	{
		_type = type;
	}

	public Type Type {
		get { return _type; }
	}

	private Type _type;
}
