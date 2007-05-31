using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 100);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81219";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	public static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void OnPaint (PaintEventArgs pe)
	{
		base.OnPaint (pe);

		Font = new Font ("Arial", 12);
		StringFormat format = StringFormat.GenericTypographic;
		format.SetDigitSubstitution (0, StringDigitSubstitute.Traditional);
		format.FormatFlags |= (StringFormatFlags.DisplayFormatControl | StringFormatFlags.NoWrap);
		pe.Graphics.DrawString ("THIS IS A FEED\u0000", Font, new SolidBrush (ForeColor), 10, 10, format);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
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
			"1. An unknown character \"box\" is displayed after the text " +
			"\"THIS IS A FEED\".",
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
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81219";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
