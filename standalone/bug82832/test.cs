using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length == 0) {
			Console.Error.WriteLine ("Please specify the action.");
			return 1;
		}

		switch (args [0]) {
		case "create":
			Create1 ();
			Create2 ();
			Create3 ();
			Create4 ();
			Create5 ();
			Create6 ();
			Create7 ();
			break;
		case "verify":
			Verify1 ();
			Verify2 ();
			Verify3 ();
			Verify4 ();
			Verify5 ();
			Verify7 ();
			Verify8 ();
			Verify9 ();
			Verify10 ();
			break;
		default:
			Console.Error.WriteLine ("Unsupported action.");
			return 1;
		}

		return 0;
	}

	static void Create1 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib1";

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		ab.DefineVersionInfoResource ("BBB", "2.0", "CCC", "DDD", "EEE");
		ab.Save ("lib1.dll");
	}

	static void Verify1 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib1.dll");

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
	}

	static void Create2 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib2";

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		ab.DefineVersionInfoResource (null, null, null, null, null);
		ab.Save ("lib2.dll");
	}

	static void Verify2 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib2.dll");

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
	}

	static void Create3 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib3";

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
		ab.Save ("lib3.dll");
	}

	static void Verify3 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib3.dll");

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
	}

	static void Create4 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib4";

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
		ab.Save ("lib4.dll");
	}

	static void Verify4 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib4.dll");

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
	}

	static void Create5 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib5";

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		ab.DefineVersionInfoResource ();
		ab.Save ("lib5.dll");
	}

	static void Verify5 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib5.dll");

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
	}

	static void Create6 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib6";

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
	}

	static void Create7 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib7";

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		// AssemblyVersion
		Type attrType = typeof (AssemblyVersionAttribute);
		ConstructorInfo ci = attrType.GetConstructor (new Type [] { typeof (String) });
		CustomAttributeBuilder cab = new CustomAttributeBuilder (ci, new object [1] { "1.2.3.4" });
		ab.SetCustomAttribute (cab);

		ab.DefineVersionInfoResource ();
		ab.Save ("lib7.dll");
	}

	static void Verify7 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib7.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.CompanyName, "#G1");
		Assert.AreEqual (" ", fvi.ProductName, "#G2");
		Assert.AreEqual (" ", fvi.ProductVersion, "#G3");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#G4");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#G5");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#G6");
		Assert.AreEqual (0, fvi.FileBuildPart, "#G7");
		Assert.AreEqual (0, fvi.FileMajorPart, "#G8");
		Assert.AreEqual (0, fvi.FileMinorPart, "#G9");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#G10");
	}

	static void Verify8 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib8a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("Mono Team", fvi.CompanyName, "#H1a");
		Assert.AreEqual ("Mono Runtime", fvi.ProductName, "#H2a");
		Assert.AreEqual ("4,2,1,7", fvi.ProductVersion, "#H3a");
		Assert.AreEqual ("Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#H4a");
		Assert.AreEqual ("Registered to All", fvi.LegalTrademarks, "#H5a");
		Assert.AreEqual ("1.2.3.4", fvi.FileVersion, "#H6a");
		Assert.AreEqual (6, fvi.FileBuildPart, "#H7a");
		Assert.AreEqual (2, fvi.FileMajorPart, "#H8a");
		Assert.AreEqual (4, fvi.FileMinorPart, "#H9a");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#H10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib8b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("Mono Team", fvi.CompanyName, "#H1b");
		Assert.AreEqual ("Mono Runtime", fvi.ProductName, "#H2b");
		Assert.AreEqual ("4,2,1,7", fvi.ProductVersion, "#H3b");
		Assert.AreEqual ("Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#H4b");
		Assert.AreEqual ("Registered to All", fvi.LegalTrademarks, "#H5b");
		Assert.AreEqual ("1.2.3.4", fvi.FileVersion, "#H6b");
		Assert.AreEqual (6, fvi.FileBuildPart, "#H7b");
		Assert.AreEqual (2, fvi.FileMajorPart, "#H8b");
		Assert.AreEqual (4, fvi.FileMinorPart, "#H9b");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#H10b");
	}

	static void Verify9 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib9a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("", fvi.CompanyName, "#I1a");
		Assert.AreEqual ("", fvi.ProductName, "#I2a");
		Assert.AreEqual ("", fvi.ProductVersion, "#I3a");
		Assert.AreEqual ("", fvi.LegalCopyright, "#I4a");
		Assert.AreEqual ("", fvi.LegalTrademarks, "#I5a");
		Assert.AreEqual ("", fvi.FileVersion, "#I6a");
		Assert.AreEqual (6, fvi.FileBuildPart, "#I7a");
		Assert.AreEqual (2, fvi.FileMajorPart, "#I8a");
		Assert.AreEqual (4, fvi.FileMinorPart, "#I9a");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#I10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib9b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("", fvi.CompanyName, "#I1b");
		Assert.AreEqual ("", fvi.ProductName, "#I2b");
		Assert.AreEqual ("", fvi.ProductVersion, "#I3b");
		Assert.AreEqual ("", fvi.LegalCopyright, "#I4b");
		Assert.AreEqual ("", fvi.LegalTrademarks, "#I5b");
		Assert.AreEqual ("", fvi.FileVersion, "#I6b");
		Assert.AreEqual (6, fvi.FileBuildPart, "#I7b");
		Assert.AreEqual (2, fvi.FileMajorPart, "#I8b");
		Assert.AreEqual (4, fvi.FileMinorPart, "#I9b");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#I10b");
	}

	static void Verify10 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib10a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("", fvi.CompanyName, "#J1a");
		Assert.AreEqual ("", fvi.ProductName, "#J2a");
		Assert.AreEqual ("", fvi.ProductVersion, "#J3a");
		Assert.AreEqual ("", fvi.LegalCopyright, "#J4a");
		Assert.AreEqual ("", fvi.LegalTrademarks, "#J5a");
		Assert.AreEqual ("", fvi.FileVersion, "#J6a");
		Assert.AreEqual (6, fvi.FileBuildPart, "#J7a");
		Assert.AreEqual (2, fvi.FileMajorPart, "#J8a");
		Assert.AreEqual (4, fvi.FileMinorPart, "#J9a");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#J10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib10b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("", fvi.CompanyName, "#J1b");
		Assert.AreEqual ("", fvi.ProductName, "#J2b");
		Assert.AreEqual ("", fvi.ProductVersion, "#J3b");
		Assert.AreEqual ("", fvi.LegalCopyright, "#J4b");
		Assert.AreEqual ("", fvi.LegalTrademarks, "#J5b");
		Assert.AreEqual ("", fvi.FileVersion, "#J6b");
		Assert.AreEqual (6, fvi.FileBuildPart, "#J7b");
		Assert.AreEqual (2, fvi.FileMajorPart, "#J8b");
		Assert.AreEqual (4, fvi.FileMinorPart, "#J9b");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#J10b");
	}
}
