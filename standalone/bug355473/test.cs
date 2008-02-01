using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		return RunTest ();
	}

	static int RunTest ()
	{
		using (TcpClient client = new TcpClient ()) {
			client.NoDelay = true;
			int _portNum = 50000;

			StartArgs startArgs = new StartArgs ();
			startArgs.client = client;
			startArgs.portNum = _portNum;
			startArgs.waitHandle = new AutoResetEvent (false);
			ThreadPool.QueueUserWorkItem (new WaitCallback (OnSocketConnect), startArgs);

			if (startArgs.waitHandle.WaitOne (25000, false)) {
				client.Close ();
				return 1;
			} else {
				return 0;
			}
		}
	}

	static void OnSocketConnect (object result)
	{
		StartArgs args = (StartArgs) result;
		TcpClient client = args.client;
		int tryCount = 0;
		while (!client.Connected && tryCount++ < 10) {
			try {
				client.Connect ("localhost", args.portNum);
				throw new Exception ("Connection should have failed");
			} catch (SocketException) {
			}
			Thread.Sleep (150);
		}
		if (!client.Connected) {
			client.Close ();
			return;
		}
		args.waitHandle.Set ();
	}

	struct StartArgs
	{
		public TcpClient client;
		public int portNum;
		public AutoResetEvent waitHandle;
	}
}
