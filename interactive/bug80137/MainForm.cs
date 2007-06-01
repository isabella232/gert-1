using System;
using System.ComponentModel;
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
		_label.AutoSize = true;
		_label.BackColor = Color.White;
		_label.BorderStyle = BorderStyle.FixedSingle;
		_label.ForeColor = Color.Black;
		_label.Location = new Point (8, 8);
		_label.Text = "short text";
		Controls.Add (_label);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 150;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the \"Short Text\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. All three lines of text of the Label are fully visible.",
#else
			"1. Only a single line of text of the Label is fully visible.",
#endif
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _shortTextCheck
		// 
		_shortTextCheck = new CheckBox ();
		_shortTextCheck.Checked = true;
		_shortTextCheck.Location = new Point (8, 65);
		_shortTextCheck.Size = new Size (120, 23);
		_shortTextCheck.Text = "Short Text";
		_shortTextCheck.Click += new EventHandler (ShortTextCheck_CheckedChanged);
		Controls.Add (_shortTextCheck);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (292, 250);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80137";
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
			_label.Text = string.Format ("A little longer text{0}with line breaks" +
				"{0}and whatever you wish for in this life...",
				Environment.NewLine);
		}
	}

	private Label _label;
	private CheckBox _shortTextCheck;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TextBox _bugDescriptionText1;
}
