using System;
using System.Configuration.Assemblies;
using System.Globalization;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Assembly a = Assembly.GetExecutingAssembly ();
		AssemblyName [] refs = a.GetReferencedAssemblies ();

		AssemblyName an = FindByName (refs, "liba");

		Assert.IsNotNull (an, "#A1");
		Assert.IsNull (an.CodeBase, "#A2");
		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#A3");
		Assert.IsNull (an.EscapedCodeBase, "#A4");
		Assert.AreEqual (AssemblyNameFlags.None, an.Flags, "#A5");
		Assert.AreEqual ("liba, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null", an.FullName, "#A6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#A7");
		Assert.IsNull (an.KeyPair, "#A8");
		Assert.AreEqual ("liba", an.Name, "#A9");
#if NET_2_0
		Assert.AreEqual (ProcessorArchitecture.None, an.ProcessorArchitecture, "#A10");
#endif
		Assert.AreEqual (new Version (1, 0, 0, 1), an.Version, "#A11");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#A12");
		Assert.IsNull (an.GetPublicKey (), "#A13");
		Assert.IsNotNull (an.GetPublicKeyToken (), "#A14a");
		Assert.AreEqual (0, an.GetPublicKeyToken ().Length, "#A14b");
		Assert.AreEqual (an.FullName, an.ToString (), "#A15");

		an = FindByName (refs, "libb");

		Assert.IsNotNull (an, "#B1");
		Assert.IsNull (an.CodeBase, "#B2");
		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#B3");
		Assert.IsNull (an.EscapedCodeBase, "#B4");
		Assert.AreEqual (AssemblyNameFlags.None, an.Flags, "#B5");
		Assert.AreEqual ("libb, Version=1.2.0.0, Culture=neutral, PublicKeyToken=8dcf90ebde298dcd", an.FullName, "#B6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#B7");
		Assert.IsNull (an.KeyPair, "#B8");
		Assert.AreEqual ("libb", an.Name, "#B9");
#if NET_2_0
		Assert.AreEqual (ProcessorArchitecture.None, an.ProcessorArchitecture, "#B10");
#endif
		Assert.AreEqual (new Version (1, 2, 0, 0), an.Version, "#B11");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#B12");
		Assert.IsNull (an.GetPublicKey (), "#B13");
		Assert.IsNotNull (an.GetPublicKeyToken (), "#B14a");
		Assert.AreEqual (8, an.GetPublicKeyToken ().Length, "#B14b");
		Assert.AreEqual (an.FullName, an.ToString (), "#B15");

		an = FindByName (refs, "libc");

		Assert.IsNotNull (an, "#C1");
		Assert.IsNull (an.CodeBase, "#C2");
		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#C3");
		Assert.IsNull (an.EscapedCodeBase, "#C4");
		Assert.AreEqual (AssemblyNameFlags.None, an.Flags, "#C5");
		Assert.AreEqual ("libc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=8dcf90ebde298dcd", an.FullName, "#C6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#C7");
		Assert.IsNull (an.KeyPair, "#C8");
		Assert.AreEqual ("libc", an.Name, "#C9");
#if NET_2_0
		Assert.AreEqual (ProcessorArchitecture.None, an.ProcessorArchitecture, "#C10");
#endif
		Assert.AreEqual (new Version (1, 0, 0, 0), an.Version, "#C11");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#C12");
		Assert.IsNull (an.GetPublicKey (), "#C13");
		Assert.IsNotNull (an.GetPublicKeyToken (), "#C14a");
		Assert.AreEqual (8, an.GetPublicKeyToken ().Length, "#C14b");
		Assert.AreEqual (an.FullName, an.ToString (), "#C15");

		a = typeof (Foo).Assembly;
		an = a.GetName ();

		Assert.IsNotNull (an, "#D1");
		Assert.IsNotNull (an.CodeBase, "#D2");
		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#D3");
		Assert.IsNotNull (an.EscapedCodeBase, "#D4");
		Assert.AreEqual (AssemblyNameFlags.PublicKey, an.Flags, "#D5");
		Assert.AreEqual ("liba, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null", an.FullName, "#D6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#D7");
		Assert.IsNull (an.KeyPair, "#D8");
		Assert.AreEqual ("liba", an.Name, "#D9");
