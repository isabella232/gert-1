using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using Timer = System.Windows.Forms.Timer;
using System.Threading;
using System.Windows.Forms;

public class MainForm : Form
{
	static ArrayList _events = new ArrayList ();
	static bool _failInCtor;
	static string _exceptionFile;
	static string _successFile;
	Timer _timer;

	public MainForm ()
	{
		if (_failInCtor)
			ForceFailure ();

		_timer = new Timer ();
		_timer.Interval = 3000;
		_timer.Enabled = true;
		_timer.Tick += new EventHandler (Timer_Tick);

		Load += new EventHandler (MainForm_Load);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		ForceFailure ();
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		Close ();
	}

	[STAThread]
	static void Main ()
	{
		DateTime start;
		TimeSpan elapsed;

		UnhandledExceptionEventHandler uhe = new UnhandledExceptionEventHandler (OnUnhandledException);

		Application.ThreadException += new ThreadExceptionEventHandler (OnThreadException);
		AppDomain.CurrentDomain.UnhandledException += uhe;

		_exceptionFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"unhandled");
		_successFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"success");

		_failInCtor = false;
		start = DateTime.Now;
		Application.Run (new MainForm ());
		elapsed = (DateTime.Now - start);

		AppDomain.CurrentDomain.UnhandledException -= uhe;

		Assert.IsTrue (elapsed.TotalMilliseconds > 2000, "#A1");
		Assert.IsTrue (elapsed.TotalMilliseconds < 4000, "#A2");
		Assert.AreEqual (2, _events.Count, "#A3");
		Assert.AreEqual ("Finally", _events [0], "#A4");
		Assert.AreEqual ("ThreadException:MWF | MyException", _events [1], "#A5");
		Assert.IsFalse (File.Exists (_exceptionFile), "#A6");

		AppDomain.CurrentDomain.UnhandledException += uhe;
		_events.Clear ();

		_failInCtor = true;
		start = DateTime.Now;
		try {
			Application.Run (new MainForm ());
			Assert.Fail ("#B1");
		} catch (Exception ex) {
			elapsed = (DateTime.Now - start);

			AppDomain.CurrentDomain.UnhandledException -= uhe;

			Assert.AreEqual (typeof (MyException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.AreEqual ("MWF", ex.Message, "#B4");

			Assert.IsTrue (elapsed.TotalMilliseconds < 1000, "#B5");
			Assert.AreEqual (1, _events.Count, "#B6");
			Assert.AreEqual ("Finally", _events [0], "#B7");
			Assert.IsFalse (File.Exists (_exceptionFile), "#B8");

			AppDomain.CurrentDomain.UnhandledException += uhe;
			File.Create (_successFile).Close ();

			throw;
		}
	}

	static void ForceFailure ()
	{
		try {
			throw (new MyException ("MWF"));
		} finally {
			_events.Add ("Finally");
		}
	}

	static void OnThreadException (object sender, ThreadExceptionEventArgs e)
	{
		_events.Add ("ThreadException:" + e.Exception.Message + " | " + e.Exception.GetType ().FullName);
	}

	static void OnUnhandledException (object sender, UnhandledExceptionEventArgs e)
	{
		if (e.ExceptionObject != null)
			_events.Add ("UnhandledException:" + e.ExceptionObject + " | " + e.IsTerminating);
		else
			_events.Add ("UnhandledException");

		using (StreamWriter sw = new StreamWriter (_exceptionFile, false, Encoding.UTF8)) {
			sw.Write (e.ExceptionObject.ToString ());
		}
	}
}

class MyException : Exception
{
	public MyException (String message)
		: base (message)
	{
	}
}
