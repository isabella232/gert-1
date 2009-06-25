using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public delegate byte [] SocketRequestHandler (Socket socket);

class SocketResponder : IDisposable
{
	private Socket listener;
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
		Start ();
	}

	public IPEndPoint LocalEndPoint {
		get { return _localEndPoint; }
	}

	public bool IsStopped {
		get {
			lock (_syncRoot) {
				return _stopped;
			}
		}
	}

	public void Start ()
	{
		lock (_syncRoot) {
			if (!_stopped)
				throw new InvalidOperationException ("This instance is already started.");
			_stopped = false;

			listener = new Socket (0, SocketType.Stream, ProtocolType.Tcp);
			listener.Bind (_localEndPoint);
			listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, 0);
			listener.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.NoDelay, 1);
			listener.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 0);
			listener.Blocking = true;
			listener.Listen (-1);
			listenThread = new Thread (new ThreadStart (Listen));
			listenThread.Start ();
			Thread.Sleep (500);
		}
	}

	public void Stop ()
	{
		lock (_syncRoot) {
			if (_stopped)
				return;
			_stopped = true;
			if (listener != null) {
				try {
					if (listener.Connected) {
						listener.Shutdown (SocketShutdown.Send);
					}
					listener.Close ();
				} catch { }
				listener = null;
				Thread.Sleep (100);
			}
			listenThread.Join ();
		}
	}

	public void Dispose ()
	{
		Stop ();
	}

	private void Listen ()
	{
		while (!_stopped) {
			Socket socket = null;

			try {
				socket = listener.Accept ();
			} catch (SocketException ex) {
				// ignore interruption of blocking call
				if (ex.ErrorCode != SOCKET_CLOSED)
					throw;
				break;
			}

			RequestProcessor processor = new RequestProcessor (socket,
				_requestHandler);
			Thread t = new Thread (new ThreadStart (processor.Process));
			t.Start ();
		}
	}

	class RequestProcessor
	{
		private Socket _socket;
		private SocketRequestHandler _handler;

		public RequestProcessor (Socket socket, SocketRequestHandler handler)
		{
			_socket = socket;
			_handler = handler;
		}

		public void Process ()
		{
			try {
				_socket.Send (_handler (_socket));
			} catch (SocketException ex) {
				// ignore interruption of blocking call
				if (ex.ErrorCode != SOCKET_CLOSED)
					throw;
			} finally {
				try {
					_socket.Shutdown (SocketShutdown.Receive);
					_socket.Shutdown (SocketShutdown.Send);
				} catch {
				}

				Thread.Sleep (100);
				_socket.Close ();
				Thread.Sleep (100);
			}
		}
	}
}
