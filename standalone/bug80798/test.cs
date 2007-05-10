using System;
using System.Runtime.InteropServices;
using System.Threading;

public class MultiThreadExceptionTest
{
	[DllImport ("ole32.dll")]
	static extern int CoInitialize (IntPtr pvReserved);

	static void MyThreadStart ()
	{
		CoInitialize (IntPtr.Zero);
#if MONO || !NET_2_0
		throw new Exception ();
#endif
	}

	public static void Main ()
	{
		Thread t1 = new Thread (new ThreadStart
			(MultiThreadExceptionTest.MyThreadStart));
		t1.IsBackground = true;
		Thread t2 = new Thread (new ThreadStart
			(MultiThreadExceptionTest.MyThreadStart));
		t1.IsBackground = true;
		t1.Start ();
		t2.Start ();
	}
}
