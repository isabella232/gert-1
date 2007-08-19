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
			"Expected result on start-up:{0}{0}" +
			"1. The form is not displayed in the taskbar.",
			Environment.NewLine);
		_tabPage1.Controls.Add (_bugDescriptionText1);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Press Alt-Tab and release it to switch to another form.{0}{0}" +
			"2. Press Alt-Tab and hold the keys.{0}{0}" +
			"3. Release the keys.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, a icon for this form is displayed in the window " +
			"list.{0}{0}" +
			"2. On step 3, this form is active again.{0}{0}" +
			"Note:{0}" +
			"On X11, this may not work.",
			Environment.NewLine);
		_tabPage2.Controls.Add (_bugDescriptionText2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (330, 255);
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81722";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
