using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Move the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form cannot be moved.",
			Environment.NewLine);
		_tabPage1.Controls.Add (_bugDescriptionText1);
		// 
		// MainForm
		// 
		ClientSize = new Size (250, 140);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79378";
		ResumeLayout (false);
	}

	protected override void WndProc (ref Message m)
	{
		const int WM_NCLBUTTONDOWN = 161;
		const int WM_SYSCOMMAND = 274;
		const int HTCAPTION = 2;
		const int SC_MOVE = 61456;

		if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32 () == SC_MOVE))
			return;
		if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32 () == HTCAPTION))
			return;

		base.WndProc (ref m);
	}

	[STAThread]
	private static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
