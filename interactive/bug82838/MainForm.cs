using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _invalidateButton
		// 
		_invalidateButton = new Button ();
		_invalidateButton.Location = new Point (150, 65);
		_invalidateButton.Size = new Size (100, 20);
		_invalidateButton.Text = "Invalidate";
		_invalidateButton.Click += new EventHandler (InvalidateButton_Click);
		Controls.Add (_invalidateButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 140);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82838";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void OnPaint (PaintEventArgs e)
	{
		base.OnPaint (e);

		_num++;
		using (GraphicsPath path = CreatePath ()) {
			if (_num % 2 == 0)
				e.Graphics.FillPath (Brushes.Red, path);
			else
				e.Graphics.FillPath (Brushes.Green, path);
		}
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void InvalidateButton_Click (object sender, EventArgs e)
	{
		Invalidate (Rectangle.Empty);
	}

	GraphicsPath CreatePath ()
	{
		GraphicsPath path = new GraphicsPath ();
		path.AddEllipse (new Rectangle (20, 20, 100, 100));
		return path;
	}

	private int _num;
	private Button _invalidateButton;
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
			"1. Click the Invalidate button twice.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The color of the ellipse changes on each click.",
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
		ClientSize = new Size (300, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82838";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
