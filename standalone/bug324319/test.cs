public class Foo
{
	public virtual ServiceType GetService<ServiceType> (params object [] args)
		where ServiceType : class
	{
		return null;
	}
}

public class Bar
{
	public P GetService<P> () where P : class
	{
		return null;
	}
}
