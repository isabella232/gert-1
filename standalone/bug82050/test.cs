using System;

namespace Application
{
	public class App
	{
		public static void Test ()
		{
			MyClass c = new MyClass ();
			c.Run ();
		}

		public static void Test2 ()
		{
		}

		static int Main ()
		{
			for (int i = 0; i < 1000000; ++i) {
				try {
					Test ();
					return 1;
				} catch (TypeLoadException) {
				}
			}
			Test2 ();
			return 0;
		}
	}
	
	class MyClass: IMyInterface
	{
		public void Run ()
		{
		}
	}
}
