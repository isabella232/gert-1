public abstract class MyAbstractBase
{
	public abstract void Initialize ();
}

public abstract class MyAbstract : MyAbstractBase
{
	public virtual void Initialize ()
	{
		System.Console.WriteLine ("MyAbstract Initialized!");
	}
}

public class MyConcrete : MyAbstract
{
}

public class Program
{
	static void Main (string [] args)
	{
		MyAbstractBase gonnaFail = new MyConcrete ();
		gonnaFail.Initialize ();
	}
}
