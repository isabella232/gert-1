using System;

namespace Application
{
	public class App
	{
		public static void Main ()
		{
			try {
				MyClass c = new MyClass ();
				c.Run ();
			} catch (Exception ex) {
				Console.WriteLine ("Got an exception: " + ex.Message);
			}
		}
	}

	class MyClass : IMyInterface
	{
		public void Run ()
		{
		}
	}
}
