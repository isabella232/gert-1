using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		ResourceManager resources = new ResourceManager (typeof (MainForm));
		// 
		// _panel
		// 
		_panel = new Panel ();
		_panel.BackColor = Color.Transparent;
		_panel.BackgroundImage = ((Bitmap) (resources.GetObject ("_panel.BackgroundImage")));
		_panel.Dock = DockStyle.Fill;
		_panel.Size = new Size (248, 192);
		_panel.TabIndex = 0;
		_panel.MouseUp += new MouseEventHandler (Panel_MouseUp);
		_panel.MouseMove += new MouseEventHandler (Panel_MouseMove);
		_panel.MouseDown += new MouseEventHandler (Panel_MouseDown);
		Controls.Add (_panel);
		// 
		// _quitButton
		// 
		_quitButton = new Button ();
		_quitButton.BackColor = Color.Sienna;
		_quitButton.Font = new Font ("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (0)));
		_quitButton.ForeColor = Color.White;
		_quitButton.Location = new Point (108, 116);
		_quitButton.Size = new Size (42, 16);
		_quitButton.Visible = false;
		_quitButton.TabIndex = 3;
		_quitButton.Text = "Quit?";
		_quitButton.Click += new EventHandler (QuitButton_Click);
		_panel.Controls.Add (_quitButton);
		// 
		// _label
		// 
		_label = new Label ();
		_label.BackColor = Color.Sienna;
		_label.Font = new Font ("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (0)));
		_label.ForeColor = Color.White;
		_label.Location = new Point (40, 114);
		_label.Size = new Size (160, 10);
		_label.TabIndex = 1;
		_label.TextAlign = ContentAlignment.MiddleCenter;
		_label.Text = "Please wait ...";
		_panel.Controls.Add (_label);
		// 
		// _progressBar
		// 
		_progressBar = new ProgressBar ();
		_progressBar.Location = new Point (40, 124);
		_progressBar.Size = new Size (160, 8);
		_progressBar.TabIndex = 0;
		_panel.Controls.Add (_progressBar);
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
		BackColor = Color.White;
		ClientSize = new Size (248, 192);
		FormBorderStyle = FormBorderStyle.None;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80855";
		TransparencyKey = Color.White;
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

	private void Panel_MouseDown (object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left) {
			mouseDown = true;
		}
	}

	private void Panel_MouseUp (object sender, MouseEventArgs e)
	{
		mouseDown = false;
	}

	private void Panel_MouseMove (object sender, MouseEventArgs e)
	{
		if (mouseDown) {
			Left = Cursor.Position.X - _panel.Width / 2;
			Top = Cursor.Position.Y - _panel.Height / 2;
		}
	}

	private void Timer_Tick (object sender, EventArgs e)
	{
		_progressBar.Value = pBar++;
		if (pBar == 100) {
			_timer.Enabled = false;
			_label.Hide ();
			_progressBar.Hide ();
			_quitButton.Show ();
		}
	}

	private void QuitButton_Click (object sender, EventArgs e)
	{
		Application.Exit ();
	}

	private Panel _panel;
	private ProgressBar _progressBar;
	private Timer _timer;
	private Label _label;
	private Button _quitButton;
	private bool mouseDown;
	private int pBar = 0;
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
			"1. The background of the form is transparent (no black box).{0}{0}" +
			"2. The form can be moved by clicking and dragging the image.",
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
		ClientSize = new Size (340, 120);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80855";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
