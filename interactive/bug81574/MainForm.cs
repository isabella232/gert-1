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
		// _groupBox
		// 
		_groupBox = new GroupBox ();
		_groupBox.AllowDrop = true;
		_groupBox.Dock = DockStyle.Top;
		_groupBox.Height = 100;
		_groupBox.TabIndex = 0;
		_groupBox.TabStop = false;
		_groupBox.Text = "Drop a file here";
		_groupBox.DragDrop += new DragEventHandler (GroupBox_DragDrop);
		_groupBox.DragEnter += new DragEventHandler (GroupBox_DragEnter);
		Controls.Add (_groupBox);
		// 
		// _filesListBox
		// 
		_filesListBox = new ListBox ();
		_filesListBox.Dock = DockStyle.Bottom;
		_filesListBox.Height = 150;
		Controls.Add (_filesListBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 265);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81574";
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

	void GroupBox_DragDrop (object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent (DataFormats.FileDrop)) {
			string [] filenames = (string []) e.Data.GetData (DataFormats.FileDrop);
			if (filenames != null) {
				foreach (string fileName in filenames)
					_filesListBox.Items.Add ("Drop => " + fileName);
			}
		}
	}

	void GroupBox_DragEnter (object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent (DataFormats.FileDrop)) {
			string [] filenames = (string []) e.Data.GetData (DataFormats.FileDrop);
			if (filenames != null) {
				e.Effect = DragDropEffects.Copy;
				foreach (string fileName in filenames)
					_filesListBox.Items.Add ("Enter => " + fileName);
			} else {
				e.Effect = DragDropEffects.None;
			}
		}
	}

	private GroupBox _groupBox;
	private ListBox _filesListBox;
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
			"1. Drag&Drop one or more files on the GroupBox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. When the GroupBox is entered, the full path of each file is " +
			"added to the ListBox with a matching prefix.{0}{0}" +
			"2. When the files are dropped on the GroupBox, the full path of " +
			"each file is added to the ListBox with a matching prefix.",
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
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81574";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
