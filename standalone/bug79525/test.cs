interface Interface1<T>
{
}

class Generic1<T>
{

	class Nested : Interface1<T>
	{
		public void salute ()
		{
		}
	}

	public Interface1<T> getAnInstance ()
	{
		return new Nested ();
	}

	public void test (Interface1<T> gi)
	{
		Nested n = (Nested) gi;
		n.salute ();
	}

}

class Program
{
	static void Main ()
	{
		Generic1<int> g1 = new Generic1<int> ();
		Interface1<int> gi = g1.getAnInstance ();
		g1.test (gi);
	}
}
