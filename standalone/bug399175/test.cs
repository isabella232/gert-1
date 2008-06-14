using System;
using System.IO;
using System.Collections.Generic;
using System.CodeDom.Compiler;

class TestDomProvider
{
	static int Main (string [] args)
	{
		string source = @"
			using System;
			using System.Collections.Generic;

			namespace Temporary
			{
				public class Temporary
				{
					public static IEnumerable<char> func()
					{
						yield return '0';
						yield break;
						foreach (char c in ""1"")
							yield return c;
					}
				}
			}";

		foreach (char c in Temporary.Temporary.func ()) {
			if (c != '0')
				return 1;
		}

		var parameters = new CompilerParameters ();
		parameters.GenerateInMemory = true;
		var results = CodeDomProvider.CreateProvider ("CSharp").CompileAssemblyFromSource (
			parameters, source);
		var compiledType = results.CompiledAssembly.GetType ("Temporary.Temporary");

		foreach (char c in (IEnumerable<char>) compiledType.GetMethod ("func").Invoke (null, new object [0])) {
			if (c != '0')
				return 1;
		}

		return 0;
	}
}

namespace Temporary
{
	public class Temporary
	{
		public static IEnumerable<char> func ()
		{
			yield return '0';
			yield break;
			foreach (char c in "1")
				yield return c;
		}
	}
}
