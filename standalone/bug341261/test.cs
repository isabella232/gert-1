using System;
using System.Reflection;

class Program
{
	static int Main ()
	{
		string [] s = new string [] { "hello", "world" };
		string result = (string) s.GetType ().InvokeMember ("Get", 
			BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.InvokeMethod, null, s, new object [] { 0 });
		if (result != s [0])
			return 1;
		return 0;
	}
}
