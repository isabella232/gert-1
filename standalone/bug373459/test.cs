using System;
using System.Reflection;

class Test
{
	static void Main ()
	{
		ConstructorInfo ci = typeof (Gen<>).GetConstructor (Type.EmptyTypes);
		try {
			ci.Invoke (null);
			Assert.Fail ("#1");
		} catch (MemberAccessException ex) {
			Assert.AreEqual (typeof (MemberAccessException), ex.GetType (), "#2");
			Assert.IsNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.Message, "#4");
			Assert.IsTrue (ex.Message.IndexOf ("Type.ContainsGenericParameters") != -1, "#5");
		}
	}
}

public class Gen<T>
{
	T t;
	public Gen ()
	{
		t = default (T);
		if (t == null) {
		}
	}
}
