using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _comboBox
		// 
		_comboBox = new ComboBox ();
		_comboBox.Items.Add ("a");
		_comboBox.Items.Add ("b");
		_comboBox.Items.Add ("c");
		_comboBox.Items.Add ("d");
		_comboBox.Location = new Point (8, 8);
		_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		_comboBox.SelectedIndexChanged += new EventHandler (ComboBox_SelectedIndexChanged);
		Controls.Add (_comboBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #352830";
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

	void ComboBox_SelectedIndexChanged (object sender, EventArgs e)
	{
		Form f = new Form ();
		f.ClientSize = new Size (300, 70);
		f.Location = new Point (250, 205);
		f.StartPosition = FormStartPosition.Manual;
		f.Text = "Child";
		f.Show ();
	}

	private ComboBox _comboBox;
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
			"1. Select an item in the combobox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A new form is displayed.",
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
		ClientSize = new Size (300, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #352830";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
