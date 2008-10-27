using System;
using System.Net;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify test to run.");
			return 1;
		}

		int expected;

		switch (args [0]) {
		case "test1":
			expected = 3;
			break;
		case "test2":
		case "test3":
			expected = ServicePointManager.DefaultPersistentConnectionLimit;
			break;
		default:
			Console.WriteLine ("Unsupported test '{0}'.", args [0]);
			return 2;
		}

		Assert.AreEqual (expected, ServicePointManager.DefaultConnectionLimit, "#1");
		ServicePointManager.DefaultConnectionLimit = 8;
		Assert.AreEqual (8, ServicePointManager.DefaultConnectionLimit, "#2");
		ServicePointManager.DefaultConnectionLimit = 1;
		Assert.AreEqual (1, ServicePointManager.DefaultConnectionLimit, "#3");

		return 0;
	}
}
