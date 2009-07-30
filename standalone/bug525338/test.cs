using System;
using System.Reflection;

public class Program
{
	static void Main ()
	{
		Type gType = typeof (Generic2<MyBase>).GetGenericTypeDefinition ();
		Type typeArg = gType.GetGenericArguments () [0];
		FieldInfo fi = typeArg.GetDefaultMembers () [0] as FieldInfo;
		Assert.IsNotNull (fi, "#1");
		Assert.AreEqual ("flag", fi.Name, "#2");
		Assert.AreEqual (typeof (bool), fi.FieldType, "#3");
	}
}

[DefaultMemberAttribute ("flag")]
public class MyBase
{
	public bool flag;
}

public class Generic2<T> where T : MyBase
{
}
