using System;

class Program
{
	static int Main ()
	{
		B b = new B ();
		return b.M ();
	}
}

abstract class A<T1, T2>
{
	public int M ()
	{
		try {
			M2 ();
			return 1;
		} catch (Exception ex) {
			if (ex is NestedException)
				return 0;
			else
				return 2;
		}
	}

	protected abstract void M2 ();

	protected class NestedException : Exception
	{
		public NestedException () : base ()
		{
		}
	}
}

class B : A<int, int>
{
	protected override void M2 ()
	{
		throw new NestedException ();
	}
}
