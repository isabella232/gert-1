using System;

public class ClassA<T>
{
}

public class ClassB
{
}

public class Class1<T>
{
	public virtual void Method1<U, V> (U myvar)
		where U : ClassA<V>
		where V : ClassB
	{
	}
}

public class Class2<T> : Class1<T>
{
	public override void Method1<U, V> (U myvar)
	{
	}
}
