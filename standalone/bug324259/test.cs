using System;
using System.Threading;

class Program
{
	~Program ()
	{
		Thread.Sleep (2000);
	}

	[STAThread]
	static void Main ()
	{
		for (int i = 0; i < 10; i++)
			new Program ();
	}
}
