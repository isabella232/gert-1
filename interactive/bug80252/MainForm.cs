using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Multiline = true;
		_eventsText.Location = new Point (8, 8);
		_eventsText.Size = new Size (280, 200);
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		Cursor = Cursors.WaitCursor;
		ContextMenu = new ContextMenu ();
		ContextMenu.MenuItems.Add ("Test");
		ContextMenu.Popup += new EventHandler (ContextMenu_Popup);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80252";
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

	void ContextMenu_Popup (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"ContextMenu => Popup" +
			Environment.NewLine);
	}

	private TextBox _eventsText;
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
			"1. Right-click the area below the TextBox on different " +
			"positions.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. If the context menu was displayed at another position, the " +
			"context menu is no longer displayed at that position.{0}{0}" +
			"2. The context menu pops up where you right-clicked.{0}{0}" +
			"3. A Popup event is fired whenever you right-click the area " +
			"below the TextBox.",
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
		ClientSize = new Size (350, 250);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80252";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
