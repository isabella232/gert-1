using System;
using System.IO;
using System.Net;

public class Test
{
	static int Main ()
	{
		WebClient wc = new WebClient ();
		wc.Credentials = new NetworkCredential ("anonymous", "password");
		string filename = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"download.bin");
		File.Delete (filename);
		wc.DownloadFile ("ftp://ftp.adobe.com/Acrobat/WHA Library CHS.bin", filename);
		if (!File.Exists (filename))
			return 1;
		wc.DownloadFile ("ftp://ftp.adobe.com/Acrobat/WHA Library CHS.bin", filename);
		if (!File.Exists (filename))
			return 2;
		File.Delete (filename);
		wc.DownloadFile ("ftp://ftp.adobe.com/Acrobat/WHA%20Library%20CHS.bin", filename);
		if (!File.Exists (filename))
			return 3;
		return 0;
	}
}
