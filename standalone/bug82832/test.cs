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
		if (args.Length != 2) {
			Console.Error.WriteLine ("Please specify the action and the CLR version.");
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
			Create18 ();
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
			Verify17 (args [1]);
			Verify18 ();
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
		ab.DefineVersionInfoResource ("BBB", "2.3", "CCC", "DDD", "EEE");
		ab.Save ("lib1.dll");
	}

	static void Verify1 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib1.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.Comments, "#A1");
		Assert.AreEqual ("CCC", fvi.CompanyName, "#A2");
		Assert.AreEqual (0, fvi.FileBuildPart, "#A3");
		Assert.AreEqual (" ", fvi.FileDescription, "#A4");
		Assert.AreEqual (0, fvi.FileMajorPart, "#A5");
		Assert.AreEqual (0, fvi.FileMinorPart, "#A6");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#A7");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#A8");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#A9");
		Assert.AreEqual ("lib1", fvi.InternalName, "#A10");
		Assert.IsFalse (fvi.IsDebug, "#A11");
		Assert.IsFalse (fvi.IsPatched, "#A12");
		Assert.IsFalse (fvi.IsPreRelease, "#A13");
		Assert.IsFalse (fvi.IsPrivateBuild, "#A14");
		Assert.IsFalse (fvi.IsSpecialBuild, "#A15");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#A16");
		Assert.AreEqual ("DDD", fvi.LegalCopyright, "#A17");
		Assert.AreEqual ("EEE", fvi.LegalTrademarks, "#A18");
		Assert.AreEqual ("lib1.dll", fvi.OriginalFilename, "#A19");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#A20");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#A21");
		Assert.AreEqual (2, fvi.ProductMajorPart, "#A22");
		Assert.AreEqual (3, fvi.ProductMinorPart, "#A23");
		Assert.AreEqual ("BBB", fvi.ProductName, "#A24");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#A25");
		Assert.AreEqual ("2.3", fvi.ProductVersion, "#A26");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#A27");
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
		Assert.AreEqual (" ", fvi.Comments, "#B1");
		Assert.AreEqual (" ", fvi.CompanyName, "#B2");
		Assert.AreEqual (0, fvi.FileBuildPart, "#B3");
		Assert.AreEqual (" ", fvi.FileDescription, "#B4");
		Assert.AreEqual (0, fvi.FileMajorPart, "#B5");
		Assert.AreEqual (0, fvi.FileMinorPart, "#B6");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#B7");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#B8");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#B9");
		Assert.AreEqual ("lib2", fvi.InternalName, "#B10");
		Assert.IsFalse (fvi.IsDebug, "#B11");
		Assert.IsFalse (fvi.IsPatched, "#B12");
		Assert.IsFalse (fvi.IsPreRelease, "#B13");
		Assert.IsFalse (fvi.IsPrivateBuild, "#B14");
		Assert.IsFalse (fvi.IsSpecialBuild, "#B15");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#B16");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#B17");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#B18");
		Assert.AreEqual ("lib2.dll", fvi.OriginalFilename, "#B19");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#B20");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#B21");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#B22");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#B23");
		Assert.AreEqual (" ", fvi.ProductName, "#B24");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#B25");
		Assert.AreEqual (" ", fvi.ProductVersion, "#B26");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#B27");
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
		Assert.AreEqual (" ", fvi.Comments, "#C1");
		Assert.AreEqual ("Mono Team", fvi.CompanyName, "#C2");
		Assert.AreEqual (6, fvi.FileBuildPart, "#C3");
		Assert.AreEqual (" ", fvi.FileDescription, "#C4");
		Assert.AreEqual (2, fvi.FileMajorPart, "#C5");
		Assert.AreEqual (4, fvi.FileMinorPart, "#C6");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#C7");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#C8");
		Assert.AreEqual ("2.4.6.8", fvi.FileVersion, "#C9");
		Assert.AreEqual ("lib3", fvi.InternalName, "#C10");
		Assert.IsFalse (fvi.IsDebug, "#C11");
		Assert.IsFalse (fvi.IsPatched, "#C12");
		Assert.IsFalse (fvi.IsPreRelease, "#C13");
		Assert.IsFalse (fvi.IsPrivateBuild, "#C14");
		Assert.IsFalse (fvi.IsSpecialBuild, "#C15");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#C16");
		Assert.AreEqual ("Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#C17");
		Assert.AreEqual ("Registered to All", fvi.LegalTrademarks, "#C18");
		Assert.AreEqual ("lib3.dll", fvi.OriginalFilename, "#C19");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#C20");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#C21");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#C22");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#C23");
		Assert.AreEqual ("Mono Runtime", fvi.ProductName, "#C24");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#C25");
		Assert.AreEqual (" ", fvi.ProductVersion, "#C26");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#C27");
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

		ab.DefineVersionInfoResource ("AAA", "2.4.6.1", "BBB", "CCC", "DDD");
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
		Assert.AreEqual (" ", fvi.Comments, "#D1a");
		Assert.AreEqual ("BBB", fvi.CompanyName, "#D2a");
		Assert.AreEqual (0, fvi.FileBuildPart, "#D3a");
		Assert.AreEqual (" ", fvi.FileDescription, "#D4a");
		Assert.AreEqual (0, fvi.FileMajorPart, "#D5a");
		Assert.AreEqual (0, fvi.FileMinorPart, "#D6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#D7a");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#D8a");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#D9a");
		Assert.AreEqual ("lib4a", fvi.InternalName, "#D10a");
		Assert.IsFalse (fvi.IsDebug, "#D11a");
		Assert.IsFalse (fvi.IsPatched, "#D12a");
		Assert.IsFalse (fvi.IsPreRelease, "#D13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#D14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#D15a");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#D16a");
		Assert.AreEqual ("CCC", fvi.LegalCopyright, "#D17a");
		Assert.AreEqual ("DDD", fvi.LegalTrademarks, "#D18a");
		Assert.AreEqual ("lib4a.dll", fvi.OriginalFilename, "#D19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#D20a");
		Assert.AreEqual (6, fvi.ProductBuildPart, "#D21a");
		Assert.AreEqual (2, fvi.ProductMajorPart, "#D22a");
		Assert.AreEqual (4, fvi.ProductMinorPart, "#D23a");
		Assert.AreEqual ("AAA", fvi.ProductName, "#D24a");
		Assert.AreEqual (1, fvi.ProductPrivatePart, "#D25a");
		Assert.AreEqual ("2.4.6.1", fvi.ProductVersion, "#D26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#D27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib4b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.Comments, "#D1b");
		Assert.AreEqual ("BBB", fvi.CompanyName, "#D2b");
		Assert.AreEqual (7, fvi.FileBuildPart, "#D3b");
		Assert.AreEqual (" ", fvi.FileDescription, "#D4b");
		Assert.AreEqual (3, fvi.FileMajorPart, "#D5b");
		Assert.AreEqual (5, fvi.FileMinorPart, "#D6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#D7b");
		Assert.AreEqual (9, fvi.FilePrivatePart, "#D8b");
		Assert.AreEqual ("3.5.7.9", fvi.FileVersion, "#D9b");
		Assert.AreEqual ("lib4b", fvi.InternalName, "#D10b");
		Assert.IsFalse (fvi.IsDebug, "#D11b");
		Assert.IsFalse (fvi.IsPatched, "#D12b");
		Assert.IsFalse (fvi.IsPreRelease, "#D13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#D14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#D15b");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#D16b");
		Assert.AreEqual ("CCC", fvi.LegalCopyright, "#D17b");
		Assert.AreEqual ("DDD", fvi.LegalTrademarks, "#D18b");
		Assert.AreEqual ("lib4b.dll", fvi.OriginalFilename, "#D19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#D20b");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#D21b");
		Assert.AreEqual (2, fvi.ProductMajorPart, "#D22b");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#D23b");
		Assert.AreEqual ("AAA", fvi.ProductName, "#D24b");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#D25b");
		Assert.AreEqual ("2.0", fvi.ProductVersion, "#D26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#D27b");
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
		Assert.AreEqual (" ", fvi.Comments, "#E1");
		Assert.AreEqual (" ", fvi.CompanyName, "#E2");
		Assert.AreEqual (0, fvi.FileBuildPart, "#E3");
		Assert.AreEqual (" ", fvi.FileDescription, "#E4");
		Assert.AreEqual (0, fvi.FileMajorPart, "#E5");
		Assert.AreEqual (0, fvi.FileMinorPart, "#E6");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#E7");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#E8");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#E9");
		Assert.AreEqual ("lib5", fvi.InternalName, "#E10");
		Assert.IsFalse (fvi.IsDebug, "#E11");
		Assert.IsFalse (fvi.IsPatched, "#E12");
		Assert.IsFalse (fvi.IsPreRelease, "#E13");
		Assert.IsFalse (fvi.IsPrivateBuild, "#E14");
		Assert.IsFalse (fvi.IsSpecialBuild, "#E15");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#E16");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#E17");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#E18");
		Assert.AreEqual ("lib5.dll", fvi.OriginalFilename, "#E19");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#E20");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#E21");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#E22");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#E23");
		Assert.AreEqual (" ", fvi.ProductName, "#E24");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#E25");
		Assert.AreEqual (" ", fvi.ProductVersion, "#E26");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#E27");
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
		Assert.AreEqual (" ", fvi.Comments, "#G1");
		Assert.AreEqual (" ", fvi.CompanyName, "#G2");
		Assert.AreEqual (0, fvi.FileBuildPart, "#G3");
		Assert.AreEqual (" ", fvi.FileDescription, "#G4");
		Assert.AreEqual (0, fvi.FileMajorPart, "#G5");
		Assert.AreEqual (0, fvi.FileMinorPart, "#G6");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#G7");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#G8");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#G9");
		Assert.AreEqual ("lib7", fvi.InternalName, "#G10");
		Assert.IsFalse (fvi.IsDebug, "#G11");
		Assert.IsFalse (fvi.IsPatched, "#G12");
		Assert.IsFalse (fvi.IsPreRelease, "#G13");
		Assert.IsFalse (fvi.IsPrivateBuild, "#G14");
		Assert.IsFalse (fvi.IsSpecialBuild, "#G15");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#G16");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#G17");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#G18");
		Assert.AreEqual ("lib7.dll", fvi.OriginalFilename, "#G19");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#G20");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#G21");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#G22");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#G23");
		Assert.AreEqual (" ", fvi.ProductName, "#G24");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#G25");
		Assert.AreEqual (" ", fvi.ProductVersion, "#G26");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#G27");
	}

	static void Verify8 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib8a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("N Comment", fvi.Comments, "#H1a");
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#H2a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#H3a");
		Assert.AreEqual ("N File Description", fvi.FileDescription, "#H4a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#H5a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#H6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#H7a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#H8a");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#H9a");
		Assert.AreEqual ("N lib3", fvi.InternalName, "#H10a");
		Assert.IsFalse (fvi.IsDebug, "#H11a");
		Assert.IsFalse (fvi.IsPatched, "#H12a");
		Assert.IsFalse (fvi.IsPreRelease, "#H13a");
		Assert.IsTrue (fvi.IsPrivateBuild, "#H14a");
		Assert.IsTrue (fvi.IsSpecialBuild, "#H15a");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#H16a");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#H17a");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#H18a");
		Assert.AreEqual ("N lib3.dll", fvi.OriginalFilename, "#H19a");
		Assert.AreEqual ("N PRIV", fvi.PrivateBuild, "#H20a");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#H21a");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#H22a");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#H23a");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#H24a");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#H25a");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#H26a");
		Assert.AreEqual ("N SPEC", fvi.SpecialBuild, "#H27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib8b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("N Comment", fvi.Comments, "#H1b");
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#H2b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#H3b");
		Assert.AreEqual ("N File Description", fvi.FileDescription, "#H4b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#H5b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#H6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#H7b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#H8b");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#H9b");
		Assert.AreEqual ("N lib3", fvi.InternalName, "#H10b");
		Assert.IsFalse (fvi.IsDebug, "#H11b");
		Assert.IsFalse (fvi.IsPatched, "#H12b");
		Assert.IsFalse (fvi.IsPreRelease, "#H13b");
		Assert.IsTrue (fvi.IsPrivateBuild, "#H14b");
		Assert.IsTrue (fvi.IsSpecialBuild, "#H15b");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#H16b");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#H17b");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#H18b");
		Assert.AreEqual ("N lib3.dll", fvi.OriginalFilename, "#H19b");
		Assert.AreEqual ("N PRIV", fvi.PrivateBuild, "#H20b");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#H21b");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#H22b");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#H23b");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#H24b");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#H25b");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#H26b");
		Assert.AreEqual ("N SPEC", fvi.SpecialBuild, "#H27b");
	}

	static void Verify9 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib9a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.Comments, "#I1a");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#I2a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#I3a");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#I4a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#I5a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#I6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#I7a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#I8a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#I9a");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#I10a");
		Assert.IsFalse (fvi.IsDebug, "#I11a");
		Assert.IsFalse (fvi.IsPatched, "#I12a");
		Assert.IsFalse (fvi.IsPreRelease, "#I13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#I14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#I15a");
