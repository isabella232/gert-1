using Mono.Math;
using System.Threading;
using System;

class Foo
{
	private class Calculator
	{
		BigInteger a = BigInteger.Parse ("1505778177850948193710646556683821540721977879292014079862893403596323542752005465584270551016994129419693809808055196483547488078132201447066538900759073912922768432567519189511369447574678154606261886226850691181193737850245824867");
		BigInteger b = BigInteger.Parse ("677945009437120105694669798094511858617540659626");
		BigInteger prime = new Mono.Math.BigInteger (
			new byte [] {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xC9, 0xF, 0xDA, 0xA2, 0x21,
				0x68, 0xC2, 0x34, 0xC4, 0xC6, 0x62, 0x8B, 0x80, 0xDC, 0x1C, 0xD1,
				0x29, 0x2, 0x4E, 0x8, 0x8A, 0x67, 0xCC, 0x74, 0x2, 0xB, 0xBE, 0xA6,
				0x3B, 0x13, 0x9B, 0x22, 0x51, 0x4A, 0x8, 0x79, 0x8E, 0x34, 0x4, 0xDD,
				0xEF, 0x95, 0x19, 0xB3, 0xCD, 0x3A, 0x43, 0x1B, 0x30, 0x2B, 0xA, 0x6D,
				0xF2, 0x5F, 0x14, 0x37, 0x4F, 0xE1, 0x35, 0x6D, 0x6D, 0x51, 0xC2,
				0x45, 0xE4, 0x85, 0xB5, 0x76, 0x62, 0x5E, 0x7E, 0xC6, 0xF4, 0x4C,
				0x42, 0xE9, 0xA6, 0x3A, 0x36, 0x21, 0x0, 0x0, 0x0, 0x0, 0x0, 0x9, 0x5,
				0x63 }
			);

		public void Calculate ()
		{
			try {
				while (!Foo.stopping)
					new BigInteger (a.GetBytes ()).ModPow (new BigInteger (b.GetBytes ()), new BigInteger (prime.GetBytes ()));
			} catch {
				Console.WriteLine ("AAAGH");
			}
		}
	}

	static void Main (string [] args)
	{
		Thread t1 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t1.Start ();
		Thread t2 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t2.Start ();
		Thread t3 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t3.Start ();
		Thread t4 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t4.Start ();
		Thread t5 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t5.Start ();
		Thread t6 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t6.Start ();
		Thread t7 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t7.Start ();
		Thread t8 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t8.Start ();
		Thread t9 = new Thread (new ThreadStart (new Calculator ().Calculate));
		t9.Start ();

		DateTime start = DateTime.Now;
		DateTime end = start.AddSeconds (10);
		while (DateTime.Now < end) {
			System.Threading.Thread.Sleep (50);
		}

		stopping = true;

		t1.Abort ();
		t2.Abort ();
		t3.Abort ();
		t4.Abort ();
		t5.Abort ();
		t6.Abort ();
		t7.Abort ();
		t8.Abort ();
		t9.Abort ();
	}

	public volatile static bool stopping;
}
