namespace TestCase
{
	class Pair<A, B>
	{
	}

	abstract class Abstract
	{
		internal abstract A GetA<A, B, PAIR> ()
			where PAIR : Pair<A, B>;
	}

	class Concrete : Abstract
	{
		internal override A GetA<A, B, PAIR> ()
		{
			throw new System.Exception ();
		}
	}
}
