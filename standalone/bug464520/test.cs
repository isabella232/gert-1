using System;
using System.Reflection;
using System.Reflection.Emit;

public class Program
{
	static int Main ()
	{
		try {
			ILTest ();
			return 1;
		} catch (Exception e) {
			Assert.AreEqual ("SomeImportantMessage", e.Message, "Message");
			return 0;
		}
	}

	public static void ILTest ()
	{
		ConstructorInfo constructor = typeof (ClassWithThrowingConstructor).GetConstructor (Type.EmptyTypes);
		DynamicMethod dm = new DynamicMethod (String.Empty, typeof (object), new Type [] { typeof (object []) });

		ILGenerator il = dm.GetILGenerator ();
		il.Emit (OpCodes.Newobj, constructor);
		il.Emit (OpCodes.Ret);

		MyDelegate md = dm.CreateDelegate (typeof (MyDelegate)) as MyDelegate;
		md.Invoke (new object [0]);
	}

	public delegate object MyDelegate (params object [] arguments);

	public class ClassWithThrowingConstructor
	{
		public ClassWithThrowingConstructor ()
		{
			throw new Exception ("SomeImportantMessage");
		}
	}
}

