using System;
#if NET_2_0
using System.Collections.Generic;
#endif
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _propertyGrid
		// 
		_propertyGrid = new PropertyGrid ();
		_propertyGrid.Dock = DockStyle.Top;
		_propertyGrid.Height = 200;
		Controls.Add (_propertyGrid);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (120, 210);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #358332";
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

		Config conf = new Config ();
		_propertyGrid.SelectedObject = conf;
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_propertyGrid.ResetSelectedProperty ();
	}

	private PropertyGrid _propertyGrid;
	private Button _resetButton;
}

public class Config
{
#if NET_2_0
	private List <string> _header;
#else
	private string [] _header;
#endif
	private string [] _lines;
	private string [] _footer = new string [] { "Copyright (c) 2008", "All rights reserved" };
#if NET_2_0
	private IList <string> _notes = new List <string> ();
	private List <string> _index = new List <string> ();
#endif

	public Config ()
	{
	}

	[DefaultValue (null)]
	public
#if NET_2_0
	List <string>
#else
	string []
#endif
	Header {
		get { return _header; }
		set { _header = value; }
	}

	[DefaultValue (null)]
	public string [] Lines {
		get { return _lines; }
		set { _lines = value; }
	}

	[DefaultValue (null)]
	public string [] Footer {
		get { return _footer; }
		set { _footer = value; }
	}

#if NET_2_0
	public IList <string> Notes {
		get { return _notes; }
		set { _notes = value; }
	}

	[DefaultValue (null)]
	public List <string> Index {
		get { return _index; }
		set { _index = value; }
	}
#endif
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
			"1. The following values are displayed:{0}{0}" +
			"   * Footer: String[] Array (in bold){0}" +
			"   * Header:{0}" +
#if NET_2_0
			"   * Index: Collection (in bold){0}" +
			"   * Lines:{0}" +
			"   * Notes:",
#else
 "   * Lines:",
#endif
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
			"1. Click the value of each item and click the button " +
			"to edit the value.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. A multiline String Collection Editor is displayed " +
			"for:{0}{0}" +
			"   * Footer{0}" +
			"   * Lines{0}{0}" +
			"2. A regular (two pane) String Collection Editor is " +
			"displayed for:{0}{0}" +
			"   * Header{0}" +
			"   * Index{0}{0}" +
			"3. A drop-down list with a (none) value is displayed " +
			"for the Notes item.",
#else
			"1. A multiline String Collection Editor is displayed " +
			"for each item.",
#endif
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
#if NET_2_0
			"1. Select the following items and click the Reset button:{0}{0}" +
			"   * Footer{0}" +
			"   * Index{0}{0}" +
#else
			"1. Select the Footer item and click the Reset button.{0}{0}" +
#endif
			"Expected result:{0}{0}" +
			"1. The value is empty, and cannot be expanded.",
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
		ClientSize = new Size (320, 300);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #358332";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
