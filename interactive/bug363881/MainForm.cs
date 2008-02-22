using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _captureButton
		// 
		_captureButton = new Button ();
		_captureButton.Anchor = (AnchorStyles.Bottom);
		_captureButton.Location = new Point (110, 240);
		_captureButton.Size = new Size (60, 20);
		_captureButton.Text = "Capture";
		_captureButton.Click += new EventHandler (CaptureButton_Click);
		Controls.Add (_captureButton);
		// 
		// _pictureBox
		// 
		_pictureBox = new PictureBox ();
		_pictureBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left |AnchorStyles.Right);
		_pictureBox.BackColor = Color.Blue;
		_pictureBox.BorderStyle = BorderStyle.FixedSingle;
		_pictureBox.Location = new Point (8, 8);
		_pictureBox.Size = new Size (280, 225);
		_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
		Controls.Add (_pictureBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 235);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #363881";
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

	void CaptureButton_Click (object sender, EventArgs e)
	{
		Rectangle rec = new Rectangle (_pictureBox.Location, _pictureBox.Size);
		Bitmap bmp = GetScreenRegion (rec);
		_pictureBox.Image = bmp;
		_pictureBox.Refresh ();
		_pictureBox.BackColor = Color.DarkGray;
	}

	Bitmap GetScreenRegion (Rectangle rec)
	{
		Bitmap bitmap = new Bitmap (rec.Width, rec.Height);
		using (Graphics gfx = Graphics.FromImage (bitmap)) {
			gfx.CopyFromScreen (rec.Left, rec.Top, 0, 0, rec.Size);
		}
		return bitmap;
	}

	private PictureBox _pictureBox;
	private Button _captureButton;
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
			"1. Click the Capture button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A screen capture is displayed in the picturebox.",
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
		ClientSize = new Size (320, 145);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #363881";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
