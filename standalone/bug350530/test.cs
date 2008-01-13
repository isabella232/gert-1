using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Policy;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		string tempFile = Path.Combine (dir, "temp");
		string logFile = Path.Combine (dir, "log");

		AppDomain dA = AppDomain.CreateDomain ("New App Domain");
		dA.ExecuteAssembly ("a.exe");
		AppDomain.Unload (dA);

		Assert.IsTrue (File.Exists (tempFile), "#A1");
		Assert.IsFalse (File.Exists (logFile), "#A2");
		File.Delete (tempFile);

#if NET_2_0
		AppDomain dB = AppDomain.CreateDomain ("New App Domain 2");
		dB.ExecuteAssemblyByName ("a");
		AppDomain.Unload (dB);

		Assert.IsTrue (File.Exists (tempFile), "#B1");
		Assert.IsFalse (File.Exists (logFile), "#B2");
		File.Delete (tempFile);
#endif

		AppDomain dC = AppDomain.CreateDomain ("New App Domain");
		dC.ExecuteAssembly ("a.exe", AppDomain.CurrentDomain.Evidence,
			new string [] { logFile });
		AppDomain.Unload (dC);

		Assert.IsFalse (File.Exists (tempFile), "#C1");
		Assert.IsTrue (File.Exists (logFile), "#C2");
		File.Delete (logFile);

#if NET_2_0
		AppDomain dD = AppDomain.CreateDomain ("New App Domain 2");
		dD.ExecuteAssemblyByName ("a", AppDomain.CurrentDomain.Evidence,
			new string [] { logFile });
		AppDomain.Unload (dD);

		Assert.IsFalse (File.Exists (tempFile), "#D1");
		Assert.IsTrue (File.Exists (logFile), "#D2");
		File.Delete (logFile);
#endif

		AppDomain dE = AppDomain.CreateDomain ("New App Domain");
		dE.ExecuteAssembly ("a.exe", (Evidence) null, (string []) null);
		AppDomain.Unload (dE);

		Assert.IsTrue (File.Exists (tempFile), "#E1");
		Assert.IsFalse (File.Exists (logFile), "#E2");
		File.Delete (tempFile);

#if NET_2_0
		AppDomain dF = AppDomain.CreateDomain ("New App Domain 2");
		dF.ExecuteAssemblyByName ("a", (Evidence) null, (string []) null);
		AppDomain.Unload (dF);

		Assert.IsTrue (File.Exists (tempFile), "#F1");
		Assert.IsFalse (File.Exists (logFile), "#F2");
		File.Delete (tempFile);
#endif

		AppDomain dG = AppDomain.CreateDomain ("New App Domain");
		try {
			dG.ExecuteAssembly ("b.dll");
			Assert.Fail ("#G1");
#if NET_2_0
		} catch (MissingMethodException ex) {
			// Entry point not found in assembly '...'
			Assert.AreEqual (typeof (MissingMethodException), ex.GetType (), "#G2");
			Assert.IsNull (ex.InnerException, "#G3");
			Assert.IsNotNull (ex.Message, "#G4");
			Assert.IsTrue (ex.Message.IndexOf ("'b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'") != -1, "#G5");
#else
		} catch (COMException ex) {
			// Unspecified error
			Assert.AreEqual (typeof (COMException), ex.GetType (), "#G2");
			Assert.AreEqual (-2147467259, ex.ErrorCode, "#G3");
			Assert.IsNull (ex.InnerException, "#G4");
			Assert.IsNotNull (ex.Message, "#G5");
#endif
		} finally {
			AppDomain.Unload (dG);
		}

#if NET_2_0
		AppDomain dH = AppDomain.CreateDomain ("New App Domain 2");
		try {
			dH.ExecuteAssemblyByName ("b");
			Assert.Fail ("#H1");
		} catch (MissingMethodException ex) {
			// Entry point not found in assembly '...'
			Assert.AreEqual (typeof (MissingMethodException), ex.GetType (), "#H2");
			Assert.IsNull (ex.InnerException, "#H3");
			Assert.IsNotNull (ex.Message, "#H4");
			Assert.IsTrue (ex.Message.IndexOf ("'b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'") != -1, "#H5");
		} finally {
			AppDomain.Unload (dH);
		}
#endif

		AppDomain dI = AppDomain.CreateDomain ("New App Domain");
		try {
			dI.ExecuteAssembly ("c.dll");
			Assert.Fail ("#I1");
		} catch (BadImageFormatException ex) {
			// Could not load file or assembly '...' or one of its
			// dependencies. The module was expected to contain an
			// assembly manifest
			Assert.AreEqual (typeof (BadImageFormatException), ex.GetType (), "#I2");
			Assert.IsNotNull (ex.FileName, "#I3");
			Assert.IsTrue (ex.FileName.IndexOf ("c.dll") != -1, "#I4");
			Assert.IsNull (ex.InnerException, "#I5");
			Assert.IsNotNull (ex.Message, "#I6");
			Assert.IsTrue (ex.Message.IndexOf ("c.dll") != -1, "#I7");
		} finally {
			AppDomain.Unload (dI);
		}

#if NET_2_0 && !MONO // bug #353537
		AppDomain dJ = AppDomain.CreateDomain ("New App Domain 2");
		try {
			dJ.ExecuteAssemblyByName ("c");
			Assert.Fail ("#J1");
		} catch (BadImageFormatException ex) {
			// Could not load file or assembly '...' or one of its
			// dependencies. The module was expected to contain an
			// assembly manifest
			Assert.AreEqual (typeof (BadImageFormatException), ex.GetType (), "#J2");
			Assert.AreEqual ("c", ex.FileName, "#J3");
			Assert.IsNull (ex.InnerException, "#J4");
			Assert.IsNotNull (ex.Message, "#J5");
			Assert.IsTrue (ex.Message.IndexOf ("'c'") != -1, "#J6");
		} finally {
			AppDomain.Unload (dJ);
		}
#endif

		AppDomain dK = AppDomain.CreateDomain ("New App Domain");
		try {
			dK.ExecuteAssembly ("d.dll");
			Assert.Fail ("#I1");
		} catch (FileNotFoundException ex) {
			// Could not load file or assembly '...' or one of its
			// dependencies. The system cannot find the file specified
			Assert.AreEqual (typeof (FileNotFoundException), ex.GetType (), "#K2");
			Assert.IsNotNull (ex.FileName, "#K3");
			Assert.IsTrue (ex.FileName.IndexOf ("d.dll") != -1, "#K4");
			Assert.IsNull (ex.InnerException, "#K5");
			Assert.IsNotNull (ex.Message, "#K6");
			Assert.IsTrue (ex.Message.IndexOf ("d.dll") != -1, "#K7");
		} finally {
			AppDomain.Unload (dK);
		}

#if NET_2_0
		AppDomain dL = AppDomain.CreateDomain ("New App Domain 2");
		try {
			dL.ExecuteAssemblyByName ("d");
			Assert.Fail ("#L1");
		} catch (FileNotFoundException ex) {
			// Could not load file or assembly 'd' or one of its
			// dependencies. The system cannot find the file specified
			Assert.AreEqual (typeof (FileNotFoundException), ex.GetType (), "#L2");
			Assert.AreEqual ("d", ex.FileName, "#L3");
			Assert.IsNull (ex.InnerException, "#L4");
			Assert.IsNotNull (ex.Message, "#L5");
			Assert.IsTrue (ex.Message.IndexOf ("'d'") != -1, "#L6");
		} finally {
			AppDomain.Unload (dL);
		}
#endif
	}
}
