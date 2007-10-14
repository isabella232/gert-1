using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

class Program
{
	static void Main (string [] args)
	{
		Ping pingSender = new Ping ();
		PingOptions options = new PingOptions ();

		// Use the default Ttl value which is 128,
		// but change the fragmentation behavior.
		options.DontFragment = true;

		// Create a buffer of 32 bytes of data to be transmitted.
		string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
		byte [] buffer = Encoding.ASCII.GetBytes (data);
		int timeout = 120;
		PingReply reply = pingSender.Send (args [0], timeout, buffer, options);
		Console.WriteLine ("Status: {0}", reply.Status);
	}
}
