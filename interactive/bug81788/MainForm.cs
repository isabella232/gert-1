using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _listBox
		// 
		_listBox = new ListBox ();
		_listBox.DisplayMember = "Name";
		_listBox.Location = new Point (8, 8);
		_listBox.Size = new Size (100, 60);
		_listBox.ValueMember = "Value";
		Controls.Add (_listBox);
		// 
		// 
		// 
		_clearButton = new Button ();
		_clearButton.Location = new Point (140, 30);
		_clearButton.Text = "Clear";
		_clearButton.Click += new EventHandler (ClearButton_Click);
		Controls.Add (_clearButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (240, 80);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81788";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		list.Add (new ListBoxItem ("Miguel", 4));
		list.Add (new ListBoxItem ("Everaldo", 5));
		_listBox.DataSource = list;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ClearButton_Click (object sender, EventArgs e)
	{
		_listBox.DataSource = null;
		list.Insert (0, "fff");
		list.Insert (1, "fff");
	}

	private ListBox _listBox;
	private Button _clearButton;
	private ArrayList list = new ArrayList ();
}

public class ListBoxItem
{
	public ListBoxItem (string name, int value)
	{
		_name = name;
		_value = value;
	}

	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	public int Value
	{
		get { return _value; }
		set { _value = value; }
	}

	private string _name;
	private int _value;
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
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Clear button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The ListBox no longer contains any items.",
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
		ClientSize = new Size (330, 135);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81788";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
