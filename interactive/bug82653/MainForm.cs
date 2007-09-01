using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _toolStrip
		// 
		_toolStrip = new ToolStrip ();
		_toolStrip.Location = new Point (0, 24);
		_toolStrip.Size = new Size (632, 25);
		_toolStrip.TabIndex = 1;
		_toolStrip.Text = "ToolStrip";
		Controls.Add (_toolStrip);
		// 
		// _textBox
		// 
		_textBox = new ToolStripTextBox ();
		_toolStrip.Items.Add (_textBox);
		// 
		// _borderStyleGroupBox
		// 
		_borderStyleGroupBox = new GroupBox ();
		_borderStyleGroupBox.Dock = DockStyle.Bottom;
		_borderStyleGroupBox.Height = 85;
		_borderStyleGroupBox.Text = "BorderStyle";
		Controls.Add (_borderStyleGroupBox);
		// 
		// _fixed3DBorderStyleRadioButton
		// 
		_fixed3DBorderStyleRadioButton = new RadioButton ();
		_fixed3DBorderStyleRadioButton.Checked = true;
		_fixed3DBorderStyleRadioButton.Location = new Point (8, 16);
		_fixed3DBorderStyleRadioButton.Text = "Fixed3D";
		_fixed3DBorderStyleRadioButton.Size = new Size (95, 20);
		_fixed3DBorderStyleRadioButton.CheckedChanged += new EventHandler (Fixed3DBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_fixed3DBorderStyleRadioButton);
		// 
		// _fixedSingleBorderStyleRadioButton
		// 
		_fixedSingleBorderStyleRadioButton = new RadioButton ();
		_fixedSingleBorderStyleRadioButton.Location = new Point (8, 36);
		_fixedSingleBorderStyleRadioButton.Text = "FixedSingle";
		_fixedSingleBorderStyleRadioButton.Size = new Size (95, 20);
		_fixedSingleBorderStyleRadioButton.CheckedChanged += new EventHandler (FixedSingleBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_fixedSingleBorderStyleRadioButton);
		// 
		// _noneBorderStyleRadioButton
		// 
		_noneBorderStyleRadioButton = new RadioButton ();
		_noneBorderStyleRadioButton.Location = new Point (8, 56);
		_noneBorderStyleRadioButton.Text = "None";
		_noneBorderStyleRadioButton.Size = new Size (95, 20);
		_noneBorderStyleRadioButton.CheckedChanged += new EventHandler (NoneBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_noneBorderStyleRadioButton);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (300, 120);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82653";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void Fixed3DBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_fixed3DBorderStyleRadioButton.Checked)
			_textBox.BorderStyle = BorderStyle.Fixed3D;
	}

	void FixedSingleBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_fixedSingleBorderStyleRadioButton.Checked)
			_textBox.BorderStyle = BorderStyle.FixedSingle;
	}

	void NoneBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_noneBorderStyleRadioButton.Checked)
			_textBox.BorderStyle = BorderStyle.None;
	}

	private ToolStrip _toolStrip;
	private ToolStripTextBox _textBox;
	private GroupBox _borderStyleGroupBox;
	private RadioButton _fixed3DBorderStyleRadioButton;
	private RadioButton _fixedSingleBorderStyleRadioButton;
	private RadioButton _noneBorderStyleRadioButton;
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The textbox fills the entire height of the toolstrip " +
			"and has no border.",
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
			"1. Check the Fixed3D radiobutton.{0}{0}" +
			"2. Move the mouse cursor over the textbox.{0}{0}" +
			"3. Move the mouse cursor away from the textbox.{0}{0}" +
			"4. Click inside the textbox.{0}{0}" +
			"5. Move the mouse cursor away from the textbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the textbox has no border.{0}{0}" +
			"2. On step 2, the textbox has a single-line border.{0}{0}" +
			"3. On step 3, the textbox has no border.{0}{0}" +
			"4. On steps 4 and 5, the textbox has a single-line border.",
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
			"1. Check the FixedSingle radiobutton.{0}{0}" +
			"2. Move the mouse cursor over the textbox.{0}{0}" +
			"3. Move the mouse cursor away from the textbox.{0}{0}" +
			"4. Click inside the textbox.{0}{0}" +
			"5. Move the mouse cursor away from the textbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textbox at all times has a single-line border.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText4
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Check the None radiobutton.{0}{0}" +
			"2. Move the mouse cursor over the textbox.{0}{0}" +
			"3. Move the mouse cursor away from the textbox.{0}{0}" +
			"4. Click inside the textbox.{0}{0}" +
			"5. Move the mouse cursor away from the textbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textbox never has a border.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (330, 330);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82653";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
