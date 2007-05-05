using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

public class Test
{
	static void Main ()
	{
		Thread [] threads = new Thread [100];
		for (int x = 0; x < threads.Length; x++) {
			threads [x] = new Thread (new ThreadStart (ThreadLoad));
		}
		foreach (Thread t in threads) {
			t.Start ();
		}
		foreach (Thread t in threads) {
			t.Join ();
		}
	}

	public static void ThreadLoad ()
	{
		RSA rsa = new RSACryptoServiceProvider (384);
		rsa.ExportParameters (false);
	}
}
