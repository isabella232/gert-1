using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		this.Load += new EventHandler (MainForm_Load);
		this.Text = "bug #79713";
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		IsMdiContainer = true;

		ChildForm child = new ChildForm ();
		child.MdiParent = this;
		child.Show ();
	}
}

class ChildForm : Form
{
	public ChildForm ()
	{
		this.Load += new EventHandler (ChildForm_Load);
	}

	void ChildForm_Load (object sender, EventArgs e)
	{
		// 
		// _button
		// 
		_button = new Button ();
		_button.Left = 0;
		_button.Top = 0;
		_button.Width = 100;
		_button.Height = 100;
		_button.Text = "Button1";
		Controls.Add (_button);
		// 
		// _bugDescriptionLabel
		// 
		_bugDescriptionLabel = new Label ();
		_bugDescriptionLabel.Location = new Point (8, 120);
		_bugDescriptionLabel.Size = new Size (280, 200);
		_bugDescriptionLabel.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The application started up.",
			Environment.NewLine);
		Controls.Add (_bugDescriptionLabel);
	}

	private Button _button = new Button ();
	private Label _bugDescriptionLabel;
}
