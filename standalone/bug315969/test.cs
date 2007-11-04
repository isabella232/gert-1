using System;
using System.Diagnostics;
using System.IO;

class Program
{
	static int Main ()
	{
		bool foundCurrent = false;
		bool foundServices = false;

		foreach (Process process in Process.GetProcesses ()) {
			switch (process.ProcessName) {
			case "bug315969":
				foundCurrent = true;
				if (process.MainModule.FileName != Path.Combine (AppDomain.CurrentDomain.BaseDirectory, process.ProcessName + ".exe"))
					return 1;
				break;
			case "services":
				foundServices = true;
				if (process.MainModule.FileName != Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.System), process.ProcessName + ".exe"))
					return 2;
				break;
			}
		}

		if (!foundCurrent)
			return 3;
		if (!foundServices)
			return 4;
		return 0;
	}
}
