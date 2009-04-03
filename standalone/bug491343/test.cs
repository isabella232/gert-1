using System;
using System.Web;
using System.Web.Caching;
using System.Net;

class Program
{
	static void Main ()
	{
		Cache cache = HttpRuntime.Cache;
		cache ["hello"] = "world";

		Cache cacheClone = HttpRuntime.Cache;
		string s = cacheClone ["hello"] as String;
		Assert.AreEqual ("world", s, "#1");

#if NET_2_0
		System.Net.HttpListener listener = new System.Net.HttpListener ();
		listener.Prefixes.Add ("http://127.0.0.1:8081/");
		listener.Start ();

		Assert.IsTrue (listener.IsListening, "#2");
#endif
	}
}
