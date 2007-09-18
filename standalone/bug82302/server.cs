using System;
using System.IO;
using System.Runtime.Remoting;
using System.Text;

public class RemoteLoggingServer
{
	public static void Main ()
	{
		RemoteLoggingSinkImpl sink = new RemoteLoggingSinkImpl ();

#if NET_2_0
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
		IPerson ITest.GetPerson ()
		{
			return new Person ();
		}

		IPerson ITest.GetPerson (string name)
		{
			return new Person ();
		}

		public override object InitializeLifetimeService ()
		{
			return null;
		}
	}

	[Serializable]
	public class Person : IPerson
	{
		void IPerson.Call ()
		{
		}

		void IPerson.Call (string name)
		{
		}
	}
}
