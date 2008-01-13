using System;
using System.Reflection;
using System.Runtime.Remoting;

using MyDemo.Remoting;

namespace MyDemo.Client
{
	class Program
	{
		static int Main ()
		{
			RemotingConfiguration.Configure (Assembly.GetExecutingAssembly ().Location + ".config", false);

			for (int i = 0; i < 10; i++) {
				IController controller = RemotingTypeCache.GetObject<IController> ();
				ISession session = controller.CreateSession ("user-name", "password");
				if (session == null)
					return 1;
			}
			return 0;
		}
	}
}
