using System;
using System.Threading;
using System.Net;
using System.IO;
using System.Text;

class Program
{
	const int Count = 30;
	static AutoResetEvent [] events = new AutoResetEvent [Count];
	static int exit_code;

	static int Main ()
	{
		for (int i = 0; i < Count; i++) {
			events [i] = new AutoResetEvent (false);
			ThreadPool.QueueUserWorkItem (new WaitCallback (Callback), i);
		}

		AutoResetEvent.WaitAll (events);
		return exit_code;
	}

	static void Callback (object state)
	{
		bool result = DoGet ();
		if (!result)
			exit_code = 1;
		events [(int) state].Set ();
	}

	private static bool DoGet ()
	{
		try {
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://google.com");
			request.Timeout = 10000;

			using (WebResponse response = request.GetResponse ())
			using (Stream responseStream = response.GetResponseStream ()) {
				StreamReader reader = new StreamReader (responseStream);
				reader.ReadToEnd ();
			}
			return true;
		} catch (Exception e) {
			Console.WriteLine (e);
			return false;
		}
	}
}
