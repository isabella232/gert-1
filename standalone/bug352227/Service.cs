using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;

using MyDemo.Remoting;

namespace MyDemo.Service
{
	public sealed class Controller : MarshalByRefObject, IController
	{
		private sealed class Session : MarshalByRefObject, ISession
		{
			void ISession.RefreshConfiguration ()
			{
			}

			void ISession.Start ()
			{
			}

			void ISession.Stop ()
			{
			}

			internal Session ()
			{
			}
		}

		public Controller ()
		{
		}

		public override object InitializeLifetimeService ()
		{
			return null;
		}

		public ISession CreateSession (string userName, string password)
		{
			return new Session ();
		}
	}

	class Program
	{
		static void Main (string [] args)
		{
			RemotingConfiguration.Configure (Assembly.GetExecutingAssembly ().Location + ".config", false);
			Console.ReadLine ();
		}
	}
}
