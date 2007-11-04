using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _splitter
		// 
		_splitter = new Splitter ();
		_splitter.BorderStyle = BorderStyle.FixedSingle;
		_splitter.Dock = DockStyle.Bottom;
		Controls.Add (_splitter);
		// 
		// _panel
		// 
		_panel = new Panel ();
		_panel.Dock = DockStyle.Bottom;
		_panel.Height = 75;
		_panel.BackColor = SystemColors.Control;
		Controls.Add (_panel);
		// 
		// _label
		// 
		_label = new Label ();
		_label.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
		_label.Height = 75;
		_label.Width = _panel.Width - 4;
		_panel.Controls.Add (_label);
		// 
		// MainForm
		// 
		BackColor = Color.White;
		ClientSize = new Size (300, 150);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #338966";
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

	private Splitter _splitter;
	private Panel _panel;
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
			"Steps to execute:{0}{0}" +
			"1. Grap the splitter bar and move it up.{0}{0}" +
			"2. Release the splitter bar.{0}{0}" +
			"3. Grap the splitter bar and move it down.{0}{0}" +
			"4. Release the splitter bar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The splitter can be used to resize the panel.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #338966";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
