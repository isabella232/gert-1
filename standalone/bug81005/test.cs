using System;
using System.IO;
using System.Net;

public class WebClientTest
{
	static int Main (string [] args)
	{
		string fileName = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"google.html");
		using (FileStream fs = File.Create (fileName)) {
			fs.WriteByte (5);
			fs.Close ();
		}
		WebClient wc = new WebClient ();
		wc.DownloadFile ("http://google.com/", fileName);
		using (StreamReader sr = File.OpenText (fileName)) {
			string content = sr.ReadToEnd ();
			if (content.IndexOf ("<html>") == -1)
				return 1;
		}
		return 0;
	}
}
