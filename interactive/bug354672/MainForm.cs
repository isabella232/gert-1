using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		tableLayoutPanel1 = new TableLayoutPanel ();
		tableLayoutPanel2 = new TableLayoutPanel ();
		label1 = new Label ();
		label2 = new Label ();
		textBox1 = new TextBox ();
		textBox2 = new TextBox ();
		label3 = new Label ();
		tableLayoutPanel1.SuspendLayout ();
		tableLayoutPanel2.SuspendLayout ();
		SuspendLayout ();
		// 
		// tableLayoutPanel1
		// 
		tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
		tableLayoutPanel1.ColumnCount = 2;
		tableLayoutPanel1.ColumnStyles.Add (new ColumnStyle ());
		tableLayoutPanel1.ColumnStyles.Add (new ColumnStyle ());
		tableLayoutPanel1.Controls.Add (tableLayoutPanel2, 1, 0);
		tableLayoutPanel1.Controls.Add (label3, 0, 0);
		tableLayoutPanel1.Location = new Point (20, 30);
		tableLayoutPanel1.RowCount = 2;
		tableLayoutPanel1.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		tableLayoutPanel1.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		tableLayoutPanel1.Size = new Size (250, 145);
		tableLayoutPanel1.TabIndex = 0;
		// 
		// tableLayoutPanel2
		// 
		tableLayoutPanel2.AutoSize = true;
		tableLayoutPanel2.ColumnCount = 2;
		tableLayoutPanel2.ColumnStyles.Add (new ColumnStyle ());
		tableLayoutPanel2.ColumnStyles.Add (new ColumnStyle (SizeType.Percent, 50F));
		tableLayoutPanel2.Controls.Add (label1, 0, 0);
		tableLayoutPanel2.Controls.Add (label2, 0, 1);
		tableLayoutPanel2.Controls.Add (textBox1, 1, 0);
		tableLayoutPanel2.Controls.Add (textBox2, 1, 1);
		tableLayoutPanel2.Location = new Point (68, 3);
		tableLayoutPanel2.RowCount = 2;
		tableLayoutPanel2.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		tableLayoutPanel2.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		tableLayoutPanel2.Size = new Size (131, 39);
		tableLayoutPanel2.TabIndex = 0;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point (3, 0);
		label1.Size = new Size (19, 13);
		label1.TabIndex = 0;
		label1.Text = "en";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new Point (3, 19);
		label2.Size = new Size (18, 13);
		label2.TabIndex = 1;
		label2.Text = "es";
		// 
		// textBox1
		// 
		textBox1.Dock = DockStyle.Fill;
		textBox1.Location = new Point (28, 3);
		textBox1.Size = new Size (100, 20);
		textBox1.TabIndex = 2;
		// 
		// textBox2
		// 
		textBox2.Dock = DockStyle.Fill;
		textBox2.Location = new Point (28, 22);
		textBox2.Size = new Size (100, 20);
		textBox2.TabIndex = 3;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new Point (3, 0);
		label3.Size = new Size (59, 13);
		label3.TabIndex = 1;
		label3.Text = "Head word";
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (292, 200);
		Controls.Add (tableLayoutPanel1);
		tableLayoutPanel1.ResumeLayout (false);
		tableLayoutPanel1.PerformLayout ();
		tableLayoutPanel2.ResumeLayout (false);
		tableLayoutPanel2.PerformLayout ();
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #354672";
		ResumeLayout (false);
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

	private TableLayoutPanel tableLayoutPanel1;
	private TableLayoutPanel tableLayoutPanel2;
	private Label label1;
	private Label label2;
	private TextBox textBox1;
	private Label label3;
	private TextBox textBox2;
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
			"Expected result at start-up:{0}{0}" +
			"1. A table with 2 columns and 2 rows is drawn.{0}{0}" +
			"2. The top-left cell contains a label with text " +
			"\"Head word\".{0}{0}" +
			"3. The top-right cell contains two labels and two " +
			"textboxes.",
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
		ClientSize = new Size (300, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #354672";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
