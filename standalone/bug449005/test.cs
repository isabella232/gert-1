using System;

public struct CInt
{
	int data;

	public CInt (int data)
	{
		this.data = data;
	}

	public static implicit operator CInt (int xx)
	{
		return new CInt (xx);
	}

	public static implicit operator int (CInt xx)
	{
		return xx.data;
	}
}


public class Klass<T> where T : struct
{
	T? t;
	public Klass (T? t)
	{
		this.t = t;
	}

	public T? Value {
		get {
			return t;
		}
	}
}

public class Program
{
	static int Main ()
	{
		if ((new Klass<CInt> (new CInt (3))).Value == 3)
			return 0;
		return 1;
	}
}
