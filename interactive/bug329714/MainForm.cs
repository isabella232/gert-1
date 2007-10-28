using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Location = new Point (8, 8);
		_textBox.Size = new Size (210, 20);
		// 
		// _errorProvider
		// 
		_errorProvider = new ErrorProvider ();
		_errorProvider.SetIconAlignment (_textBox, ErrorIconAlignment.MiddleRight);
		_errorProvider.SetIconPadding (_textBox, 2);
		_errorProvider.ContainerControl = this;
		Controls.Add (_textBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (240, 50);
		Location = new Point (280, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #329714";
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

		_errorProvider.SetError (_textBox, "Mono");
	}

	private TextBox _textBox;
	private ErrorProvider _errorProvider;
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
			"Expected result on startup:{0}{0}" +
			"1. An exclamation icon is located to the right of " +
			"the textbox, and flashes 3 times.{0}{0}" +
			"2. The icon remains visible.{0}{0}" +
			"3. When hovering over the icon, a tooltip with text " +
			"\"Mono\" is displayed.",
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
		ClientSize = new Size (300, 170);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #329714";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
