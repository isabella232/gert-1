using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 270);
		IsMdiContainer = true;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #325211";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.ClientSize = new Size (150, 50);
		child.MdiParent = this;
		child.Show ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}
}

class ChildForm : Form
{
	public ChildForm ()
	{
		// 
		// _allowCloseCheckBox
		// 
		_allowCloseCheckBox = new CheckBox ();
		_allowCloseCheckBox.Checked = false;
		_allowCloseCheckBox.Location = new Point (8, 8);
		_allowCloseCheckBox.Text = "Allow Close";
		Controls.Add (_allowCloseCheckBox);
	}

	protected override void OnClosing (CancelEventArgs e)
	{
		base.OnClosing (e);
		e.Cancel = !_allowCloseCheckBox.Checked;
	}

	private CheckBox _allowCloseCheckBox;
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
			"1. Uncheck the Allow Close checkbox.{0}{0}" +
			"2. Attempt to close the MDI child form using the " +
			"control box.{0}{0}" +
			"3. Attempt to close the MDI parent form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * The child form is not closed.{0}" +
			"   *  The close button in the control box does not " +
			"remain pressed.{0}" +
			"   * The child form can be moved.{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * The child form is not closed.{0}" +
			"   * The parent form is not closed.",
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
		ClientSize = new Size (350, 310);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #325211";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
