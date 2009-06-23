using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public delegate byte [] SocketRequestHandler (Socket socket);

class SocketResponder : IDisposable
{
	private TcpListener tcpListener;
	private readonly IPEndPoint _localEndPoint;
	private Thread listenThread;
	private SocketRequestHandler _requestHandler;
	private bool _stopped = true;
	private readonly object _syncRoot = new object ();

	private const int SOCKET_CLOSED = 10004;

	public SocketResponder (IPEndPoint localEP, SocketRequestHandler requestHandler)
	{
		_localEndPoint = localEP;
		_requestHandler = requestHandler;
	}

	public IPEndPoint LocalEndPoint
	{
		get { return _localEndPoint; }
	}

	public void Dispose ()
	{
		Stop ();
	}

	public bool IsStopped
	{
		get
		{
			lock (_syncRoot) {
				return _stopped;
			}
		}
	}

	public void Start ()
	{
		lock (_syncRoot) {
			if (!_stopped)
				return;
			_stopped = false;
			tcpListener = new TcpListener (LocalEndPoint);
			tcpListener.Start ();
			listenThread = new Thread (new ThreadStart (Listen));
			listenThread.Start ();
			Thread.Sleep (50);
		}
	}

	public void Stop ()
	{
		lock (_syncRoot) {
			if (_stopped)
				return;
			_stopped = true;
			if (tcpListener != null) {
				tcpListener.Stop ();
				tcpListener = null;
				Thread.Sleep (100);
			}
		}
	}

	private void Listen ()
	{
		while (!_stopped) {
			Socket socket = null;

			try {
				socket = tcpListener.AcceptSocket ();
				socket.Send (_requestHandler (socket));
				try {
					socket.Shutdown (SocketShutdown.Receive);
					socket.Shutdown (SocketShutdown.Send);
				} catch {
				}
			} catch (SocketException ex) {
				// ignore interruption of blocking call
				if (ex.ErrorCode != SOCKET_CLOSED)
					throw;
			} finally {
				Thread.Sleep (100);
				if (socket != null)
					socket.Close ();
				Thread.Sleep (100);
			}
		}
	}
}
