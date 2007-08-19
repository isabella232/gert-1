using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		// 
		// _components
		// 
		_components = new Container ();
		// 
		// _imageList
		// 
		_imageList = new ImageList (_components);
		_imageList.ImageSize = new Size (16, 16);
		_imageList.Images.Add (new Icon (Path.Combine (dir, "Computer.ico")).ToBitmap ());
		_imageList.Images.Add (new Icon (Path.Combine (dir, "Computer.ico")));
		_imageList.TransparentColor = Color.Transparent;
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		_tabControl.HotTrack = true;
		_tabControl.ImageList = _imageList;
		_tabControl.SelectedIndex = 1;
		Controls.Add (_tabControl);
		// 
		// _myComputerTab
		// 
		_myComputerTab = new TabPage ();
		_myComputerTab.Height = 100;
		_myComputerTab.ImageIndex = 0;
		_myComputerTab.Text = "My Computer";
		_tabControl.Controls.Add (_myComputerTab);
		// 
		// _remoteComputerTab
		// 
		_remoteComputerTab = new TabPage ();
		_remoteComputerTab.ImageIndex = 1;
		_remoteComputerTab.Text = "Remote Computer";
		_tabControl.Controls.Add (_remoteComputerTab);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 90);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82486";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing) {
			if (_components != null)
				_components.Dispose ();
		}
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private IContainer _components;
	private ImageList _imageList;
	private TabControl _tabControl;
	private TabPage _myComputerTab;
	private TabPage _remoteComputerTab;
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
			"1. The same 8-bit icon is displayed in both tab leaves.",
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
		ClientSize = new Size (330, 90);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82486";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
