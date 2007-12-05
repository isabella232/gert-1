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
			Assert.AreEqual (4, sd.Bindings.Count, "#A1");
			Assert.AreEqual ("AnotherBinding", sd.Bindings [0].Name, "#A2");
			Assert.AreEqual ("http://tempuri.org/:AnotherBinding", sd.Bindings [0].Type.ToString (), "#A3");
			Assert.AreEqual ("AnotherBinding1", sd.Bindings [1].Name, "#A4");
			Assert.AreEqual ("http://tempuri.org/:AnotherBinding", sd.Bindings [1].Type.ToString (), "#A5");
			Assert.AreEqual ("TestWebServiceHttpGet", sd.Bindings [2].Name, "#A6");
			Assert.AreEqual ("http://tempuri.org/:TestWebServiceHttpGet", sd.Bindings [2].Type.ToString (), "#A7");
			Assert.AreEqual ("TestWebServiceHttpPost", sd.Bindings [3].Name, "#A8");
			Assert.AreEqual ("http://tempuri.org/:TestWebServiceHttpPost", sd.Bindings [3].Type.ToString (), "#A9");
#else
			Assert.AreEqual (3, sd.Bindings.Count, "#A1");
			Assert.AreEqual ("AnotherBinding", sd.Bindings [0].Name, "#A2");
			Assert.AreEqual ("http://tempuri.org/:AnotherBinding", sd.Bindings [0].Type.ToString (), "#A3");
			Assert.AreEqual ("TestWebServiceHttpGet", sd.Bindings [1].Name, "#A6");
			Assert.AreEqual ("http://tempuri.org/:TestWebServiceHttpGet", sd.Bindings [1].Type.ToString (), "#A7");
			Assert.AreEqual ("TestWebServiceHttpPost", sd.Bindings [2].Name, "#A8");
			Assert.AreEqual ("http://tempuri.org/:TestWebServiceHttpPost", sd.Bindings [2].Type.ToString (), "#A9");
#endif

			Assert.AreEqual (3, sd.PortTypes.Count, "#B1");
			Assert.AreEqual ("AnotherBinding", sd.PortTypes [0].Name, "#B2");
			Assert.AreEqual ("TestWebServiceHttpGet", sd.PortTypes [1].Name, "#B3");
			Assert.AreEqual ("TestWebServiceHttpPost", sd.PortTypes [2].Name, "#B4");
		}
	}
}
