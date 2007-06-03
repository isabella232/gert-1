using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _toolBar1
		// 
		_toolBar1 = new ToolBar ();
		_toolBar1.Appearance = ToolBarAppearance.Normal;
		_toolBar1.BorderStyle = BorderStyle.FixedSingle;
		Controls.Add (_toolBar1);
		// 
		// _toolBar2
		// 
		_toolBar2 = new ToolBar ();
		_toolBar2.Appearance = ToolBarAppearance.Flat;
		_toolBar2.BorderStyle = BorderStyle.FixedSingle;
		Controls.Add (_toolBar2);
		// 
		// _backColorBox
		// 
		_backColorBox = new GroupBox ();
		_backColorBox.Location = new Point (8, 95);
		_backColorBox.Size = new Size (135, 100);
		_backColorBox.Text = "Background Color";
		Controls.Add (_backColorBox);
		// 
		// _controlColorRadioButton
		// 
		_controlColorRadioButton = new RadioButton ();
		_controlColorRadioButton.Checked = true;
		_controlColorRadioButton.Location = new Point (8, 20);
		_controlColorRadioButton.Size = new Size (100, 20);
		_controlColorRadioButton.Text = "Control";
		_controlColorRadioButton.CheckedChanged += new EventHandler (ControlColorRadioButton_CheckedChanged);
		_backColorBox.Controls.Add (_controlColorRadioButton);
		// 
		// _redColorRadioButton
		// 
		_redColorRadioButton = new RadioButton ();
		_redColorRadioButton.Location = new Point (8, 40);
		_redColorRadioButton.Size = new Size (100, 20);
		_redColorRadioButton.Text = "Red";
		_redColorRadioButton.CheckedChanged += new EventHandler (RedColorRadioButton_CheckedChanged);
		_backColorBox.Controls.Add (_redColorRadioButton);
		// 
		// _blueColorRadioButton
		// 
		_blueColorRadioButton = new RadioButton ();
		_blueColorRadioButton.Location = new Point (8, 60);
		_blueColorRadioButton.Size = new Size (100, 20);
		_blueColorRadioButton.Text = "Blue";
		_blueColorRadioButton.CheckedChanged += new EventHandler (BlueColorRadioButton_CheckedChanged);
		_backColorBox.Controls.Add (_blueColorRadioButton);
		// 
		// _flatCheck
		// 
		_flatCheck = new CheckBox ();
		_flatCheck.Checked = true;
		_flatCheck.Location = new Point (250, 95);
		_flatCheck.Text = "Flat";
		_flatCheck.CheckedChanged += new EventHandler (FlatCheck_CheckedChanged);
		Controls.Add (_flatCheck);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 210);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80553";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void FlatCheck_CheckedChanged (object sender, EventArgs e)
	{
		if (_flatCheck.Checked)
			_toolBar2.Appearance = ToolBarAppearance.Flat;
		else
			_toolBar2.Appearance = ToolBarAppearance.Normal;
	}

	void BlueColorRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_blueColorRadioButton.Checked)
			BackColor = Color.Blue;
	}

	void ControlColorRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_controlColorRadioButton.Checked)
			BackColor = Color.FromKnownColor (KnownColor.Control);
	}

	void RedColorRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_redColorRadioButton.Checked)
			BackColor = Color.Red;
	}

	private GroupBox _backColorBox;
	private RadioButton _controlColorRadioButton;
	private RadioButton _redColorRadioButton;
	private RadioButton _blueColorRadioButton;
	private CheckBox _flatCheck;
	private ToolBar _toolBar1;
	private ToolBar _toolBar2;
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
			"Steps to execute:{0}{0}" +
			"1. Resize the width of the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The height of the toolbars does not change.",
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
			"1. Check the Flat checkbox.{0}{0}" +
			"2. Select the Blue radiobutton.{0}{0}" +
			"3. Uncheck the Flat checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * the top toolbar is blue.{0}" +
			"   * the bottom toolbar is gray.{0}" +
			"   * the form is blue.{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * the top toolbar is gray.{0}" +
			"   * the bottom toolbar is gray.{0}" +
			"   * the form is blue.{0}{0}" +
			"3. The height of the toolbars does not change.",
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
			"1. Uncheck the Flat checkbox.{0}{0}" +
			"2. Select the Control radiobutton.{0}{0}" +
			"2. Select the Red radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The top toolbar is gray.{0}{0}" +
			"2. The bottom toolbar is gray.{0}{0}" +
			"3. The form is red.{0}{0}" +
			"4. The height of the toolbars does not change.",
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
			"1. Check the Flat checkbox.{0}{0}" +
			"2. Select the Blue radiobutton.{0}{0}" +
			"3. Select the Red radiobutton.{0}{0}" +
			"3. Increase and reduce the width of the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * the top toolbar is blue.{0}" +
			"   * the bottom toolbar is gray.{0}" +
			"   * the form is blue.{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * the top toolbar is red.{0}" +
			"   * the bottom toolbar is gray.{0}" +
			"   * the form is red.{0}{0}" +
			"3. The height of the toolbars does not change.",
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
		ClientSize = new Size (400, 380);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80553";
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
