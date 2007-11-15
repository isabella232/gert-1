using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _comboBox
		// 
		_comboBox = new ComboBox ();
		_comboBox.Location = new Point (8, 12);
		_comboBox.Size = new Size (285, 20);
		_comboBox.GotFocus += new EventHandler (ComboBox_GotFocus);
		_comboBox.LostFocus += new EventHandler (ComboBox_LostFocus);
		Controls.Add (_comboBox);
		// 
		// _selectButton
		// 
		_selectButton = new NonSelectableButton ();
		_selectButton.FlatStyle = FlatStyle.Flat;
		_selectButton.Location = new Point (10, 100);
		_selectButton.Text = "Select";
		_selectButton.Click += new EventHandler (SelectButton_Click);
		Controls.Add (_selectButton);
		// 
		// _refreshButton
		// 
		_refreshButton = new NonSelectableButton ();
		_refreshButton.FlatStyle = FlatStyle.Flat;
		_refreshButton.Location = new Point (115, 100);
		_refreshButton.Text = "Refresh";
		_refreshButton.Click += new EventHandler (RefreshButton_Click);
		Controls.Add (_refreshButton);
		// 
		// _quitButton
		// 
		_quitButton = new Button ();
		_quitButton.FlatStyle = FlatStyle.Flat;
		_quitButton.Location = new Point (215, 100);
		_quitButton.Text = "Quit";
		_quitButton.Click += new EventHandler (QuitButton_Click);
		Controls.Add (_quitButton);
		// 
		// _selectionStartLabel
		// 
		_selectionStartLabel = new Label ();
		_selectionStartLabel.Location = new Point (8, 50);
		_selectionStartLabel.Size = new Size (100, 20);
		_selectionStartLabel.Text = "SelectionStart:";
		Controls.Add (_selectionStartLabel);
		// 
		// _selectionStartValue
		// 
		_selectionStartValue = new Label ();
		_selectionStartValue.Location = new Point (110, 50);
		_selectionStartValue.Size = new Size (100, 20);
		Controls.Add (_selectionStartValue);
		// 
		// _selectionLengthLabel
		// 
		_selectionLengthLabel = new Label ();
		_selectionLengthLabel.Location = new Point (8, 75);
		_selectionLengthLabel.Size = new Size (100, 20);
		_selectionLengthLabel.Text = "SelectionLength:";
		Controls.Add (_selectionLengthLabel);
		// 
		// _selectionLengthValue
		// 
		_selectionLengthValue = new Label ();
		_selectionLengthValue.Location = new Point (110, 75);
		_selectionLengthValue.Size = new Size (100, 20);
		Controls.Add (_selectionLengthValue);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 135);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #333663";
		Load += new EventHandler (MainForm_Load);
	}
	
	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		for (int i = 1; i <= 40; i++)
			_comboBox.Items.Add ("Item " + i.ToString (CultureInfo.InvariantCulture));
		_comboBox.SelectedIndex = 4;
		_comboBox.SelectionLength = 2;
		_comboBox.SelectionStart = 3;

		RefreshSelection ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ComboBox_GotFocus (object sender, EventArgs e)
	{
		RefreshSelection ();
	}

	void ComboBox_LostFocus (object sender, EventArgs e)
	{
		RefreshSelection ();
	}

	void SelectButton_Click (object sender, EventArgs e)
	{
		_comboBox.SelectionLength = 3;
		_comboBox.SelectionStart = 1;
		RefreshSelection ();
	}

	void RefreshButton_Click (object sender, EventArgs e)
	{
		RefreshSelection ();
	}

	void QuitButton_Click (object sender, EventArgs e)
	{
		Application.Exit ();
	}

	void RefreshSelection ()
	{
		_selectionStartValue.Text = _comboBox.SelectionStart.ToString (CultureInfo.InvariantCulture);
		_selectionLengthValue.Text = _comboBox.SelectionLength.ToString (CultureInfo.InvariantCulture);
	}

	private ComboBox _comboBox;
	private Button _selectButton;
	private Button _refreshButton;
	private Button _quitButton;
	private Label _selectionStartLabel;
	private Label _selectionStartValue;
	private Label _selectionLengthLabel;
	private Label _selectionLengthValue;
}

public class NonSelectableButton : Button
{
	public NonSelectableButton ()
	{
		SetStyle (ControlStyles.Selectable, false);
	}
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
			"Expected result on start-up:{0}{0}" +
			"1. \"Item 5\" is highlighted.{0}{0}" +
			"2. SelectionStart is 0.{0}{0}" +
			"2. SelectionLength is 6.",
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
			"1. Click the dropdown arrow.{0}{0}" +
			"2. Scroll down.{0}{0}" +
			"3. Select \"Item 17\".{0}{0}" +
			"4. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The dropdown list is closed.{0}{0}" +
			"2. The text \"Item 17\" is highlighted in the combobox.{0}{0}" +
			"3. SelectionStart is 0.{0}{0}" +
			"4. SelectionLength is 7.",
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
			"1. Click the dropdown arrow.{0}{0}" +
			"2. Scroll up.{0}{0}" +
			"3. Select \"Item 8\".{0}{0}" +
			"4. Press the Tab key.{0}{0}." +
			"5. Click the Select button.{0}{0}" +
			"6. Press the Tab key.{0}{0}." +
			"Expected result:{0}{0}" +
			"1. On step 4:{0}{0}" +
			"   * The text \"Item 8\" is no longer selected.{0}" +
			"   * SelectionStart is 0.{0}" +
			"   * SelectionLength is 0.{0}{0}" +
			"2. On step 5:{0}{0}" +
			"   * The letters \"tem\" are selected.{0}" +
			"   * SelectionStart is 1.{0}" +
			"   * SelectionLength is 3.{0}{0}" +
			"3. On step 6:{0}{0}" +
			"   * The text \"Item 8\" is selected.{0}" +
			"   * SelectionStart is 0.{0}" +
			"   * SelectionLength is 6.",
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
		ClientSize = new Size (300, 480);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #333663";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
