using System;

namespace Application
{
	public class App
	{
		static void Test ()
		{
			MyClass c = new MyClass ();
			c.Run ();
		}

		public static void Main ()
		{
			try {
				Test ();
			} catch (TypeLoadException ex) {
				Console.WriteLine (ex.ToString ());
				Console.WriteLine ("Got an exception: " + ex.Message);
			}
		}
	}
	
	class MyClass: IMyInterface
	{
		public void Run ()
		{
		}
	}
}
