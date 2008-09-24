using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

using BaseLib;

namespace ClientAsync
{
	class Client
	{
		delegate void SetValueDelegate (int pValue);
		delegate int GetValueDelegate ();
		delegate string GetTextDelegate ();

		[STAThread]
		static void Main (string [] args)
		{
			DateTime start = DateTime.Now;
			HttpChannel chnl = new HttpChannel ();
#if NET_2_0
			ChannelServices.RegisterChannel (chnl, false);
#else
			ChannelServices.RegisterChannel (chnl);
#endif
			BaseRemoteObject obj = (BaseRemoteObject) Activator.GetObject (typeof (BaseRemoteObject),
				"http://localhost:1237/MyRemoteObject.soap");
			Test test = new Test ();
			test.t = "test";

			obj.test = test;
			SetValueDelegate svd = new SetValueDelegate (obj.setValue);
			IAsyncResult arValSet = svd.BeginInvoke (625, null, null);
			svd.EndInvoke (arValSet);

			GetValueDelegate gvd = new GetValueDelegate (obj.getValue);
			IAsyncResult arValGet = gvd.BeginInvoke (null, null);

			GetTextDelegate gtd = new GetTextDelegate (obj.getText);
			IAsyncResult arTxt = gtd.BeginInvoke (null, null);

			int iVal = gvd.EndInvoke (arValGet);
			string str = gtd.EndInvoke (arTxt);
			TimeSpan elapsed = DateTime.Now - start;

			Assert.AreEqual (625, iVal, "#A1");
			Assert.AreEqual ("Narendra", str, "#A2");

			Assert.IsTrue (elapsed.TotalMilliseconds > 9000, "#B1:" + elapsed.TotalMilliseconds);
			Assert.IsTrue (elapsed.TotalMilliseconds < 12000, "#B2:" + elapsed.TotalMilliseconds);
		}
	}
}
