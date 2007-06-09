using System;

class Program
{
	delegate object Conv (string str);

	static void Main ()
	{
		string str = "123";

		object o = int.Parse (str);
		Console.WriteLine ("1: {0}", o != null);
		Console.WriteLine ("2: {0}", o.GetType ().FullName);
		Console.WriteLine ("3: {0}", o.ToString ());
		Console.WriteLine ();

		Conv c = new Conv (int.Parse);

		o = c (str);
		Console.WriteLine ("4: {0}", o != null);
		Console.WriteLine ("5: {0}", o.GetType ().FullName);
		Console.WriteLine ("6: {0}", o.ToString ());
	}
}
