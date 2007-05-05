using System;
using System.IO;
using System.Runtime.Remoting;
using System.Text;

public class RemoteLoggingServer
{
	public static void Main ()
	{
		RemoteLoggingSinkImpl sink = new RemoteLoggingSinkImpl ();

#if NET_2_0 && !MONO
		RemotingConfiguration.Configure (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
#else
		RemotingConfiguration.Configure (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
#endif

		RemotingServices.Marshal (sink, "LoggingSink", typeof (IRemoteLoggingSink));

		Console.ReadLine ();

		RemotingServices.Disconnect (sink);
	}

	private class RemoteLoggingSinkImpl : MarshalByRefObject, IRemoteLoggingSink
	{
		public void LogEvents (LoggingEvent [] events)
		{
			if (events != null) {
				foreach (LoggingEvent logEvent in events) {
					string logFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
						"log");
					using (StreamWriter sw = File.AppendText (logFile)) {
						sw.WriteLine (logEvent.Message);
					}
				}
			}
		}

		public override object InitializeLifetimeService ()
		{
			return null;
		}
	}
}
