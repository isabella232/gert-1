using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static void Main ()
	{
		Test1 ();
		Test2 ();
		Test3 ();
		Test4 ();
		Test5 ();
		Test6 ();
	}

	static void Test1 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib";

		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib.dll");

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		ab.DefineVersionInfoResource ("BBB", "2.0", "CCC", "DDD", "EEE");
		ab.Save ("lib.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("CCC", fvi.CompanyName, "#A1");
		Assert.AreEqual ("BBB", fvi.ProductName, "#A2");
		Assert.AreEqual ("2.0", fvi.ProductVersion, "#A3");
		Assert.AreEqual ("DDD", fvi.LegalCopyright, "#A4");
		Assert.AreEqual ("EEE", fvi.LegalTrademarks, "#A5");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#A6");
		Assert.AreEqual (0, fvi.FileBuildPart, "#A7");
		Assert.AreEqual (0, fvi.FileMajorPart, "#A8");
		Assert.AreEqual (0, fvi.FileMinorPart, "#A9");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#A10");

		File.Delete (assemblyFile);
	}

	static void Test2 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib";

		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib.dll");

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		ab.DefineVersionInfoResource (null, null, null, null, null);
		ab.Save ("lib.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.IsNotNull (fvi.CompanyName, "#B1");
		Assert.AreEqual (" ", fvi.CompanyName, "#B2");
		Assert.IsNotNull (fvi.ProductName, "#B3");
		Assert.AreEqual (" ", fvi.ProductName, "#B4");
		Assert.IsNotNull (fvi.ProductVersion, "#B5");
		Assert.AreEqual (" ", fvi.ProductVersion, "#B6");
		Assert.IsNotNull (fvi.LegalCopyright, "#B7");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#B8");
		Assert.IsNotNull (fvi.LegalTrademarks, "#B9");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#B10");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#B11");
		Assert.AreEqual (0, fvi.FileBuildPart, "#B12");
		Assert.AreEqual (0, fvi.FileMajorPart, "#B13");
		Assert.AreEqual (0, fvi.FileMinorPart, "#B14");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#B15");

		File.Delete (assemblyFile);
	}

	static void Test3 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib";

		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib.dll");

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		// CompanyName
		Type attrType = typeof (AssemblyCompanyAttribute);
		ConstructorInfo ci = attrType.GetConstructor (
			new Type [] { typeof (String) });
		CustomAttributeBuilder cab =
			new CustomAttributeBuilder (ci, new object [1] { "Mono Team" });
		ab.SetCustomAttribute (cab);

		// ProductName
		attrType = typeof (AssemblyProductAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "Mono Runtime" });
		ab.SetCustomAttribute (cab);

		// LegalCopyright
		attrType = typeof (AssemblyCopyrightAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "Copyright 2007 Mono Hackers" });
		ab.SetCustomAttribute (cab);


		// LegalTrademarks
		attrType = typeof (AssemblyTrademarkAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "Registered to All" });
		ab.SetCustomAttribute (cab);

		// AssemblyVersion
		attrType = typeof (AssemblyVersionAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "1.2.3.4" });
		ab.SetCustomAttribute (cab);

		// AssemblyFileVersion
		attrType = typeof (AssemblyFileVersionAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "2.4.6.8" });
		ab.SetCustomAttribute (cab);

		ab.DefineVersionInfoResource ();
		ab.Save ("lib.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("Mono Team", fvi.CompanyName, "#C1");
		Assert.AreEqual ("Mono Runtime", fvi.ProductName, "#C2");
		Assert.AreEqual (" ", fvi.ProductVersion, "#C3");
		Assert.AreEqual ("Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#C4");
		Assert.AreEqual ("Registered to All", fvi.LegalTrademarks, "#C5");
		Assert.AreEqual ("2.4.6.8", fvi.FileVersion, "#C6");
		Assert.AreEqual (6, fvi.FileBuildPart, "#C7");
		Assert.AreEqual (2, fvi.FileMajorPart, "#C8");
		Assert.AreEqual (4, fvi.FileMinorPart, "#C9");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#C10");

		File.Delete (assemblyFile);
	}

	static void Test4 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib";

		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib.dll");

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		// CompanyName
		Type attrType = typeof (AssemblyCompanyAttribute);
		ConstructorInfo ci = attrType.GetConstructor (
			new Type [] { typeof (String) });
		CustomAttributeBuilder cab =
			new CustomAttributeBuilder (ci, new object [1] { "Mono Team" });
		ab.SetCustomAttribute (cab);

		// ProductName
		attrType = typeof (AssemblyProductAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "Mono Runtime" });
		ab.SetCustomAttribute (cab);

		// LegalCopyright
		attrType = typeof (AssemblyCopyrightAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "Copyright 2007 Mono Hackers" });
		ab.SetCustomAttribute (cab);


		// LegalTrademarks
		attrType = typeof (AssemblyTrademarkAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "Registered to All" });
		ab.SetCustomAttribute (cab);

		// AssemblyVersion
		attrType = typeof (AssemblyVersionAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "1.2.3.4" });
		ab.SetCustomAttribute (cab);

		// AssemblyFileVersion
		attrType = typeof (AssemblyFileVersionAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "2.4.6.8" });
		ab.SetCustomAttribute (cab);

		ab.DefineVersionInfoResource ("AAA", "2.0", "BBB", "CCC", "DDD");
		ab.Save ("lib.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("BBB", fvi.CompanyName, "#D1");
		Assert.AreEqual ("AAA", fvi.ProductName, "#D2");
		Assert.AreEqual ("2.0", fvi.ProductVersion, "#D3");
		Assert.AreEqual ("CCC", fvi.LegalCopyright, "#D4");
		Assert.AreEqual ("DDD", fvi.LegalTrademarks, "#D5");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#D6");
		Assert.AreEqual (0, fvi.FileBuildPart, "#D7");
		Assert.AreEqual (0, fvi.FileMajorPart, "#D8");
		Assert.AreEqual (0, fvi.FileMinorPart, "#D9");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#D10");

		File.Delete (assemblyFile);
	}

	static void Test5 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib";

		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib.dll");

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		ab.DefineVersionInfoResource ();
		ab.Save ("lib.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.IsNotNull (fvi.CompanyName, "#E1");
		Assert.AreEqual (" ", fvi.CompanyName, "#E2");
		Assert.IsNotNull (fvi.ProductName, "#E3");
		Assert.AreEqual (" ", fvi.ProductName, "#E4");
		Assert.IsNotNull (fvi.ProductVersion, "#E5");
		Assert.AreEqual (" ", fvi.ProductVersion, "#E6");
		Assert.IsNotNull (fvi.LegalCopyright, "#E7");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#E8");
		Assert.IsNotNull (fvi.LegalTrademarks, "#E9");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#E10");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#E11");
		Assert.AreEqual (0, fvi.FileBuildPart, "#E12");
		Assert.AreEqual (0, fvi.FileMajorPart, "#E13");
		Assert.AreEqual (0, fvi.FileMinorPart, "#E14");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#E15");

		File.Delete (assemblyFile);
	}

	static void Test6 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib";

		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib.dll");

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		ab.DefineVersionInfoResource ();
		try {
			ab.DefineVersionInfoResource ();
			Assert.Fail ("#F1");
		} catch (ArgumentException ex) {
			// Native resource has already been defined
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#F2");
			Assert.IsNull (ex.InnerException, "#F3");
			Assert.IsNotNull (ex.Message, "#F4");
			Assert.IsNull (ex.ParamName, "#F4");
		}

		File.Delete (assemblyFile);
	}
}
