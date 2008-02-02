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
		Text = "bug #357638";
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

		ContextMenu context = new ContextMenu ();
		context.MenuItems.Add (new MenuItem ("&Close"));

		_propertyGrid.ContextMenu = context;
		_propertyGrid.SelectedObject = new Config ();
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
	private Color _backColor = Color.Red;
	private String _title;

	[Category ("Appearance")]
	[Description ("The backcolor of the text.")]
	public Color BackColor {
		get { return _backColor; }
		set { _backColor = value; }
	}

	[Category ("Appearance")]
	public string Title {
		get { return _title; }
		set { _title = value; }
	}
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
			"1. Right-click the Title item.{0}{0}" +
			"2. Right-click the BackColor item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1:{0}{0}" +
			"   * The Title item is selected.{0}" +
			"   * A context menu is displayed.{0}{0}" +
			"2. On step 2:{0}{0}" +
			"   * The previous context menu is closed.{0}" +
			"   * The BackColor item is selected.{0}" +
			"   * A context menu is displayed.",
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
		ClientSize = new Size (320, 300);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #357638";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
