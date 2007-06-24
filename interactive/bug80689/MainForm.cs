using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		Location = new Point (210, 100);
		Height = FixedHeight;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80689";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void WndProc (ref Message m)
	{
		if (m.Msg == WM_WINDOWPOSCHANGING)
			unsafe {
				((WINDOWPOS*)m.LParam)->cy = FixedHeight;
			} 
		else
			base.WndProc (ref m);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	const int WM_WINDOWPOSCHANGING = 0x0046;
	const int FixedHeight = 200;

	struct WINDOWPOS
	{
		IntPtr hwnd;
		IntPtr hwndInsertAfter;
		int x;
		int y;
		int cx;
		public int cy;
		uint flags;
	}
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Attempt to change the vertical size of the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The vertical size of the form cannot be modified.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 140);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80689";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
