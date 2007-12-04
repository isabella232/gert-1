using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	public MainForm ()
	{
		SuspendLayout ();
		TestPanel TestPanel = new TestPanel ();
		TestPanel.AutoScroll = true;
		TestPanel.Dock = DockStyle.Top;
		Controls.Add (TestPanel);
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #342932";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout ();
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}
}

public class TestPanel : Panel
{
	public TestPanel ()
	{
		Resize += new EventHandler (TestPanel_Resize);

		m_IdLbl.Text = "ID: ";
		m_IdTxt.Text = " ";
		m_RemLbl.Text = "Remark: ";
		m_RemTxt.Text = " ";

		Controls.Add (m_IdLbl);
		Controls.Add (m_IdTxt);
		Controls.Add (m_RemLbl);
		Controls.Add (m_RemTxt);
	}

	void TestPanel_Resize (object sender, EventArgs e)
	{
		m_IdLbl.Left = 0;
		m_IdLbl.Top = 0;
		m_IdTxt.Left = m_IdLbl.Right;
		m_IdTxt.Top = m_IdLbl.Top;
		m_RemLbl.Left = m_IdTxt.Right + 20;
		m_RemLbl.Top = m_RemLbl.Top;
		m_RemTxt.Left = m_RemLbl.Right;
		m_RemTxt.Top = m_RemLbl.Top;
		m_RemTxt.Width = 250;
	}

	private TextBox m_IdTxt = new TextBox ();
	private Label m_IdLbl = new Label ();
	private Label m_RemLbl = new Label ();
	private TextBox m_RemTxt = new TextBox ();
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
			"1. Move the horizontal scrollbar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No crash.",
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
		ClientSize = new Size (300, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #342932";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
