using System;

public class Program
{
	static int Main ()
	{
		System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom ("lib.dll");
		Console.WriteLine ("assembly loaded");
		Type type = asm.GetType ("NS.TestClass", true);
		Console.WriteLine ("got type 'NS.TestClass'");

		System.Reflection.FieldInfo field = type.GetField ("TestField");
		Console.WriteLine ("about to get value of 'TestField'");
		Console.WriteLine ("got field 'TestField'");
		int val = (int) field.GetValue (null);
		Console.WriteLine ("Value of field: " + val);
#if NET_2_0
		if (val == 1)
			return 0;
#else
		if (val == 0)
			return 0;
#endif
		return 1;
	}
}
