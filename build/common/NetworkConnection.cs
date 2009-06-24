using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class NetworkConnection
{
	private readonly object _syncRoot = new object ();
	private StreamReader _stdOut;
	private StringBuilder _output;
	private readonly IPEndPoint ep;

	public NetworkConnection (IPEndPoint ep)
	{
		this.ep = ep;
	}

	public bool IsActive
	{
		get
		{
			lock (_syncRoot) {
				string tempFile = Path.GetTempFileName ();
				try {
					PerformNetStat (tempFile);
					return GrepOutput (tempFile);
				} finally {
					File.Delete (tempFile);
				}
			}
		}
	}

	void PerformNetStat (string outFile)
	{
		Process p = new Process ();
		p.StartInfo.FileName = "netstat";
		p.StartInfo.Arguments = "-n";
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.RedirectStandardOutput = true;

		p.Start ();

		_output = new StringBuilder ();
		Thread outputThread = new Thread (new ThreadStart (NetStatus_Output));
		_stdOut = p.StandardOutput;
		outputThread.Start ();

		try {
			p.Start ();
		} finally {
			outputThread.Join (2000);
		}

		// on Windows, netstat does not exit when redirecting stdout
		if (!p.WaitForExit (3000)) {
			p.Kill ();
		} else {
			if (p.ExitCode != 0)
				throw new Exception (string.Format (CultureInfo.InvariantCulture,
					"Failure checking network connections. Exit code '{0}'.",
					p.ExitCode));
		}

		using (FileStream fs = File.OpenWrite (outFile)) {
			StreamWriter sw = new StreamWriter (fs, Encoding.UTF8);
			sw.Write (_output.ToString ());
			sw.Close ();
		}
	}

	void NetStatus_Output ()
	{
		StreamReader reader = _stdOut;

		while (true) {
			string line = reader.ReadLine ();
			if (line == null)
				break;

			_output.Append (line);
			_output.Append (Environment.NewLine);
		}
	}

	bool GrepOutput (string outFile)
	{
		if (!File.Exists (outFile))
			throw new Exception ("Netstat output file does not exist.");

		Process p = new Process ();
		p.StartInfo.FileName = "grep";
		p.StartInfo.Arguments = ep.ToString () + " \"" + outFile + "\"";
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.CreateNoWindow = true;
		p.Start ();

		if (!p.WaitForExit (2000)) {
			p.Kill ();
			throw new Exception ("Failure checking netstat output.");
		}

		return (p.ExitCode == 0);
	}
}
