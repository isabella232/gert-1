using System;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _linkLabel
		// 
		_linkLabel = new LinkLabel ();
		_linkLabel.Dock = DockStyle.Top;
		_linkLabel.Height = 100;
		_linkLabel.TabStop = true;
		_linkLabel.TabIndex = 3;
		_linkLabel.BackColor = Color.AntiqueWhite;
		_linkLabel.DisabledLinkColor = Color.Silver;
		_linkLabel.VisitedLinkColor = Color.Navy;
		_linkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
		_linkLabel.LinkColor = Color.Blue;
		Controls.Add (_linkLabel);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 150;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The LinkLabel contains the following lines of text:{0}{0}" +
			"   Barbecue Chicken Pizza{0}{0}" +
			"   1 batch Pizza Dough{0}" +
			"   1 cup BBQ Sauce",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		// 
		Size = new Size (603, 290);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79614";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}
	
	private void MainForm_Load (object sender, EventArgs e)
	{
		string s = "Barbecue Chicken Pizza\r\n\r\n";
		s += "1 batch Pizza Dough\r\n";
		s += "1 cup BBQ Sauce\r\n";
		_linkLabel.LinkArea = new LinkArea (0, 0);
		_linkLabel.Text = s;
	}

	private LinkLabel _linkLabel;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
