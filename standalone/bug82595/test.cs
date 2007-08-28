using System;

class C : ContextBoundObject
{
	public virtual T Q<T> (T t)
	{
		return t;
	}

	static void Main ()
	{
//			new C ();
	}
}
