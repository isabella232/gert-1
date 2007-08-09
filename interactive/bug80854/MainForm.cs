using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _timer
		// 
		_timer = new Timer ();
		_timer.Enabled = true;
		_timer.Interval = 10;
		_timer.Tick += new EventHandler (Timer_Tick);
		// 
		// _againButton
		// 
		_againButton = new Button ();
		_againButton.BackColor = Color.Silver;
		_againButton.Location = new Point (64, 368);
		_againButton.Size = new Size (88, 24);
		_againButton.TabIndex = 0;
		_againButton.Text = "Do it again";
		_againButton.Visible = false;
		_againButton.Click += new EventHandler (AgainButton_Click);
		Controls.Add (_againButton);
		// 
		// _quitButton
		// 
		_quitButton = new Button ();
		_quitButton.BackColor = Color.Silver;
		_quitButton.Location = new Point (176, 368);
		_quitButton.Size = new Size (88, 24);
		_quitButton.TabIndex = 1;
		_quitButton.Text = "Quit";
		_quitButton.Visible = false;
		_quitButton.Click += new System.EventHandler (QuitButton_Click);
		Controls.Add (_quitButton);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		BackColor = Color.Blue;
		ClientSize = new Size (328, 400);
		ControlBox = false;
		FormBorderStyle = FormBorderStyle.None;
		MaximizeBox = false;
		MinimizeBox = false;
		StartPosition = FormStartPosition.CenterScreen;
		TransparencyKey = Color.Blue;
		WindowState = FormWindowState.Minimized;
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void OnPaint (PaintEventArgs e)
	{
		e.Graphics.DrawImage (btmLunaticsInc,
			rect,
			Left - Width / 2 - (size * btmLunaticsInc.Width) / 2, Top - (size * btmLunaticsInc.Height) / 2, size * btmLunaticsInc.Width, size * btmLunaticsInc.Height,
			GraphicsUnit.Pixel);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		SetStyle (ControlStyles.AllPaintingInWmPaint |
			ControlStyles.UserPaint |
			ControlStyles.DoubleBuffer,
			true);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
		WindowState = FormWindowState.Normal;
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		size -= 0.1f;
		if (size <= 1.15f) {
			_timer.Enabled = false;
			_againButton.Show ();
			_quitButton.Show ();
		}
		Invalidate ();
	}

	void AgainButton_Click (object sender, EventArgs e)
	{
		size = 20.0f;
		_timer.Enabled = true;
		_againButton.Hide ();
		_quitButton.Hide ();
	}

	void QuitButton_Click (object sender, EventArgs e)
	{
		Application.Exit ();
	}

	private Timer _timer;
	private Button _againButton;
	private Button _quitButton;
	private Bitmap btmLunaticsInc = new Bitmap ("LunaticsInc.png");
	private float size = 20.0f;
	private Rectangle rect = new Rectangle (0, 0, 326, 349);
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
			"1. No form is displayed (no blue box).{0}{0}" +
			"2. An animation is displayed in the center of the screen.{0}{0}" +
			"3. Once finished, an image is displayed in the top left corner."
			+ "{0}{0}" +
			"4. Two buttons are displayed.{0}{0}" +
			"5. Form is transparent.",
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
		ClientSize = new Size (340, 200);
		Location = new Point (450, 50);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80854";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
