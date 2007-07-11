using System;

namespace Application
{
	public class App
	{
		static void Main ()
		{
			try {
				MyClass c = new MyClass ();
				c.Run ();
			} catch (Exception) {
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
