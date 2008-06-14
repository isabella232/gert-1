using System;
using System.IO;
using System.Reflection;

using NUnit.Framework;

[TestFixture]
public class AssemblyTest
{
	static void Load (string file)
	{
		Assembly a = Assembly.LoadFile (file);
		a.GetExportedTypes ();
	}

	[Test]
	public void AssemblyLoad_Test ()
	{
		string corlib = typeof (int).Assembly.Location;

		string assembly_dir = Path.GetDirectoryName (corlib);
		foreach (string file in assemblies) {
			string assembly_file = Path.Combine (assembly_dir, file);
			if (!File.Exists (assembly_file))
				continue;
			Load (assembly_file);
		}

		try {
			string base_dir = AppDomain.CurrentDomain.BaseDirectory;
			Load (Path.Combine (base_dir, "nunit_Reflection.dll"));
			Assert.Fail ("#1");
		} catch (FileNotFoundException) {
		}
	}

	static string [] assemblies = {
		"Accessibility.dll",
		"cscompmgd.dll",
		"CustomMarshalers.dll",
		"Microsoft.JScript.dll",
		"Microsoft.VisualC.dll",
		"Microsoft.Vsa.dll",
		"mscorlib.dll",
		"System.Configuration.Install.dll",
		"System.Data.dll",
		"System.Data.OracleClient.dll",
		"System.Design.dll",
		"System.DirectoryServices.dll",
		"System.dll",
		"System.Drawing.Design.dll",
		"System.Drawing.dll",
		"System.EnterpriseServices.dll",
		"System.Management.dll",
		"System.Messaging.dll",
		"System.Runtime.Remoting.dll",
		"System.Runtime.Serialization.dll",
		"System.Security.dll",
		"System.ServiceProcess.dll",
		"System.Web.dll",
		"System.Web.Services.dll",
		"System.Windows.Forms.dll",
		"System.Xml.dll" };
}

