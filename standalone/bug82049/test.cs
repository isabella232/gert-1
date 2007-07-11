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
			Console.Write ("test");
		}

		static int Main ()
		{
			Console.Write ("start");
			try {
				Test ();
				return 1;
			} catch (TypeLoadException ex) {
				if (ex.Message.IndexOf ("Stop") == -1)
					return 2;
				if (ex.Message.IndexOf ("Application.MyClass") == -1)
					return 3;
				if (ex.Message.IndexOf ("test, Version=0.0.0.0, Culture=neutral") == -1)
					return 4;
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
