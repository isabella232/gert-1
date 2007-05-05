class M
{
	static void Main ()
	{
		C c;
	}
}

class A<a> { }

class B<a> : A<a> { }

class C : B<C> { }
