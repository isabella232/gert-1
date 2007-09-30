using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _cell
		// 
		_cell = new Cell ();
		_cell.Dock = DockStyle.Top;
		_cell.Height = 100;
		Controls.Add (_cell);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #328681";
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
	}

	private Cell _cell;
}

public class Cell : UserControl
{
	public Cell ()
	{
		SetStyle (ControlStyles.OptimizedDoubleBuffer, true);
		SetStyle (ControlStyles.AllPaintingInWmPaint, true);
	}

	protected override void OnPaint (PaintEventArgs e)
	{
		this.BackColor = Color.Blue;
		base.OnPaint (e);
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
			"1. The background-color of the top part of the form " +
			"is blue.",
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
		ClientSize = new Size (300, 90);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #328681";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
