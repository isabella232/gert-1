using System;
using System.Reflection;

namespace Mono.Test
{
	class Program
	{
		static void Main ()
		{
			MethodInfo m;
			int index;

			Type t = typeof (B);
			InterfaceMapping map = t.GetInterfaceMap (typeof (ITest));

			m = t.GetMethod ("get_Success", BindingFlags.Public | BindingFlags.Instance);
			Assert.IsNotNull (m, "#A1");
			index = Array.IndexOf (map.TargetMethods, m);
			Assert.IsTrue (index != -1, "#A2");
			Assert.AreEqual ("get_Success", m.Name, "#A3");

			m = t.GetMethod ("Run", BindingFlags.Public | BindingFlags.Instance);
			Assert.IsNotNull (m, "#B1");
			index = Array.IndexOf (map.TargetMethods, m);
			Assert.IsTrue (index != -1, "#B2");
			Assert.AreEqual ("Run", m.Name, "#B3");

			m = t.GetMethod ("get_Success", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
			Assert.IsNull (m, "#C1");
			m = t.GetMethod ("Run", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
			Assert.IsNull (m, "#C2");
		}
	}

	public interface ITest
	{
		bool Success {
			get;
		}

		void Run ();
	}

	public class A
	{
		public bool Success {
			get { return true; }
		}

		public void Run ()
		{
		}
	}

	public class B : A, ITest
	{
	}
}
