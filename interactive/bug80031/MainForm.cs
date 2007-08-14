using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _showPanelsCheck
		// 
		_showPanelsCheck = new CheckBox ();
		_showPanelsCheck.Checked = true;
		_showPanelsCheck.Location = new Point (8, 8);
		_showPanelsCheck.Size = new Size (80, 20);
		_showPanelsCheck.CheckedChanged += new EventHandler (ShowPanelsCheck_CheckedChanged);
		_showPanelsCheck.Text = "Panels";
		Controls.Add (_showPanelsCheck);
		// 
		// _largeTextCheck
		// 
		_largeTextCheck = new CheckBox ();
		_largeTextCheck.Checked = false;
		_largeTextCheck.Location = new Point (100, 8);
		_largeTextCheck.Size = new Size (100, 20);
		_largeTextCheck.CheckedChanged += new EventHandler (LargeTextCheck_CheckedChanged);
		_largeTextCheck.Text = "Large Text";
		Controls.Add (_largeTextCheck);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 250;
		Controls.Add (_tabControl);
		// 
		// _statusBar
		// 
		_statusBar = new StatusBar ();
		_statusBar.Dock = DockStyle.Bottom;
		//_statusBar.Location = new Point (0, 229);
		_statusBar.Name = "_statusBar";
		_statusBar.ShowPanels = true;
		//_statusBar.Size = new Size (456, 22);
		_statusBar.TabIndex = 0;
		_statusBar.Text = "_statusBar";
		Controls.Add (_statusBar);
		// 
		// _statusBarPanel1
		// 
		_statusBarPanel1 = new StatusBarPanel ();
		((ISupportInitialize) (_statusBarPanel1)).BeginInit ();
		_statusBarPanel1.AutoSize = StatusBarPanelAutoSize.Contents;
		_statusBarPanel1.Width = 10;
		_statusBarPanel1.Text = "Bye";
		_statusBar.Panels.Add (_statusBarPanel1);
		// 
		// _statusBarPanel2
		// 
		_statusBarPanel2 = new StatusBarPanel ();
		((ISupportInitialize) (_statusBarPanel2)).BeginInit ();
		_statusBarPanel2.AutoSize = StatusBarPanelAutoSize.None;
		_statusBarPanel2.Width = 30;
		_statusBarPanel2.Text = "Ok";
		_statusBar.Panels.Add (_statusBarPanel2);
		// 
		// _statusBarPanel3
		// 
		_statusBarPanel3 = new StatusBarPanel ();
		((ISupportInitialize) (_statusBarPanel3)).BeginInit ();
		_statusBarPanel3.AutoSize = StatusBarPanelAutoSize.Spring;
		_statusBarPanel3.Width = 10;
		_statusBarPanel3.Text = "Rock";
		_statusBar.Panels.Add (_statusBarPanel3);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The first panel shows the text \"Bye\".{0}{0}" +
			"2. The second panel shows the text \"Ok\".{0}{0}" +
			"3. The third panel shows the text \"Rock\".{0}{0}" +
			"4. The first and second panel are about 5 pixels wider than the " +
			"text in them.{0}{0}" +
			"5. The third panel fills the remaining part of the status bar.",
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
		_bugDescriptionText2.Location = new Point (8, 8);
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to reproduce:{0}{0}" +
			"1. Check the Large Text checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The first panel shows the text \"Hello world\".{0}{0}" +
			"2. The second panel shows the text \"Or\".{0}{0}" +
			"3. The third panel shows the text \"Rock is not dead\".{0}{0}" +
			"4. The first and second panel are about 5 pixels wider than the " +
			"text in them.{0}{0}" +
			"5. The third panel fills the remaining part of the status bar.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Location = new Point (8, 8);
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to reproduce:{0}{0}" +
			"1. Check the Large Text checkbox.{0}{0}" +
			"1. Uncheck the Large Text checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The first panel shows the text \"Bye\".{0}{0}" +
			"2. The second panel shows the text \"Ok\".{0}{0}" +
			"3. The third panel shows the text \"Rock\".{0}{0}" +
			"4. The first and second panel are about 5 pixels wider than the " +
			"text in them.{0}{0}" +
			"5. The third panel fills the remaining part of the status bar.",
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
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (456, 315);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80031";
		((ISupportInitialize) (_statusBarPanel2)).EndInit ();
		((ISupportInitialize) (_statusBarPanel1)).EndInit ();
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void LargeTextCheck_CheckedChanged (object sender, EventArgs e)
	{
		if (_largeTextCheck.Checked) {
			_statusBarPanel1.Text = "Hello world";
			_statusBarPanel2.Text = "Or     maybe not";
			_statusBarPanel3.Text = "Rock is not dead";
		} else {
			_statusBarPanel1.Text = "Bye";
			_statusBarPanel2.Text = "Ok";
			_statusBarPanel3.Text = "Rock";
		}
	}

	void ShowPanelsCheck_CheckedChanged (object sender, EventArgs e)
	{
		_statusBar.ShowPanels = _showPanelsCheck.Checked;
	}

	private CheckBox _largeTextCheck;
	private CheckBox _showPanelsCheck;
	private StatusBarPanel _statusBarPanel1;
	private StatusBarPanel _statusBarPanel2;
	private StatusBarPanel _statusBarPanel3;
	private StatusBar _statusBar;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
