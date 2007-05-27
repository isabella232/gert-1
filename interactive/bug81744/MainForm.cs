using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _printPreviewControl
		// 
		_printPreviewControl = new PrintPreviewControl ();
		_printPreviewControl.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		_printPreviewControl.Dock = DockStyle.Bottom;
		_printPreviewControl.Height = 295;
		_printPreviewControl.TabIndex = 0;
		_printPreviewControl.Zoom = 1;
		Controls.Add (_printPreviewControl);
		// 
		// _printButton
		// 
		_zoomTrackBar = new TrackBar ();
		_zoomTrackBar.Location = new Point (12, 12);
		_zoomTrackBar.Maximum = 100;
		_zoomTrackBar.Minimum = 1;
		_zoomTrackBar.Size = new Size (330, 23);
		_zoomTrackBar.TabIndex = 1;
		_zoomTrackBar.Text = "Zoom";
		_zoomTrackBar.Value = 10;
		_zoomTrackBar.ValueChanged += new EventHandler (ZoomTrackBar_ValueChanged);
		Controls.Add (_zoomTrackBar);
		// 
		// _printDocument
		// 
		_printDocument = new PrintDocument ();
		_printDocument.PrintPage += new PrintPageEventHandler (PrintDocument_PrintPage);
		_printPreviewControl.Document = _printDocument;
		// 
		// MainForm
		// 
		ClientSize = new Size (350, 350);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81744";
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

	void PrintDocument_PrintPage (object sender, PrintPageEventArgs e)
	{
		using (Pen linePen = new Pen (Color.Black, 1f)) {
			e.Graphics.DrawLine (linePen, 20, 20, 160, 20);
			e.Graphics.DrawLine (linePen, 20, 40, 160, 40);
		}

		using (SolidBrush stringBrush = new SolidBrush (Color.Black)) {
			e.Graphics.DrawString ("This is a test string.", new Font (FontFamily.GenericSansSerif, 12f), stringBrush, new PointF (20f, 20f));
		}
	}

	void ZoomTrackBar_ValueChanged (object sender, EventArgs e)
	{
		_printPreviewControl.Zoom = (double) _zoomTrackBar.Value / 10d;
	}

	private PrintPreviewControl _printPreviewControl;
	private PrintDocument _printDocument;
	private TrackBar _zoomTrackBar;
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
			"1. The document in the PrintPreviewControl contains the following " +
			"text:{0}{0}" +
			"   -----------------------------{0}" +
			"   This is a test string.{0}" +
			"   -----------------------------{0}{0}" +
			"2. The text can easily be read.{0}{0}" +
			"3. Scrollbars are displayed that can be used to scroll though " +
			"the document.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Move the grip of the TrackBar in either direction.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The zoom level of the displayed document modifies accordingly.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 210);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81744";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
