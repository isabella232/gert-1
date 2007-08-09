using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _againButton
		// 
		_againButton = new Button ();
		_againButton.BackColor = Color.Transparent;
		_againButton.ForeColor = Color.White;
		_againButton.Location = new Point (75, 144);
		_againButton.Name = "_againButton";
		_againButton.Size = new Size (48, 18);
		_againButton.TabIndex = 0;
		_againButton.Text = "Again?";
		_againButton.Visible = false;
		_againButton.Click += new System.EventHandler (AgainButton_Click);
		Controls.Add (_againButton);
		// 
		// _quitButton
		// 
		_quitButton = new Button ();
		_quitButton.BackColor = Color.Transparent;
		_quitButton.ForeColor = Color.White;
		_quitButton.Location = new Point (129, 144);
		_quitButton.Name = "_quitButton";
		_quitButton.Size = new Size (46, 18);
		_quitButton.TabIndex = 1;
		_quitButton.Text = "Quit?";
		_quitButton.Visible = false;
		_quitButton.Click += new System.EventHandler (QuitButton_Click);
		Controls.Add (_quitButton);
		// 
		// _timer
		// 
		_timer = new Timer ();
		_timer.Enabled = true;
		_timer.Interval = 25;
		_timer.Tick += new EventHandler (Timer_Tick);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		BackColor = Color.Blue;
		ClientSize = new Size (250, 194);
		FormBorderStyle = FormBorderStyle.None;
		Location = new Point (250, 100);
		Opacity = 0;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80853";
		TransparencyKey = Color.Blue;
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void OnPaint (PaintEventArgs e)
	{
		e.Graphics.DrawImage (btmBurl,
			rect,
			0, 0, btmBurl.Width, btmBurl.Height,
			GraphicsUnit.Pixel);
	}

	protected override void WndProc (ref Message m)
	{
		if (m.Msg == WM_NCHITTEST)
			m.Result = new IntPtr (HTCAPTION);
		else
			base.WndProc (ref m);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		SetStyle (ControlStyles.AllPaintingInWmPaint |
			ControlStyles.UserPaint |
			ControlStyles.DoubleBuffer,
			true);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		_opacity += 0.03f;
		Opacity = _opacity;
		if (_opacity > 1.0) {
			_timer.Enabled = false;
			_againButton.Show ();
			_quitButton.Show ();
		}
		Invalidate ();
	}

	void AgainButton_Click (object sender, EventArgs e)
	{
		_opacity = 0;
		_againButton.Hide ();
		_quitButton.Hide ();
		_timer.Enabled = true;
	}

	void QuitButton_Click (object sender, EventArgs e)
	{
		Application.Exit ();
	}

	private Button _againButton;
	private Button _quitButton;
	private Timer _timer;
	private float _opacity = 0;
	private Bitmap btmBurl = new Bitmap ("BurlWoodTech.jpg");
	private Rectangle rect = new Rectangle (0, 0, 250, 194);

	private const int WM_NCHITTEST = 0x84;
	private const int HTCAPTION = 0x2;
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
			"Expected result on start-up:{0}{0}" +
			"1. The form fades into view, and stays fully visible.",
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
		ClientSize = new Size (300, 100);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80853";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
