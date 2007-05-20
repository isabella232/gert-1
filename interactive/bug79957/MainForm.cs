using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _numericUpDown
		// 
		_numericUpDown = new NumericUpDown ();
		_numericUpDown.Location = new Point (8, 8);
		_numericUpDown.Maximum = 100000;
		_numericUpDown.LostFocus += new EventHandler (NumericUpDown_LostFocus);
		_numericUpDown.GotFocus += new EventHandler (NumericUpDown_GotFocus);
		Controls.Add (_numericUpDown);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (135, 8);
		_resetButton.Size = new Size (70, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _eventsLabel
		// 
		_eventsLabel = new Label ();
		_eventsLabel.Location = new Point (8, 35);
		_eventsLabel.AutoSize = true;
		_eventsLabel.Text = "Events:";
		Controls.Add (_eventsLabel);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Location = new Point (8, 55);
		_eventsText.Multiline = true;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		_eventsText.Size = new Size (350, 100);
		Controls.Add (_eventsText);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 440;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Click in the NumericUpDown control.{0}{0}" +
			"Expected result:{0}{0}" +
			"2. A line stating \"Got focus.\" is appended to the Events " +
			"textbox.{0}{0}" +
			"======={0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Click in the Events textbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A line stating \"Lost focus.\" is appended to the Events " +
			"textbox.{0}{0}" +
			"2. Focus is moved to the Events textbox.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.ScrollBars = ScrollBars.Vertical;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Click in the NumericUpDown control.{0}{0}" +
			"3. Click in the Events textbox control.{0}{0}" +
			"4. Click in the NumericUpDown control.{0}{0}" +
			"5. Press Tab key (3x).{0}{0}" +
			"6. Click in the Events textbox control.{0}{0}" +
			"7. Click in the NumericUpDown control.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 5, focus is on the TabControl.{0}{0}" +
			"2. On step 7, the following lines are in the Events textbox:{0}{0}" +
			"   Got Focus.{0}" +
			"   Lost Focus.{0}" +
			"   Got Focus.{0}" +
			"   Lost Focus.{0}" +
			"   Got Focus.{0}{0}" +
			"3. Focus is on the NumericUpDown control.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.ScrollBars = ScrollBars.Vertical;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Click in the NumericUpDown control.{0}{0}" +
			"3. Press Tab key.{0}{0}" +
			"4. Press Shift-Tab key.{0}{0}" +
			"5. Click the Reset button.{0}{0}" +
			"6. Press Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 4, the following events have fired:{0}{0}" +
			"   Got Focus.{0}" +
			"   Lost Focus.{0}" +
			"   Got Focus.{0}{0}" +
			"2. On step 6, no events have fired.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (370, 610);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79957";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_numericUpDown.Value = 0;
		_eventsText.Text = "";
	}

	void NumericUpDown_GotFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText ("Got focus." + Environment.NewLine);
	}

	void NumericUpDown_LostFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText ("Lost focus." + Environment.NewLine);
	}

	private Label _eventsLabel;
	private TextBox _eventsText;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private Button _resetButton;
	private NumericUpDown _numericUpDown;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
