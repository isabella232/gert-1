using System;
using System.IO;
using System.Web.Services.Description;
using System.Web.Services.Discovery;

class Program
{
	static void Main ()
	{
		TestWebService svc = new TestWebService ();
		Assert.AreEqual ("Hello World", svc.HelloWorld (), "#1");

		string url = "http://127.0.0.1:8081/TestWebService.asmx?WSDL";

		DiscoveryClientProtocol dcp = new DiscoveryClientProtocol ();

		using (Stream s = dcp.Download (ref url)) {
			ServiceDescription sd = ServiceDescription.Read (s);
#if NET_2_0
			Assert.AreEqual (2, sd.Bindings.Count, "#A1");
			Assert.AreEqual ("TestWebServiceSoap", sd.Bindings [0].Name, "#A2");
			Assert.AreEqual ("http://tempuri.org/:TestWebServiceSoap", sd.Bindings [0].Type.ToString (), "#A3");
			Assert.AreEqual ("TestWebServiceSoap12", sd.Bindings [1].Name, "#A4");
			Assert.AreEqual ("http://tempuri.org/:TestWebServiceSoap", sd.Bindings [0].Type.ToString (), "#A5");
#else
			Assert.AreEqual (1, sd.Bindings.Count, "#A1");
			Assert.AreEqual ("TestWebServiceSoap", sd.Bindings [0].Name, "#A2");
			Assert.AreEqual ("http://tempuri.org/:TestWebServiceSoap", sd.Bindings [0].Type.ToString (), "#A3");
#endif

			Assert.AreEqual (1, sd.PortTypes.Count, "#B1");
			Assert.AreEqual ("TestWebServiceSoap", sd.PortTypes [0].Name, "#B2");
		}
	}
}
