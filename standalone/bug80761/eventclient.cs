using System;
using System.Reflection;

class Program
{
	static void Main()
	{
		string service = "tcp://localhost:5000/";
		ITest test = (ITest) Activator.GetObject (typeof (ITest), service + "Test");
		test.Test (DateTime.Now);
		test.TestEvent += new EventHandler (TestHandler);
		test.TestEvent += new EventHandler (TestHandler);
		test.Info = typeof (Program).GetMethod("Foo")
			.MakeGenericMethod (new Type[] {typeof (int)});
		test.Raise();
	}

	public static void Foo<T>()
	{
	}

	public static void TestHandler (object sender, EventArgs eventArgs)
	{
	}
}
