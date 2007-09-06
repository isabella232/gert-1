using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _table
		// 
		_table = new TableLayoutPanel ();
		_table.ColumnStyles.Add (new ColumnStyle (SizeType.Percent, 100F));
		_table.Dock = DockStyle.Fill;
		_table.RowCount = 1;
		_table.RowStyles.Add (new RowStyle (SizeType.Absolute, 80F));
		Controls.Add (_table);
		// 
		// _label
		// 
		_label = new Label ();
		_label.Anchor = ((AnchorStyles) ((AnchorStyles.Left | AnchorStyles.Right)));
		_label.AutoEllipsis = true;
		_label.AutoSize = true;
		_label.Text = "Centered Label";
		_label.TextAlign = ContentAlignment.MiddleCenter;
		_table.Controls.Add (_label, 0, 1);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82605";
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

	private TableLayoutPanel _table;
	private Label _label;
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
			"1. The label is horizontally centered at the bottom " +
			"of the form.",
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
		Text = "Instructions - bug #82605";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
