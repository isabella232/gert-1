using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

public class ParentObject : MarshalByRefObject
{
	static int Main ()
	{
		AppDomainSetup domainsetup = new AppDomainSetup ();
		domainsetup.ShadowCopyFiles = "true";
		AppDomain plugindomain = AppDomain.CreateDomain ("BugTest", null, domainsetup);

		RemotingObject assldr = (RemotingObject) plugindomain.CreateInstanceAndUnwrap (
			typeof (RemotingObject).Assembly.FullName,
			typeof (RemotingObject).FullName);

		string dir = AppDomain.CurrentDomain.BaseDirectory;
		if (dir.EndsWith (Path.DirectorySeparatorChar.ToString ()))
			dir = dir.Substring (0, dir.Length - 1);

		if (assldr.StartupPath != dir)
			return 1;
		if (assldr.ExecutablePath != Path.Combine (dir, "test.exe"))
			return 2;
		return 0;
	}
}

public class RemotingObject : MarshalByRefObject
{
	public string StartupPath {
		get {
			return Application.StartupPath;
		}
	}

	public string ExecutablePath {
		get {
			return Application.ExecutablePath;
		}
	}

	public string ProcessName {
		get {
			return Process.GetCurrentProcess ().ProcessName;
		}
	}
}
