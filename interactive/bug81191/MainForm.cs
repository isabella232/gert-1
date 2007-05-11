using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.CheckBoxes = true;
		_listView.Dock = DockStyle.Top;
		_listView.Columns.Add (new ColumnHeader ());
		_listView.Height = 100;
		_listView.HideSelection = false;
		_listView.Items.Add ("Miguel");
		_listView.StateImageList = new ImageList ();
		_listView.StateImageList.Images.Add (Icon.ToBitmap ());
		_listView.View = View.Details;
		_listView.ItemCheck += new ItemCheckEventHandler (ListView_ItemCheck);
		Controls.Add (_listView);
		// 
		// _addImageButton
		// 
		_addImageButton = new Button ();
		_addImageButton.Location = new Point (8, 110);
		_addImageButton.Size = new Size (80, 20);
		_addImageButton.Text = "Add Image";
		_addImageButton.Click += new EventHandler (AddImageButton_Click);
		Controls.Add (_addImageButton);
		// 
		// _replaceImageButton
		// 
		_replaceImageButton = new Button ();
		_replaceImageButton.Location = new Point (120, 110);
		_replaceImageButton.Size = new Size (100, 20);
		_replaceImageButton.Text = "Replace Image";
		_replaceImageButton.Click += new EventHandler (ReplaceImageButton_Click);
		Controls.Add (_replaceImageButton);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (230, 110);
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
		_eventsText.Location = new Point (8, 135);
		_eventsText.Multiline = true;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81191";
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

	void ListView_ItemCheck (object sender, ItemCheckEventArgs e)
	{
		_eventsText.AppendText ("ItemCheck: " + e.Index.ToString () + " | "
			+ e.CurrentValue.ToString () + " => " + e.NewValue.ToString ()
			+ Environment.NewLine);
	}

	void AddImageButton_Click (object sender, EventArgs e)
	{
		if (_listView.StateImageList.Images.Count > 1)
			return;

		string iconFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"earth.ico");
		_listView.StateImageList.Images.Add (new Icon (iconFile));
	}

	void ReplaceImageButton_Click (object sender, EventArgs e)
	{
		string iconFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"earth.ico");
		_listView.StateImageList.Images [0] = Image.FromFile (iconFile);
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_listView.Items.Clear ();
		_listView.Items.Add ("Miguel");

		ImageList imgList = new ImageList ();
		imgList.Images.Add (Icon.ToBitmap ());
		_listView.StateImageList = imgList;

		_eventsText.Text = string.Empty;
	}

	private ListView _listView;
	private Button _addImageButton;
	private Button _replaceImageButton;
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
			"Expected result on start-up:{0}{0}" +
			"1. The \"Miguel\" item is displayed with the form icon in front " +
			"of it.",
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the icon of the \"Miguel\" item.{0}{0}" +
			"3. Double-click the icon of the \"Miguel\" item.{0}{0}" +
			"4. Click the text of the \"Miguel\" item.{0}{0}" +
			"5. Press the Space key.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. The ItemCheck event does not fire.{0}{0}" +
			"2. The form icon remains displayed in front of the \"Miguel\" " +
			"item during each step.",
#else
			"1. On step 2, the ItemCheck event does not fire.{0}{0}" +
			"2. On step 3, the following events fire:{0}{0}" +
			"   * ItemCheck: 0 | Unchecked => Checked{0}" +
			"   * ItemCheck: 0 | Checked => Unchecked{0}{0}" +
			"3. On step 5, no events fire.{0}{0}" +
			"4. The form icon remains displayed in front of the \"Miguel\" " +
			"item during each step.",
#endif
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"Add Image\" button.{0}{0}" +
			"3. Click the icon of the \"Miguel\" item.{0}{0}" +
			"4. Press the Space key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the form icon is displayed in front of the item.{0}{0}" +
			"2. On step 3, a globe icon is displayed in front of the item.{0}{0}" +
			"3. On step 4, the form icon is displayed in front of the item.{0}{0}" +
			"4. The following events has fired:{0}{0}" +
			"   * ItemCheck: 0 | Unchecked => Checked{0}" +
			"   * ItemCheck: 0 | Checked => Unchecked",
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the text of the \"Miguel\" item.{0}{0}" +
			"3. Wait a second.{0}{0}" +
			"4. Double-click the text of the \"Miguel\" item.{0}{0}" +
			"5. Wait a second.{0}{0}" +
			"6. Double-click the text of the \"Miguel\" item.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. On step 4, no icon is displayed in front of the item.{0}{0}" +
			"2. On step 6, the form icon is displayed in front of the item.{0}{0}" +
			"3. The following events have fired:{0}{0}" +
#else
			"1. The form icon remains displayed in front of the \"Miguel\" " +
			"item during each step.{0}{0}" +
			"2. The following events have fired:{0}{0}" +
#endif
			"   * ItemCheck: 0 | Unchecked => Checked{0}" +
			"   * ItemCheck: 0 | Checked => Unchecked",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// _bugDescriptionText5
		// 
		_bugDescriptionText5 = new TextBox ();
		_bugDescriptionText5.Multiline = true;
		_bugDescriptionText5.Dock = DockStyle.Fill;
		_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"Add Image\" button.{0}{0}" +
			"3. Double-click the icon of the \"Miguel\" item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A globe icon is displayed in front of the item.{0}{0}" +
			"2. The following events have fired:{0}{0}" +
			"   * ItemCheck: 0 | Unchecked => Checked{0}" +
			"   * ItemCheck: 0 | Checked => Unchecked{0}" +
			"   * ItemCheck: 0 | Unchecked => Checked",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (370, 380);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81191";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
}
