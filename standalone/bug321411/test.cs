public interface IA<K>
	where K : System.IComparable, System.IComparable<K>
{
}

public class A<K> : IA<K>
	where K : System.IComparable, System.IComparable<K>
{
}

public interface IB<K, T>
	where T : System.IDisposable
{
}

public class B<K, T> : IB<K, T>
	where T : B<K, T>.Element, System.IDisposable, new ()
	where K : System.IComparable, System.IComparable<K>
{
	public abstract class Element : A<K>
	{
	}
}
