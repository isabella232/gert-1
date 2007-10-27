using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

class Program
{
	static int Main ()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		ResourceManager rm;
		Assembly assembly = Assembly.GetExecutingAssembly ();

#if ONLY_1_1
		const string baseNameErrorMsg = "ResourceManager base name " +
			"should not end in .resources. It should be similar " +
			"to MyResources, which the ResourceManager can convert " +
			"into MyResources.<culture>.resources; for example, " +
			"MyResources.en-US.resources.";
#endif

		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

		rm = new ResourceManager ("MyComponent.resources", assembly);
		Assert.AreEqual ("Mono Component", rm.GetString ("$this.name"), "#A");

#if NET_2_0
		rm = new ResourceManager ("OtherComponent.resources", assembly);
		try {
			rm.GetObject ("$this.name");
			Assert.Fail ("#B1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingInAssembly (
				"OtherComponent.resources", assembly);
			Assert.AreEqual (expected, ex.Message, "#B2");
		}
#else
		try {
			new ResourceManager ("OtherComponent.resources", assembly);
			Assert.Fail ("#B1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
			Assert.AreEqual (baseNameErrorMsg, ex.Message, "#B5");
			Assert.IsNull (ex.ParamName, "#B6");
		}
#endif

		rm = new ResourceManager (".resources", assembly);
		try {
			rm.GetObject ("$this.name");
			Assert.Fail ("#C1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingInAssembly (
				".resources", assembly);
			Assert.AreEqual (expected, ex.Message, "#C2");
		}

		rm = ResourceManager.CreateFileBasedResourceManager ("FileComponentA",
			AppDomain.CurrentDomain.BaseDirectory, typeof (ResourceSet));
		Assert.AreEqual ("Mono Component", rm.GetString ("$this.name"), "#D");

		rm = ResourceManager.CreateFileBasedResourceManager ("FileComponentB.resources",
			AppDomain.CurrentDomain.BaseDirectory, typeof (ResourceSet));
		Assert.AreEqual ("Mono Component", rm.GetString ("$this.name"), "#E");

		rm = ResourceManager.CreateFileBasedResourceManager ("FileComponentB.ResOurces",
			AppDomain.CurrentDomain.BaseDirectory, typeof (ResourceSet));
		Assert.AreEqual ("Mono Component", rm.GetString ("$this.name"), "#F");

		rm = ResourceManager.CreateFileBasedResourceManager ("FileComponentB",
			AppDomain.CurrentDomain.BaseDirectory, typeof (ResourceSet));
		try {
			rm.GetString ("$this.name");
			Assert.Fail ("#G1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingOnDisk (
				"FileComponentB");
			Assert.AreEqual (expected, ex.Message, "#G2");
		}

#if NET_2_0
		rm = ResourceManager.CreateFileBasedResourceManager (
			"FileComponentB.resources.resources",
			AppDomain.CurrentDomain.BaseDirectory,
			typeof (ResourceSet));
		try {
			rm.GetString ("$this.name");
			Assert.Fail ("#H1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingOnDisk (
				"FileComponentB.resources.resources");
			Assert.AreEqual (expected, ex.Message, "#H2");
		}
#else
		try {
			ResourceManager.CreateFileBasedResourceManager (
				"FileComponentB.resources.resources",
				AppDomain.CurrentDomain.BaseDirectory,
				typeof (ResourceSet));
			Assert.Fail ("#I1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#I2");
			Assert.IsNull (ex.InnerException, "#I3");
			Assert.IsNotNull (ex.Message, "#I4");
			Assert.AreEqual (baseNameErrorMsg, ex.Message, "#I5");
			Assert.IsNull (ex.ParamName, "#I6");
		}
#endif

#if NET_2_0
		rm = ResourceManager.CreateFileBasedResourceManager (
			"FileComponentA.resources",
			AppDomain.CurrentDomain.BaseDirectory,
			typeof (ResourceSet));
		try {
			rm.GetString ("$this.name");
			Assert.Fail ("#J1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingOnDisk (
				"FileComponentA.resources");
			Assert.AreEqual (expected, ex.Message, "#J2");
		}
#else
		try {
			ResourceManager.CreateFileBasedResourceManager (
				"FileComponentA.resources",
				AppDomain.CurrentDomain.BaseDirectory,
				typeof (ResourceSet));
			Assert.Fail ("#K1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#K2");
			Assert.IsNull (ex.InnerException, "#K3");
			Assert.IsNotNull (ex.Message, "#K4");
			Assert.AreEqual (baseNameErrorMsg, ex.Message, "#K5");
			Assert.IsNull (ex.ParamName, "#K6");
		}
#endif

		rm = ResourceManager.CreateFileBasedResourceManager (
			".resources",
			AppDomain.CurrentDomain.BaseDirectory,
			typeof (ResourceSet));
		try {
			rm.GetString ("$this.name");
			Assert.Fail ("#L1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingOnDisk (
				".resources");
			Assert.AreEqual (expected, ex.Message, "#J2");
		}

		rm = new ResourceManager (typeof (Mono.ResourceTest));
		try {
			rm.GetString ("$this.name");
			Assert.Fail ("#M1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingInAssembly (
				typeof (Mono.ResourceTest));
			Assert.AreEqual (expected, ex.Message, "#M2");
		}

#if NET_2_0
		rm = ResourceManager.CreateFileBasedResourceManager (
			"DoesNotExist",
			AppDomain.CurrentDomain.BaseDirectory,
			typeof (ResourceSet));
		try {
			rm.GetStream ("$this.name");
			Assert.Fail ("#N1");
		} catch (MissingManifestResourceException ex) {
			string expected = CreateMissingOnDisk (
				"DoesNotExist");
			Assert.AreEqual (expected, ex.Message, "#N2");
		}
#endif

		return 0;
	}

