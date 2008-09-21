#define DEBUG

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify action.");
			return 1;
		}

		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		string logfile = Path.Combine (basedir, "debug.log");

		switch (args [0]) {
		case "write":
			TextWriterTraceListener debugLog = new TextWriterTraceListener (logfile);
			Debug.AutoFlush = true;
			Debug.Listeners.Add (debugLog);
			Debug.Write ("OK");
			break;
		case "read":
			using (FileStream fs = new FileStream (Path.Combine (basedir, "debug.log"), FileMode.Open, FileAccess.Read, FileShare.Read)) {
				StreamReader sr = new StreamReader (fs, Encoding.Default, true);
#if ONLY_1_1 && !MONO
				Assert.AreEqual (string.Empty, sr.ReadToEnd (), "#1");
#else
				Assert.AreEqual ("OK", sr.ReadToEnd (), "#1");
#endif
				sr.Close ();
			}
			break;
		}

		return 0;
	}
}
