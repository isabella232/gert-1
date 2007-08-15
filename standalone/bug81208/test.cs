using System;
using System.Reflection;

unsafe class Program
{
	public static void* _field;

	static int Main ()
	{
		string corlib = typeof(int).Assembly.FullName;

		Type t = null;

		t = Type.GetType ("System.Byte*");
		if (t.AssemblyQualifiedName != ("System.Byte*, " + corlib))
			return 1;

		t = Type.GetType ("System.Void*");
		if (t.AssemblyQualifiedName != ("System.Void*, " + corlib))
			return 2;

		t = Type.GetType("System.Int32*");
		if (t.AssemblyQualifiedName != ("System.Int32*, " + corlib))
			return 3;

		Type unsafeType = typeof (Unsafe);
		t = unsafeType.GetField("Src").FieldType;
		if (t.AssemblyQualifiedName != ("System.Byte*, " + corlib))
			return 4;

		t = unsafeType.GetField ("Dest").FieldType;
		if (t.AssemblyQualifiedName != ("System.Void*, " + corlib))
			return 5;

		t = unsafeType.GetField("Copy").FieldType;
		if (t.AssemblyQualifiedName != ("System.Int32*, " + corlib))
			return 6;

		FieldInfo field = typeof (Program).GetField ("_field",
			BindingFlags.Static | BindingFlags.Public);
		t = field.FieldType;
		if (t.AssemblyQualifiedName != ("System.Void*, " + corlib))
			return 7;

		return 0;
	}

	public unsafe class Unsafe
	{
		public byte* Src;
		public void* Dest;
		public int* Copy;
	}
}