	static string CreateMissingOnDisk (string baseName)
	{
		return string.Format ("Could not find any " +
			"resources appropriate for the specified culture " +
			"(or the neutral culture) on disk.{0}" +
			"baseName: {1}  locationInfo: {2}  fileName: {3}",
			Environment.NewLine, baseName, "<null>",
			baseName + ".resources");
	}

	static string CreateMissingInAssembly (string baseName, Assembly assembly)
	{
#if NET_2_0
		return string.Format ("Could not find any resources " +
			"appropriate for the specified culture or the " +
			"neutral culture.  Make sure \"{0}\" was correctly " +
			"embedded or linked into assembly \"{1}\" at " +
			"compile time, or that all the satellite assemblies " +
			"required are loadable and fully signed.",
			baseName + ".resources", assembly.GetName ().Name);
#else
		return string.Format ("Could not find any resources " +
			"appropriate for the specified culture (or the " +
			"neutral culture) in the given assembly.  Make " +
			"sure \"{0}\" was correctly embedded or linked " +
			"into assembly \"{1}\".{2}" +
			"baseName: {3}  locationInfo: {4}  resource file " +
			"name: {0}  assembly: {5}", baseName + ".resources",
			assembly.GetName ().Name, Environment.NewLine,
			baseName, "<null>", assembly.FullName);
#endif
	}

	static string CreateMissingInAssembly (Type resourceSource)
	{
#if NET_2_0
		return string.Format ("Could not find any resources " +
			"appropriate for the specified culture or the " +
			"neutral culture.  Make sure \"{0}\" was correctly " +
			"embedded or linked into assembly \"{1}\" at " +
			"compile time, or that all the satellite assemblies " +
			"required are loadable and fully signed.",
			resourceSource.FullName + ".resources",
			resourceSource.Assembly.GetName ().Name);
#else
		return string.Format ("Could not find any resources " +
			"appropriate for the specified culture (or the " +
			"neutral culture) in the given assembly.  Make " +
			"sure \"{0}\" was correctly embedded or linked " +
			"into assembly \"{1}\".{2}" +
			"baseName: {3}  locationInfo: {4}  resource file " +
			"name: {0}  assembly: {5}", resourceSource.Name + ".resources",
			resourceSource.Assembly.GetName ().Name, Environment.NewLine,
			resourceSource.Name, resourceSource.FullName,
			resourceSource.Assembly.FullName);
#endif
	}
}

namespace Mono
{
	class ResourceTest
	{
	}
}
