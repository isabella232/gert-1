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
		Controls.Add (_numericUpDown);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (135, 8);
		_resetButton.Size = new Size (70, 20);
		_resetButton.Text = "Reset";
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
		_tabControl.Height = 400;
		_tabControl.TabIndex = 1;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Press the Tab key.{0}{0}" +
			"2. Press the Tab key.{0}{0}" +
			"3. Press the Tab key.{0}{0}" +
			"4. Press the Tab key.{0}{0}" +
			"5. Press the Tab key.{0}{0}" +
			"6. Press the Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Before step 1, focus is on the NumericUpDown.{0}{0}" +
			"2. On step 1, focus is on the Reset button.{0}{0}" +
			"3. On step 2, focus is on the TabControl.{0}{0}" +
			"4. On step 3, focus is on the TextBox in the TabControl.{0}{0}" +
			"5. On step 4, focus is on the Events TextBox.{0}{0}" +
			"6. On step 5, focus is on the NumericUpDown.",
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
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (370, 570);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81687";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private Label _eventsLabel;
	private TextBox _eventsText;
	private TextBox _bugDescriptionText1;
	private Button _resetButton;
	private NumericUpDown _numericUpDown;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
