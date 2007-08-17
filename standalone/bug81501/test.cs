using System;
using System.Reflection;

abstract class Base
{
}

class Program : Base
{
	static void Main (string [] args)
	{
		object obj = System.Runtime.Serialization.FormatterServices.GetUninitializedObject
			(typeof (Program));
		typeof (Base).GetConstructor (BindingFlags.Instance | BindingFlags.NonPublic, 
			null, Type.EmptyTypes, null).Invoke (obj, new object [0]);
	}
}
