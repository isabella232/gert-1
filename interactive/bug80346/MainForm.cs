using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _numericUpDown
		// 
		_numericUpDown = new NumericUpDown ();
		_numericUpDown.Location = new Point (8, 8);
		_numericUpDown.Value = 1;
		Controls.Add (_numericUpDown);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 300;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The text in the NumericUpDown is not selected.{0}{0}" + 
			"2. The cursor caret is positioned before the text.",
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
			"1. Select the text in the NumericUpDown.{0}{0}" +
			"2. Press Tab to move focus to the TabControl.{0}{0}" +
			"3. Press Shift-Tab to move focus back to the NumericUpDown.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"    * Focus is moved to the TabControl.{0}" +
			"    * The text in the NumericUpDown is no longer highlighted.{0}{0}" +
			"3. On step 3:{0}{0}" +
			"    * Focus is moved to the NumericUpDown.{0}" +
			"    * The text in the NumericUpDown is highlighted.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Enter 5555 as value in the NumericUpDown.{0}{0}" +
			"2. Press the Up button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text changes to 100.{0}{0}" +
			"Note:{0}{0}" +
			"If you repeat these steps again, then 5555 will remain displayed " +
			"as text since the underlying value did not change.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// MainForm
		// 
		ClientSize = new Size (500, 340);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80346";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private NumericUpDown _numericUpDown;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
