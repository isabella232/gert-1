using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

public class Test
{
	static int Main ()
	{
		string assemblyFileName = Path.Combine (
			AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
			"bug78468.dll");

		AssemblyName assemblyName = new AssemblyName ();
		assemblyName.Name = "bug78468";

		AssemblyBuilder ab = AppDomain.CurrentDomain
			.DefineDynamicAssembly (assemblyName,
			AssemblyBuilderAccess.Save,
			Path.GetDirectoryName (assemblyFileName),
			AppDomain.CurrentDomain.Evidence);
		ab.AddResourceFile ("readme", "test.cs");
		ab.Save (Path.GetFileName (assemblyFileName));

		Assembly assembly;

		using (FileStream fs = File.OpenRead (assemblyFileName)) {
			byte[] buffer = new byte[fs.Length];
			fs.Read (buffer, 0, buffer.Length);
			assembly = Assembly.Load (buffer);
			fs.Close ();
		}

		if (assembly.Location != string.Empty) {
			Console.WriteLine ("Failure #1");
			return 1;
		}

#if NET_2_0
		try {
			assembly.GetManifestResourceStream ("readme");
			Console.WriteLine ("Failure #2");
			return 1;
		} catch (FileNotFoundException) {
		}
#else
		Stream s = assembly.GetManifestResourceStream ("readme");
		if (s != null) {
			Console.WriteLine ("Failure #2");
			return 1;
		}
#endif

		return 0;
	}
}
