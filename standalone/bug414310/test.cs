using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using dWorld.Foundation.Utility.Threading;

public class Program
{
	internal class TestScheduledProcess : dLightWeightScheduledProcessBase
	{
		#region Private data
		static int m_Version = 0;
		static Stopwatch m_TestTimer = new Stopwatch ();
		private string m_Name = null;
		private ManualResetEvent m_ExposedEvent = new ManualResetEvent (false);
		private ManualResetEvent m_RegisterEvent = new ManualResetEvent (false);
		private ManualResetEvent m_UnRegisterEvent = new ManualResetEvent (false);
		private int m_WorkCost = 0;
		private int m_nNumUpdates = 0;
		#endregion

		public TestScheduledProcess (int _costinwork, int _fps)
			: base (_fps)
		{
			m_WorkCost = _costinwork;
			m_Version++;
			m_Name = string.Format ("Test scheduled process {0}", m_Version);
		}

		static public void StartTimer ()
		{
			m_TestTimer.Reset ();
			m_TestTimer.Start ();
		}

		static public void StopTimer ()
		{
			m_TestTimer.Stop ();
		}

		static public double TimeElapsed
		{
			get { return m_TestTimer.Elapsed.TotalSeconds; }
		}

		public int NumUpdates
		{
			get { return m_nNumUpdates; }
		}

		public override string Name
		{
			get { return m_Name; }
		}

		public void DoWork ()
		{
			base.IncrementProcessFlag ();
		}

		public override void Update ()
		{
			for (int j = 0; j != m_WorkCost * 100000; j++) { }

			m_nNumUpdates++;
		}

		public void WaitForUpdate ()
		{
			WaitForRegistration ();
			m_ExposedEvent.WaitOne (100000, false);
		}

		public void WaitForRegistration ()
		{
			m_RegisterEvent.WaitOne (100000, false);
		}

		public void WaitForUnRegistration ()
		{
			m_UnRegisterEvent.WaitOne (100000, false);
		}

		public override void Registered ()
		{
			m_RegisterEvent.Set ();
		}

		public override void UnRegistered ()
		{
			m_UnRegisterEvent.Set ();
		}
	}

	public void DoTest ()
	{
		dLightWeightProcessThread.Init ();

		// The fps we want the processes to run at
		int testfps = 30;

		// how many do we want to spawn
		const int iNumProcesses = 50;

		// Create a 100 of these processes
		TestScheduledProcess [] sps = new TestScheduledProcess [iNumProcesses];

		// Create the processes and add it
		for (int j = 0; j != iNumProcesses; j++)
			sps [j] = new TestScheduledProcess (1, testfps);

		// Ok launchem
		foreach (TestScheduledProcess p in sps)
			dLightWeightProcessThread.AddService (p);

		// Start the timer
		TestScheduledProcess.StartTimer ();

		// Check how many are done
		int iNumDoneInAsecond = 0;
		while (iNumDoneInAsecond < iNumProcesses) {
			for (int j = 0; j != iNumProcesses; j++) {
				TestScheduledProcess p = sps [j];

				if (p != null && p.NumUpdates == testfps) {
					iNumDoneInAsecond++;
					sps [j] = null;
				}
			}
		}

		// Stop the timer
		TestScheduledProcess.StopTimer ();

		dLightWeightProcessThread.Quit ();
	}

	static void Main (string [] args)
	{
		Program p = new Program ();
		p.DoTest ();
	}
}