#if !MONO
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#I16a");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#I17a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#I18a");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#I19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#I20a");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#I21a");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#I22a");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#I23a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#I24a");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#I25a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#I26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#I27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib9b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.Comments, "#I1b");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#I2b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#I3b");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#I4b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#I5b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#I6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#I7b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#I8b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#I9b");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#I10b");
		Assert.IsFalse (fvi.IsDebug, "#I11b");
		Assert.IsFalse (fvi.IsPatched, "#I12b");
		Assert.IsFalse (fvi.IsPreRelease, "#I13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#I14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#I15b");
#if !MONO
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#I16b");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#I17b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#I18b");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#I19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#I20b");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#I21b");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#I22b");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#I23b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#I24b");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#I25b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#I26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#I27b");
	}

	static void Verify10 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib10a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.Comments, "#J1a");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#J2a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#J3a");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#J4a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#J5a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#J6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#J7a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#J8a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#J9a");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#J10a");
		Assert.IsFalse (fvi.IsDebug, "#J11a");
		Assert.IsFalse (fvi.IsPatched, "#J12a");
		Assert.IsFalse (fvi.IsPreRelease, "#J13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#J14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#J15a");
#if !MONO
		Assert.AreEqual ("English (United States)", fvi.Language, "#J16a");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#J17a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#J18a");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#J19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#J20a");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#J21a");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#J22a");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#J23a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#J24a");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#J25a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#J26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#J27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib10b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.Comments, "#J1b");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#J2b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#J3b");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#J4b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#J5b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#J6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#J7b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#J8b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#J9b");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#J10b");
		Assert.IsFalse (fvi.IsDebug, "#J11b");
		Assert.IsFalse (fvi.IsPatched, "#J12b");
		Assert.IsFalse (fvi.IsPreRelease, "#J13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#J14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#J15b");
