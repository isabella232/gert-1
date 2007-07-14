using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_checkedListBox = new CheckedListBox ();
		_checkedListBox.Dock = DockStyle.Top;
		_checkedListBox.Font = new Font (_checkedListBox.Font.FontFamily, _checkedListBox.Font.Height + 8);
		_checkedListBox.Height = 120;
		Controls.Add (_checkedListBox);
		// 
		// _threeDCheckBox
		// 
		_threeDCheckBox = new CheckBox ();
		_threeDCheckBox.Checked = _checkedListBox.ThreeDCheckBoxes;
		_threeDCheckBox.FlatStyle = FlatStyle.Flat;
		_threeDCheckBox.Location = new Point (8, 125);
		_threeDCheckBox.Text = "3D checkboxes";
		_threeDCheckBox.CheckedChanged += new EventHandler (ThreeDCheckBox_CheckedChanged);
		Controls.Add (_threeDCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 150);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82100";
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

		_checkedListBox.Items.Add ("A", true);
		_checkedListBox.Items.Add ("B", false);
		_checkedListBox.Items.Add ("C", true);
		_checkedListBox.SelectedIndex = 1;
	}

	void ThreeDCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_checkedListBox.ThreeDCheckBoxes = _threeDCheckBox.Checked;
	}

	private CheckedListBox _checkedListBox;
	private CheckBox _threeDCheckBox;
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
			"1. The background color of the checkboxes is white.{0}{0}" +
			"2. The size of the checkboxes in the CheckedListBox matches that " +
			"of the regular CheckBox.{0}{0}" +
			"3. Switching the style of the checkbox between flat and 3D does " +
			"not change their size.",
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
		ClientSize = new Size (360, 170);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82100";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
