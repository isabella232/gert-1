using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

public class Test
{
	public static void Main ()
	{
		CompilerParameters options = new CompilerParameters ();
		options.WarningLevel = 4;

		CodeDomProvider provider = new CSharpCodeProvider ();
#if NET_2_0
		CompilerResults result = provider.CompileAssemblyFromDom (
			options, new CodeSnippetCompileUnit (src));
#else
		ICodeCompiler compiler = provider.CreateCompiler ();
		CompilerResults result = compiler.CompileAssemblyFromDom (
			options, new CodeSnippetCompileUnit (src));
#endif

		Assert.IsFalse (result.Errors.HasErrors, "#1");
#if ONLY_1_0
		Assert.IsFalse (result.Errors.HasWarnings, "#2");
		Assert.AreEqual (0, result.Errors.Count, "#3");
#else
		Assert.IsTrue (result.Errors.HasWarnings, "#2");
#if MONO
		Assert.AreEqual (2, result.Errors.Count, "#3");
		Assert.AreEqual ("CS0108", result.Errors [0].ErrorNumber, "#4");
		Assert.IsTrue (result.Errors [0].IsWarning, "#5");
		Assert.AreEqual ("CS0169", result.Errors [1].ErrorNumber, "#6");
		Assert.IsTrue (result.Errors [1].IsWarning, "#7");
#else
		Assert.AreEqual (1, result.Errors.Count, "#3");
		Assert.AreEqual ("CS0108", result.Errors [0].ErrorNumber, "#4");
		Assert.IsTrue (result.Errors [0].IsWarning, "#5");
#endif
#endif
	}

	static string src = @"
		public class Foo
		{
			static void Main ()
			{
			}

			public void X ()
			{
			}
		}

		public class Bar : Foo
		{
			public int X ()
			{
				return 0;
			}
		}";
}
