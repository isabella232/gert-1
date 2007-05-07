using System;

public class InvalidILTest
{
	static int Main ()
	{
		string result;

		result = (new Bar (5)).ToString ();
		if (result != "5")
			return 1;

		result = (new Foo<string> ("hello")).ToString ();
		if (result != "hello")
			return 2;

		result = (new Foo<int?> (5)).ToString ();
		if (result != "5")
			return 3;

		result = (new Foo<int> (5)).ToString ();
		if (result != "5")
			return 4;

		return 0;
	}
}

public class Foo<T1>
{
	public Foo (T1 t1)
	{
		m_t1 = t1;
	}

	public override string ToString ()
	{
		return Bar (m_t1 == null ? "null" : m_t1.ToString ());
	}

	public string Bar (string argument) { return argument; }

	readonly T1 m_t1;
}

public class Bar
{
	public Bar (int a)
	{
		m_str = a;
	}

	public override string ToString ()
	{
		return Foo (m_str == null ? "null" : m_str.ToString ());
	}

	public string Foo (string argument)
	{
		return argument;
	}

	readonly int? m_str;
}
