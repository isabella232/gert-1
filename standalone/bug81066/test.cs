using System;
using System.IO;
using System.Net;
using System.Text;

public class WebClientTest
{
	static int Main (string [] args)
	{
		WebClient wc = new WebClient ();
		string filename = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"temp.html");
		File.Delete (filename);
		wc.DownloadFile ("http://google.com/", filename);
		if (!File.Exists (filename))
			return 1;

		using (StreamReader sr = new StreamReader (filename, Encoding.Default, true)) {
			string content = sr.ReadToEnd ();
			if (content.IndexOf ("<title>Google</title>") == -1) {
				Console.WriteLine (content);
				return 2;
			}
		}

		return 0;
	}
}
