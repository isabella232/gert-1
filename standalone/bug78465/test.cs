using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

public class Test
{
	static int Main ()
	{
		string assemblyFileName = Path.Combine (
			AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
			"bug78465.dll");

		AssemblyName assemblyName = new AssemblyName ();
		assemblyName.Name = "bug78465";

		AssemblyBuilder ab = AppDomain.CurrentDomain
			.DefineDynamicAssembly (assemblyName,
			AssemblyBuilderAccess.Save,
			Path.GetDirectoryName (assemblyFileName),
			AppDomain.CurrentDomain.Evidence);
		ab.Save (Path.GetFileName (assemblyFileName));

		using (FileStream fs = File.OpenRead (assemblyFileName)) {
			byte[] buffer = new byte[fs.Length];
			fs.Read (buffer, 0, buffer.Length);
			Assembly assembly = Assembly.Load (buffer);
			if (assembly.Location != string.Empty) {
				Console.WriteLine ("Failure #1");
				return 1;
			}
			fs.Close ();
		}

		AppDomain testDomain = AppDomain.CreateDomain ("bug78465", 
			AppDomain.CurrentDomain.Evidence, 
			AppDomain.CurrentDomain.SetupInformation);

		try {
			Type testerType = typeof (CrossDomainTester);
			CrossDomainTester tester = (CrossDomainTester) testDomain.CreateInstanceAndUnwrap (
				testerType.Assembly.FullName, testerType.FullName, false,
				BindingFlags.Public | BindingFlags.Instance, null, new object[0],
				CultureInfo.InvariantCulture, new object[0], testDomain.Evidence);
			if (!tester.Test (assemblyFileName)) {
				return 1;
			}
		} finally {
			AppDomain.Unload (testDomain);
			File.Delete (assemblyFileName);
		}
		return 0;
	}

	private class CrossDomainTester : MarshalByRefObject
	{
		public bool Test (string assemblyFileName)
		{
			Assembly assembly = Assembly.LoadFrom (assemblyFileName, AppDomain.CurrentDomain.Evidence);
			if (assembly.Location == string.Empty) {
				Console.WriteLine ("Failure #2");
				return false;
			}
			if (Path.GetFileName (assemblyFileName) != Path.GetFileName (assembly.Location)) {
				Console.WriteLine ("Failure #3: expected '{0}', but was '{1}'.",
					Path.GetFileName (assemblyFileName), Path.GetFileName (assembly.Location));
				return false;
			}
			if (Path.GetDirectoryName (assembly.Location) == string.Empty) {
				Console.WriteLine ("Failure #4");
				return false;
			}
			return true;
		}
	}
}
