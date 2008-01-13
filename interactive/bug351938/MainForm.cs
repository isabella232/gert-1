using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _richTextBox
		// 
		_richTextBox = new RichTextBox ();
		_richTextBox.Dock = DockStyle.Top;
		_richTextBox.Height = 200;
		Controls.Add (_richTextBox);
		// 
		// _changeFontButton
		// 
		_changeFontButton = new Button ();
		_changeFontButton.Text = "ChangeFont";
		_changeFontButton.Dock = DockStyle.Top;
		_changeFontButton.Click += new EventHandler (ChangeFontButton_Click);
		Controls.Add (_changeFontButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 130);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #351938";
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

	void ChangeFontButton_Click (object sender, EventArgs e)
	{
		FontDialog dialog = new FontDialog ();
		dialog.ShowDialog ();
		_richTextBox.SelectionFont = dialog.Font;
		_richTextBox.Focus ();
	}

	private RichTextBox _richTextBox;
	private Button _changeFontButton;
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
			"1. Click the Change Font button.{0}{0}" +
			"2. Select a new font and font-size.{0}{0}" +
			"3. Click inside the textbox and enter some text.{0}{0}" +
			"4. Click the Change Font button.{0}{0}" +
			"5. Select a new font and font-size.{0}{0}" +
			"6. Click inside the textbox and enter some text.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the newly entered text is drawn using " +
			"the selected font.{0}{0}" +
			"2. On step 6, only the newly entered text is drawn " +
			"the selected font.",
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
		ClientSize = new Size (300, 340);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #351938";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
