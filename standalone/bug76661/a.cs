using System;
using System.Reflection;

namespace a
{
	public class SomeClass
	{
		public static void Main (string [] args)
		{
			Console.WriteLine ("Loading assembly \"b\" ...");
			Assembly.LoadFrom ("b.dll");
			Console.WriteLine ("Assembly \"b\" loaded ok.");

			Console.WriteLine ("Initializing type in assembly \"b\" ...");
			b.SomeClass some = new b.SomeClass ();
			Console.WriteLine ("Type initialized ok.");

			Console.WriteLine ("Invoking method which uses assembly \"c\" ...");
			some.Test ();
			Console.WriteLine ("Method invoke ok.");
		}
	}
}
