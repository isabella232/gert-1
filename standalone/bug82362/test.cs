using System;
using System.Reflection;

class Program
{
	public void Run (MethodInfo mi)
	{
		AddConversion (
			delegate (object from) {
				return mi.Invoke (null, new object [] { from });
			});
	}

	void AddConversion (CallTarget converter)
	{
	}
}

public delegate object CallTarget (object arg0);
