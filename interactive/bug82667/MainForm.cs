using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _labelA
		// 
		_labelA = new Label ();
		_labelA.BackColor = Color.Orange;
		_labelA.Location = new Point (20, 20);
		_labelA.Text = "A";
		Controls.Add (_labelA);
		// 
		// _labelB
		// 
		_labelB = new Label ();
		_labelB.BackColor = Color.Green;
		_labelB.Location = new Point (0, 0);
		_labelB.Size = new Size (180, 70);
		_labelB.Text = "B";
		_labelB.Visible = false;
		Controls.Add (_labelB);
		// 
		// _labelBVisibleCheckBox
		// 
		_labelBVisibleCheckBox = new CheckBox ();
		_labelBVisibleCheckBox.Text = "Label B Visible";
		_labelBVisibleCheckBox.Location = new Point (_labelB.Right + 5, 15);
		_labelBVisibleCheckBox.Size = new Size (100, 40);
		_labelBVisibleCheckBox.CheckedChanged += new EventHandler (LabelBVisibleCheckBox_CheckedChanged);
		Controls.Add (_labelBVisibleCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 70);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82667";
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

	void LabelBVisibleCheckBox_CheckedChanged (object o, EventArgs args)
	{
		_labelB.Visible = _labelBVisibleCheckBox.Checked;
	}

	private Label _labelA;
	private Label _labelB;
	private CheckBox _labelBVisibleCheckBox;
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
			"1. Check the Label B Visible checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The (green) B label is visible.{0}{0}" +
			"2. The (orange) A label is displayed on top op the B label.",
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
		ClientSize = new Size (300, 180);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82667";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
