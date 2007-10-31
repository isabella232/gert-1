using System;
using System.Reflection;

public interface ITest
{
	void Raise();
	event EventHandler TestEvent;
	MethodInfo Info { get; set; }
	void Test (DateTime d);
}
