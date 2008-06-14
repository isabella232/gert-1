using System;
using System.ComponentModel;
using System.Reflection;

[assembly: AssemblyTitle ("bug 322332")]
[module: Category ("ModA")]

class Foo
{
	[Category ("A")]
	class Bar
	{
	}
}
