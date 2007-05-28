using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	private ToolBar _toolBar;
	private ToolBarButton _newButton;
	private ImageList imgToolMenus;
	private ToolBarButton _openButton;
	private ToolBarButton _moveNowButton;

	public MainForm ()
	{
		ComponentResourceManager resources = new ComponentResourceManager (typeof (MainForm));
		SuspendLayout ();
		// 
		// imgToolMenus
		// 
		imgToolMenus = new ImageList ();
		imgToolMenus.ImageStream = ((ImageListStreamer) (resources.GetObject ("imgToolMenus.ImageStream")));
		imgToolMenus.TransparentColor = Color.Transparent;
		// 
		// _toolBar
		// 
		_toolBar = new ToolBar ();
		_toolBar.Appearance = ToolBarAppearance.Flat;
		_toolBar.DropDownArrows = true;
		_toolBar.ImageList = imgToolMenus;
		_toolBar.Location = new Point (0, 0);
		_toolBar.Name = "_toolBar";
		_toolBar.ShowToolTips = true;
		_toolBar.Size = new Size (690, 28);
		_toolBar.TabIndex = 32;
		_toolBar.TextAlign = ToolBarTextAlign.Right;
		_toolBar.Wrappable = false;
		Controls.Add (_toolBar);
		// 
		// _newButton
		// 
		_newButton = new ToolBarButton ();
		_newButton.ImageIndex = 0;
		_newButton.ToolTipText = "Start a new chess game";
		_toolBar.Buttons.Add (_newButton);
		// 
		// _openButton
		// 
		_openButton = new ToolBarButton ();
		_openButton.ImageIndex = 1;
		_openButton.ToolTipText = "Open a saved chess game";
		_toolBar.Buttons.Add (_openButton);
		// 
		// _moveNowButton
		// 
		_moveNowButton = new ToolBarButton ();
		_moveNowButton.ImageIndex = 11;
		_moveNowButton.Text = "Move Now";
		_moveNowButton.ToolTipText = "Make the computer immediately play the best move it has found so far";
		_toolBar.Buttons.Add (_moveNowButton);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (200, 80);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		FormBorderStyle = FormBorderStyle.FixedDialog;
		SizeGripStyle = SizeGripStyle.Hide;
		Text = "bug #81733";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
		PerformLayout ();
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
			"1. The following buttons are displayed:{0}{0}" +
			"   * New{0}" +
			"   * Open{0}" +
			"   * Move Now{0}{0}" +
			"2. The New and Open buttons have no text, and have a \"normal\" " +
			"width.{0}{0}" +
			"3. The MoveNow button has text and is move wide.",
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
		ClientSize = new Size (360, 200);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81733";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
