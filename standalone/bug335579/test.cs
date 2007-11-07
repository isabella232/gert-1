using System;
using System.Collections;
using System.Threading;

class Program
{
	private static ArrayList _threads = new ArrayList ();

	static int Main ()
	{
		if (Thread.CurrentThread.ManagedThreadId <= 0)
			return 1;

		ThreadPool.QueueUserWorkItem (AnotherThread);
		ThreadPool.QueueUserWorkItem (AnotherThread);
		ThreadPool.QueueUserWorkItem (AnotherThread);
		Thread.Sleep (300);

		if (_threads.Count != 3)
			return 2;

		ThreadIdentity id0 = (ThreadIdentity) _threads [0];
		ThreadIdentity id1 = (ThreadIdentity) _threads [1];
		ThreadIdentity id2 = (ThreadIdentity) _threads [2];

		if (id0.ManagedThreadId <= 0)
			return 3;
		if (id1.ManagedThreadId <= 0)
			return 4;
		if (id2.ManagedThreadId <= 0)
			return 5;
		if (id0.HashCode <= 0)
			return 6;
		if (id1.HashCode <= 0)
			return 7;
		if (id2.HashCode <= 0)
			return 8;

		return 0;
	}

	static void AnotherThread (object o)
	{
		Thread t = Thread.CurrentThread;

		ThreadIdentity i;
		i = new ThreadIdentity (t.GetHashCode (), t.ManagedThreadId);
		_threads.Add (i);
	}
}

public class ThreadIdentity
{
	public ThreadIdentity (int hashCode, int managedThreadId)
	{
		_hashCode = hashCode;
		_managedThreadId = managedThreadId;
	}

	public int HashCode {
		get { return _hashCode; }
	}

	public int ManagedThreadId {
		get { return _managedThreadId; }
	}

	private readonly int _hashCode;
	private readonly int _managedThreadId;
}
