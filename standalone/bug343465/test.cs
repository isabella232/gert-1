using System;
using System.Reflection;

namespace Mono
{
	class Program
	{
		static void Main ()
		{
			Type t = typeof (Foo);
			Type [] interfaces = t.GetInterfaces ();
			Assert.AreEqual (1, interfaces.Length, "#A1");
			Assert.AreEqual ("Mono.Bar+IMarshal", interfaces [0].FullName, "#A2");

			MethodInfo [] methods = t.GetMethods (BindingFlags.DeclaredOnly |
				BindingFlags.NonPublic | BindingFlags.Public |
				BindingFlags.Instance);

			Assert.AreEqual (1, methods.Length, "#B1");
#if ONLY_1_1
			Assert.AreEqual ("Mono.Bar+IMarshal.Release", methods [0].Name, "#B2");
#else
			Assert.AreEqual ("Mono.Bar.IMarshal.Release", methods [0].Name, "#B2");
#endif
		}
	}

	class Foo : Bar.IMarshal
	{
		void Bar.IMarshal.Release ()
		{
		}
	}

	class Bar
	{
		public interface IMarshal
		{
			void Release ();
		}
	}
}
