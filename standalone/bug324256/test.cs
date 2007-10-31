using System;
using System.Globalization;
using System.Net;

class Program
{
	static int Main ()
	{
		Service svc = new Service ();
		Assert.AreEqual (1, svc.GetSessionCounter (), "#A2");
		Assert.AreEqual (1, svc.GetSessionCounter (), "#A1");
		Assert.AreEqual (1, svc.GetSessionCounter (), "#A2");
		Assert.AreEqual (1, svc.GetApplicationCounter (), "#A3");
		Assert.AreEqual (2, svc.GetApplicationCounter (), "#A4");
		Assert.IsTrue (svc.HasApplication (), "#A5");
		Assert.IsFalse (svc.HasSession (), "#A6");

		svc = new Service ();
		svc.CookieContainer = new CookieContainer ();
		Assert.AreEqual (1, svc.GetSessionCounter (), "#B1");
		Assert.AreEqual (2, svc.GetSessionCounter (), "#B2");
		Assert.AreEqual (3, svc.GetApplicationCounter (), "#B3");
		Assert.AreEqual (4, svc.GetApplicationCounter (), "#B4");
		Assert.IsTrue (svc.HasApplication (), "#B5");
		Assert.IsFalse (svc.HasSession (), "#B6");

		return 0;
	}
}
