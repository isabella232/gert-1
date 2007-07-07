using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
	static int Main (string [] args)
	{
		Type t = typeof (SlowConvert<,>);
		MethodInfo [] methods = t.GetMethods (BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		if (methods.Length != 2)
			return 1;
		foreach (MethodInfo m in methods) {
			if (m.IsSpecialName) {
				if (m.Name != "IConvert<KeyPair<K,T>>.get_Result")
					return 2;
			} else if (m.Name != "IConvert<KeyPair<K,T>>.Convert")
				return 3;
		}

		PropertyInfo [] properties = t.GetProperties (BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		if (properties.Length != 1)
			return 4;
		if (properties [0].Name != "IConvert<KeyPair<K,T>>.Result")
			return 5;
		return 0;
	}
}

class FastConvert<T> : IConvert<T>
{
	void IConvert<T>.Convert (T x, T y)
	{
	}

	T IConvert<T>.Result {
		get { return default (T); }
	}
}

class SlowConvert<K, T> : IConvert<KeyPair<K, T>>
{
	void IConvert<KeyPair<K, T>>.Convert (KeyPair<K, T> x, KeyPair<K, T> y)
	{
	}

	KeyPair<K, T> IConvert<KeyPair<K, T>>.Result {
		get { return default (KeyPair<K, T>); }
	}

	public void Reverse<A, B> ()
	{
	}
}

class KeyPair<K, P>
{
}

interface IConvert<T>
{
	void Convert (T x, T y);
	T Result {
		get;
	}
}
