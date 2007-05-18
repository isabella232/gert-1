using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Location = new Point (8, 70);
		_tabControl.Size = new Size (280, 300);
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result at start-up:{0}{0}" +
			"1. The toolbar buttons do not displayed any mnemonic characters.{0}{0}" +
			"2. The text of the toolbar buttons does not contain amperstants.",
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
		_bugDescriptionText2.Location = new Point (8, 8);
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck Text checkbox (if checked).{0}{0}" +
			"2. Check Text checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text of the toolbar buttons does not contain amperstants.",
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
		_bugDescriptionText3.Location = new Point (8, 8);
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the Text checkbox (if checked).{0}{0}" +
			"2. Check the Text checkbox.{0}{0}" +
			"3. Press the Alt key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text of the toolbar buttons shows T, D and O as mnemonic " +
			"characters for the individual buttons.{0}{0}" +
			"2. Press Alt in combination with these mnemonic keys should not " +
			"cause the corresponding button to be clicked.{0}{0}" +
			"3. Once the Alt key has been pressed, the indication of the " +
			"mnemonic key stays visible (even after pressing Alt again).",
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
		_bugDescriptionText4.Location = new Point (8, 8);
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck Text checkbox (if checked).{0}{0}" +
			"2. Check the Text checkbox.{0}{0}" +
			"3. Press the Alt key.{0}{0}" +
			"4. Uncheck the Text checkbox.{0}{0}" +
			"5. Check the Text checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The mnemonic characters are displayed on step 3 and 5.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// _autoSizeCheck
		// 
		_autoSizeCheck = new CheckBox ();
		_autoSizeCheck.Checked = true;
		_autoSizeCheck.Location = new Point (8, 40);
		_autoSizeCheck.Size = new Size (80, 20);
		_autoSizeCheck.Text = "Autosize";
		_autoSizeCheck.CheckedChanged += new EventHandler (AutoSizeCheck_CheckedChanged);
		Controls.Add (_autoSizeCheck);
		// 
		// _buttonTextCheck
		// 
		_buttonTextCheck = new CheckBox ();
		_buttonTextCheck.Checked = true;
		_buttonTextCheck.Location = new Point (120, 40);
		_buttonTextCheck.Size = new Size (60, 20);
		_buttonTextCheck.Text = "Text";
		_buttonTextCheck.CheckedChanged += new EventHandler (ButtonTextCheck_CheckedChanged);
		Controls.Add (_buttonTextCheck);
		// 
		// _imagesCheck
		// 
		_imagesCheck = new CheckBox ();
		_imagesCheck.Checked = true;
		_imagesCheck.Location = new Point (210, 40);
		_imagesCheck.Size = new Size (80, 20);
		_imagesCheck.Text = "Images";
		_imagesCheck.CheckedChanged += new EventHandler (ImagesCheck_CheckedChanged);
		Controls.Add (_imagesCheck);
		// 
		// _imageList
		// 
		_imageList = new ImageList ();
		_imageList.ColorDepth = ColorDepth.Depth24Bit;
		_imageList.ImageSize = new Size (16, 16);
		_imageList.TransparentColor = Color.Transparent;
		_imageList.Images.Add (Image.FromFile (Path.Combine (dir, "NewMessage.png")));
		_imageList.Images.Add (Image.FromFile (Path.Combine (dir, "Options.png")));
		// 
		// _toggleButton
		// 
		_toggleButton = new ToolBarButton ();
		_toggleButton.ImageIndex = 0;
		_toggleButton.Style = ToolBarButtonStyle.ToggleButton;
		_toggleButton.ToolTipText = "Toggle";
		_toggleButton.Text = "&Toggle";
		// 
		// _dropDownButton
		// 
		_dropDownButton = new ToolBarButton ();
		_dropDownButton.DropDownMenu = new ContextMenu (new MenuItem [] {
			new MenuItem ("Send") });
		_dropDownButton.ImageIndex = 1;
		_dropDownButton.Style = ToolBarButtonStyle.DropDownButton;
		_dropDownButton.ToolTipText = "Drop Down";
		_dropDownButton.Text = "&Drop Down";
		// 
		// _pushButton
		// 
		_pushButton = new ToolBarButton ();
		_pushButton.ImageIndex = 0;
		_pushButton.Style = ToolBarButtonStyle.PushButton;
		_pushButton.ToolTipText = "Options";
		_pushButton.Text = "&Options";
		// 
		// _toolBar
		// 
		_toolBar = new ToolBar ();
		_toolBar.AutoSize = true;
		_toolBar.ImageList = _imageList;
		_toolBar.Appearance = ToolBarAppearance.Flat;
		_toolBar.Buttons.AddRange (new ToolBarButton [] { _toggleButton,
			_dropDownButton, _pushButton });
		_toolBar.ButtonClick += new ToolBarButtonClickEventHandler (ToolBar_ButtonClick);
		Controls.Add (_toolBar);
		// 
		// _tabPage3
		// 
		// 
		// MainForm
		// 
		StartPosition = FormStartPosition.CenterScreen;
		ClientSize = new Size (300, 380);
		Text = "bug #79640";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		if (SystemInformation.MenuAccessKeysUnderlined)
			MessageBox.Show ("The \"hide underlined letters for keyboard " +
				"navigation until I press the Alt key\" option should be " +
				"enabled for this test to yield the expected results.");
	}

	void AutoSizeCheck_CheckedChanged (object sender, EventArgs e)
	{
		if (_autoSizeCheck.Checked) {
			_toolBar.AutoSize = true;
		} else {
			_toolBar.AutoSize = false;
		}
	}

	void ButtonTextCheck_CheckedChanged (object sender, EventArgs e)
	{
		if (_buttonTextCheck.Checked) {
			_toggleButton.Text = "&Toggle";
			_dropDownButton.Text = "&Drop Down";
			_pushButton.Text = "&Options";
		} else {
			_toggleButton.Text = string.Empty;
			_dropDownButton.Text = string.Empty;
			_pushButton.Text = string.Empty;
		}
	}

	void ImagesCheck_CheckedChanged (object sender, EventArgs e)
	{
		if (_imagesCheck.Checked) {
			_toolBar.ImageList = _imageList;
		} else {
			_toolBar.ImageList = null;
		}
	}

	void ToolBar_ButtonClick (object sender, ToolBarButtonClickEventArgs e)
	{
		MessageBox.Show ("Button clicked.");
	}

	private CheckBox _autoSizeCheck;
	private CheckBox _buttonTextCheck;
	private CheckBox _imagesCheck;
	private ToolBar _toolBar;
	private ImageList _imageList;
	private ToolBarButton _toggleButton;
	private ToolBarButton _dropDownButton;
	private ToolBarButton _pushButton;
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
