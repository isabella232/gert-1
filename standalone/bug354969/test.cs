using System;
using System.Configuration.Assemblies;
using System.Globalization;
using System.IO;
using System.Reflection;

class Program
{
	static void Main (string [] args)
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		TestLibA (dir);
		TestLibB (dir);
		TestLibC ();
	}

	static void TestLibA (string dir)
	{
		Assembly a = Assembly.LoadFrom (Path.Combine (dir, "liba.dll"));
		AssemblyName an = a.GetName ();

		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#A1");
		Assert.IsNotNull (an.EscapedCodeBase, "#A2");
		Assert.AreEqual (AssemblyNameFlags.PublicKey | AssemblyNameFlags.Retargetable, an.Flags, "#A3");
		Assert.AreEqual ("liba, Version=9.7.5.3, Culture=neutral, PublicKeyToken=5ca3085bccb6d96f, Retargetable=Yes", an.FullName, "#A4");
		Assert.AreEqual (160, an.GetPublicKey ().Length, "#A5");
		Assert.AreEqual (new byte [] { 0x5c, 0xa3, 0x08, 0x5b, 0xcc, 0xb6, 0xd9, 0x6f }, an.GetPublicKeyToken (), "#A6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#A7");
		Assert.IsNull (an.KeyPair, "#A8");
		Assert.AreEqual ("liba", an.Name, "#A9");
#if NET_2_0
		Assert.AreEqual (ProcessorArchitecture.MSIL, an.ProcessorArchitecture, "#A10");
#endif
		Assert.AreEqual (an.FullName, an.ToString (), "#A11");
		Assert.AreEqual (new Version (9, 7, 5, 3), an.Version, "#A12");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#A13");

		Type type = a.GetType ("Foo");
		Assert.IsNotNull (type, "#B1");
		Assert.AreEqual ("Foo", type.FullName, "#B2");
		Assert.AreEqual ("Foo, liba, Version=9.7.5.3, Culture=neutral, PublicKeyToken=5ca3085bccb6d96f, Retargetable=Yes",
			type.AssemblyQualifiedName, "#B3");
	}

	static void TestLibB (string dir)
	{
		Assembly a = Assembly.LoadFrom (Path.Combine (dir, "libb.dll"));
		AssemblyName an = a.GetName ();

		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#A1");
		Assert.IsNotNull (an.EscapedCodeBase, "#A2");
		Assert.AreEqual (AssemblyNameFlags.PublicKey | AssemblyNameFlags.Retargetable, an.Flags, "#A3");
		Assert.AreEqual ("libb, Version=9.7.5.3, Culture=neutral, PublicKeyToken=null, Retargetable=Yes", an.FullName, "#A4");
		Assert.AreEqual (new byte [0], an.GetPublicKey (), "#A5");
		Assert.IsNull (an.GetPublicKeyToken (), "#A6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#A7");
		Assert.IsNull (an.KeyPair, "#A8");
		Assert.AreEqual ("libb", an.Name, "#A9");
#if NET_2_0
		Assert.AreEqual (ProcessorArchitecture.MSIL, an.ProcessorArchitecture, "#A10");
#endif
		Assert.AreEqual (an.FullName, an.ToString (), "#A11");
		Assert.AreEqual (new Version (9, 7, 5, 3), an.Version, "#A12");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#A13");

		Type type = a.GetType ("Foo");
		Assert.IsNotNull (type, "#B1");
		Assert.AreEqual ("Foo", type.FullName, "#B2");
		Assert.AreEqual ("Foo, libb, Version=9.7.5.3, Culture=neutral, PublicKeyToken=null, Retargetable=Yes",
			type.AssemblyQualifiedName, "#B3");
	}

	static void TestLibC ()
	{
		try {
			Assembly.Load ("libc, Version=9.7.5.3, Culture=neutral, PublicKeyToken=5ca3085bccb6d96f, Retargetable=Yes");
			Assert.Fail ("#A1");
		} catch (FileLoadException ex) {
			Assert.AreEqual (typeof (FileLoadException), ex.GetType (), "#A2");
			Assert.AreEqual ("libc", ex.FileName, "#A3");
			Assert.IsNull (ex.InnerException, "#A4");
			Assert.IsNotNull (ex.Message, "#A5");
		}

		Assembly a = Assembly.Load ("libc, Version=9.7.5.3, Culture=neutral, PublicKeyToken=5ca3085bccb6d96f");
		AssemblyName an = a.GetName ();

		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#B1");
		Assert.IsNotNull (an.EscapedCodeBase, "#B2");
		Assert.AreEqual (AssemblyNameFlags.PublicKey | AssemblyNameFlags.Retargetable, an.Flags, "#B3");
		Assert.AreEqual ("libc, Version=9.7.5.3, Culture=neutral, PublicKeyToken=5ca3085bccb6d96f, Retargetable=Yes", an.FullName, "#B4");
		Assert.AreEqual (160, an.GetPublicKey ().Length, "#B5");
		Assert.AreEqual (new byte [] { 0x5c, 0xa3, 0x08, 0x5b, 0xcc, 0xb6, 0xd9, 0x6f }, an.GetPublicKeyToken (), "#B6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#B7");
		Assert.IsNull (an.KeyPair, "#B8");
		Assert.AreEqual ("libc", an.Name, "#B9");
#if NET_2_0
		Assert.AreEqual (ProcessorArchitecture.MSIL, an.ProcessorArchitecture, "#B10");
#endif
		Assert.AreEqual (an.FullName, an.ToString (), "#B11");
		Assert.AreEqual (new Version (9, 7, 5, 3), an.Version, "#B12");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#B13");

		Type type = a.GetType ("Foo");
		Assert.IsNotNull (type, "#C1");
		Assert.AreEqual ("Foo", type.FullName, "#C2");
		Assert.AreEqual ("Foo, libc, Version=9.7.5.3, Culture=neutral, PublicKeyToken=5ca3085bccb6d96f, Retargetable=Yes",
			type.AssemblyQualifiedName, "#C3");
	}
}
