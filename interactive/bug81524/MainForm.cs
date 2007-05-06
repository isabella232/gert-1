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
		_toolBarButton1.Text = "Open";
		_toolBar.Buttons.Add (_toolBarButton1);
		// 
		// _toolBarButton2
		// 
		_toolBarButton2 = new ToolBarButton ();
		_toolBarButton2.Text = "New Document";
		_toolBar.Buttons.Add (_toolBarButton2);
		// 
		// _toolBarButton3
		// 
		_toolBarButton3 = new ToolBarButton ();
		_toolBar.Buttons.Add (_toolBarButton3);
		// 
		// _toolBarButton4
		// 
		_toolBarButton4 = new ToolBarButton ();
		_toolBarButton4.Text = "Quit";
		_toolBar.Buttons.Add (_toolBarButton4);
		// 
		// _textCheckBox
		// 
		_textCheckBox = new CheckBox ();
		_textCheckBox.Checked = true;
		_textCheckBox.Location = new Point (8, 45);
		_textCheckBox.Text = "Text";
		_textCheckBox.CheckedChanged += new EventHandler (TextCheckBox_CheckedChanged);
		Controls.Add (_textCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 105);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81524";
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

	void TextCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		if (_textCheckBox.Checked) {
			_toolBarButton1.Text = "Open";
			_toolBarButton2.Text = "Save";
			_toolBarButton4.Text = "Exit The Application Right Now";
		} else {
			_toolBarButton1.Text = string.Empty;
			_toolBarButton2.Text = string.Empty;
			_toolBarButton4.Text = string.Empty;
		}
	}

	private ToolBar _toolBar;
	private ToolBarButton _toolBarButton1;
	private ToolBarButton _toolBarButton2;
	private ToolBarButton _toolBarButton3;
	private ToolBarButton _toolBarButton4;
	private CheckBox _textCheckBox;
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
			"1. The Text checkbox is positioned directly underneath the " +
			"toolbar.{0}{0}" +
			"2. The buttons have the following text visible:{0}{0}" +
			"  * Open{0}" +
			"  * New Document{0}" +
			"  * (Nothing){0}" +
			"  * Quit{0}{0}" +
			"3. All buttons have the same height.{0}{0}" +
			"4. The width of buttons 1, 2 and 4 is automatically sized to fit " +
			"their respective text.{0}{0}" +
			"5. The width of button 3 matches that of button 2.{0}{0}",
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
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the Text checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The height of the buttons does not change.{0}{0}" +
			"2. The width of all buttons is resized to match the width of " +
			"button 2.{0}{0}" +
			"3. None of the buttons have text.",
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
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Check the Text checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The height of the buttons does not change.{0}{0}" +
			"2. The buttons have the following text visible:{0}{0}" +
			"  * Open{0}" +
			"  * Save{0}" +
			"  * (Nothing){0}" +
			"  * Exit The Application Right Now{0}{0}" +
			"3. The width of buttons 1, 2 and 4 is automatically resized " +
			"to fit their respective text.{0}{0}" +
			"4. The width of button 3 did not change.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 290);
		Location = new Point (700, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81524";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
