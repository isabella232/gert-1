using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
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
		_dataGridView.Location = new Point (26, 22);
		_dataGridView.Size = new Size (240, 221);
		_dataGridView.TabIndex = 0;
		Controls.Add (_dataGridView);
		// 
		// _changeButton
		// 
		_changeButton = new Button ();
		_changeButton.Location = new Point (97, 261);
		_changeButton.Size = new Size (112, 32);
		_changeButton.TabIndex = 1;
		_changeButton.Text = "&Change";
		_changeButton.UseVisualStyleBackColor = true;
		_changeButton.Click += new EventHandler (ChangeButton_Click);
		Controls.Add (_changeButton);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb (((int) (((byte) (220)))), ((int) (((byte) (220)))), ((int) (((byte) (255)))));
		ClientSize = new Size (292, 305);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #78523";
		Layout += new LayoutEventHandler (OnLayout);
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
		CreateArrayList ();
		_dataGridView.DataSource = _list;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void CreateArrayList ()
	{
		_list = new List<TrialDataRow> ();
		Random r = new Random ();
		for (int i = 0; i < 20; ++i) {
			_list.Add (new TrialDataRow (r.NextDouble ()));
		}
	}

	void ChangeButton_Click (object sender, EventArgs e)
	{
		ScrollForward ();

		// Refresh the Datagrid with the new random number
		CurrencyManager cm =
			(CurrencyManager) _dataGridView.BindingContext [_list];
		if (cm != null) {
			cm.Refresh ();
		}
	}

	void ScrollForward ()
	{
		_list.RemoveAt (0);
		Random r = new Random ();
		_list.Add (new TrialDataRow (r.NextDouble ()));
	}

	void OnLayout (object sender, LayoutEventArgs e)
	{
		_dataGridView.Width = Width - 50;
		_dataGridView.Height = Height - _changeButton.Height * 2 - 50;
		_changeButton.Top = _dataGridView.Height + _changeButton.Height * 2 - 15;
		_changeButton.Left = Width / 2 - _changeButton.Width / 2;
	}

	private DataGridView _dataGridView;
	private Button _changeButton;
	private List<TrialDataRow> _list;
}

public class TrialDataRow
{
	private double num;

	public TrialDataRow (double d)
	{
		num = d;
	}

	public double RandomValue {
		get { return num; }
		set { num = value; }
	}

	public double SqrtValue {
		get { return Math.Sqrt (num); }
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Double-click in one of the cells.{0}{0}" +
			"2. Resize the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No crash.",
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
		ClientSize = new Size (350, 200);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #78523";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
