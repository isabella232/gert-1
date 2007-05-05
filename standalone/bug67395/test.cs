using System;

class Program
{
	static int Main ()
	{
		string message = "is \0 ok ?";
		string result = message.Replace ("\0", "this");
		if (result != "is this ok ?") {
			Console.WriteLine ("Replace did not return expected result.");
			Console.WriteLine ("Expected: is this ok ?");
			Console.WriteLine ("Actual: " + result);
			return 1;
		}
		return 0;
	}
}
