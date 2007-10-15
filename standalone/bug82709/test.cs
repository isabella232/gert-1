using System;
using System.IO;
using System.Net;
using System.Globalization;
using System.Text;

class Program
{
	static int Main ()
	{
		CookieContainer container = new CookieContainer ();

		if (!ExecuteRequest (container, 1))
			return 1;

		if (!ExecuteRequest (container, 2))
			return 2;

		if (!ExecuteRequest (new CookieContainer (), 1))
			return 3;

		if (!ExecuteRequest (container, 3))
			return 4;

		EndSession (container);

		if (!ExecuteRequest (container, 1))
			return 5;

		return 0;
	}

	static bool ExecuteRequest (CookieContainer container, int expectedCounter)
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.CookieContainer = container;
		request.Method = "GET";

		HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
		using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
			string result = sr.ReadToEnd ();
			string expected = string.Format (CultureInfo.InvariantCulture,
				"<span id=\"CounterLabel\">{0}</span>",
				expectedCounter);
			if (result.IndexOf (expected) == -1) {
				Console.WriteLine (result);
				return false;
			}
		}
		response.Close ();

		return true;
	}

	static void EndSession (CookieContainer container)
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/end.aspx");
		request.CookieContainer = container;
		request.Method = "GET";

		HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
		response.Close ();
	}
}
