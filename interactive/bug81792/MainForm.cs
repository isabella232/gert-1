using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_textBox = new TextBox ();
		_textBox.Location = new Point (8, 8);
		_textBox.Text = "ghIjKpy";
		_textBox.BorderStyle = BorderStyle.None;
		Controls.Add (_textBox);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 170;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The following text is displayed in the TextBox:{0}{0}" +
			"   ghIjKpy{0}{0}" +
			"2. The highlighted text fills the complete height of the TextBox.{0}{0}" +
			"3. The bottom part of the letters is visible.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		// 
		ClientSize = new Size (405, 210);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81792";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private TextBox _textBox;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
