using System.Collections.Generic;

public class A
{
	public static void Foo (IEnumerable<double> a)
	{
		IEnumerator<double> a_enum = a.GetEnumerator ();
		double b = a_enum.Current<double>;
	}
}
