using System;
using System.Collections.Generic;

public class Test
{
	public static Comparison<T> WrapComparison<T> (Comparison<T> comparison)
	{
		return delegate (T x, T y) { return comparison (x, y); };
	}

	public delegate int MyComparison<T> (T x, T y);
	public static MyComparison<T> WrapMyComparison<T> (MyComparison<T> myComparison)
	{
		return delegate (T x, T y) { return myComparison (x, y); };
	}
}
