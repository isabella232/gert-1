using System;
using System.Collections.Generic;
using System.Reflection;

namespace A
{
	public class tester
	{
		const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
		public static int Main ()
		{
			foreach (MethodInfo m in typeof (Type []).GetMethods (flags)) {
				if (m.Name == "System.Collections.Generic.IList`1.IndexOf") {
					int length = m.GetParameters ().Length;
					Console.WriteLine (length);
				}
			}
			return 0;
		}
	}
}

