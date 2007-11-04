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
		_panel.Height = 50;
		_panel.BackColor = SystemColors.Control;
		Controls.Add (_panel);
		// 
		// _label
		// 
		_label = new Label ();
		_label.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
		_label.AutoSize = false;
		_label.AutoEllipsis = true;
		_label.Height = 50;
		_label.Width = _panel.Width - 4;
		_panel.Controls.Add (_label);
		// 
		// MainForm
		// 
		BackColor = Color.White;
		ClientSize = new Size (300, 150);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #338965";
		Load += new EventHandler (MainForm_Load);
	}
	
	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_label.Text = "A collection of additional paths to search for "
			+ "reference assemblies." + Environment.NewLine
			+ "Note: This is a PROJECT level property that is "
			+ "shared by all the documenters.";

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
			"1. Move the splitter bar down a little to move part " +
			"of the last line vertically off the screen.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. When part of the text (or part of a line) is no " +
			"longer fully visible, the ellipsis character (...) " +
			"appears at the right edge of the control.",
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
		ClientSize = new Size (300, 190);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #338965";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
