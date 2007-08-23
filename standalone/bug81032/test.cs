using System;
using System.Net;

class Program
{
	[STAThread]
	static int Main ()
	{
		WebClient objClient = new WebClient ();
		objClient.DownloadStringCompleted += objClient_DownloadStringCompleted;
		objClient.DownloadStringAsync (new Uri ("http://www.google.com"));
		while (!_complete) {
		}
		if (_result == null)
			return 1;
		if (_result.IndexOf ("<html>") == -1)
			return 2;
		return 0;
	}

	static void objClient_DownloadStringCompleted (object objSender, DownloadStringCompletedEventArgs e)
	{
		_result = e.Result;
		_complete = true;
	}

	private static bool _complete = false;
	private static string _result;
}