#if !MONO
		Assert.AreEqual ("English (United States)", fvi.Language, "#J16b");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#J17b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#J18b");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#J19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#J20b");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#J21b");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#J22b");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#J23b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#J24b");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#J25b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#J26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#J27b");
	}

	static void Verify11 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib11a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull (fvi.Comments, "#K1a");
		Assert.IsNull (fvi.CompanyName, "#K2a");
#else
		Assert.AreEqual (string.Empty, fvi.Comments, "#K1a");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#K2a");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#K3a");
#if NET_2_0
		Assert.IsNull (fvi.FileDescription, "#K4a");
#else
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#K4a");
#endif
		Assert.AreEqual (0, fvi.FileMajorPart, "#K5a");
		Assert.AreEqual (0, fvi.FileMinorPart, "#K6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#K7a");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#K8a");
#if NET_2_0
		Assert.IsNull (fvi.FileVersion, "#K9a");
		Assert.IsNull (fvi.InternalName, "#K10a");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#K9a");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#K10a");
#endif
		Assert.IsFalse (fvi.IsDebug, "#K11a");
		Assert.IsFalse (fvi.IsPatched, "#K12a");
		Assert.IsFalse (fvi.IsPreRelease, "#K13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#K14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#K15a");
#if NET_2_0
		Assert.IsNull (fvi.Language, "#K16a");
		Assert.IsNull (fvi.LegalCopyright, "#K17a");
		Assert.IsNull (fvi.LegalTrademarks, "#K18a");
		Assert.IsNull (fvi.OriginalFilename, "#K19a");
		Assert.IsNull (fvi.PrivateBuild, "#K20a");
