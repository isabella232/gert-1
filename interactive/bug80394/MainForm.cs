using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_panel = new Panel ();
		_panel.SuspendLayout ();
		SuspendLayout ();
		// 
		// _splitterLeft
		// 
		_splitterLeft = new Splitter ();
		_splitterLeft.BorderStyle = BorderStyle.Fixed3D;
		_splitterLeft.Location = new Point (184, 0);
		_splitterLeft.Size = new Size (3, 390);
		_splitterLeft.TabStop = false;
		// 
		// _splitterRight
		// 
		_splitterRight = new Splitter ();
		_splitterRight.BorderStyle = BorderStyle.Fixed3D;
		_splitterRight.Location = new Point (323, 0);
		_splitterRight.Size = new Size (3, 390);
		_splitterRight.TabStop = false;
		// 
		// _propertyGrid
		// 
		_propertyGrid = new PropertyGrid ();
		_propertyGrid.Dock = DockStyle.Left;
		_propertyGrid.SelectedObject = new Config ();
		_propertyGrid.Size = new Size (184, 390);
		// 
		// _checkedListBox
		// 
		_checkedListBox = new CheckedListBox ();
		_checkedListBox.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
		_checkedListBox.CheckOnClick = true;
		_checkedListBox.Size = new Size (136, 349);
		// 
		// _setAllButton
		// 
		_setAllButton = new Button ();
		_setAllButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		_setAllButton.Location = new Point (72, 360);
		_setAllButton.Size = new Size (56, 24);
		_setAllButton.TabIndex = 10;
		_setAllButton.Text = "Set All";
		// 
		// _clearAllButton
		// 
		_clearAllButton = new Button ();
		_clearAllButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		_clearAllButton.Location = new Point(8, 360);
		_clearAllButton.Size = new Size(56, 24);
		_clearAllButton.TabIndex = 9;
		_clearAllButton.Text = "Clear All";
		// 
		// _panel
		// 
		_panel.Controls.AddRange (new Control [] { _checkedListBox, _setAllButton, _clearAllButton });
		_panel.Dock = DockStyle.Left;
		_panel.Location = new Point (187, 0);
		_panel.Size = new Size (136, 390);
		_panel.TabIndex = 11;
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
			"1. The CheckedListBox fills the width of the center panel.{0}{0}" +
			"2. The \"Clear All\" and \"Set All\" and buttons are displayed " +
			"at the bottom of the center panel in that order.",
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
			"1. Resize the height of the form from extremely small to very " +
			"large.{0}{0}" +
			"2. Repeat this several times.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The CheckedListBox continues to fill almost the full height of " +
			"the form, leaving room only for the two buttons.",
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
		ClientSize = new Size (752, 390);
		Controls.Add (_splitterRight);
		Controls.Add (_panel);
		Controls.Add (_splitterLeft);
		Controls.Add (_propertyGrid);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80394";
		Load += new EventHandler (MainForm_Load);
		_panel.ResumeLayout (false);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_checkedListBox.Items.Add ("Miguel de Icaza", true);
	}

	private Splitter _splitterLeft;
	private Splitter _splitterRight;
	private CheckedListBox _checkedListBox;
	private Panel _panel;
	private Button _setAllButton;
	private Button _clearAllButton;
	private PropertyGrid _propertyGrid;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}

public class Config
{
	private string _FeedbackEmailAddress = "something";

	[Category ("Documentation")]
	[Description ("Whatever.")]
	[DefaultValue ("")]
	public string FeedbackEmailAddress
	{
		get { return _FeedbackEmailAddress; }
		set
		{
			_FeedbackEmailAddress = value;
		}
	}
}
