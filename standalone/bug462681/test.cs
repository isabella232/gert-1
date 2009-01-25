using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main (string [] args)
	{
		HttpWebRequest request;
		HttpWebResponse response = null;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/test.asmx");
		request.Method = "GET";

		try {
			response = request.GetResponse () as HttpWebResponse;
			Assert.Fail ("#1");
		} catch (WebException ex) {
			response = ex.Response as HttpWebResponse;
			Assert.IsNotNull (response, "#2");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();
#if MONO
				Assert.IsTrue (result.IndexOf ("System.Web.HttpException") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("Type Bad.Bad not found.") != -1, "#4:" + result);
#else
				Assert.IsTrue (result.IndexOf ("HttpParseException") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("Could not create type 'Bad.Bad'.") != -1, "#4:" + result);
#endif
			}
		} finally {
			if (response != null)
				response.Close ();
		}

		return 0;
	}
}
