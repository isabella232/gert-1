using System;
using System.Configuration;
using System.Diagnostics;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Specify the test to run.");
			return 1;
		}

		switch (args [0]) {
		case "test1":
			Test1 ();
			break;
		case "test2":
#if !MONO
			Test2 ();
#endif
			break;
		case "test3":
			Test3 ();
			break;
		case "test4":
			Test4 ();
			break;
		default:
			Console.WriteLine ("Unsupported test '{0}'.", args [0]);
			return 1;
		}

		return 0;
	}

	static void Test1 ()
	{
		TraceListenerCollection listeners = Trace.Listeners;
		Assert.AreEqual (4, listeners.Count, "#A");

		TraceListener listener;

		listener = listeners [0];
		Assert.AreEqual ("loggerA", listener.Name, "#B1");
		Assert.AreEqual (0, listener.Attributes.Count, "#B2");
		Assert.AreEqual (TraceOptions.None, listener.TraceOutputOptions, "#B3");

		listener = listeners [1];
		Assert.AreEqual ("loggerB", listener.Name, "#C1");
		Assert.AreEqual (0, listener.Attributes.Count, "#C2");
		Assert.AreEqual (TraceOptions.Timestamp, listener.TraceOutputOptions, "#C3");

		listener = listeners [2];
		Assert.AreEqual ("loggerC", listener.Name, "#D1");
		Assert.AreEqual (0, listener.Attributes.Count, "#D2");
		Assert.AreEqual (TraceOptions.Timestamp | TraceOptions.DateTime, listener.TraceOutputOptions, "#D3");

		listener = listeners [3];
		Assert.AreEqual ("loggerD", listener.Name, "#E1");
		Assert.AreEqual (0, listener.Attributes.Count, "#E2");
		Assert.AreEqual (TraceOptions.None, listener.TraceOutputOptions, "#E3");
	}

#if !MONO
	static void Test2 ()
	{
		try {
			TraceListenerCollection listeners = Trace.Listeners;
			Assert.Fail ("#1:" + listeners);
		} catch (ConfigurationErrorsException ex) {
			// The value of the property 'traceOutputOptions' cannot
			// be parsed. The error is: The enumeration value must be
			// one of the following: None, LogicalOperationStack,
			// DateTime, Timestamp, ProcessId, ThreadId, Callstack
			Assert.AreEqual (typeof (ConfigurationErrorsException), ex.GetType (), "#2");
#if !MONO
			Assert.IsNotNull (ex.Errors, "#3");
			Assert.AreEqual (1, ex.Errors.Count, "#4");
			Assert.AreEqual (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, ex.Filename, "#5");
#else
			Assert.AreEqual (string.Empty, ex.Filename, "#5");
#endif

			Assert.IsNull (ex.InnerException, "#6");
#if !MONO
			Assert.AreEqual (14, ex.Line, "#7");
#else
			Assert.AreEqual (0, ex.Line, "#7");
#endif
			Assert.IsNotNull (ex.Message, "#8");
			Assert.IsTrue (ex.Message.IndexOf ("'traceOutputOptions'") != -1, "#9");
		}
	}
#endif

	static void Test3 ()
	{
		try {
			TraceListenerCollection listeners = Trace.Listeners;
			Assert.Fail ("#1:" + listeners);
		} catch (ConfigurationErrorsException ex) {
			// The value of the property 'traceOutputOptions' cannot
			// be parsed. The error is: The enumeration value must be
			// one of the following: None, LogicalOperationStack,
			// DateTime, Timestamp, ProcessId, ThreadId, Callstack
			Assert.AreEqual (typeof (ConfigurationErrorsException), ex.GetType (), "#2");
#if !MONO
			Assert.IsNotNull (ex.Errors, "#3");
			Assert.AreEqual (1, ex.Errors.Count, "#4");
			Assert.AreEqual (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, ex.Filename, "#5");
#else
			Assert.IsNull (ex.Filename, "#5");
#endif
			Assert.IsNull (ex.InnerException, "#6");
#if !MONO
			Assert.AreEqual (18, ex.Line, "#7");
#else
			Assert.AreEqual (0, ex.Line, "#7");
#endif
			Assert.IsNotNull (ex.Message, "#8");
			Assert.IsTrue (ex.Message.IndexOf ("'traceOutputOptions'") != -1, "#9");
		}
	}

	static void Test4 ()
	{
		try {
			object value = ConfigurationManager.AppSettings ["test"];
			Assert.Fail ("#1:" + value);
		} catch (ConfigurationErrorsException ex) {
			// Unrecognized element 'whatever'
			Assert.AreEqual (typeof (ConfigurationErrorsException), ex.GetType (), "#2");
#if !MONO
			Assert.IsNotNull (ex.Errors, "#3");
			Assert.AreEqual (1, ex.Errors.Count, "#4");
#endif
			Assert.AreEqual (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, ex.Filename, "#5");
			Assert.IsNull (ex.InnerException, "#6");
#if !MONO
			Assert.AreEqual (3, ex.Line, "#7");
#else
			Assert.AreEqual (2, ex.Line, "#7");
#endif
			Assert.IsNotNull (ex.Message, "#8");
			Assert.IsTrue (ex.Message.IndexOf ("'whatever'") != -1, "#9");
		}
	}
}
