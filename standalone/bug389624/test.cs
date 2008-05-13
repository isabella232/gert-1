class Program
{
	delegate void Handler ();

	static T Foo<T> () where T : new ()
	{
		T result = default (T);
		Bar (delegate () {
			result = new T ();
		});
		return result;
	}

	static void Bar (Handler h)
	{
		h ();
	}

	static void Main (string [] args)
	{
		Foo<object> ();
	}
}
