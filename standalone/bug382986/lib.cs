public abstract class FooBase
{
	protected internal virtual int Test ()
	{
		return 0;
	}
}

public class Bar
{
	public static int RunTest<T> (T f) where T : FooBase
	{
		return f.Test ();
	}
}
