using System;
using System.Net;
using System.Diagnostics;

namespace stacktracetest
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			Dns.BeginGetHostEntry ("localhost", new AsyncCallback (ResolveCallback), null);
			System.Threading.Thread.Sleep (2000);

			Console.WriteLine ();
			Console.WriteLine ("Expected result:");
			Console.WriteLine ("1. The following output was written to the console:");
			Console.WriteLine ();
			Console.WriteLine ("   ResolveCallback()");
			Console.WriteLine ("   method: Void ResolveCallback(System.IAsyncResult)");
			Console.WriteLine ("   method: Void Complete(IntPtr)");
			Console.WriteLine ("   method: Void CompleteCallback(System.Object)");
			Console.WriteLine ("   method: Void Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)");
			Console.WriteLine ("   method: Void Complete(IntPtr)");
			Console.WriteLine ("   method: Void ProtectedInvokeCallback(System.Object, IntPtr)");
			Console.WriteLine ("   method: Void ResolveCallback(System.Object)");
			Console.WriteLine ("   method: Void PerformWaitCallback(System.Object)");
			Console.WriteLine ("   ResolveCallback() complete");
			Console.WriteLine ();
			Console.WriteLine ("Press Enter to continue.");
			Console.ReadLine ();
		}

		public static void ResolveCallback (IAsyncResult ar)
		{
			Console.WriteLine ("ResolveCallback()");
			StackTrace st = new StackTrace ();
			for (int i = 0; i < st.FrameCount; i++) {
				StackFrame sf = st.GetFrame (i);
				Console.WriteLine ("method: {0}", sf.GetMethod ());
			}
			Console.WriteLine ("ResolveCallback() complete");
		}
	}
}
