using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _contextMenu
		//
		_contextMenu = new ContextMenu ();
		_contextMenu.MenuItems.Add (new MenuItem ("Close"));
		//
		// _customControl
		//
		_customControl = new CustomControl ();
		_customControl.Dock = DockStyle.Fill;
		_customControl.BackColor = Color.LightBlue;
		_customControl.ContextMenu = _contextMenu;
		Controls.Add (_customControl);
		// 
		// _listBox
		//
		_listBox = new ListBox ();
		_listBox.Dock = DockStyle.Bottom;
		_listBox.Height = 150;
		_customControl.ListBox = _listBox;
		Controls.Add (_listBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #325535";
		Load += new EventHandler (MainForm_Load);
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

	private ContextMenu _contextMenu;
	private CustomControl _customControl;
	private ListBox _listBox;
}

class CustomControl : Control
{
	public ListBox ListBox {
		get { return _listBox; }
		set { _listBox = value; }
	}

	protected override void OnMouseUp (MouseEventArgs args)
	{
		base.OnMouseUp (args);
		_listBox.Items.Add ("Method => OnMouseUp");
	}

	protected override void WndProc (ref Message msg)
	{
		if (msg.Msg == 0x007B) // WM_CONTEXTMENU
			_listBox.Items.Add ("Message => WM_CONTEXTMENU");
		else if (msg.Msg == 0x0205) // WM_RBUTTONUP
			_listBox.Items.Add ("Message => WM_RBUTTONUP");
		base.WndProc (ref msg);
	}

	private ListBox _listBox;
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
			"1. Right-click the blue area.{0}{0}" +
			"2. Release the mouse button.{0}{0}" +
			"3. Click the Close menuitem.{0}{0}" +
			"Expected results:{0}{0}" +
			"1.On step 2:{0}{0}" +
			"   * A contextmenu is displayed{0}" +
			"   * The following messages have been received:{0}{0}" +
			"      WM_RBUTTONUP{0}" +
			"      WM_CONTEXTMENU{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * The contextmenu is closed.{0}" +
			"   * The OnMouseUp method is invoked once the " +
			"contextmenu is closed.",
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
		ClientSize = new Size (400, 340);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #325535";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
