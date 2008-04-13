using System.CodeDom.Compiler;

using Microsoft.CSharp;

class Program
{
	static void Main ()
	{
		const string source = @"
			public class Scriptefaa4ad0a85c49519cad6a19fbb93caf
			{
				string PadRight (string str, int padding)
				{
					return str.PadRight(padding);
				}
			}";

		CompilerParameters parameters = new CompilerParameters ();
		parameters.GenerateInMemory = true;

		CodeDomProvider provider = new CSharpCodeProvider ();
#if NET_2_0
		CompilerResults results = provider.CompileAssemblyFromSource (
			parameters, source);
#else
		ICodeCompiler compiler = provider.CreateCompiler ();
		CompilerResults results = compiler.CompileAssemblyFromSource (
			parameters, source);
#endif

		Assert.AreEqual (1, results.Errors.Count, "#1");
		Assert.IsFalse (results.Errors.HasErrors, "#2");
		Assert.IsTrue (results.Errors.HasWarnings, "#3");

		foreach (CompilerError error in results.Errors)
			Assert.IsTrue (error.IsWarning, "#4");

		Assert.IsNotNull (results.CompiledAssembly, "#5");
	}
}
