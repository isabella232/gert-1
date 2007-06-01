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
		// _toolBar
		// 
		_toolBar = new ToolBar ();
		_toolBar.Appearance = ToolBarAppearance.Flat;
		_toolBar.BorderStyle = BorderStyle.FixedSingle;
		_toolBar.Dock = DockStyle.Top;
		_toolBar.DropDownArrows = true;
		_toolBar.ShowToolTips = true;
		_toolBar.Height = 43;
		_toolBar.TabIndex = 0;
		// 
		// _toolBarButton
		// 
		_toolBarButton = new ToolBarButton ();
		_toolBarButton.Text = "Should be orange";
		_toolBar.Buttons.Add (_toolBarButton);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The ToolBar is orange.{0}{0}" +
			"2. There is no gap between the ToolBar and the TabControl.",
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
			"1. Click the \"Should be orange\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No artifact (line) is left behind after releasing the button.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		BackColor = Color.OrangeRed;
		ClientSize = new Size (300, 180);
		Controls.Add (_tabControl);
		Controls.Add (_toolBar);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80196";
		ResumeLayout (false);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private ToolBar _toolBar;
	private ToolBarButton _toolBarButton;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
