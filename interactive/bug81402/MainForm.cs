using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox1
		// 
		_textBox1 = new TextBox ();
		_textBox1.BorderStyle = BorderStyle.FixedSingle;
		_textBox1.Location = new Point (8, 8);
		_textBox1.Size = new Size (180, 10);
		Controls.Add (_textBox1);
		// 
		// _textBox2
		// 
		_textBox2 = new TextBox ();
		_textBox2.BorderStyle = BorderStyle.None;
		_textBox2.Location = new Point (8, 40);
		_textBox2.Size = new Size (180, 50);
		Controls.Add (_textBox2);
		// 
		// _textBox3
		// 
		_textBox3 = new TextBox ();
		_textBox3.BorderStyle = BorderStyle.Fixed3D;
		_textBox3.Location = new Point (8, 72);
		_textBox3.Size = new Size (180, 10);
		Controls.Add (_textBox3);
		// 
		// _textBox4
		// 
		_textBox4 = new TextBox ();
		_textBox4.BorderStyle = BorderStyle.FixedSingle;
		_textBox4.Location = new Point (8, 104);
		_textBox4.Multiline = true;
		_textBox4.Size = new Size (180, 50);
		Controls.Add (_textBox4);
		// 
		// _textBox5
		// 
		_textBox5 = new TextBox ();
		_textBox5.BorderStyle = BorderStyle.None;
		_textBox5.Location = new Point (8, 175);
		_textBox5.Multiline = true;
		_textBox5.Size = new Size (180, 10);
		Controls.Add (_textBox5);
		// 
		// _textBox6
		// 
		_textBox6 = new TextBox ();
		_textBox6.BorderStyle = BorderStyle.Fixed3D;
		_textBox6.Location = new Point (8, 210);
		_textBox6.Multiline = true;
		_textBox6.Size = new Size (180, 50);
		Controls.Add (_textBox6);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (200, 300);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81402";
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

		_textBox1.Text = _textBox1.ClientSize.Height.ToString (
			CultureInfo.InvariantCulture);
		_textBox2.Text = _textBox2.ClientSize.Height.ToString (
			CultureInfo.InvariantCulture);
		_textBox3.Text = _textBox3.ClientSize.Height.ToString (
			CultureInfo.InvariantCulture);
		_textBox4.Text = _textBox4.ClientSize.Height.ToString (
			CultureInfo.InvariantCulture);
		_textBox5.Text = _textBox5.ClientSize.Height.ToString (
			CultureInfo.InvariantCulture);
		_textBox6.Text = _textBox6.ClientSize.Height.ToString (
			CultureInfo.InvariantCulture);
	}

	private TextBox _textBox1;
	private TextBox _textBox2;
	private TextBox _textBox3;
	private TextBox _textBox4;
	private TextBox _textBox5;
	private TextBox _textBox6;
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
			"1. The text of the individual textboxes matches their clientsize " +
			"height, and is (from top to bottom):{0}{0}" +
			"   * 20{0}" +
			"   * 13{0}" +
			"   * 16{0}" +
			"   * 50{0}" +
			"   * 10{0}" +
			"   * 46",
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
		ClientSize = new Size (300, 200);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81402";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
