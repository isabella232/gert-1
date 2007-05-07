using System;
using System.Reflection;
using System.Runtime.InteropServices;

public class Program
{
	static int Main ()
	{
		MethodInfo dofoo = typeof(TestClass).GetMethod("DoFoo");
		if ((dofoo.GetMethodImplementationFlags() & MethodImplAttributes.PreserveSig) != 0)
			return 0;
		else
			return 1;
	}
}

public class TestClass
{
	[PreserveSig]
	public int DoFoo()
	{
		return 0;
	}
}
