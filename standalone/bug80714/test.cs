using System;

public struct A
{
	public static bool operator == (A left, A right)
	{
		return true;
	}
	public static bool operator != (A left, A right)
	{
		return false;
	}
	public override bool Equals (object o)
	{
		return false;
	}
	public override int GetHashCode ()
	{
		return 1;
	}
}

public class T
{
	static void Main ()
	{
		A a;
		Console.WriteLine (a == null);
	}
}