#else
		Assert.AreEqual (string.Empty, fvi.Language, "#K16a");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#K17a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#K18a");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#K19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#K20a");
#endif
		Assert.AreEqual (0, fvi.ProductBuildPart, "#K21a");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#K22a");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#K23a");
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#K24a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#K24a");
#endif
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#K25a");
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#K26a");
		Assert.IsNull (fvi.SpecialBuild, "#K27a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#K26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#K27a");
#endif

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib11b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull (fvi.Comments, "#K1b");
		Assert.IsNull (fvi.CompanyName, "#K2b");
#else
		Assert.AreEqual (string.Empty, fvi.Comments, "#K1b");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#K2b");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#K3b");
#if NET_2_0
		Assert.IsNull (fvi.FileDescription, "#K4b");
#else
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#K4b");
#endif
		Assert.AreEqual (0, fvi.FileMajorPart, "#K5b");
		Assert.AreEqual (0, fvi.FileMinorPart, "#K6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#K7b");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#K8b");
#if NET_2_0
		Assert.IsNull (fvi.FileVersion, "#K9b");
		Assert.IsNull (fvi.InternalName, "#K10b");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#K9b");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#K10b");
#endif
		Assert.IsFalse (fvi.IsDebug, "#K11b");
		Assert.IsFalse (fvi.IsPatched, "#K12b");
		Assert.IsFalse (fvi.IsPreRelease, "#K13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#K14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#K15b");
#if NET_2_0
		Assert.IsNull (fvi.Language, "#K16b");
		Assert.IsNull (fvi.LegalCopyright, "#K17b");
		Assert.IsNull (fvi.LegalTrademarks, "#K18b");
		Assert.IsNull (fvi.OriginalFilename, "#K19b");
		Assert.IsNull (fvi.PrivateBuild, "#K20b");
#else
		Assert.AreEqual (string.Empty, fvi.Language, "#K16b");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#K17b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#K18b");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#K19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#K20b");
