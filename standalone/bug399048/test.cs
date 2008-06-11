using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Threading;

class Program
{
	static void Main ()
	{
		ArrayList threads = new ArrayList ();

		for (int i = 0; i < 5; ++i) {
			Thread t = new Thread (new ThreadStart (Work));
			threads.Add (t);
			t.Start ();
		}

		for (int i = 0; i < 5; ++i) {
			Thread t = (Thread) threads [i];
			t.Join ();
		}
	}

	private static void Work ()
	{
		byte [] buffer = new byte [65536];

		for (int i = 0; i < 10; i++) {
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://www.mono-project.com/");

			using (HttpWebResponse response = (HttpWebResponse) request.GetResponse ()) {
				Stream responseStream = response.GetResponseStream ();

				while (responseStream.Read (buffer, 0, buffer.Length) > 0) {
				}
			}
		}
	}
}
