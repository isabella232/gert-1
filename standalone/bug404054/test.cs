using System;
using System.Configuration;
using System.Diagnostics;

class Program
{
	static void Main (string [] args)
	{
		try {
			TraceListenerCollection listeners = Trace.Listeners;
			Assert.Fail ("#1:" + listeners);
		} catch (ConfigurationErrorsException ex) {
			// A listener with no type name specified references
			// the sharedListeners section and cannot have any
			// attributes other than 'Name'.  Listener: 'loggerB'
			Assert.AreEqual (typeof (ConfigurationErrorsException), ex.GetType (), "#2");
#if !MONO
			Assert.IsNotNull (ex.Errors, "#3");
			Assert.AreEqual (1, ex.Errors.Count, "#4");
#endif	
			Assert.IsNull (ex.Filename, "#5");
			Assert.IsNull (ex.InnerException, "#6");
			Assert.AreEqual (0, ex.Line, "#7");
			Assert.IsNotNull (ex.Message, "#8");
			Assert.IsTrue (ex.Message.IndexOf ("'loggerB'") != -1, "#9");
		}
	}
}
