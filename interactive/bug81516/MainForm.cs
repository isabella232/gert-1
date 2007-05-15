using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _customControl
		// 
		_customControl = new CustomControl ();
		_customControl.BackColor = Color.Yellow;
		_customControl.Location = new Point (5, 5);
		_customControl.Parent = this;
		_customControl.Size = new Size (50, 50);
		Controls.Add (_customControl);
		// 
		// MainForm
		// 
		ClientSize = new Size (200, 70);
		Location = new Point (350, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81516";
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

	private CustomControl _customControl;
}

public class CustomControl : Control
{
	protected override void OnPaint (PaintEventArgs args)
	{
		Graphics g = args.Graphics;

		SolidBrush brush = new SolidBrush (ForeColor);
		StringFormat sformat = new StringFormat ();
		sformat.FormatFlags = StringFormatFlags.LineLimit;
		g.DrawString ("WeShouldIncludeWhiteSpaces", Font, brush, new Rectangle (0, 0, 55, 100),
				sformat);
		brush.Dispose ();
		sformat.Dispose ();
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
			"Expected result on start-up:{0}{0}" +
			"1. A yellow shape is drawn containing the text \"WeShouldInclude" +
			"WhiteSpaces\" spread over multiple lines.",
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
		ClientSize = new Size (330, 110);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81516";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
