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
		_tabControl.Height = 280;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click left of the number inside the NumericUpDown " +
			"and do not release the mouse button down.{0}{0}" +
			"2. Move to the right of the number.{0}{0}" +
			"3. Release the mouse button.{0}{0}" +
			"4. Move the mouse pointer left and right over the form.{0}{0}" +
			"5. Click to the right of the number.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 4, the number remains highlighted.{0}{0}" +
			"2. On step 5, the number is no longer highlighted.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		// 
		ClientSize = new Size (500, 320);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #357482";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private NumericUpDown _numericUpDown;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
