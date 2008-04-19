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
		// _propertyGrid
		// 
		_propertyGrid = new PropertyGrid ();
		_propertyGrid.Dock = DockStyle.Fill;
		_propertyGrid.Height = 100;
		Controls.Add (_propertyGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #375788";
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

		_propertyGrid.SelectedObject = new Config ();
	}

	private PropertyGrid _propertyGrid;
}

public class Config
{
	private int [] _measurements;
	private string _name;

	public Config ()
	{
		_measurements = new int [] { 5, 7, 9, 2 };
	}

	public int [] Measurements {
		get { return _measurements; }
		set { _measurements = value; }
	}

	public string Name {
		get { return _name; }
		set { _name = value; }
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
			"1. Click the value of the Measurements item.{0}{0}" +
			"2. Click the button to edit the Measurements item.{0}{0}" +
			"3. Select item 9 and click the Remove button.{0}{0}" +
			"4. Select item 2 and click the Remove button.{0}{0}" +
			"5. Select item 5 and click the Remove button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, item 2 is selected.{0}{0}" +
			"2. On step 4, item 7 is selected.{0}{0}" +
			"3. On step 5, item 7 is selected.",
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
		Text = "Instructions - bug #375788";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
