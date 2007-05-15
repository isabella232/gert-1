using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

class Program
{
	static int Main ()
	{
		//the number of socket listeners
		const int NUM_SOCKETS = 100;

		//the wait events for each of the socket listeners
		ManualResetEvent [] socketWaitEvents = new ManualResetEvent [NUM_SOCKETS];

		Socket [] sockets = new Socket [NUM_SOCKETS];

		//initialize all the listeners and start them listening
		for (int i = 0; i < sockets.Length; i++) {
			Socket s = new Socket (AddressFamily.InterNetwork, SocketType.Stream,
				ProtocolType.Tcp);
			s.Bind (new IPEndPoint (IPAddress.Parse ("0.0.0.0"), 0));
			s.Listen (int.MaxValue);

			sockets [i] = s;
			socketWaitEvents [i] = new ManualResetEvent (false);
		}

		//start accepting incoming connections (even though we wont get any)
		for (int i = 0; i < sockets.Length; i++) {
			sockets [i].BeginAccept (new AsyncCallback (BeginAcceptCallback),
				socketWaitEvents [i]);
		}

		//let the system digest everything we just told it to do
		Thread.Sleep (50);

		//close down all the listeners
		for (int i = 0; i < sockets.Length; i++) {
			sockets [i].Close ();
		}

		//make sure that we get the beginacceptcallback for all the listeners
		for (int i = 0; i < socketWaitEvents.Length; i++) {
			if (!socketWaitEvents [i].WaitOne (100, false))
				return 1;
		}
		return 0;
	}

	static void BeginAcceptCallback (IAsyncResult asyncResult)
	{
		((ManualResetEvent) asyncResult.AsyncState).Set ();
	}
}
