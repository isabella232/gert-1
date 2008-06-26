using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string cache_control = response.Headers ["Cache-Control"];
				Assert.IsNotNull (cache_control, "#A1");
				Assert.AreEqual ("private", cache_control, "#A2");

				string expires = response.Headers ["Expires"];
				Assert.IsNotNull (expires, "#B1");
				DateTime expires_time = DateTime.ParseExact (expires, "ddd, d MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
				Assert.IsTrue (expires_time > DateTime.UtcNow.AddMinutes (19), "#B2");
				Assert.IsTrue (expires_time < DateTime.UtcNow.AddMinutes (21), "#B3");

				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<title>bug #404083</title>") != -1, "#C:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 1;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string cache_control = response.Headers ["Cache-Control"];
				Assert.IsNotNull (cache_control, "#A1");
				Assert.AreEqual ("private", cache_control, "#A2");

				string expires = response.Headers ["Expires"];
				Assert.IsNull (expires, "#B");

				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<title>bug #404083</title>") != -1, "#C:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 1;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/start.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string cache_control = response.Headers ["Cache-Control"];
				Assert.IsNotNull (cache_control, "#A1");
				Assert.AreEqual ("private", cache_control, "#A2");

				string expires = response.Headers ["Expires"];
				Assert.IsNull (expires, "#B");

				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<title>bug #404083</title>") != -1, "#C:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 1;
		}

		return 0;
	}
}
