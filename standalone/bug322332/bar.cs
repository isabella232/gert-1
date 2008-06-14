using System;
using System.ComponentModel;
using System.Reflection;

[assembly: AssemblyFileVersion ("2.0")]
[module: Category ("ModB")]

class Bar
{
	[Category ("B")]
	class Foo
	{
	}
}
