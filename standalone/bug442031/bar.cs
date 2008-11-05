public class BarA
{
	private FooA foo;

	public void Run ()
	{
		foo = new FooA ();
		if (foo == null) {
		}
	}
}

public class BarB
{
	public void Run ()
	{
		FooB foo = new FooB ();
		if (foo == null) {
		}
	}
}

public class BarC
{
	public FooB Walk ()
	{
		return null;
	}
}