#endif
		Assert.AreEqual (0, fvi.ProductBuildPart, "#K21b");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#K22b");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#K23b");
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#K24b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#K24b");
#endif
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#K25b");
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#K26b");
		Assert.IsNull (fvi.SpecialBuild, "#K27b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#K26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#K27b");
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
		Assert.AreEqual ("N Comment", fvi.Comments, "#L1a");
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#L2a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#L3a");
		Assert.AreEqual ("N File Description", fvi.FileDescription, "#L4a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#L5a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#L6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#L7a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#L8a");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#L9a");
		Assert.AreEqual ("N lib3", fvi.InternalName, "#L10a");
		Assert.IsFalse (fvi.IsDebug, "#L11a");
		Assert.IsFalse (fvi.IsPatched, "#L12a");
		Assert.IsFalse (fvi.IsPreRelease, "#L13a");
		Assert.IsTrue (fvi.IsPrivateBuild, "#L14a");
		Assert.IsTrue (fvi.IsSpecialBuild, "#L15a");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#L16a");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#L17a");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#L18a");
		Assert.AreEqual ("N lib3.dll", fvi.OriginalFilename, "#L19a");
		Assert.AreEqual ("N PRIV", fvi.PrivateBuild, "#L20a");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#L21a");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#L22a");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#L23a");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#L24a");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#L25a");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#L26a");
		Assert.AreEqual ("N SPEC", fvi.SpecialBuild, "#L27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib12b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("N Comment", fvi.Comments, "#L1b");
		Assert.AreEqual ("N Mono Team", fvi.CompanyName, "#L2b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#L3b");
		Assert.AreEqual ("N File Description", fvi.FileDescription, "#L4b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#L5b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#L6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#L7b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#L8b");
		Assert.AreEqual ("N 1.2.3.4", fvi.FileVersion, "#L9b");
		Assert.AreEqual ("N lib3", fvi.InternalName, "#L10b");
		Assert.IsFalse (fvi.IsDebug, "#L11b");
		Assert.IsFalse (fvi.IsPatched, "#L12b");
		Assert.IsFalse (fvi.IsPreRelease, "#L13b");
		Assert.IsTrue (fvi.IsPrivateBuild, "#L14b");
		Assert.IsTrue (fvi.IsSpecialBuild, "#L15b");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#L16b");
		Assert.AreEqual ("N Copyright 2007 Mono Hackers", fvi.LegalCopyright, "#L17b");
		Assert.AreEqual ("N Registered to All", fvi.LegalTrademarks, "#L18b");
		Assert.AreEqual ("N lib3.dll", fvi.OriginalFilename, "#L19b");
		Assert.AreEqual ("N PRIV", fvi.PrivateBuild, "#L20b");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#L21b");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#L22b");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#L23b");
		Assert.AreEqual ("N Mono Runtime", fvi.ProductName, "#L24b");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#L25b");
		Assert.AreEqual ("N 4,2,1,7", fvi.ProductVersion, "#L26b");
		Assert.AreEqual ("N SPEC", fvi.SpecialBuild, "#L27b");
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
		Assert.AreEqual (string.Empty, fvi.Comments, "#M1a");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#M2a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#M3a");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#M4a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#M5a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#M6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#M7a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#M8a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#M9a");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#M10a");
		Assert.IsFalse (fvi.IsDebug, "#M11a");
		Assert.IsFalse (fvi.IsPatched, "#M12a");
		Assert.IsFalse (fvi.IsPreRelease, "#M13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#M14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#M15a");
#if !MONO
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#M16a");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#M17a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#M18a");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#M19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#M20a");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#M21a");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#M22a");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#M23a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#M24a");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#M25a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#M26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#M27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib13b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.Comments, "#M1b");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#M2b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#M3b");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#M4b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#M5b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#M6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#M7b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#M8b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#M9b");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#M10b");
		Assert.IsFalse (fvi.IsDebug, "#M11b");
		Assert.IsFalse (fvi.IsPatched, "#M12b");
		Assert.IsFalse (fvi.IsPreRelease, "#M13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#M14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#M15b");
#if !MONO
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#M16b");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#M17b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#M18b");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#M19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#M20b");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#M21b");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#M22b");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#M23b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#M24b");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#M25b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#M26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#M27b");
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
		Assert.AreEqual (string.Empty, fvi.Comments, "#N1a");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#N2a");
		Assert.AreEqual (1, fvi.FileBuildPart, "#N3a");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#N4a");
		Assert.AreEqual (6, fvi.FileMajorPart, "#N5a");
		Assert.AreEqual (9, fvi.FileMinorPart, "#N6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#N7a");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#N8a");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#N9a");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#N10a");
		Assert.IsFalse (fvi.IsDebug, "#N11a");
		Assert.IsFalse (fvi.IsPatched, "#N12a");
		Assert.IsFalse (fvi.IsPreRelease, "#N13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#N14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#N15a");
#if !MONO
		Assert.AreEqual ("English (United States)", fvi.Language, "#N16a");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#N17a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#N18a");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#N19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#N20a");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#N21a");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#N22a");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#N23a");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#N24a");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#N25a");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#N26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#N27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib14b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (string.Empty, fvi.Comments, "#N1b");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#N2b");
		Assert.AreEqual (1, fvi.FileBuildPart, "#N3b");
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#N4b");
		Assert.AreEqual (6, fvi.FileMajorPart, "#N5b");
		Assert.AreEqual (9, fvi.FileMinorPart, "#N6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#N7b");
		Assert.AreEqual (3, fvi.FilePrivatePart, "#N8b");
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#N9b");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#N10b");
		Assert.IsFalse (fvi.IsDebug, "#N11b");
		Assert.IsFalse (fvi.IsPatched, "#N12b");
		Assert.IsFalse (fvi.IsPreRelease, "#N13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#N14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#N15b");
#if !MONO
		Assert.AreEqual ("English (United States)", fvi.Language, "#N16b");
#endif
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#N17b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#N18b");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#N19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#N20b");
		Assert.AreEqual (7, fvi.ProductBuildPart, "#N21b");
		Assert.AreEqual (9, fvi.ProductMajorPart, "#N22b");
		Assert.AreEqual (8, fvi.ProductMinorPart, "#N23b");
		Assert.AreEqual (string.Empty, fvi.ProductName, "#N24b");
		Assert.AreEqual (6, fvi.ProductPrivatePart, "#N25b");
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#N26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#N27b");
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
		Assert.IsNull (fvi.Comments, "#O1a");
		Assert.IsNull (fvi.CompanyName, "#O2a");
#else
		Assert.AreEqual (string.Empty, fvi.Comments, "#O1a");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#O2a");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#O3a");
#if NET_2_0
		Assert.IsNull (fvi.FileDescription, "#O4a");
#else
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#O4a");
#endif
		Assert.AreEqual (0, fvi.FileMajorPart, "#O5a");
		Assert.AreEqual (0, fvi.FileMinorPart, "#O6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#O7a");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#O8a");
#if NET_2_0
		Assert.IsNull (fvi.FileVersion, "#O9a");
		Assert.IsNull (fvi.InternalName, "#O10a");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#O9a");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#O10a");
#endif
		Assert.IsFalse (fvi.IsDebug, "#O11a");
		Assert.IsFalse (fvi.IsPatched, "#O12a");
		Assert.IsFalse (fvi.IsPreRelease, "#O13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#O14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#O15a");
#if NET_2_0
		Assert.IsNull (fvi.Language, "#O16a");
		Assert.IsNull (fvi.LegalCopyright, "#O17a");
		Assert.IsNull (fvi.LegalTrademarks, "#O18a");
		Assert.IsNull (fvi.OriginalFilename, "#O19a");
		Assert.IsNull (fvi.PrivateBuild, "#O20a");
#else
		Assert.AreEqual (string.Empty, fvi.Language, "#O16a");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#O17a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#O18a");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#O19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#O20a");
#endif
		Assert.AreEqual (0, fvi.ProductBuildPart, "#O21a");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#O22a");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#O23a");
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#O24a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#O24a");
#endif
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#O25a");
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#O26a");
		Assert.IsNull (fvi.SpecialBuild, "#O27a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#O26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#O27a");
#endif

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib15b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull (fvi.Comments, "#O1b");
		Assert.IsNull (fvi.CompanyName, "#O2b");
#else
		Assert.AreEqual (string.Empty, fvi.Comments, "#O1b");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#O2b");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#O3b");
#if NET_2_0
		Assert.IsNull (fvi.FileDescription, "#O4b");
#else
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#O4b");
#endif
		Assert.AreEqual (0, fvi.FileMajorPart, "#O5b");
		Assert.AreEqual (0, fvi.FileMinorPart, "#O6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#O7b");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#O8b");
#if NET_2_0
		Assert.IsNull (fvi.FileVersion, "#O9b");
		Assert.IsNull (fvi.InternalName, "#O10b");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#O9b");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#O10b");
#endif
		Assert.IsFalse (fvi.IsDebug, "#O11b");
		Assert.IsFalse (fvi.IsPatched, "#O12b");
		Assert.IsFalse (fvi.IsPreRelease, "#O13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#O14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#O15b");
#if NET_2_0
		Assert.IsNull (fvi.Language, "#O16b");
		Assert.IsNull (fvi.LegalCopyright, "#O17b");
		Assert.IsNull (fvi.LegalTrademarks, "#O18b");
		Assert.IsNull (fvi.OriginalFilename, "#O19b");
		Assert.IsNull (fvi.PrivateBuild, "#O20b");
#else
		Assert.AreEqual (string.Empty, fvi.Language, "#O16b");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#O17b");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#O18b");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#O19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#O20b");
#endif
		Assert.AreEqual (0, fvi.ProductBuildPart, "#O21b");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#O22b");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#O23b");
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#O24b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#O24b");
#endif
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#O25b");
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#O26b");
		Assert.IsNull (fvi.SpecialBuild, "#O27b");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#O26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#O27b");
#endif
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
		Assert.AreEqual (" ", fvi.Comments, "#P1a");
		Assert.AreEqual (" ", fvi.CompanyName, "#P2a");
		Assert.AreEqual (7, fvi.FileBuildPart, "#P3a");
		Assert.AreEqual (" ", fvi.FileDescription, "#P4a");
		Assert.AreEqual (3, fvi.FileMajorPart, "#P5a");
		Assert.AreEqual (5, fvi.FileMinorPart, "#P6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#P7a");
		Assert.AreEqual (9, fvi.FilePrivatePart, "#P8a");
		Assert.AreEqual ("3.5.7.9", fvi.FileVersion, "#P9a");
		Assert.AreEqual ("lib16a", fvi.InternalName, "#P10a");
		Assert.IsFalse (fvi.IsDebug, "#P11a");
		Assert.IsFalse (fvi.IsPatched, "#P12a");
		Assert.IsFalse (fvi.IsPreRelease, "#P13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#P14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#P15a");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#P16a");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#P17a");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#P18a");
		Assert.AreEqual ("lib16a.dll", fvi.OriginalFilename, "#P19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#P20a");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#P21a");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#P22a");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#P23a");
		Assert.AreEqual (" ", fvi.ProductName, "#P24a");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#P25a");
		Assert.AreEqual (" ", fvi.ProductVersion, "#P26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#P27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib16b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.Comments, "#P1b");
		Assert.AreEqual (" ", fvi.CompanyName, "#P2b");
		Assert.AreEqual (6, fvi.FileBuildPart, "#P3b");
		Assert.AreEqual (" ", fvi.FileDescription, "#P4b");
		Assert.AreEqual (2, fvi.FileMajorPart, "#P5b");
		Assert.AreEqual (4, fvi.FileMinorPart, "#P6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#P7b");
		Assert.AreEqual (8, fvi.FilePrivatePart, "#P8b");
		Assert.AreEqual ("2.4.6.8", fvi.FileVersion, "#P9b");
		Assert.AreEqual ("lib16b", fvi.InternalName, "#P10b");
		Assert.IsFalse (fvi.IsDebug, "#P11b");
		Assert.IsFalse (fvi.IsPatched, "#P12b");
		Assert.IsFalse (fvi.IsPreRelease, "#P13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#P14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#P15b");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#P16b");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#P17b");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#P18b");
		Assert.AreEqual ("lib16b.dll", fvi.OriginalFilename, "#P19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#P20b");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#P21b");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#P22b");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#P23b");
		Assert.AreEqual (" ", fvi.ProductName, "#P24b");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#P25b");
		Assert.AreEqual (" ", fvi.ProductVersion, "#P26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#P27b");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib16c.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual (" ", fvi.Comments, "#P1c");
		Assert.AreEqual (" ", fvi.CompanyName, "#P2c");
		Assert.AreEqual (0, fvi.FileBuildPart, "#P3c");
		Assert.AreEqual (" ", fvi.FileDescription, "#P4c");
		Assert.AreEqual (0, fvi.FileMajorPart, "#P5c");
		Assert.AreEqual (0, fvi.FileMinorPart, "#P6c");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#P7c");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#P8c");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#P9c");
		Assert.AreEqual ("lib16c", fvi.InternalName, "#P10c");
		Assert.IsFalse (fvi.IsDebug, "#P11c");
		Assert.IsFalse (fvi.IsPatched, "#P12c");
		Assert.IsFalse (fvi.IsPreRelease, "#P13c");
		Assert.IsFalse (fvi.IsPrivateBuild, "#P14c");
		Assert.IsFalse (fvi.IsSpecialBuild, "#P15c");
		Assert.AreEqual ("Invariant Language (Invariant Country)", fvi.Language, "#P16c");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#P17c");
		Assert.AreEqual (" ", fvi.LegalTrademarks, "#P18c");
		Assert.AreEqual ("lib16c.dll", fvi.OriginalFilename, "#P19c");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#P20c");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#P21c");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#P22c");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#P23c");
		Assert.AreEqual (" ", fvi.ProductName, "#P24c");
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#P25c");
		Assert.AreEqual (" ", fvi.ProductVersion, "#P26c");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#P27c");
	}

	static void Verify17 (string clr_version)
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib17a.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		Assert.AreEqual ("liba description", fvi.Comments, "#Q1a");
		Assert.AreEqual ("liba company", fvi.CompanyName, "#Q2a");
		Assert.AreEqual (3, fvi.FileBuildPart, "#Q3a");
		Assert.AreEqual ("liba title", fvi.FileDescription, "#Q4a");
		Assert.AreEqual (3, fvi.FileMajorPart, "#Q5a");
		Assert.AreEqual (2, fvi.FileMinorPart, "#Q6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#Q7a");
		Assert.AreEqual (2, fvi.FilePrivatePart, "#Q8a");
		Assert.AreEqual ("3.2.3.2", fvi.FileVersion, "#Q9a");
		Assert.AreEqual ("lib17a.dll", fvi.InternalName, "#Q10a");
		Assert.IsFalse (fvi.IsDebug, "#Q11a");
		Assert.IsFalse (fvi.IsPatched, "#Q12a");
		Assert.IsFalse (fvi.IsPreRelease, "#Q13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#Q14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#Q15a");
		Assert.AreEqual ("Dutch (Belgium)", fvi.Language, "#Q16a");
		Assert.AreEqual ("liba copyright", fvi.LegalCopyright, "#Q17a");
		Assert.AreEqual ("liba trademark", fvi.LegalTrademarks, "#Q18a");
		Assert.AreEqual ("lib17a.dll", fvi.OriginalFilename, "#Q19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#Q20a");
		Assert.AreEqual (4, fvi.ProductBuildPart, "#Q21a");
		Assert.AreEqual (7, fvi.ProductMajorPart, "#Q22a");
		Assert.AreEqual (2, fvi.ProductMinorPart, "#Q23a");
		Assert.AreEqual ("liba", fvi.ProductName, "#Q24a");
		Assert.AreEqual (3, fvi.ProductPrivatePart, "#Q25a");
		Assert.AreEqual ("7.2.4.3", fvi.ProductVersion, "#Q26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#Q27a");

		assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib17b.dll");

		fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
		switch (clr_version) {
		case "2.0":
			Assert.AreEqual (string.Empty, fvi.Comments, "#Q1b");
			Assert.AreEqual (string.Empty, fvi.CompanyName, "#Q2b");
			break;
		case "1.1":
			Assert.AreEqual (" ", fvi.Comments, "#Q1b");
			Assert.AreEqual (" ", fvi.CompanyName, "#Q2b");
			break;
		default:
			Assert.Fail ("CLR version not supported.");
			break;
		}
		Assert.AreEqual (0, fvi.FileBuildPart, "#Q3b");
		Assert.AreEqual (" ", fvi.FileDescription, "#Q4b");
		Assert.AreEqual (0, fvi.FileMajorPart, "#Q5b");
		Assert.AreEqual (0, fvi.FileMinorPart, "#Q6b");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#Q7b");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#Q8b");
		Assert.AreEqual ("0.0.0.0", fvi.FileVersion, "#Q9b");
		Assert.AreEqual ("lib17b.dll", fvi.InternalName, "#Q10b");
		Assert.IsFalse (fvi.IsDebug, "#Q11b");
		Assert.IsFalse (fvi.IsPatched, "#Q12b");
		Assert.IsFalse (fvi.IsPreRelease, "#Q13b");
		Assert.IsFalse (fvi.IsPrivateBuild, "#Q14b");
		Assert.IsFalse (fvi.IsSpecialBuild, "#Q15b");
		Assert.AreEqual ("Language Neutral", fvi.Language, "#Q16b");
		Assert.AreEqual (" ", fvi.LegalCopyright, "#Q17b");
		switch (clr_version) {
		case "2.0":
			Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#Q18b");
			break;
		case "1.1":
			Assert.AreEqual (" ", fvi.LegalTrademarks, "#Q18b");
			break;
		default:
			Assert.Fail ("CLR version not supported.");
			break;
		}
		Assert.AreEqual ("lib17b.dll", fvi.OriginalFilename, "#Q19b");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#Q20b");
		Assert.AreEqual (0, fvi.ProductBuildPart, "#Q21b");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#Q22b");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#Q23b");
		switch (clr_version) {
		case "2.0":
			Assert.AreEqual (string.Empty, fvi.ProductName, "#Q24b");
			break;
		case "1.1":
			Assert.AreEqual (" ", fvi.ProductName, "#Q24b");
			break;
		default:
			Assert.Fail ("CLR version not supported.");
			break;
		}
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#Q25b");
		Assert.AreEqual ("0.0.0.0", fvi.ProductVersion, "#Q26b");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#Q27b");
	}

	static void Create18 ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "lib18";
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

		ab.Save ("lib18.dll");
	}

	static void Verify18 ()
	{
		string assemblyFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"lib18.dll");

		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo (assemblyFile);
