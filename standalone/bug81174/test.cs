using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Create.aspx");
		request.Method = "GET";

		HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
		using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
			string result = sr.ReadToEnd ();
			if (result.IndexOf ("Een titel") == -1) {
				Console.WriteLine (result);
				return 1;
			}
			if (result.IndexOf ("Hoofding") == -1) {
				Console.WriteLine (result);
				return 2;
			}
		}
		response.Close ();

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		response = (HttpWebResponse) request.GetResponse ();
		using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
			string result = sr.ReadToEnd ();
			if (result.IndexOf ("Noot") == -1) {
				Console.WriteLine (result);
				return 3;
			}
			if (result.IndexOf ("Inhoudstafel") == -1) {
				Console.WriteLine (result);
				return 4;
			}
		}
		response.Close ();

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Sub/Default.aspx");
		request.Method = "GET";

		response = (HttpWebResponse) request.GetResponse ();
		using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
			string result = sr.ReadToEnd ();
			if (result.IndexOf ("Noot") == -1) {
				Console.WriteLine (result);
				return 5;
			}
			if (result.IndexOf ("Inhoudsopgave") == -1) {
				Console.WriteLine (result);
				return 6;
			}
		}
		response.Close ();

		return 0;
	}
}
