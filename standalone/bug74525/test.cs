using System;
using System.Threading;

namespace MonitorSynchro
{
	class MonitorSample
	{
		Thread t1;
		Thread t2;
		object myLock = new object();

		public void ThreadProc1()
		{
			Console.WriteLine("T1 getting lock...");
			lock(myLock)
			{
				Console.WriteLine("T1 got the lock.");
				Console.WriteLine("T1 sleeping for 10 sec...");
				Thread.Sleep(10000);
				Console.WriteLine("T1 woke up. Pulse and wait now...");
				Monitor.Pulse(myLock);
				Monitor.Wait(myLock);
				Console.WriteLine("T1 woke up. Stopping T2 in 10 sec...");
				Thread.Sleep(10000);
				Console.WriteLine("T1 stopping T2 now.");
				t2.Interrupt();
			}
			Console.WriteLine("T1 released lock and waiting for T2.");
			t2.Join();
			Console.WriteLine("T1 leaving. Bye!");
		}

		public void ThreadProc2()
		{
			bool working = true;

			while(working)
			{
				try
				{
					Console.WriteLine("T2 getting lock...");
					lock(myLock)
					{
						Console.WriteLine("T2 got the lock.");
						Console.WriteLine("T2 sleeping for 5 sec...");
						Thread.Sleep(5000);
						Console.WriteLine("T2 woke up. Pulse and sleep 1 sec now...");
						Monitor.Pulse(myLock);
						Thread.Sleep(1000);
					}
					Console.WriteLine("T2 released lock.");
				}
				catch(ThreadInterruptedException)
				{
					Console.WriteLine("T2 being asked to quit.");
					working = false;
				}
			}
			Console.WriteLine("T2 leaving. Bye!");
		}

		public MonitorSample()
		{
			t1 = new Thread(new ThreadStart(ThreadProc1));
			t2 = new Thread(new ThreadStart(ThreadProc2));

			t1.Start();
			t2.Start();

			t1.Join();
		}

		static void Main(string[] args)
		{
			new MonitorSample();
			return;
		}
	}
}
