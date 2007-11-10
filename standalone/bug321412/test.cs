public interface IA<K> : System.IComparable<K> where K : System.IComparable<K>
{
}

public interface IB<C> where C : IB<C>
{
}

public interface IC<K, C> : IB<C>, IA<K>
	where C : IC<K, C>
	where K : System.IComparable<K>
{
}

public interface ID<K, C> : IC<K, C>
	where C : ID<K, C>, IC<K, C>
	where K : System.IComparable<K>
{
}

public class E<K, C> : ID<K, E<K, C>>
	where C : IA<K>
	where K : System.IComparable<K>
{
	int System.IComparable<K>.CompareTo (K other)
	{
		return 0;
	}
}