#if NET_2_0
		//Assert.AreEqual (ProcessorArchitecture.MSIL, an.ProcessorArchitecture, "#D10");
#endif
		Assert.AreEqual (new Version (1, 0, 0, 1), an.Version, "#D11");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#D12");
		Assert.IsNotNull (an.GetPublicKey (), "#D13a");
		Assert.AreEqual (0, an.GetPublicKey ().Length, "#D13b");
#if NET_2_0
		Assert.IsNotNull (an.GetPublicKeyToken (), "#D14a");
		Assert.AreEqual (0, an.GetPublicKeyToken ().Length, "#D14b");
#else
		Assert.IsNull (an.GetPublicKeyToken (), "#D14");
#endif
		Assert.AreEqual (an.FullName, an.ToString (), "#D15");

		a = typeof (Bar).Assembly;
		an = a.GetName ();

		Assert.IsNotNull (an, "#E1");
		Assert.IsNotNull (an.CodeBase, "#E2");
		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#E3");
		Assert.IsNotNull (an.EscapedCodeBase, "#E4");
		Assert.AreEqual (AssemblyNameFlags.PublicKey, an.Flags, "#E5");
		Assert.AreEqual ("libb, Version=1.2.0.0, Culture=neutral, PublicKeyToken=8dcf90ebde298dcd", an.FullName, "#E6");
		Assert.AreEqual (AssemblyHashAlgorithm.SHA1, an.HashAlgorithm, "#E7");
		Assert.IsNull (an.KeyPair, "#E8");
		Assert.AreEqual ("libb", an.Name, "#E9");
#if NET_2_0
		//Assert.AreEqual (ProcessorArchitecture.MSIL, an.ProcessorArchitecture, "#E10");
#endif
		Assert.AreEqual (new Version (1, 2, 0, 0), an.Version, "#E11");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#E12");
		Assert.IsNotNull (an.GetPublicKey (), "#E13a");
		Assert.AreEqual (160, an.GetPublicKey ().Length, "#E13b");
		Assert.IsNotNull (an.GetPublicKeyToken (), "#E14a");
		Assert.AreEqual (8, an.GetPublicKeyToken ().Length, "#E14b");
		Assert.AreEqual (an.FullName, an.ToString (), "#E15");

		a = typeof (Woo).Assembly;
		an = a.GetName ();

		Assert.IsNotNull (an, "#F1");
		Assert.IsNotNull (an.CodeBase, "#F2");
		Assert.AreEqual (CultureInfo.InvariantCulture, an.CultureInfo, "#F3");
		Assert.IsNotNull (an.EscapedCodeBase, "#F4");
		Assert.AreEqual (AssemblyNameFlags.PublicKey, an.Flags, "#F5");
		Assert.AreEqual ("libc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=8dcf90ebde298dcd", an.FullName, "#F6");
		Assert.AreEqual (AssemblyHashAlgorithm.MD5, an.HashAlgorithm, "#F7");
		Assert.IsNull (an.KeyPair, "#F8");
		Assert.AreEqual ("libc", an.Name, "#F9");
#if NET_2_0
		//Assert.AreEqual (ProcessorArchitecture.MSIL, an.ProcessorArchitecture, "#F10");
#endif
		Assert.AreEqual (new Version (1, 0, 0, 0), an.Version, "#F11");
		Assert.AreEqual (AssemblyVersionCompatibility.SameMachine,
			an.VersionCompatibility, "#F12");
		Assert.IsNotNull (an.GetPublicKey (), "#F13a");
		Assert.AreEqual (160, an.GetPublicKey ().Length, "#F13b");
		Assert.IsNotNull (an.GetPublicKeyToken (), "#F14a");
		Assert.AreEqual (8, an.GetPublicKeyToken ().Length, "#F14b");
		Assert.AreEqual (an.FullName, an.ToString (), "#F15");
	}

	static AssemblyName FindByName (AssemblyName [] anames, string name)
	{
		foreach (AssemblyName an in anames)
			if (an.Name == name)
				return an;
		return null;
	}
}
