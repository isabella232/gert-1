using System;
using System.Diagnostics;
using System.Drawing;
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
		Assert.AreEqual (0, c2.OnMouseDownCalls, "#A6");
		Assert.AreEqual (0, c2.OnEnterCalls, "#A7");
		c2.SimulateClick ();
		Assert.IsFalse (c1.Focused, "#B1");
		Assert.IsFalse (c2.Focused, "#B2");
		Assert.IsNull (ActiveControl, "#B3");
		Assert.AreEqual (0, c1.SelectCalls, "#B4");
		Assert.AreEqual (0, c2.SelectCalls, "#B5");
		Assert.AreEqual (1, c2.OnMouseDownCalls, "#B6");
		Assert.AreEqual (0, c2.OnEnterCalls, "#B7");
	}
}

class FocusTestControl : UserControl
{
	public int SelectCalls;
	public int OnMouseDownCalls;
	public int OnEnterCalls;

	public void SimulateClick ()
	{
		const int WM_LBUTTONDOWN = 0x0201;
		const int MK_LBUTTON = 0x0001;
		Message m = new Message ();
		m.Msg = WM_LBUTTONDOWN;
		m.WParam = (IntPtr) MK_LBUTTON;
		Assert.IsTrue (CanSelect, "#C");
		WndProc (ref m);
	}

	protected override void Select (bool directed, bool forward)
	{
		base.Select (directed, forward);
		SelectCalls++;
	}

	protected override void OnMouseDown (MouseEventArgs e)
	{
		base.OnMouseDown (e);
		OnMouseDownCalls++;
	}

	protected override void OnEnter (EventArgs e)
	{
		base.OnEnter (e);
		OnEnterCalls++;
	}
}
