using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _minimizeBoxCheckBox
		// 
		_minimizeBoxCheckBox = new CheckBox ();
		_minimizeBoxCheckBox.Checked = MinimizeBox;
		_minimizeBoxCheckBox.Location = new Point (10, 40);
		_minimizeBoxCheckBox.Size = new Size (95, 20);
		_minimizeBoxCheckBox.Text = "MinimizeBox";
		_minimizeBoxCheckBox.CheckedChanged += new EventHandler (MinimizeBoxCheckBox_CheckedChanged);
		Controls.Add (_minimizeBoxCheckBox);
		// 
		// _controlBoxCheckBox
		// 
		_controlBoxCheckBox = new CheckBox ();
		_controlBoxCheckBox.Checked = ControlBox;
		_controlBoxCheckBox.Location = new Point (110, 40);
		_controlBoxCheckBox.Size = new Size (80, 20);
		_controlBoxCheckBox.Text = "ControlBox";
		_controlBoxCheckBox.CheckedChanged += new EventHandler (ControlBoxCheckBox_CheckedChanged);
		Controls.Add (_controlBoxCheckBox);
		// 
		// _maximizeBoxCheckBox
		// 
		_maximizeBoxCheckBox = new CheckBox ();
		_maximizeBoxCheckBox.Checked = MaximizeBox;
		_maximizeBoxCheckBox.Location = new Point (210, 40);
		_maximizeBoxCheckBox.Size = new Size (95, 20);
		_maximizeBoxCheckBox.Text = "MaximizeBox";
		_maximizeBoxCheckBox.CheckedChanged += new EventHandler (MaximizeBoxCheckBox_CheckedChanged);
		Controls.Add (_maximizeBoxCheckBox);
		// 
		// _showMessageButton
		// 
		_showMessageButton = new Button ();
		_showMessageButton.Location = new Point (95, 8);
		_showMessageButton.Size = new Size (100, 20);
		_showMessageButton.Text = "Show Message";
		_showMessageButton.Click += new EventHandler (ShowMessageButton_Click);
		Controls.Add (_showMessageButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 75);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #82483";
		FormBorderStyle = FormBorderStyle.FixedDialog;
	}

	[STAThread]
	static void Main ()
	{
		string expected = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Right-clicking the title bar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A context menu is displayed with the following " +
			"options either disabled or not visible at all:{0}{0}" +
			"   * Minimize{0}" +
			"   * Maximize{0}" +
			"   * (Re)Size",
			Environment.NewLine);
		MessageBox.Show (expected, "bug #82483", MessageBoxButtons.OK);

		Application.Run (new MainForm ());
	}

	void MinimizeBoxCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		MinimizeBox = _minimizeBoxCheckBox.Checked;
	}

	void ControlBoxCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		ControlBox = _controlBoxCheckBox.Checked;
	}

	void MaximizeBoxCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		MaximizeBox = _maximizeBoxCheckBox.Checked;
	}

	void ShowMessageButton_Click (object sender, EventArgs e)
	{
		string expected = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Right-clicking the title bar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A context menu is displayed with the following " +
			"options either disabled or not visible at all:{0}{0}" +
			"   * Minimize{0}" +
			"   * Maximize{0}" +
			"   * (Re)Size",
			Environment.NewLine);
		MessageBox.Show (expected, "bug #82483", MessageBoxButtons.OK);
	}

	private CheckBox _minimizeBoxCheckBox;
	private CheckBox _controlBoxCheckBox;
	private CheckBox _maximizeBoxCheckBox;
	private Button _showMessageButton;
}
