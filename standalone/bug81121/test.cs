public class SomeClass<T> where T : new ()
{
	public void Foo ()
	{
		new T ();
	}
}
