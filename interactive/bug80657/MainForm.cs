using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGridView
		// 
		_dataGridView = new DataGridView ();
		_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		_dataGridView.Dock = DockStyle.Fill;
		_dataGridView.TabIndex = 0;
		Controls.Add (_dataGridView);
		// 
		// _textBoxColumn
		// 
		_textBoxColumn = new DataGridViewTextBoxColumn ();
		_textBoxColumn.HeaderText = "ColumnA";
		_textBoxColumn.Name = "ColumnA";
		_dataGridView.Columns.Add (_textBoxColumn);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (292, 266);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80657";
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

	private DataGridView _dataGridView;
	private DataGridViewTextBoxColumn _textBoxColumn;
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
			"Excepted result on start-up:{0}{0}" +
			"1. A column named \"ColumnA\" is displayed.{0}{0}" +
			"2. An empty data row is displayed.{0}{0}" +
			"3. A selection column is displayed.",
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
		ClientSize = new Size (400, 200);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80657";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