#if NET_2_0
		Assert.IsNull (fvi.Comments, "#R1a");
		Assert.IsNull (fvi.CompanyName, "#R2a");
#else
		Assert.AreEqual (string.Empty, fvi.Comments, "#R1a");
		Assert.AreEqual (string.Empty, fvi.CompanyName, "#R2a");
#endif
		Assert.AreEqual (0, fvi.FileBuildPart, "#R3a");
#if NET_2_0
		Assert.IsNull (fvi.FileDescription, "#R4a");
#else
		Assert.AreEqual (string.Empty, fvi.FileDescription, "#R4a");
#endif
		Assert.AreEqual (0, fvi.FileMajorPart, "#R5a");
		Assert.AreEqual (0, fvi.FileMinorPart, "#R6a");
		Assert.AreEqual (assemblyFile, fvi.FileName, "#R7a");
		Assert.AreEqual (0, fvi.FilePrivatePart, "#R8a");
#if NET_2_0
		Assert.IsNull (fvi.FileVersion, "#R9a");
		Assert.IsNull (fvi.InternalName, "#R10a");
#else
		Assert.AreEqual (string.Empty, fvi.FileVersion, "#R9a");
		Assert.AreEqual (string.Empty, fvi.InternalName, "#R10a");
#endif
		Assert.IsFalse (fvi.IsDebug, "#R11a");
		Assert.IsFalse (fvi.IsPatched, "#R12a");
		Assert.IsFalse (fvi.IsPreRelease, "#R13a");
		Assert.IsFalse (fvi.IsPrivateBuild, "#R14a");
		Assert.IsFalse (fvi.IsSpecialBuild, "#R15a");
