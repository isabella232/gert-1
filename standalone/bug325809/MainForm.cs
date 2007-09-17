using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class TestForm : Form
{
	FocusTestControl c1 = new FocusTestControl ();
	FocusTestControl c2 = new FocusTestControl ();

	public TestForm ()
	{
		c1.Text = "1";
		c2.Text = "2";
		c2.Dock = DockStyle.Fill;
		Controls.AddRange (new Control [] { c1, c2 });
	}

	[STAThread]
	static void Main ()
	{
		new TestForm ().Show ();
	}

	protected override void OnLoad (EventArgs e)
	{
		base.OnLoad (e);
		Assert.IsFalse (c1.Focused, "#A1");
		Assert.IsFalse (c2.Focused, "#A2");
		Assert.IsNull (ActiveControl, "#A3");
		Assert.AreEqual (0, c1.SelectCalls, "#A4");
		Assert.AreEqual (0, c2.SelectCalls, "#A5");
		c2.SimulateClick ();
		Assert.IsFalse (c1.Focused, "#B1");
		Assert.IsFalse (c2.Focused, "#B2");
		Assert.IsNull (ActiveControl, "#B3");
		Assert.AreEqual (0, c1.SelectCalls, "#B4");
		Assert.AreEqual (0, c2.SelectCalls, "#B5");
	}
}

class FocusTestControl : Control
{
	public int SelectCalls;

	public void SimulateClick ()
	{
		const int WM_LBUTTONDOWN = 0x0201;
		Message m = new Message ();
		m.Msg = WM_LBUTTONDOWN;
		Assert.IsTrue (CanSelect, "#C");
		WndProc (ref m);
	}

	protected override void Select (bool directed, bool forward)
	{
		base.Select (directed, forward);
		SelectCalls++;
	}
}

class Assert
{
	public static void AreEqual (int x, int y, string msg)
	{
		if (x != y)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x, y, msg));
	}

	public static void IsNull (object value, string msg)
	{
		if (value != null)
			throw new Exception (msg);
	}

	public static void IsFalse (bool value, string msg)
	{
		if (value)
			throw new Exception (msg);
	}

	public static void IsTrue (bool value, string msg)
	{
		if (!value)
			throw new Exception (msg);
	}
}
