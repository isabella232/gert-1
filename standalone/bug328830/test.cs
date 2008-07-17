using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

class BkgndWkr1 : Form
{
	public BkgndWkr1 ()
	{
		bkgndWkr.DoWork += bkgndWkr_DoWork;
		bkgndWkr.RunWorkerCompleted += bkgndWkr_RunWorkerCompleted;
		Shown += Form_Shown;
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new BkgndWkr1 ());
	}

	void Form_Shown (object sender, EventArgs e)
	{
		bkgndWkr.RunWorkerAsync ();
	}

	void bkgndWkr_DoWork (Object sender, DoWorkEventArgs e)
	{
		e.Result = 5566;
		e.Cancel = true;
		m_doWorkException = new RankException ("Rank exception manually created and thrown in _DoWork.");
		throw m_doWorkException;
	}

	void bkgndWkr_RunWorkerCompleted (Object sender, RunWorkerCompletedEventArgs e)
	{
		Assert.AreEqual (m_doWorkException, e.Error, "Test broken, DoWork is meant to fail with exception.");
		Assert.IsFalse (e.Cancelled, "When exception in DoWork, DoWorkEventArgs.Cancel is ignored/false.");
		try {
			object r = e.Result;   //Propagate any exception!!
			Assert.Fail ("RunWorkerCompletedEventArgs.Result should have thrown." + r.ToString ());
			Close ();
		} catch (System.Reflection.TargetInvocationException outerEx) {
			Assert.AreEqual (m_doWorkException, outerEx.InnerException, "InnerException");
			Close ();
		} catch (Exception) {
			Assert.Fail ("RunWorkerCompletedEventArgs.Result should have thrown the exception wrapped in a TargetInvocationException.");
		}
	}

	private BackgroundWorker bkgndWkr = new BackgroundWorker ();
	private Exception m_doWorkException;
}
