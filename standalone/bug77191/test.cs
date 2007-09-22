using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MonoRemotingBug
{
	interface I1 : IDisposable
	{
		void Test1 ();
	}

	interface I2
	{
		void Test2 ();
		void Test2 (bool argument);
	}

	interface I3 : I1, I2
	{
	}

	interface I4 : I1
	{
	}

	interface I5 : I4, I3
	{
	}

	class RemotedClass : MarshalByRefObject, I5
	{
		~RemotedClass ()
		{
			Dispose (false);
		}

		public void Test1 ()
		{
			Console.WriteLine ("Test1 OK.");
		}

		public void Test2 ()
		{
			Console.WriteLine ("Test2.1 OK");
		}

		public void Test2 (bool argument)
		{
			Console.WriteLine ("Test2.2 OK");
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (disposing)
				Console.WriteLine ("Test3 OK");
		}
	}

	class Program
	{
		static int FindFreePort ()
		{
			Socket socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try {
				socket.Bind (new IPEndPoint (IPAddress.Loopback, 0));
				return ((IPEndPoint) socket.LocalEndPoint).Port;
			} finally {
				socket.Close ();
			}
		}

		static int Main (string [] args)
		{
			try {
				int port = FindFreePort ();
				Console.WriteLine (port);
#if NET_2_0
				ChannelServices.RegisterChannel (new TcpChannel (port), false);
#else
				ChannelServices.RegisterChannel (new TcpChannel (port));
#endif
				RemotedClass remotedClass = new RemotedClass ();
				RemotingServices.Marshal (remotedClass, "Root");
				try {
					I5 i = (I5) RemotingServices.Connect (typeof (I5),
						string.Format ("tcp://" + IPAddress.Loopback.ToString ()
						+ ":{0}/Root", port));
					i.Test1 ();
					i.Test2 ();
					i.Test2 (true);
					i.Dispose ();
					return 0;
				} finally {
					RemotingServices.Disconnect (remotedClass);
				}
			} catch (Exception e) {
				Console.Error.WriteLine (e);
				return 1;
			}
		}
	}
}
