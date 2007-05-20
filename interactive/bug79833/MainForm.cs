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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected results:{0}{0}" +
			"1. A Size-Grip is displayed in the lower right corner of the " +
			"form.{0}{0}" +
			"2. The form cannot be resize to less than 250 by 150 pixels.",
			Environment.NewLine);
		_tabPage1.Controls.Add (_bugDescriptionText1);
		// 
		// MainForm
		// 
		AllowDrop = true;
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (250, 150);
		MinimumSize = new Size (250, 150);
		SizeGripStyle = SizeGripStyle.Show;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79833";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
