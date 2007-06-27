using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _richTextBox
		// 
		_richTextBox = new RichTextBox ();
		_richTextBox.Dock = DockStyle.Top;
		_richTextBox.Height = 300;
		_richTextBox.TabIndex = 0;
		Controls.Add (_richTextBox);
		// 
		// _pictureBox
		// 
		_pictureBox = new PictureBox ();
		_pictureBox.BackColor = Color.White;
		_pictureBox.BorderStyle = BorderStyle.Fixed3D;
		_pictureBox.Dock = DockStyle.Bottom;
		_pictureBox.Height = 300;
		Controls.Add (_pictureBox);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (400, 600);
		Location = new Point (150, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81915";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		using (Stream fs = new FileStream ("test.rtf", FileMode.Open)) {
			_richTextBox.LoadFile (fs, RichTextBoxStreamType.RichText);
			_richTextBox.AcceptsTab = true;
			_richTextBox.BulletIndent = 2;
		}

		_pictureBox.Image = Image.FromFile ("expected.png");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private RichTextBox _richTextBox;
	private PictureBox _pictureBox;
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. Both parts of the form are identical.",
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
		ClientSize = new Size (360, 80);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81915";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
