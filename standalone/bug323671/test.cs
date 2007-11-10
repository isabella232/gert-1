using System;
using System.Net;
using System.Threading;

class Program
{
	static void Main (string [] args)
	{
		StartRequest ();
		Thread.Sleep (5000);
	}

	static bool StartRequest ()
	{
		HttpWebRequest myRequest = (HttpWebRequest) WebRequest.Create ("http://www.google.com");
		myRequest.BeginGetResponse (new AsyncCallback (Callback), null);
		return true;
	}

	static void Callback (IAsyncResult ar)
	{
		throw new Exception ();
	}
}
