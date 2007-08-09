using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 200;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The shape is colored orange.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the lower part of the shape.{0}{0}" +
			"2. Click the lower part again.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. After step 1, the full shape colors blue.{0}{0}" +
			"2. After step 2, the full shape colors orange.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _controlB
		// 
		_controlB = new ControlB ();
		_controlB.Dock = DockStyle.Top;
		_controlB.Height = 128;
		Controls.Add (_controlB);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 340);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81135";
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
#if NET_2_0
		Application.SetCompatibleTextRenderingDefault (false);
#endif
		Application.Run (new MainForm ());
	}

	private ControlB _controlB;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}

public class ControlB : Control
{
	public ControlB () : base ()
	{
		focus = false;
		Click += new EventHandler (ControlB_Click);
	}

	void ControlB_Click (object sender, EventArgs e)
	{
		focus ^= true;

		if (focus && c == null) {
			c = new ControlA ();
			c.Location = new Point (0, 0);
			c.Size = new Size (Width, Height / 2);
			FindForm ().Controls.Add (c);
			c.BringToFront ();
		} else if (!focus && c != null) {
			FindForm ().Controls.Remove (c);
			c = null;
		}
		Invalidate ();
	}

	protected override void OnPaint (PaintEventArgs e)
	{
		if (focus)
			e.Graphics.FillRectangle (Brushes.Blue, Bounds);
		else
			e.Graphics.FillRectangle (Brushes.Orange, Bounds);
	}

	private bool focus;
	private ControlA c;
}

public class ControlA : Control
{
	public ControlA () : base ()
	{
	}

	protected override void OnMove (EventArgs e)
	{
		RecreateHandle ();
	}

	protected override void OnPaintBackground (PaintEventArgs e)
	{
		// do nothing
	}

	protected override CreateParams CreateParams {
		get {
			CreateParams cp = base.CreateParams;
			cp.ExStyle |= 0x20;
			return cp;
		}
	}
}
