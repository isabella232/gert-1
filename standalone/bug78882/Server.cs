using System;
using Test;

namespace Test
{
	class Program
	{
		static int Main()
		{
			ServerLib server = new ServerLib(8888, "Test");
			server.Run();
			Console.ReadLine ();
			return 0;
		}
	}
}
