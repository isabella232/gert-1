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
		_imageList.Images.Add (new Icon (Path.Combine (dir, "Folder.ico")));
		_imageList.Images.Add (new Icon (Path.Combine (dir, "Computer.ico")));
		_imageList.Images.Add (new Icon (Path.Combine (dir, "Services.ico")));
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
		// _folderTab
		// 
		_folderTab = new TabPage ();
		_folderTab.ImageIndex = 0;
		_folderTab.Text = "Folder";
		_tabControl.Controls.Add (_folderTab);
		// 
		// _computerTab
		// 
		_computerTab = new TabPage ();
		_computerTab.ImageIndex = 1;
		_computerTab.Text = "Computer";
		_tabControl.Controls.Add (_computerTab);
		// 
		// _servicesTab
		// 
		_servicesTab = new TabPage ();
		_servicesTab.ImageIndex = 2;
		_servicesTab.Text = "Services";
		_tabControl.Controls.Add (_servicesTab);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 50);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81836";
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
	private TabPage _folderTab;
	private TabPage _computerTab;
	private TabPage _servicesTab;
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
			"1. The text and icons in the leafs are fully visible.{0}{0}" +
			"2. The icons are drawn within the leafs.{0}{0}" +
			"3. The text is not drawn on top of the icons.",
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
		ClientSize = new Size (330, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81836";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
