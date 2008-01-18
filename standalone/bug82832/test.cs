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
			Create4a ();
			Create4b ();
			Create5 ();
			Create6 ();
			Create7 ();
			Create12a ();
			Create12b ();
			Create13a ();
			Create13b ();
			Create14a ();
			Create14b ();
			Create15a ();
			Create15b ();
			Create16a ();
			Create16b ();
			Create16c ();
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
			Verify11 ();
			Verify12 ();
			Verify13 ();
			Verify14 ();
			Verify15 ();
			Verify16 ();
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
		aname.Version = new Version (3, 5, 7, 9);

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

	static void Create4a ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib4a";

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
		ab.Save ("lib4a.dll");
	}

	static void Create4b ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib4b";
		aname.Version = new Version (3, 5, 7, 9);

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
		ab.Save ("lib4b.dll");
	}

	static void Verify4 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib4a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("BBB", fvi.CompanyName, "#D1a");
		Assert.AreEqual ("AAA", fvi.ProductName, "#D2a");
		Assert.AreEqual ("2.0", fvi.ProductVersion, "#D3a");
		Assert.AreEqual ("CCC", fvi.LegalCopyright, "#D4a");
		Assert.AreEqual ("DDD", fvi.LegalTrademarks, "#D5a");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#D6a");
		Assert.AreEqual (0, fvi.FileBuildPart, "#D7a");
		Assert.AreEqual (0, fvi.FileMajorPart, "#D8a");
		Assert.AreEqual (0, fvi.FileMinorPart, "#D9a");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#D10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib4b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("BBB", fvi.CompanyName, "#D1b");
		Assert.AreEqual ("AAA", fvi.ProductName, "#D2b");
		Assert.AreEqual ("2.0", fvi.ProductVersion, "#D3b");
		Assert.AreEqual ("CCC", fvi.LegalCopyright, "#D4b");
		Assert.AreEqual ("DDD", fvi.LegalTrademarks, "#D5b");
		Assert.AreEqual ("3.5.7.9", fvi.FileVersion, "#D6b");
		Assert.AreEqual (7, fvi.FileBuildPart, "#D7b");
		Assert.AreEqual (3, fvi.FileMajorPart, "#D8b");
		Assert.AreEqual (5, fvi.FileMinorPart, "#D9b");
		Assert.AreEqual (9, fvi.FilePrivatePart, "#D10b");
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
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#H1a");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#H2a");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#H3a");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#H4a");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#H5a");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#H6a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#H7a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#H8a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#H9a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#H10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib8b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#H1b");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#H2b");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#H3b");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#H4b");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#H5b");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#H6b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#H7b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#H8b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#H9b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#H10b");
	}

	static void Verify9 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib9a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#I1a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#I2a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#I3a");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#I4a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#I5a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#I6a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#I7a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#I8a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#I9a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#I10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib9b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#I1b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#I2b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#I3b");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#I4b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#I5b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#I6b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#I7b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#I8b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#I9b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#I10b");
	}

	static void Verify10 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib10a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#J1a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#J2a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#J3a");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#J4a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#J5a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#J6a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#J7a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#J8a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#J9a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#J10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib10b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#J1b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#J2b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#J3b");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#J4b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#J5b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#J6b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#J7b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#J8b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#J9b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#J10b");
	}

	static void Verify11 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib11a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull (fvi.CompanyName, "#K1a");
#else
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#K1a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#K2a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#K2a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#K3a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#K3a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalCopyright, "#K4a");
#else
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#K4a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalTrademarks, "#K5a");
#else
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#K5a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#K6a");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#K6a");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#K7a");
		Assert.AreEqual (0, fvi.FileMajorPart, "#K8a");
		Assert.AreEqual (0, fvi.FileMinorPart, "#K9a");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#K10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib11b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull (fvi.CompanyName, "#K1b");
#else
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#K1b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#K2b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#K2b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#K3b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#K3b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalCopyright, "#K4b");
#else
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#K4b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalTrademarks, "#K5b");
#else
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#K5b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#K6b");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#K6b");
#endif
	}

	static void Create12a ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib12a";
		aname.Version = new Version (9, 0, 3, 0);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

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

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib8.res"));
		ab.Save ("lib12a.dll");
	}

	static void Create12b ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib12b";
		aname.Version = new Version (9, 0, 3 ,0);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib8.res"));
		ab.Save ("lib12b.dll");
	}

	static void Verify12 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib12a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#L1a");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#L2a");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#L3a");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#L4a");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#L5a");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#L6a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#L7a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#L8a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#L9a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#L10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib12b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#L1b");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#L2b");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#L3b");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#L4b");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#L5b");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#L6b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#L7b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#L8b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#L9b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#L10b");
	}

	static void Create13a ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib13a";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

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

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib9.res"));
		ab.Save ("lib13a.dll");
	}

	static void Create13b ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib13b";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib9.res"));
		ab.Save ("lib13b.dll");
	}

	static void Verify13 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib13a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#M1a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#M2a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#M3a");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#M4a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#M5a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#M6a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#M7a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#M8a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#M9a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#M10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib13b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#M1b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#M2b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#M3b");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#M4b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#M5b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#M6b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#M7b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#M8b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#M9b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#M10b");
	}

	static void Create14a ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib14a";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

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

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib10.res"));
		ab.Save ("lib14a.dll");
	}

	static void Create14b ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib14b";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib10.res"));
		ab.Save ("lib14b.dll");
	}

	static void Verify14 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib14a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#N1a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#N2a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#N3a");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#N4a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#N5a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#N6a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#N7a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#N8a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#N9a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#N10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib14b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#N1b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#N2b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#N3b");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#N4b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#N5b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#N6b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#N7b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#N8b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#N9b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#N10b");
	}

	static void Create15a ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib15a";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

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

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib11.res"));
		ab.Save ("lib15a.dll");
	}

	static void Create15b ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib15b";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, basedir);

		ab.DefineUnmanagedResource (Path.Combine (basedir, "lib11.res"));
		ab.Save ("lib15b.dll");
	}

	static void Verify15 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib15a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull ( fvi.CompanyName, "#O1a");
