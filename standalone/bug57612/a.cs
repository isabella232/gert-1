namespace a
{
	class Program
	{
		static int Main (string[] args)
		{
			b.SomeClass b = new b.SomeClass();
			if (b.Test () != "ok b")
				return 1;
			return 0;
		}
	}
}
