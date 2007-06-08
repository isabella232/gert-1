using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Threading;
using System.Net;

namespace Test
{
	class Program
	{
		public static int Main(string[] args)
		{
			RemotingHelper.Init();
			ServerLib Service = (ServerLib)RemotingServices.Connect(typeof(ServerLib), "tcp://localhost:8888/Test");
			Service.Test();
			return 0;
		}
	}
}
