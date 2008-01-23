using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _okButton
		// 
		_okButton = new Button ();
		_okButton.FlatAppearance.BorderSize = 0;
		_okButton.FlatStyle = FlatStyle.Flat;
		_okButton.Location = new Point (60, 20);
		_okButton.Text = "OK";
		Controls.Add (_okButton);
		// 
		// _cancelButton
		// 
		_cancelButton = new Button ();
		_cancelButton.FlatAppearance.BorderSize = 0;
		_cancelButton.FlatStyle = FlatStyle.Flat;
		_cancelButton.Location = new Point (180, 20);
		_cancelButton.Text = "Cancel";
		Controls.Add (_cancelButton);
		// 
		// checkBox1
		// 
		_checkBox = new CheckBox ();
		_checkBox.Appearance = Appearance.Button;
		_checkBox.AutoSize = true;
		_checkBox.FlatAppearance.BorderSize = 0;
		_checkBox.FlatAppearance.CheckedBackColor = Color.Transparent;
		_checkBox.FlatAppearance.MouseDownBackColor = Color.Transparent;
		_checkBox.FlatAppearance.MouseOverBackColor = Color.Transparent;
		_checkBox.FlatStyle = FlatStyle.Flat;
		_checkBox.Location = new Point (8, 45);
		_checkBox.Size = new Size (6, 6);
		_checkBox.TabIndex = 0;
		_checkBox.CheckedChanged += new EventHandler (CheckBox_CheckedChanged);
		Controls.Add (_checkBox);
		// 
		// MainForm
		// 
		BackColor = Color.White;
		ClientSize = new Size (300, 70);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82081";
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

		SetImage ();
	}


	void CheckBox_CheckedChanged (object sender, EventArgs e)
	{
		SetImage ();
		_checkBox.Refresh ();
	}

	void SetImage ()
	{
		_checkBox.Image = _checkBox.Checked ? CheckedImage :
			UncheckedImage;
	}

	static bool ReturnFalse ()
	{
		return false;
	}

	static Bitmap GetBitmap (string fileName)
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		return new Bitmap (Path.Combine (dir, fileName));
	}

	private Image CheckedImage = GetBitmap ("star.png").GetThumbnailImage (20, 20, ReturnFalse, IntPtr.Zero);
	private Image UncheckedImage = GetBitmap ("star-inactive.png").GetThumbnailImage (20, 20, ReturnFalse, IntPtr.Zero);
	private Button _okButton;
	private Button _cancelButton;
	private CheckBox _checkBox;
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
			"1. The Cancel button is flat.{0}{0}" +
			"2. The Cancel button has no border.{0}{0}" +
			"3. The OK button is flat.{0}{0}" +
			"4. The OK button has no border.{0}{0}" +
			"5. The Star checkbox is flat.{0}{0}" +
			"6. The Star checkbox has no border.{0}{0}" +
			"7. The Cancel and OK buttons highlight on mouseover.",
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
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on the Star checkbox (2x).{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The image of checkbox changes on each click.{0}{0}" +
			"2. The Star checkbox has no border.",
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
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on the OK button.{0}{0}" +
			"2. Press Tab key.{0}{0}" +
			"3. Press Tab key.{0}{0}" +
			"4. Press Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, a focus rectangle is drawn around the " +
			"Cancel button.{0}{0}" +
			"2. On step 3, a focus rectangle is drawn around the " +
			"Star checkbox.{0}{0}" +
			"3. On step 4, a focus rectangle is drawn around the " +
			"OK button.{0}{0}" +
			"4. The Cancel and OK buttons highlight on mouseover.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#2";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 300);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82081";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
