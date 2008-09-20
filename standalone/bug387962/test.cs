using System;
using System.Collections;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

class Program
{
	private static ArrayList t;
	private static ArrayList t_sync;
	private static bool oneShot = true;
	private static int controllerInterval = 2000;

	static void Main ()
	{
		Start (100, 2, controllerInterval, oneShot);
		Thread.Sleep (10000);
	}

	// arg 0 -- interval for manual timers
	// arg 1 -- how many manual timers
	// arg 2 -- interval for auto controller timer
	public static void Start (int manualInterval, int timerCount, int contInterval, bool fireOnce)
	{
		oneShot = fireOnce;
		controllerInterval = contInterval;

		// tx is an independent automatic timer that stops and starts 
		// other (manual) timers on expiration 
		Timer tx = new Timer ();
		tx.AutoReset = true;
		tx.Interval = controllerInterval;
		tx.Elapsed += new ElapsedEventHandler (Timer_Elapsed);
		tx.Enabled = true;

		// t is a list of manual timers. starting options: 
		// a) from startem (auto timer's expiration handler) 
		// b) from expire (manual timers' expiration handler) 

		t = new ArrayList ();
		t_sync = new ArrayList ();
		for (int i = 0; i < timerCount; i++) {
			Timer tmp = new Timer ();
			tmp.AutoReset = !oneShot;
			tmp.Interval = manualInterval;
			tmp.Elapsed += new ElapsedEventHandler (Timer_Expire);
			t.Add (tmp);
			t_sync.Add (new object ());
		}
		foreach (Timer tm in t)
			tm.Enabled = true;
	}

	static void Timer_Expire (object sender, ElapsedEventArgs e)
	{
		try {
			for (int i = 0; i < t.Count; i++) {
				Timer tmp = (Timer) t [i];
				if (tmp.Equals (sender)) {
					if (oneShot) {
						lock (t_sync [i]) {
							tmp.Stop ();
							tmp.Start ();
						}
					}
					break;
				}
			}
		} catch (Exception ex) {
			Console.WriteLine ("Exception! " + ex.Message);
		}
	}

	static void Timer_Elapsed (object sender, ElapsedEventArgs e)
	{
		try {
			for (int i = 0; i < t.Count; i++) {
				Timer tmp = (Timer) t [i];
				lock (t_sync [i]) {
					tmp.Stop ();
					tmp.Start ();
				}
			}
		} catch (Exception ex) {
			Console.WriteLine ("Exception! " + ex.Message);
		}
	}
}
