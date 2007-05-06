using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _toolBar
		// 
		_toolBar = new ToolBar ();
		_toolBar.DropDownArrows = true;
		_toolBar.Dock = DockStyle.Top;
		_toolBar.ShowToolTips = true;
		_toolBar.TabIndex = 1;
		Controls.Add (_toolBar);
		// 
		// _toolBarButton1
		// 
		_toolBarButton1 = new ToolBarButton ();
		_toolBar.Buttons.Add (_toolBarButton1);
		// 
		// _toolBarButton2
		// 
		_toolBarButton2 = new ToolBarButton ();
		_toolBar.Buttons.Add (_toolBarButton2);
		// 
		// _toolBarButton3
		// 
		_toolBarButton3 = new ToolBarButton ();
		_toolBar.Buttons.Add (_toolBarButton3);
		// 
		// _styleGroupBox
		// 
		_styleGroupBox = new GroupBox ();
		_styleGroupBox.Location = new Point (8, 30);
		_styleGroupBox.Size = new Size (270, 65);
		_styleGroupBox.Text = "Style";
		Controls.Add (_styleGroupBox);
		// 
		// _dropDownButtonStyleRadioButton
		// 
		_dropDownButtonStyleRadioButton = new RadioButton ();
		_dropDownButtonStyleRadioButton.Checked = (_toolBarButton2.Style == ToolBarButtonStyle.DropDownButton);
		_dropDownButtonStyleRadioButton.Location = new Point (8, 15);
		_dropDownButtonStyleRadioButton.Text = "DropDownButton";
		_dropDownButtonStyleRadioButton.Width = 120;
		_dropDownButtonStyleRadioButton.CheckedChanged += new EventHandler (DropDownButtonStyleRadioButton_CheckedChanged);
		_styleGroupBox.Controls.Add (_dropDownButtonStyleRadioButton);
		// 
		// _pushButtonStyleRadioButton
		// 
		_pushButtonStyleRadioButton = new RadioButton ();
		_pushButtonStyleRadioButton.Checked = (_toolBarButton2.Style == ToolBarButtonStyle.PushButton);
		_pushButtonStyleRadioButton.Location = new Point (8, 35);
		_pushButtonStyleRadioButton.Text = "PushButton";
		_pushButtonStyleRadioButton.CheckedChanged += new EventHandler (PushButtonStyleRadioButton_CheckedChanged);
		_styleGroupBox.Controls.Add (_pushButtonStyleRadioButton);
		// 
		// _separatorStyleRadioButton
		// 
		_separatorStyleRadioButton = new RadioButton ();
		_separatorStyleRadioButton.Checked = (_toolBarButton2.Style == ToolBarButtonStyle.Separator);
		_separatorStyleRadioButton.Location = new Point (150, 15);
		_separatorStyleRadioButton.Text = "Separator";
		_separatorStyleRadioButton.CheckedChanged += new EventHandler (SeparatorStyleRadioButton_CheckedChanged);
		_styleGroupBox.Controls.Add (_separatorStyleRadioButton);
		// 
		// _toggleButtonStyleRadioButton
		// 
		_toggleButtonStyleRadioButton = new RadioButton ();
		_toggleButtonStyleRadioButton.Checked = (_toolBarButton2.Style == ToolBarButtonStyle.ToggleButton);
		_toggleButtonStyleRadioButton.Location = new Point (150, 35);
		_toggleButtonStyleRadioButton.Text = "ToggleButton";
		_toggleButtonStyleRadioButton.CheckedChanged += new EventHandler (ToggleButtonStyleRadioButton_CheckedChanged);
		_styleGroupBox.Controls.Add (_toggleButtonStyleRadioButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (285, 105);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81523";
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

	void DropDownButtonStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_dropDownButtonStyleRadioButton.Checked)
			_toolBarButton2.Style = ToolBarButtonStyle.DropDownButton;
	}

	void PushButtonStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_pushButtonStyleRadioButton.Checked)
			_toolBarButton2.Style = ToolBarButtonStyle.PushButton;
	}

	void SeparatorStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_separatorStyleRadioButton.Checked)
			_toolBarButton2.Style = ToolBarButtonStyle.Separator;
	}

	void ToggleButtonStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_toggleButtonStyleRadioButton.Checked)
			_toolBarButton2.Style = ToolBarButtonStyle.ToggleButton;
	}

	private ToolBar _toolBar;
	private ToolBarButton _toolBarButton1;
	private ToolBarButton _toolBarButton2;
	private ToolBarButton _toolBarButton3;
	private GroupBox _styleGroupBox;
	private RadioButton _toggleButtonStyleRadioButton;
	private RadioButton _separatorStyleRadioButton;
	private RadioButton _pushButtonStyleRadioButton;
	private RadioButton _dropDownButtonStyleRadioButton;
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
			"Expected result on start-up:{0}{0}" +
			"1. The Style groupbox is positioned directly underneath the " +
			"toolbar.{0}{0}" +
			"2. The (header) text of the groupbox is fully visible.",
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
		ClientSize = new Size (360, 120);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81523";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
