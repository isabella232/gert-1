using System;
using System.Net;
using System.Threading;

using Mono.WebServer;

class Program
{
	static void Main ()
	{
		XSPWebSource websource = new XSPWebSource (IPAddress.Any, 12344);
		ApplicationServer AppServer = new ApplicationServer (websource);
		AppServer.Start (true);
		Thread.Sleep (1000);
		AppServer.Stop ();
	}
}
