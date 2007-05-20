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
		_richTextBox.Dock = DockStyle.Fill;
		Controls.Add (_richTextBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 45);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81684";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		MemoryStream ms = new MemoryStream ();
		StreamWriter sw = new StreamWriter (ms);
		sw.Write (@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\colortbl\red0" +
			@"\green0\blue0;\red0\green0\blue128;\red128\green128\blue128;\red0" +
			@"\green128\blue0;\red128\green0\blue0;}\li150\cf0 \cf1 public\cf0" +
			@"  \b \cf0 Test\cf0 \b0()\par\li150\{\par\li150\}\par\li150}");
		sw.Flush ();

		ms.Position = 0;
		_richTextBox.LoadFile (ms, RichTextBoxStreamType.RichText);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private RichTextBox _richTextBox;
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
			"1. The RichTextBox contains the following text:{0}{0}" +
			"   public Test(){0}" +
			"   {{{0}" +
			"   }}{0}{0}" +
			"2. The word \"public\" is colored blue.{0}{0}" +
			"3. The word \"Test\" is colored black and is bold.{0}{0}" +
			"4. The full text is indented.",
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
		ClientSize = new Size (360, 210);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81684";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
