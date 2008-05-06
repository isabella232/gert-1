using System;
using System.Windows.Forms;

class Program
{
	static int Main ()
	{
		WeakReference wr = new WeakReference (new MainForm ());
		Application.Run ((Form) wr.Target);

		GC.Collect ();
		System.Threading.Thread.Sleep (200);
		GC.Collect ();

		return wr.IsAlive ? 1 : 0;
	}
}

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _menuStrip
		// 
		_menuStrip = new MenuStrip ();
		Controls.Add (_menuStrip);
		// 
		// _fileMenu
		// 
		_fileMenu = new ToolStripMenuItem ();
		_fileMenu.Text = "File";
		_menuStrip.Items.Add (_fileMenu);
		// 
		// _closeItem
		// 
		_closeItem = new ToolStripMenuItem ();
		_closeItem.Text = "Close";
		_fileMenu.DropDownItems.Add (_closeItem);
		// 
		// MainForm
		// 
		MainMenuStrip = _menuStrip;
		Load += new EventHandler (MainForm_Load);
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing) {
			_timer.Dispose ();
		}
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_timer = new Timer ();
		_timer.Tick += new EventHandler (Timer_Ticket);
		_timer.Interval = 100;
		_timer.Start ();
	}

	void Timer_Ticket (object sender, EventArgs e)
	{
		switch (_tickCount) {
		case 0:
			_fileMenu.ShowDropDown ();
			break;
		case 1:
			_timer.Stop ();
			_fileMenu.HideDropDown ();
			Close ();
			break;
		}

		_tickCount++;
	}

	private int _tickCount;
	private Timer _timer;
	private MenuStrip _menuStrip;
	private ToolStripMenuItem _fileMenu;
	private ToolStripMenuItem _closeItem;
}
