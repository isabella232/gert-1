using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _labelTL
		// 
		_labelTL = new Label ();
		_labelTL.AutoSize = true;
		_labelTL.Location = new Point (43, 40);
		_labelTL.Size = new Size (35, 13);
		_labelTL.Text = "Top-Left";
		// 
		// _labelTR
		// 
		_labelTR = new Label ();
		_labelTR.AutoSize = true;
		_labelTR.Location = new Point (214, 40);
		_labelTR.Size = new Size (35, 13);
		_labelTR.Text = "Top-Right";
		// 
		// _labelBL
		// 
		_labelBL = new Label ();
		_labelBL.AutoSize = true;
		_labelBL.Location = new Point (43, 213);
		_labelBL.Size = new Size (35, 13);
		_labelBL.Text = "Bottom-Left";
		// 
		// _labelBR
		// 
		_labelBR = new Label ();
		_labelBR.AutoSize = true;
		_labelBR.Location = new Point (43, 213);
		_labelBR.Size = new Size (35, 13);
		_labelBR.Text = "Bottom-Right";
		// 
		// _tableLayoutPanel
		// 
		_tableLayoutPanel = new TableLayoutPanel ();
		_tableLayoutPanel.ColumnCount = 3;
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle (SizeType.Percent, 50F));
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.Controls.Add (_labelTL, 0, 0);
		_tableLayoutPanel.Controls.Add (_labelTR, 2, 0);
		_tableLayoutPanel.Controls.Add (_labelBL, 0, 2);
		_tableLayoutPanel.Controls.Add (_labelBR, 2, 2);
		_tableLayoutPanel.Dock = DockStyle.Fill;
		_tableLayoutPanel.Padding = new Padding (40);
		_tableLayoutPanel.RowCount = 3;
		_tableLayoutPanel.RowStyles.Add (new RowStyle ());
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle ());
		Controls.Add (_tableLayoutPanel);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #354676";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private TableLayoutPanel _tableLayoutPanel;
	private Label _labelTL;
	private Label _labelTR;
	private Label _labelBL;
	private Label _labelBR;
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
			"1. The labels are displayed with a padding of 40 " +
			"pixels from the border of the form.",
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
		ClientSize = new Size (300, 100);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #354676";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
