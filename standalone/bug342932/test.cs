using System;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		TestPanel TestPanel = new TestPanel ();
		TestPanel.AutoScroll = true;
		TestPanel.Dock = DockStyle.Top;
		Controls.Add (TestPanel);
		ResumeLayout ();
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		MainForm form = new MainForm ();
		form.Show ();
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
