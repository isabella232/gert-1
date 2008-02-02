using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _listBox
		// 
		_listBox = new ListBox ();
		_listBox.Location = new Point (8, 8);
		_listBox.Size = new Size (140, 60);
		_listBox.Click += new EventHandler (ListBox_Click);
#if NET_2_0
		_listBox.MouseClick += new MouseEventHandler (ListBox_MouseClick);
		_listBox.MouseDoubleClick += new MouseEventHandler (ListBox_MouseDoubleClick);
#endif
		_listBox.MouseDown += new MouseEventHandler (ListBox_MouseDown);
		_listBox.MouseUp += new MouseEventHandler (ListBox_MouseUp);
		Controls.Add (_listBox);
		// 
		// _clearButton
		// 
		_clearButton = new Button ();
		_clearButton.Location = new Point (190, 30);
		_clearButton.Size = new Size (60, 20);
		_clearButton.Text = "Clear";
		_clearButton.Click += new EventHandler (ClearButton_Click);
		Controls.Add (_clearButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 200;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #357146";
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

		_listBox.Items.Add ("One");
		_listBox.Items.Add ("Two");
		_listBox.Items.Add ("Three");
		_listBox.Items.Add ("Four");
		_listBox.Items.Add ("Five");
		_listBox.Items.Add ("Six");
	}

	void ClearButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
		_listBox.SelectedIndex = -1;
	}

	void ListBox_Click (object sender, EventArgs e)
	{
		_eventsText.AppendText ("ListBox => Click" + Environment.NewLine);
	}

#if NET_2_0
	void ListBox_MouseClick (object sender, MouseEventArgs e)
	{
		_eventsText.AppendText ("ListBox => MouseClick" + Environment.NewLine);
	}

	void ListBox_MouseDoubleClick (object sender, MouseEventArgs e)
	{
		_eventsText.AppendText ("ListBox => MouseDoubleClick" + Environment.NewLine);
	}
#endif

	void ListBox_MouseDown (object sender, MouseEventArgs e)
	{
		_eventsText.AppendText ("ListBox => MouseDown" + Environment.NewLine);
	}

	void ListBox_MouseUp (object sender, MouseEventArgs e)
	{
		_eventsText.AppendText ("ListBox => MouseUp" + Environment.NewLine);
	}

	private ListBox _listBox;
	private Button _clearButton;
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
			"1. Click the Clear button.{0}{0}" +
			"2. Left-click an item in the listbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The item is highlighted.{0}{0}" +
			"2. The following events have fired (in order):{0}{0}" +
			"   * MouseDown{0}" +
			"   * Click{0}" +
#if NET_2_0
			"   * MouseClick{0}" +
#endif
			"   * MouseUp",
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
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Clear button.{0}{0}" +
			"2. Right-click an item in the listbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The item is not highlighted.{0}{0}" +
			"2. The following events have fired (in order):{0}{0}" +
			"   * MouseDown{0}" +
			"   * MouseUp",
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
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Clear button.{0}{0}" +
			"2. Double-click an item in the listbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The item is highlighted.{0}{0}" +
			"2. The following events have fired (in order):{0}{0}" +
			"   * MouseDown{0}" +
			"   * Click{0}" +
#if NET_2_0
			"   * MouseClick{0}" +
#endif
			"   * MouseUp{0}" +
			"   * MouseDown{0}" +
#if NET_2_0
			"   * MouseDoubleClick{0}" +
#endif
			"   * MouseUp",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (320, 300);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #357146";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
