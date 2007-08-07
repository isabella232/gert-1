using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _addComboBoxButton
		// 
		_addComboBoxButton = new Button ();
		_addComboBoxButton.Dock = DockStyle.Bottom;
		_addComboBoxButton.Text = "Add a ComboBox";
		_addComboBoxButton.Click += new EventHandler (AddComboBoxButton_Click);
		Controls.Add (_addComboBoxButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82344";
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

	void AddComboBoxButton_Click (object sender, EventArgs e)
	{
		ComboBox cmbx = new ComboBox ();
		cmbx.Dock = DockStyle.Top;
		cmbx.Items.Add ("Test a");
		cmbx.Items.Add ("Test b");
		cmbx.SelectedIndex = 1;
		cmbx.TabIndex = 0;
		Controls.Add (cmbx);
	}

	private Button _addComboBoxButton;
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
			"1. Click the Add a ComboBox button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A ComboBox is added at the top of the form.{0}{0}" +
			"2. The text of the ComboBox is \"Test b\".",
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
		ClientSize = new Size (300, 165);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82344";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
