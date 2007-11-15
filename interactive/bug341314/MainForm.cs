using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _panel
		// 
		_panel = new Panel ();
		_panel.Location = new Point (0, 0);
		_panel.Size = this.ClientSize;
		Controls.Add (_panel);
		// 
		// _quitButton
		// 
		_quitButton = new Button ();
		_quitButton.Location = new Point (50, 15);
		_quitButton.Size = new Size (100, 30);
		_quitButton.Text = "Quit";
		_quitButton.Click += new EventHandler (QuitButton_Click);
		_panel.Controls.Add (_quitButton);
		// 
		// _popupButton
		// 
		_popupButton = new Button ();
		_popupButton.Location = new Point (50, 50);
		_popupButton.Size = new Size (100, 30);
		_popupButton.Text = "Popup";
		_popupButton.Click += new EventHandler (PopupButton_Click);
		_panel.Controls.Add (_popupButton);
		// 
		// _exitButton
		// 
		_exitButton = new Button ();
		_exitButton.Location = new Point (50, 85);
		_exitButton.Size = new Size (100, 30);
		_exitButton.Text = "Exit";
		_exitButton.Click += new EventHandler (ExitButton_Click);
		_panel.Controls.Add (_exitButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (200, 150);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #341314";
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

	void QuitButton_Click (object sender, EventArgs e)
	{
		Close ();
	}

	void PopupButton_Click (object sender, EventArgs e)
	{
		_panel.Controls.Remove (_popupButton);
		_popupButton.Hide ();
		_popupButton.Dispose ();
		_popupButton = null;
		new PopupForm ().Show ();
	}

	void ExitButton_Click (object sender, EventArgs e)
	{
		Close ();
	}

	private Panel _panel;
	private Button _quitButton;
	private Button _popupButton;
	private Button _exitButton;
}

public class PopupForm : Form
{
	public PopupForm ()
	{
		// 
		// _button
		// 
		_button = new Button ();
		_button.Location = new Point (50, 50);
		_button.Size = new Size (100, 30);
		_button.Text = "Popup";
		_button.TabIndex = 1;
		_button.Visible = true;
		Controls.Add (_button);
		// 
		// PopupForm
		// 
		Load += new EventHandler (PopupForm_Load);
	}

	void PopupForm_Load (object sender, EventArgs e)
	{
		_button.Focus ();
		Close ();
	}

	private Button _button;
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
			"1. Click the Popup button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Popup button is no longer visible.{0}{0}" +
			"2. None of the buttons have focus.",
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
		ClientSize = new Size (300, 170);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #341314";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}

