using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _label
		// 
		_label = new Label ();
		_label.Size = new Size (255, 60);
		_label.Location = new Point (8, 8);
		_label.Text = "short text";
		Controls.Add (_label);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 215;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the \"Short Text\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Three lines of text of the Label are visible.{0}{0}" +
			"2. No word is cut off (on the second line).{0}{0}" +
			"3. The first line contains 3 words.{0}{0}" +
			"4. The second and third line contains 20 words in total.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _changeTextButton
		// 
		_shortTextCheck = new CheckBox ();
		_shortTextCheck.Checked = true;
		_shortTextCheck.Location = new Point (8, 70);
		_shortTextCheck.Size = new Size (120, 23);
		_shortTextCheck.Text = "Short Text";
		_shortTextCheck.Click += new EventHandler (ShortTextCheck_CheckedChanged);
		Controls.Add (_shortTextCheck);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (292, 320);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80138";
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void ShortTextCheck_CheckedChanged (object sender, EventArgs e)
	{
		if (_shortTextCheck.Checked) {
			_label.Text = "Short Text";
		} else {
			_label.Text = "123 123 123" + Environment.NewLine + "123 123 123 123 123 123 123 123 123 123 123 123 123 123 123 123 123 123 123 123";
		}
	}

	private Label _label;
	private CheckBox _shortTextCheck;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TextBox _bugDescriptionText1;
}
