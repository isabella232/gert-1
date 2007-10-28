using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

class Program
{
	[STAThread]
	static void Main ()
	{
		string [] images = new string [] {
			"bluearrow.gif",
			//"ProductIcon.ico",
			"folder.bmp",
			"ImageNotAvailable.jpg",
			"LunaticsInc.png" };

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();

		string dir = AppDomain.CurrentDomain.BaseDirectory;

		foreach (string file in images) {
			Form form = new Form ();
			form.ClientSize = new Size (300, 300);
			form.Location = new Point (250, 100);
			form.StartPosition = FormStartPosition.Manual;
			form.Text = "bug #335739";

			PictureBox pictureBox = new PictureBox ();
			pictureBox.BackColor = System.Drawing.Color.White;
			pictureBox.Dock = DockStyle.Fill;
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			form.Controls.Add (pictureBox);

			string imageFile = Path.Combine (dir, file);

			FileStream fs = File.OpenRead (imageFile);
			Image img = Image.FromStream (fs, true);
			pictureBox.Image = img;
			fs.Close ();

			form.ShowDialog ();
		}
	}
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
			"1. Close each modal form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Four modal forms, each displaying an image, are " +
			"displayed.",
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
		ClientSize = new Size (300, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #335739";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
