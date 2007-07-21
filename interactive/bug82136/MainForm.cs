using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _showModalButton
		// 
		_showModalButton = new Button ();
		_showModalButton.Location = new Point (64, 80);
		_showModalButton.Size = new Size (168, 23);
		_showModalButton.Text = "Show First Modal Window";
		_showModalButton.Click += new EventHandler (ShowModalButton_Click);
		Controls.Add (_showModalButton);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (304, 198);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #82136";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void ShowModalButton_Click (object sender, EventArgs e)
	{
		Form modal1 = new Modal1 ();
		modal1.ShowDialog ();
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();

		ShowModalButton_Click (sender, e);
	}

	private Button _showModalButton;
}

public class Modal1 : Form
{
	public Modal1 ()
	{
		// 
		// _showModalButton
		// 
		_showModalButton = new Button ();
		_showModalButton.Location = new Point (32, 72);
		_showModalButton.Size = new Size (176, 23);
		_showModalButton.TabIndex = 1;
		_showModalButton.Text = "Show Second Modal Window";
		_showModalButton.Click += new EventHandler (ShowModalButton_Click);
		Controls.Add (_showModalButton);
		// 
		// Modal1
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (248, 126);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Modal1";
		Activated += new EventHandler (Modal1_Activated);
	}

	void ShowModalButton_Click (object sender, EventArgs e)
	{
		Form modal2 = new Modal2 ();
		modal2.ShowDialog ();
	}

	void Modal1_Activated (object sender, EventArgs e)
	{
		ShowModalButton_Click (sender, e);
	}

	private Button _showModalButton;
}

public class Modal2 : Form
{
	public Modal2 ()
	{
		// 
		// _quitButton
		// 
		_quitButton = new Button ();
		_quitButton.Location = new Point (64, 32);
		_quitButton.Size = new Size (104, 23);
		_quitButton.TabIndex = 0;
		_quitButton.Text = "Quit";
		_quitButton.Click += new EventHandler (QuitButton_Click);
		Controls.Add (_quitButton);
		// 
		// Modal2
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (224, 86);
		Text = "Modal2";
	}

	void QuitButton_Click (object sender, EventArgs e)
	{
		Application.Exit ();
	}

	private Button _quitButton;
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
			"1. A single Modal2 form is displayed.{0}{0}" +
			"2. The Modal2 form hs focus and is on top of the Z-order.{0}{0}" +
			"======================{0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Close the Modal2 form using the control box.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Modal2 form is closed.{0}{0}" +
			"2. A single new Modal2 form is displayed.{0}{0}" +
			"3. Repeating step 1 always yields the same result.",
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
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82136";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
