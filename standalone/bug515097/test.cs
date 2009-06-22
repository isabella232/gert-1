using System;
using System.IO;
using System.Net;
using System.Threading;

class Program
{
	static void Main ()
	{
		ServicePointManager.Expect100Continue = false;

		DoRequest (
			() =>
			{
				byte [] data = new byte [64 * 1024];
				HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8001");
				request.Method = "POST";
				request.ContentLength = data.Length * 2;

				Stream s = request.GetRequestStream ();
				s.Write (data, 0, data.Length); // send a few bytes to start the transfer

				try {
					s.BeginWrite (data, 0, data.Length,
						(r) =>
						{
							try {
								s.EndWrite (r);
								Assert.Fail ("#1");
							} catch (ObjectDisposedException) {
							}
						},
						null);
				} finally {
					request.Abort ();
				}
			},
			(c) =>
			{
				c.Request.InputStream.ReadByte ();

				Thread.Sleep (Timeout.Infinite);
			});
	}

	private static void DoRequest (Action client, Action<HttpListenerContext> server)
	{
		using (ListenerScope scope = new ListenerScope (server)) {
			client ();
		}
	}

	private class ListenerScope : IDisposable
	{
		public HttpListener listener;
		Action<HttpListenerContext> processor;

		public ListenerScope (Action<HttpListenerContext> processor)
		{
			this.processor = processor;

			this.listener = new HttpListener ();
			this.listener.Prefixes.Add ("http://*:8001/");
			this.listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
			this.listener.Start ();

			this.listener.BeginGetContext (this.RequestHandler, null);
		}

		private void RequestHandler (IAsyncResult result)
		{
			HttpListenerContext context = null;

			try {
				context = this.listener.EndGetContext (result);
			} catch (HttpListenerException ex) {
				// check if the thread has been aborted as in the case when we are shutting down.
				if (ex.ErrorCode == 995) {
					return;
				}
			} catch (ObjectDisposedException) {
				return;
			}

			this.listener.BeginGetContext (this.RequestHandler, null);

			this.processor (context);
		}

		public void Dispose ()
		{
			this.listener.Stop ();
		}
	}
}
