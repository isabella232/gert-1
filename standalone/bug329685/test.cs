using System;
using System.IO;
using System.Reflection;

class Program
{
	public static T [] FindAll<T> (T [] array, Predicate<T> match)
	{
		return new T [0];
	}

	private bool ProtectedOnly (MemberInfo input)
	{
		return false;
	}

	public MemberInfo [] foo ()
	{
		string name = "FOO";
		MemberInfo [] res = FindAll (typeof (int).GetMember (name,
			BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic),
			ProtectedOnly);
		return res;
	}

	static void Main (String [] args)
	{
		new Program ().foo ();
	}
}
