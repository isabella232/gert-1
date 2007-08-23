public class Foo<K>
{
}

partial class B
{
}

partial class B : Foo<B.C>
{
	public class C
	{
	}
}
