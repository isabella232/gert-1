using System;
using System.Reflection;

namespace MonoBug
{
	public class Program
	{
		static int Main (string [] args)
		{
			Assembly assembly = Assembly.GetExecutingAssembly ();
			Type type = assembly.GetType ("MonoBug.Program", true);
			MethodInfo info = type.GetMethod ("Foo");
			object [] attributes = info.GetCustomAttributes (false);
			if (attributes == null) {
				Console.WriteLine ("#1");
				return 1;
			}
			if (attributes.Length != 1) {
				Console.WriteLine ("#2: " + attributes.Length.ToString ());
				return 1;
			}
			if (!(attributes [0] is MyAttribute)) {
				Console.WriteLine ("#3: " + attributes [0].GetType ().FullName);
				return 1;
			}
			return 0;
		}

		[My ("blah", new string [] { "crash" }, "additional parameter")]
		public void Foo ()
		{
		}
	}

	[AttributeUsage (AttributeTargets.Method)]
	class MyAttribute : Attribute
	{
		public MyAttribute (params object [] arguments)
		{
		}
	}
}
