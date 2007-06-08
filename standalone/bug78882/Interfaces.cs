using System;

public interface ITest
{
	V TestIface<V> (V v);
}

public class ServerBase<T> : MarshalByRefObject, ITest
{
	public virtual V TestVirt<V> (V v)
	{
		if (AppDomain.CurrentDomain.FriendlyName != "FooBar")
			throw new Exception ("wrong domain");

		return v;
	}

	public V TestIface<V> (V v)
	{
		if (AppDomain.CurrentDomain.FriendlyName != "FooBar")
			throw new Exception ("wrong domain");

		return v;
	}
}

public class Server<T> : ServerBase<T>
{
	public override V TestVirt<V> (V v)
	{
		if (AppDomain.CurrentDomain.FriendlyName != "FooBar")
			throw new Exception ("wrong domain");

		return v;
	}
}

class Test
{
	static int Main ()
	{
		AppDomain d = AppDomain.CreateDomain ("FooBar");

		ServerBase<object> s = CreateInstance<Server<object>> (d);

		if (42 != s.TestIface<int> (42))
			return 1;

		if (42 != s.TestVirt<int> (42))
			return 2;

		ITest t = CreateInstance<Server<object>> (d);
		if (42 != t.TestIface<int> (42))
			return 3;
		return 0;
	}

	static T CreateInstance<T> (AppDomain d)
	{
		return (T) d.CreateInstanceAndUnwrap (
			typeof (T).Assembly.FullName,
			typeof (T).FullName);
	}
}
