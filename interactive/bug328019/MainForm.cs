using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _toolBar
		// 
		_toolBar = new ToolBar ();
		_toolBar.Dock = DockStyle.Top;
		_toolBar.ButtonClick += new  ToolBarButtonClickEventHandler (ToolBar_ButtonClick);
		Controls.Add (_toolBar);
		// 
		// _showFormButton
		// 
		_showFormButton = new ToolBarButton ();
		_showFormButton.Text = "Show Form";
		_toolBar.Buttons.Add (_showFormButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		IsMdiContainer = true;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #328019";
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

	void ToolBar_ButtonClick (object sender, ToolBarButtonClickEventArgs e)
	{
		Form child = new Form ();
		child.ClientSize = new Size (200, 100);
		child.MdiParent = this;
		child.Text = "Child";
		child.Load += new EventHandler (Child_Load);
		child.Show ();
	}

	void Child_Load (object sender, EventArgs e)
	{
		((Form) sender).MdiParent = this;
	}

	private ToolBar _toolBar;
	private ToolBarButton _showFormButton;
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
			"1. Click the Show Form button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A small child form is displayed.",
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
		Text = "Instructions - bug #328019";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
