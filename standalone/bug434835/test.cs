using System;

public interface GenericInterface
{
	void Method (Type t, object o);
	void Method<IFACE, IMPL> () where IMPL : IFACE;
	void Method<T> (object o);
}

public class GenericConstraints : GenericInterface
{
	public void Method (Type t, object o)
	{
	}

	public void Method<IFACE, IMPL> () where IMPL : IFACE
	{
		Method<IFACE> (Activator.CreateInstance (typeof (IMPL)));
	}

	public void Method<T> (object foo)
	{
		Method (typeof (T), foo);
	}
}