#if NET_2_0
		Assert.IsNull (fvi.Language, "#R16a");
		Assert.IsNull (fvi.LegalCopyright, "#R17a");
		Assert.IsNull (fvi.LegalTrademarks, "#R18a");
		Assert.IsNull (fvi.OriginalFilename, "#R19a");
		Assert.IsNull (fvi.PrivateBuild, "#R20a");
#else
		Assert.AreEqual (string.Empty, fvi.Language, "#R16a");
		Assert.AreEqual (string.Empty, fvi.LegalCopyright, "#R17a");
		Assert.AreEqual (string.Empty, fvi.LegalTrademarks, "#R18a");
		Assert.AreEqual (string.Empty, fvi.OriginalFilename, "#R19a");
		Assert.AreEqual (string.Empty, fvi.PrivateBuild, "#R20a");
#endif
		Assert.AreEqual (0, fvi.ProductBuildPart, "#R21a");
		Assert.AreEqual (0, fvi.ProductMajorPart, "#R22a");
		Assert.AreEqual (0, fvi.ProductMinorPart, "#R23a");
#if NET_2_0
		Assert.IsNull (fvi.ProductName, "#R24a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductName, "#R24a");
#endif
		Assert.AreEqual (0, fvi.ProductPrivatePart, "#R25a");
#if NET_2_0
		Assert.IsNull (fvi.ProductVersion, "#R26a");
		Assert.IsNull (fvi.SpecialBuild, "#R27a");
#else
		Assert.AreEqual (string.Empty, fvi.ProductVersion, "#R26a");
		Assert.AreEqual (string.Empty, fvi.SpecialBuild, "#R27a");
#endif
	}
}
