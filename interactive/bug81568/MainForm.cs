using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		ComponentResourceManager resources = new ComponentResourceManager (typeof (MainForm));
		SuspendLayout ();
		// 
		// _toolStrip
		// 
		_toolStrip = new ToolStrip ();
		_toolStrip.Location = new Point (0, 24);
		_toolStrip.Name = "_toolStrip";
		_toolStrip.Size = new Size (632, 25);
		_toolStrip.TabIndex = 1;
		_toolStrip.Text = "ToolStrip";
		Controls.Add (_toolStrip);
		// 
		// _newButton
		// 
		_newButton = new ToolStripButton ();
		_newButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_newButton.Image = ((Image) (resources.GetObject ("_newButton.Image")));
		_newButton.ImageTransparentColor = Color.Black;
		_newButton.Text = "New";
		_toolStrip.Items.Add (_newButton);
		// 
		// _openButton
		// 
		_openButton = new ToolStripButton ();
		_openButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_openButton.Image = ((Image) (resources.GetObject ("_openButton.Image")));
		_openButton.ImageTransparentColor = Color.Black;
		_openButton.Text = "Open";
		_openButton.Click += new System.EventHandler (OpenFile);
		_toolStrip.Items.Add (_openButton);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (300, 300);
		IsMdiContainer = true;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81568";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
		PerformLayout ();
	}

	public ToolStrip ToolStrip {
		get { return _toolStrip; }
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void OpenFile (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.MdiParent = this;
		child.Show ();
	}

	private ToolStrip _toolStrip;
	private ToolStripButton _newButton;
	private ToolStripButton _openButton;
}

public class ChildForm : Form
{
	public ChildForm ()
	{
		ComponentResourceManager resources = new ComponentResourceManager (typeof (MainForm));
		//
		// _showFunctionButton
		//
		_showFunctionButton = new ToolStripButton ();
		_showFunctionButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_showFunctionButton.Image = ((Image) (resources.GetObject ("_showFunctionButton.Image")));
		_showFunctionButton.ImageTransparentColor = Color.White;
		_showFunctionButton.Name = "ShowFunction";
		_showFunctionButton.Size = new Size (23, 22);
		_showFunctionButton.Text = "Show Function";
		_showFunctionButton.CheckOnClick = true;
		//
		// _showContextButton
		//
		_showContextButton = new ToolStripButton ();
		_showContextButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_showContextButton.Image = ((Image) (resources.GetObject ("_showContextButton.Image")));
		_showContextButton.ImageTransparentColor = Color.Cyan;
		_showContextButton.Name = "ShowContext";
		_showContextButton.Size = new Size (23, 22);
		_showContextButton.Text = "Show Context";
		_showContextButton.CheckOnClick = true;
		// 
		// ChildForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (200, 150);
		ResumeLayout (false);
		PerformLayout ();
		Activated += new EventHandler (ChildForm_Activated);
		Deactivate += new EventHandler (ChildForm_Deactivate);
	}

	void ChildForm_Activated (object sender, EventArgs e)
	{
		(MdiParent as MainForm).ToolStrip.Items.Insert (1, _showFunctionButton);
		(MdiParent as MainForm).ToolStrip.Items.Insert (1, _showContextButton);
	}

	void ChildForm_Deactivate (object sender, EventArgs e)
	{
		(MdiParent as MainForm).ToolStrip.Items.RemoveByKey (_showFunctionButton.Name);
		(MdiParent as MainForm).ToolStrip.Items.RemoveByKey (_showContextButton.Name);
	}

	private ToolStripButton _showFunctionButton;
	private ToolStripButton _showContextButton;
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
			"Steps to execute:{0}{0}" +
			"1. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A child form is displayed.{0}{0}" +
			"2. Two buttons with icons are inserted between the New and the " +
			"Open button.",
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
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Close the child form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The two buttons that were previously inserted are no longer " +
			"displayed.{0}{0}" +
			"2. The New and Open buttons are located directly next to each " +
			"other again.",
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
		ClientSize = new Size (300, 190);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81568";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
