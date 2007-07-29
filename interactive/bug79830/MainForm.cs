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
		// _showPreviewDialogButton
		// 
		_showPreviewDialogButton = new Button ();
		_showPreviewDialogButton.Location = new Point (150, 8);
		_showPreviewDialogButton.Size = new Size (120, 20);
		_showPreviewDialogButton.Text = "Show Preview";
		_showPreviewDialogButton.Click += new EventHandler (ShowPreviewDialogButton_Click);
		Controls.Add (_showPreviewDialogButton);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 190;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Show Preview button.{0}{0}" +
			"2. Switch the zoom level or click the page buttons rapidly " +
			"multiple times.{0}{0}" +
			"3. Click the Close button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A Printing dialog box should not be displayed.",
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
		ClientSize = new Size (400, 240);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79830";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void ShowPreviewDialogButton_Click (object sender, EventArgs e)
	{
		PrintPreviewDialog ppd = new PrintPreviewDialog ();
		ppd.ClientSize = new Size (400, 300);
		ppd.Location = new Point (29, 29);
		ppd.MinimumSize = new Size (375, 250);
		ppd.UseAntiAlias = true;

		ppd.Document = new MyPrintDocument ();
		ppd.ShowDialog ();
	}

	private Button _showPreviewDialogButton;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}

public class MyPrintDocument : PrintDocument
{
	public MyPrintDocument ()
	{
		this.PrintPage += new PrintPageEventHandler (MyPrintDocument_PrintPage);
	}

	static void MyPrintDocument_PrintPage (object sender, PrintPageEventArgs e)
	{
		e.Graphics.DrawEllipse (Pens.Black, 50, 50, 100, 100);
		e.HasMorePages = false;
	}
}
