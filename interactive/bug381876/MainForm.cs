using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _groupBoxA
		// 
		_groupBoxA = new GroupBox ();
		_groupBoxA.AllowDrop = true;
		_groupBoxA.Location = new Point (8, 8);
		_groupBoxA.Size = new Size (185, 100);
		_groupBoxA.TabIndex = 0;
		_groupBoxA.TabStop = false;
		_groupBoxA.Text = "A";
		_groupBoxA.DragDrop += new DragEventHandler (GroupBoxA_DragDrop);
		_groupBoxA.DragEnter += new DragEventHandler (GroupBoxA_DragEnter);
		_groupBoxA.DragLeave += new EventHandler (GroupBoxA_DragLeave);
		_groupBoxA.DragOver += new DragEventHandler (GroupBoxA_DragOver);
		_groupBoxA.MouseDown += new MouseEventHandler (GroupBoxA_MouseDown);
		Controls.Add (_groupBoxA);
		// 
		// _groupBoxB
		// 
		_groupBoxB = new GroupBox ();
		_groupBoxB.AllowDrop = true;
		_groupBoxB.Location = new Point (203, 8);
		_groupBoxB.Size = new Size (185, 100);
		_groupBoxB.TabIndex = 0;
		_groupBoxB.TabStop = false;
		_groupBoxB.Text = "B";
		_groupBoxB.DragDrop += new DragEventHandler (GroupBoxB_DragDrop);
		_groupBoxB.DragEnter += new DragEventHandler (GroupBoxB_DragEnter);
		_groupBoxB.DragLeave += new EventHandler (GroupBoxB_DragLeave);
		_groupBoxB.DragOver += new DragEventHandler (GroupBoxB_DragOver);
		_groupBoxB.MouseDown += new MouseEventHandler (GroupBoxB_MouseDown);
		Controls.Add (_groupBoxB);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 150;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 265);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #381876";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
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

	void GroupBoxA_DragDrop (object sender, DragEventArgs e)
	{
		_eventsText.AppendText ("GroupBoxA => DragDrop"
			+ Environment.NewLine);
	}

	void GroupBoxA_DragEnter (object sender, DragEventArgs e)
	{
		_eventsText.AppendText ("GroupBoxA => DragEnter"
			+ Environment.NewLine);
	}

	void GroupBoxA_DragLeave (object sender, EventArgs e)
	{
		_eventsText.AppendText ("GroupBoxA => DragLeave"
			+ Environment.NewLine);
	}

	void GroupBoxA_DragOver (object sender, DragEventArgs e)
	{
		_eventsText.AppendText ("GroupBoxA => DragOver"
			+ Environment.NewLine);
		e.Effect = DragDropEffects.Move;
	}

	void GroupBoxA_MouseDown (object sender, MouseEventArgs e)
	{
		DoDragDrop ("erer", DragDropEffects.All);
	}

	void GroupBoxB_DragDrop (object sender, DragEventArgs e)
	{
		_eventsText.AppendText ("GroupBoxB => DragDrop"
			+ Environment.NewLine);
	}

	void GroupBoxB_DragEnter (object sender, DragEventArgs e)
	{
		_eventsText.AppendText ("GroupBoxB => DragEnter"
			+ Environment.NewLine);
	}

	void GroupBoxB_DragLeave (object sender, EventArgs e)
	{
		_eventsText.AppendText ("GroupBoxB => DragLeave"
			+ Environment.NewLine);
	}

	void GroupBoxB_DragOver (object sender, DragEventArgs e)
	{
		_eventsText.AppendText ("GroupBoxB => DragOver"
			+ Environment.NewLine);
		e.Effect = DragDropEffects.Move;
	}

	void GroupBoxB_MouseDown (object sender, MouseEventArgs e)
	{
		DoDragDrop (this, DragDropEffects.All);
	}

	private GroupBox _groupBoxA;
	private GroupBox _groupBoxB;
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click and release the mouse button on groupbox A " +
			"without moving the mouse pointer.{0}{0}" +
			"2. Click and release the mouse button on groupbox B " +
			"without moving the mouse pointer.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the following events have fired:{0}{0}" +
			"   * GroupBoxA => DragEnter{0}" +
			"   * GroupBoxA => DragLeave{0}{0}" +
			"2. On step 2, the following events have fired:{0}{0}" +
			"   * GroupBoxB => DragEnter{0}" +
			"   * GroupBoxB => DragLeave",
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
		ClientSize = new Size (360, 300);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #381876";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
