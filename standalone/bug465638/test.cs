using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace MonoHttpWebRequestBug
{
	class Program
	{
		const int Count = 5;

		static void Main (string [] args)
		{
			ServicePointManager.Expect100Continue = false;

			Thread listen = new Thread (new ThreadStart (Listener));
			listen.Start ();

			int completed = 0;

			for (int i = 0; i < Count; i++) {
				BeginRequestResponse (i, "http://127.0.0.1:8081/", "root", "Symf0rm!", () => completed++);
			}

			while (completed < Count)
				Thread.Sleep (100);

			listen.Join ();
		}

		static void Listener ()
		{
			HttpListener listener = new HttpListener ();
			listener.Prefixes.Add ("http://127.0.0.1:8081/");
			listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
			listener.Start ();

			int requestNumber = 0;

			while (true) {
				HttpListenerContext ctx = listener.GetContext ();

				Stream input = ctx.Request.InputStream;
				StreamReader sr = new StreamReader (input, ctx.Request.ContentEncoding);
				sr.ReadToEnd ();

				ctx.Response.ContentLength64 = 0;
				ctx.Response.StatusCode = 204;
				ctx.Response.StatusDescription = "No Content";

				ctx.Response.Close ();

				requestNumber++;
				if (requestNumber == Count)
					break;
			}
		}

		private class RequestContext
		{
			public Action Callback;
			public int Number;
			public byte [] Data;
			public HttpWebRequest Request;
			public Stream RequestStream;
		}

		private static void BeginRequestResponse (int i, string url, string userName, string password, Action callback)
		{
			byte [] data = new byte [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

			HttpWebRequest request = (HttpWebRequest) WebRequest.Create (new Uri (url));
			request.Method = "POST";
			request.ContentLength = data.Length;

			RequestContext context = new RequestContext { Request = request, Data = data, Number = i, Callback = callback };
			request.BeginGetRequestStream (RequestResponse2, context);
		}

		private static void RequestResponse2 (IAsyncResult result)
		{
			RequestContext context = result.AsyncState as RequestContext;

			context.RequestStream = context.Request.EndGetRequestStream (result);
			context.RequestStream.BeginWrite (context.Data, 0, context.Data.Length, RequestResponse3, context);
		}

		private static void RequestResponse3 (IAsyncResult result)
		{
			RequestContext context = result.AsyncState as RequestContext;

			context.RequestStream.EndWrite (result);
			context.RequestStream.Close ();
			context.RequestStream = null;

			context.Request.BeginGetResponse (RequestResponse4, context);
		}

		private static void RequestResponse4 (IAsyncResult result)
		{
			RequestContext context = result.AsyncState as RequestContext;

			HttpWebResponse response = null;

			try {
				response = context.Request.EndGetResponse (result) as HttpWebResponse;
				context.Callback ();
			} finally {
				response.Close ();
			}
		}
	}
}
