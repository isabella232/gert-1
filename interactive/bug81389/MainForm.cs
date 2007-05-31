using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _changeShapeButton
		// 
		_changeShapeButton = new Button ();
		_changeShapeButton.BackColor = Color.Red;
		_changeShapeButton.Cursor = Cursors.Hand;
		_changeShapeButton.Location = new Point (40, 8);
		_changeShapeButton.Size = new Size (300, 250);
		_changeShapeButton.Text = string.Empty;
		_changeShapeButton.Click += new EventHandler (ChangeButton_Click);
		_changeShapeButton.MouseEnter += new EventHandler (ChangeButton_MouseEnter);
		_changeShapeButton.MouseLeave += new EventHandler (ChangeButton_MouseLeave);
		Controls.Add (_changeShapeButton);
		// 
		// _panel
		// 
		_panel = new Panel ();
		_panel.Dock = DockStyle.Top;
		_panel.BackColor = Color.Blue;
		_panel.Height = 100;
		Controls.Add (_panel);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (455, 265);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 150;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (520, 445);
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81389";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		GraphicsPath gp = new GraphicsPath ();
		gp.AddArc (_changeShapeButton.ClientRectangle, 0.0f, 360.0f);
		_changeShapeButton.Region = new Region (gp);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ChangeButton_Click (object sender, EventArgs e)
	{
		_eventsText.AppendText ("Click" + Environment.NewLine);
	}

	void ChangeButton_MouseEnter (object sender, EventArgs e)
	{
		_eventsText.AppendText ("MouseEnter" + Environment.NewLine);
	}

	void ChangeButton_MouseLeave (object sender, EventArgs e)
	{
		_eventsText.AppendText ("MouseLeave" + Environment.NewLine);
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
	}

	private Panel _panel;
	private Button _changeShapeButton;
	private Button _resetButton;
	private TextBox _eventsText;
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
			"Expected result at start-up:{0}{0}" +
			"1. A red ellipse shape is displayed.{0}{0}" +
			"2. Outside the top rounded-off corners of the ellipse, the blue " +
			"panel is displayed.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Move the cursor inside the ellipse shape.{0}{0}" +
			"2. Move the cursor little outside the ellipse at the top left.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the mouse pointer is a hand cursor.{0}{0}" +
			"2. On step 2, the mouse pointer turns back into a regular cursor " +
			"once the mouse pointer leaves the ellipse shape.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Move the mouse pointer to the rounded-off area just outside " +
			"the ellipse shape.{0}{0}" +
			"3. Move the mouse pointer into the ellipse shape.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, no MouseEnter event is fired.{0}{0}" +
			"2. On step 3, a MouseEnter event fires when the mouse pointer " +
			"enters the ellipse shape.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText4
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Move the mouse pointer to the rounded-off area just outside " +
			"the ellipse shape.{0}{0}" +
			"3. Press and release the left mouse button.{0}{0}" +
			"4. Move the mouse pointer into the ellipse shape.{0}{0}" +
			"5. Press and release the left mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, no Click event is fired.{0}{0}" +
			"2. On step 5, a Click event is fired.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 290);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81389";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
