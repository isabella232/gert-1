using System;
using System.Collections;

public class Test
{
	public void Execute ()
	{
		TestCollection a = null;
		foreach (object x in a) {
			Console.WriteLine (x);
		}
	}
}

interface ITestCollection : IEnumerable
{
	new IEnumerator GetEnumerator ();
}

interface TestCollection : ITestCollection
{
}
