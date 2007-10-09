using System;
using System.Globalization;
using System.Reflection;

class Program
{
	[STAThread]
	static void Main ()
	{
		MethodInfo mi = typeof (Program).GetMethod ("Run");

		ParameterInfo piA = mi.GetParameters () [0];
		ParameterInfo piB = mi.GetParameters () [1];
		ParameterInfo piC = mi.GetParameters () [2];
		ParameterInfo piD = mi.GetParameters () [3];
		ParameterInfo piE = mi.GetParameters () [4];

		Assert.IsFalse (typeof (int).IsAssignableFrom (piA.ParameterType), "#A1");
		Assert.IsFalse (piA.ParameterType.IsAssignableFrom (typeof (int)), "#A2");
		Assert.IsFalse (piB.ParameterType.IsAssignableFrom (piC.ParameterType), "#A3");
		Assert.IsFalse (piC.ParameterType.IsAssignableFrom (piB.ParameterType), "#A4");
		Assert.IsTrue (piD.ParameterType.IsAssignableFrom (piE.ParameterType), "#A5");
		Assert.IsTrue (piE.ParameterType.IsAssignableFrom (piD.ParameterType), "#A6");

#if NET_2_0
		GenericRunner <CultureInfo> runner = new GenericRunner <CultureInfo> ();
		mi = runner.GetType ().GetMethod ("Run");
		piA = mi.GetParameters () [0];
		piB = mi.GetParameters () [1];

		Assert.IsTrue (typeof (object []).IsAssignableFrom (piA.ParameterType), "#B1");
		Assert.IsFalse (piA.ParameterType.IsAssignableFrom (typeof (object [])), "#B2");
		Assert.IsTrue (typeof (object).IsAssignableFrom (piB.ParameterType), "#B3");
		Assert.IsFalse (piB.ParameterType.IsAssignableFrom (typeof (object)), "#B4");
		Assert.IsTrue (typeof (object []).IsAssignableFrom (piA.ParameterType), "#B1");	

		mi = typeof (Runner).GetMethod ("Run");
		piA = mi.GetParameters () [0];
		piB = mi.GetParameters () [1];

		Assert.IsFalse (typeof (object []).IsAssignableFrom (piA.ParameterType), "#C1");
		Assert.IsFalse (piA.ParameterType.IsAssignableFrom (typeof (object [])), "#C2");
		Assert.IsTrue (typeof (object).IsAssignableFrom (piB.ParameterType), "#C3");
		Assert.IsFalse (piB.ParameterType.IsAssignableFrom (typeof (object)), "#C4");
		Assert.IsFalse (typeof (object []).IsAssignableFrom (mi.ReturnType), "#C5");
		Assert.IsFalse (mi.ReturnType.IsAssignableFrom (typeof (object [])), "#C6");
#endif
	}

	public void Run (ref int a, ref object b, ref long c, ref AttributeTargets d, ref PlatformID e)
	{
	}
}

class Assert
{
	public static void IsFalse (bool value, string msg)
	{
		if (value)
			throw new Exception (msg);
	}

	public static void IsTrue (bool value, string msg)
	{
		if (!value)
			throw new Exception (msg);
	}
}

#if NET_2_0
class GenericRunner<T>
{
	public void Run (T [] a, T b)
	{
	}
}

class Runner
{
	public T [] Run<T> (T [] a, T b, object [] c)
	{
		return null;
	}
}
#endif
