using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_tabPage = new TabPage ();
		_tabControl = new TabControl ();
		_groupBoxA = new GroupBox ();
		_groupBoxB = new GroupBox ();
		_tabPage.SuspendLayout ();
		_tabControl.SuspendLayout ();
		SuspendLayout ();
		// 
		// _bugDescriptionLabel
		// 
		_bugDescriptionLabel = new Label ();
		_bugDescriptionLabel.Location = new Point (8, 250);
		_bugDescriptionLabel.Size = new Size (235, 100);
		_bugDescriptionLabel.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result:{0}{0}" +
			"1. Groupboxes are displayed on tab page.{0}{0}" +
			"2. Border of groupboxes does not strike through label.",
			Environment.NewLine);
		// 
		// _tabPage
		// 
		_tabPage.BackColor = Color.Transparent;
		_tabPage.Controls.Add (_groupBoxA);
		_tabPage.Controls.Add (_groupBoxB);
		_tabPage.Cursor = Cursors.Default;
		_tabPage.Font = new Font ("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (0)));
		_tabPage.ImageIndex = 1;
		_tabPage.Location = new Point (4, 22);
		_tabPage.Size = new Size (225, 202);
		_tabPage.TabIndex = 1;
		_tabPage.Text = "Tab";
		// 
		// _tabControl
		// 
		_tabControl.Controls.Add (_tabPage);
		_tabControl.Cursor = Cursors.Arrow;
		_tabControl.Enabled = false;
		_tabControl.Location = new Point (8, 8);
		_tabControl.RightToLeft = RightToLeft.No;
		_tabControl.SelectedIndex = 0;
		_tabControl.Size = new Size (233, 228);
		_tabControl.TabIndex = 0;
		// 
		// _groupBoxA
		// 
		_groupBoxA.ForeColor = Color.Black;
		_groupBoxA.Location = new Point (16, 16);
		_groupBoxA.Size = new Size (192, 77);
		_groupBoxA.TabIndex = 14;
		_groupBoxA.TabStop = false;
		_groupBoxA.Text = "GroupboxA";
		// 
		// _groupBoxB
		// 
		_groupBoxB.ForeColor = Color.Black;
		_groupBoxB.Location = new Point (16, 97);
		_groupBoxB.Size = new Size (192, 93);
		_groupBoxB.TabIndex = 15;
		_groupBoxB.TabStop = false;
		_groupBoxB.Text = "GroupboxB";
		// 
		// FormConfiguration
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (247, 330);
		Controls.Add (_bugDescriptionLabel);
		Controls.Add (_tabControl);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79225";
		Load += new System.EventHandler (MainForm_Load);
		_tabPage.ResumeLayout (false);
		_tabControl.ResumeLayout (false);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, System.EventArgs e)
	{
		_tabControl.Enabled = true;
	}

	private TabPage _tabPage;
	private GroupBox _groupBoxA;
	private GroupBox _groupBoxB;
	private TabControl _tabControl;
	private Label _bugDescriptionLabel;
}
