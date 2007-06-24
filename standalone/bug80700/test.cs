using System;
using System.IO;
using System.Net;

class Program
{
	[STAThread]
	static void Main (string [] args)
	{
		string tempFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, 
			"FileWebRequestTest.tmp");
		Uri tempFileUri = GetTempFileUri (tempFile);

		WebResponse res = null;

		try {
			FileWebRequest req = (FileWebRequest) WebRequest.Create (tempFileUri);
			req.Method = "PUT";
			req.Timeout = 1000;

			IAsyncResult async = req.BeginGetRequestStream (null, null);

			try {
				req.GetResponse ();
				throw new Exception ("#3 should've failed");
			} catch (WebException) {
				// The operation has timed out
			}

			using (Stream wstream = req.EndGetRequestStream (async)) {
				wstream.WriteByte (72);
				wstream.WriteByte (101);
				wstream.WriteByte (108);
				wstream.WriteByte (108);
				wstream.WriteByte (111);
			}
		} finally {
			if (res != null) {
				res.Close ();
			}
			File.Delete (tempFile);
		}
	}

	static Uri GetTempFileUri (string tmp)
	{
		string tempFile = tmp;
		if (RunningOnUnix) {
			// remove leading slash for absolute paths
			tempFile = tempFile.TrimStart ('/');
		} else {
			tempFile = tempFile.Replace ('\\', '/');
		}
		return new Uri ("file:///" + tempFile);
	}

	static bool RunningOnUnix {
		get {
			// check for Unix platforms - see FAQ for more details
			// http://www.mono-project.com/FAQ:_Technical#How_to_detect_the_execution_platform_.3F
			int platform = (int) Environment.OSVersion.Platform;
			return ((platform == 4) || (platform == 128));
		}
	}
}
