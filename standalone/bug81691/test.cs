using System;
using System.IO;
using System.Reflection;

class Program
{
	static int Main ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"libb.dll");

		Assembly assembly = Assembly.LoadFile (assemblyFile);
		Type type = assembly.GetType ("NS.B.TestB");
		FieldInfo field =type.GetField ("testb", BindingFlags.NonPublic | BindingFlags.Static);
		if (field.Name != "testb")
			return 1;
		if (field.DeclaringType != type)
			return 2;
		if (field.Attributes != (FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.InitOnly))
			return 3;
		try {
			if (field.FieldType == null)
				return 4;
			return 5;
		} catch (FileNotFoundException ex) {
#if NET_2_0
			if (ex.FileName != "liba, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")
				return 6;
#else
			if (ex.FileName != "liba")
				return 6;
#endif
			if (ex.InnerException != null)
				return 7;
			if (ex.Message == null)
				return 8;
#if NET_2_0
			if (ex.Message.IndexOf ("liba, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null") == -1)
				return 9;
#else
			if (ex.Message.IndexOf ("liba") == -1)
				return 9;
#endif
		}
		return 0;
	}
}
