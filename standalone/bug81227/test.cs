using System;
using System.Collections;
using System.Collections.Generic;

public struct MyStruct : IList<int>
{
	public int this [int x] { get { return 0; } set { return; } }
	public int IndexOf (int x) { return 0; }
	public void Insert (int x, int y) { return; }
	public void RemoveAt (int x) { return; }
	public int Count { get { return 0; } }
	public bool IsReadOnly { get { return false; } }
	public void Add (int x) { return; }
	public void Clear () { return; }
	public bool Contains (int x) { return false; }
	public void CopyTo (int [] x, int y) { return; }
	public bool Remove (int x) { return false; }
	public IEnumerator<int> GetEnumerator () { yield return 0; }
	IEnumerator IEnumerable.GetEnumerator () { yield return 0; }
}

public class A
{
	public A (IList<IList<int>> x)
	{
		int y = x.Count;
		if (y != 1)
			Environment.Exit (2);
	}
}

public class Test
{
	static int Main ()
	{
		MyStruct [] myStructArray = new MyStruct [1];
		A a = new A (myStructArray);
		if (a == null)
			return 3;
		return 0;
	}
}
