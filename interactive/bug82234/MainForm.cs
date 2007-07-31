using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGridView
		// 
		_dataGridView = new DataGridView ();
		_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		_dataGridView.Dock = DockStyle.Top;
		_dataGridView.Height = 150;
		_dataGridView.RowHeadersVisible = false;
		_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		Controls.Add (_dataGridView);
		// 
		// _urlTextBoxColumn
		// 
		_urlTextBoxColumn = new DataGridViewTextBoxColumn ();
		_urlTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		_urlTextBoxColumn.HeaderText = "Source url";
		_dataGridView.Columns.Add (_urlTextBoxColumn);
		// 
		// _fillButton
		// 
		_fillButton = new Button ();
		_fillButton.Location = new Point (115, 160);
		_fillButton.Text = "Fill";
		_fillButton.Click += new EventHandler (FillButton_Click);
		Controls.Add (_fillButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 190);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82234";
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
	}

	void FillButton_Click (object sender, EventArgs e)
	{
		_dataGridView.Rows.Clear ();
		_dataGridView.Rows.Add ("http://www.mono-project.com/");
		_dataGridView.Rows.Add ("http://nant.sourceforge.net/");

		Refresh ();
	}

	private DataGridView _dataGridView;
	private DataGridViewTextBoxColumn _urlTextBoxColumn;
	private Button _fillButton;
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
			"1. Click the Fill button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Two rows containing URLs are added to the DataGridView.",
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
		ClientSize = new Size (320, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82234";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
