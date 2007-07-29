using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Dock = DockStyle.Top;
		_listView.FullRowSelect = true;
		_listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		_listView.Height = 100;
		_listView.HideSelection = false;
		_listView.TabIndex = 0;
		_listView.View = View.Details;
		_listView.KeyDown += new KeyEventHandler (ListView_KeyDown);
		_listView.KeyPress += new KeyPressEventHandler (ListView_KeyPress);
		Controls.Add (_listView);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (8, 112);
		_resetButton.TabStop = false;
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 220;
		_eventsText.Multiline = true;
		_eventsText.TabStop = false;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 365);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81569";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();

		_listView.Columns.Add ("Topic", 200, HorizontalAlignment.Left);
		_listView.Columns.Add ("TraceLevel", 80, HorizontalAlignment.Left);
		_listView.Items.Add ("Item One").SubItems.Add ("Sub one");
		_listView.Items.Add ("Item Two").SubItems.Add ("Sub two");
		_listView.Items.Add ("Item Three").SubItems.Add ("Sub three");
		_listView.Items.Add ("Item Four").SubItems.Add ("Sub four");
	}

	void ListView_KeyPress (object sender, KeyPressEventArgs e)
	{
		_eventsText.AppendText ("KeyPress => " + (int) e.KeyChar +
			Environment.NewLine);
	}

	void ListView_KeyDown (object sender, KeyEventArgs e)
	{
		_eventsText.AppendText ("KeyDown => " + e.KeyCode +
			Environment.NewLine);
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
	}

	private ListView _listView;
	private Button _resetButton;
	private TextBox _eventsText;
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
			"1. Ensure the ListView has focus.{0}{0}" +
			"2. Press the following keys:{0}{0}" +
			"   * Escape{0}" +
			"   * Left Arrow{0}" +
			"   * Right Arrow{0}" +
			"   * Enter{0}" +
			"   * Multiply{0}" +
			"   * Space{0}" +
			"   * Add{0}" +
			"   * Subtract{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   * KeyDown => Escape{0}" +
			"   * KeyPress => 27{0}" +
			"   * KeyDown => Left{0}" +
			"   * KeyDown => Right{0}" +
			"   * KeyDown => Return{0}" +
			"   * KeyPress => 13{0}" +
			"   * KeyDown => Multiply{0}" +
			"   * KeyPress => 42{0}" +
			"   * KeyDown => Space{0}" +
			"   * KeyPress => 32{0}" +
			"   * KeyDown => Add{0}" +
			"   * KeyPress => 43{0}" +
			"   * KeyDown => Subtract{0}" +
			"   * KeyPress => 45",
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
		ClientSize = new Size (360, 465);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81569";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