#else
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#O1a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#O2a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#O2a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#O3a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#O3a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalCopyright, "#O4a");
#else
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#O4a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalTrademarks, "#O5a");
#else
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#O5a");
#endif
#if NET_2_0
		Assert.IsNull (fvi.FileVersion, "#O6a");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#O6a");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#O7a");
		Assert.AreEqual (0, fvi.FileMajorPart, "#O8a");

		Assert.AreEqual (0, fvi.FileMinorPart, "#O9a");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#O10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib15b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull ( fvi.CompanyName, "#O1b");
#else
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#O1b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#O2b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#O2b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#O3b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#O3b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalCopyright, "#O4b");
#else
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#O4b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.LegalTrademarks, "#O5b");
#else
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#O5b");
#endif
#if NET_2_0
		Assert.IsNull (fvi.FileVersion, "#O6b");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#O6b");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#O7b");
		Assert.AreEqual (0, fvi.FileMajorPart, "#O8b");
		Assert.AreEqual (0, fvi.FileMinorPart, "#O9b");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#O10b");
	}

	static void Create16a ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib16a";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		// AssemblyVersion
		Type attrType = typeof (AssemblyVersionAttribute);
		ConstructorInfo ci = attrType.GetConstructor (new Type [] { typeof (String) });
		CustomAttributeBuilder cab = new CustomAttributeBuilder (ci, new object [1] { "1.2.3.4" });
		ab.SetCustomAttribute (cab);

		ab.DefineVersionInfoResource ();
		ab.Save ("lib16a.dll");
	}

	static void Create16b ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib16b";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		// AssemblyVersion
		Type attrType = typeof (AssemblyVersionAttribute);
		ConstructorInfo ci = attrType.GetConstructor (new Type [] { typeof (String) });
		CustomAttributeBuilder cab = new CustomAttributeBuilder (ci, new object [1] { "1.2.3.4" });
		ab.SetCustomAttribute (cab);

		// AssemblyFileVersion
		attrType = typeof (AssemblyFileVersionAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "2.4.6.8" });
		ab.SetCustomAttribute (cab);

		ab.DefineVersionInfoResource ();
		ab.Save ("lib16b.dll");
	}

	static void Create16c ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib16c";
		aname.Version = new Version (3, 5, 7, 9);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		// AssemblyVersion
		Type attrType = typeof (AssemblyVersionAttribute);
		ConstructorInfo ci = attrType.GetConstructor (new Type [] { typeof (String) });
		CustomAttributeBuilder cab = new CustomAttributeBuilder (ci, new object [1] { "1.2.3.4" });
		ab.SetCustomAttribute (cab);

		// AssemblyFileVersion
		attrType = typeof (AssemblyFileVersionAttribute);
		ci = attrType.GetConstructor (new Type [] { typeof (String) });
		cab = new CustomAttributeBuilder (ci, new object [1] { "0.0.0.0" });
		ab.SetCustomAttribute (cab);

		ab.DefineVersionInfoResource ();
		ab.Save ("lib16c.dll");
	}

	static void Verify16 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib16a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.CompanyName, "#P1a");
		Assert.AreEqual (" ", fvi.ProductName, "#P2a");
		Assert.AreEqual (" ", fvi.ProductVersion, "#P3a");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#P4a");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#P5a");
		Assert.AreEqual ("3.5.7.9", fvi.FileVersion, "#P6a");
		Assert.AreEqual (7, fvi.FileBuildPart, "#P7a");
		Assert.AreEqual (3, fvi.FileMajorPart, "#P8a");
		Assert.AreEqual (5, fvi.FileMinorPart, "#P9a");
		Assert.AreEqual (9, fvi.FilePrivatePart, "#P10a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib16b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.CompanyName, "#P1b");
		Assert.AreEqual (" ", fvi.ProductName, "#P2b");
		Assert.AreEqual (" ", fvi.ProductVersion, "#P3b");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#P4b");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#P5b");
		Assert.AreEqual ("2.4.6.8", fvi.FileVersion, "#P6b");
		Assert.AreEqual (6, fvi.FileBuildPart, "#P7b");
		Assert.AreEqual (2, fvi.FileMajorPart, "#P8b");
		Assert.AreEqual (4, fvi.FileMinorPart, "#P9b");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#P10b");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib16c.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.CompanyName, "#P1c");
		Assert.AreEqual (" ", fvi.ProductName, "#P2c");
		Assert.AreEqual (" ", fvi.ProductVersion, "#P3c");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#P4c");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#P5c");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#P6c");
		Assert.AreEqual (0, fvi.FileBuildPart, "#P7c");
		Assert.AreEqual (0, fvi.FileMajorPart, "#P8c");
		Assert.AreEqual (0, fvi.FileMinorPart, "#P9c");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#P10c");
	}
}
