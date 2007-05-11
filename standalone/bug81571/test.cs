using System;

class Program
{
	static int Main ()
	{
		int i = 0;
		GenericType<bool> g = new GenericType<bool> (true);
		if (g)
			i++;
		if (g == true)
			i++;
		if (!g)
			i++;
		return i == 2 ? 0 : 1;
	}
}

class GenericType<T>
{
	private T value;

	public GenericType (T value)
	{
		this.value = value;
	}

	public static implicit operator T (GenericType<T> o)
	{
		return o.value;
	}
}
