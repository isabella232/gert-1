using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _propertyGrid
		// 
		_propertyGrid = new PropertyGrid ();
		_propertyGrid.Dock = DockStyle.Top;
		_propertyGrid.Height = 200;
		_propertyGrid.HelpVisible = false;
		_propertyGrid.SelectedObject = new Config ();
		Controls.Add (_propertyGrid);
		// 
		// _sortListBox
		// 
		_sortListBox = new ListBox ();
		_sortListBox.Location = new Point (0, 210);
		_sortListBox.Size = new Size (200, 60);
		Controls.Add (_sortListBox);
		// 
		// _modifyButton
		// 
		_modifyButton = new Button ();
		_modifyButton.Location = new Point (215, 210);
		_modifyButton.Size = new Size (80, 20);
		_modifyButton.Text = "Modify";
		_modifyButton.Click += new EventHandler (ModifyButton_Click);
		Controls.Add (_modifyButton);
		// 
		// _refreshButton
		// 
		_refreshButton = new Button ();
		_refreshButton.Location = new Point (215, 245);
		_refreshButton.Size = new Size (80, 20);
		_refreshButton.Text = "Refresh";
		_refreshButton.Click += new EventHandler (RefreshButton_Click);
		Controls.Add (_refreshButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 275);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82196";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Array values = Enum.GetValues (typeof (PropertySort));
		_sortListBox.DataSource = values;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ModifyButton_Click (object sender, EventArgs e)
	{
		_propertyGrid.PropertySort = (PropertySort) _sortListBox.SelectedValue;
	}

	void RefreshButton_Click (object sender, EventArgs e)
	{
		for (int i = 0; i < _sortListBox.Items.Count; i++) {
			object item = _sortListBox.Items [i];
			if (((PropertySort) item) == _propertyGrid.PropertySort) {
				_sortListBox.SelectedIndex = i;
				break;
			}
		}
	}

	private PropertyGrid _propertyGrid;
	private ListBox _sortListBox;
	private Button _modifyButton;
	private Button _refreshButton;
}

public class Config
{
	private AttributeTargets[] _targets;
	private string _name;
	private string _company;
	private string _street;
	private int _houseNumber;

	[Category ("UI")]
	[Editor(typeof(TargetsArrayEditor), typeof(UITypeEditor))]
	public AttributeTargets[] Targets {
		get { return _targets; }
		set { _targets = value; }
	}

	[Category ("Personal")]
	public string Name {
		get { return _name; }
		set { _name = value; }
	}

	[Category ("Personal")]
	public string Company {
		get { return _company; }
		set { _company = value; }
	}

	[Category ("Address")]
	public string Street {
		get { return _street; }
		set { _street = value; }
	}

	[Category ("Address")]
	public int HouseNumber {
		get { return _houseNumber; }
		set { _houseNumber = value; }
	}
}

public class TargetsArrayEditor : UITypeEditor
{
	private IWindowsFormsEditorService edSvc;

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.DropDown;
	}

	public override Object EditValue(ITypeDescriptorContext context, IServiceProvider provider, Object value)
	{
		edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
		if (edSvc == null)
			return value;

		ListBox lb = new ListBox();
		lb.SelectedIndexChanged += new EventHandler (ListBox_SelectedIndexChanged);
		lb.Items.Add (AttributeTargets.Assembly.ToString ());
		lb.Items.Add (AttributeTargets.Class.ToString ());
		edSvc.DropDownControl (lb);
		if (lb.SelectedIndex != -1)
			return new AttributeTargets [] {  (AttributeTargets) Enum.Parse (
				typeof (AttributeTargets), lb.Text) };
		return null;
	}

	void ListBox_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (edSvc != null)
			edSvc.CloseDropDown ();
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
			"1. Click on the Targets label.{0}{0}" +
			"2. Click the Alphabetic toolbar button.{0}{0}" +
			"4. Click the Categorized toolbar button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The dropdown list moves along with the label.{0}{0}" +
			"2. The Targets label remains highlighted.",
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
			"1. Click on the Street label.{0}{0}" +
			"2. Click the Categorized toolbar button.{0}{0}" +
			"3. Click the Refresh button.{0}{0}" +
			"4. Click the Categorized toolbar button.{0}{0}" +
			"5. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Street label remains highlighted.{0}{0}" +
			"2. From step 2, the grid items are displayed in the " +
			"following order:{0}{0}" +
			"   [Address]{0}" +
			"   HouseNumber{0}" +
			"   Street{0}{0}" +
			"   [Personal]{0}" +
			"   Company{0}" +
			"   Name{0}{0}" +
			"   [UI]{0}" +
			"   Targets{0}{0}" +
			"3. From step 3, the CategorizedAlphabetic item " +
			"is selected in the listbox.",
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
			"1. Click on the Name label.{0}{0}" +
			"2. Click the Alphabetic toolbar button.{0}{0}" +
			"3. Click the Refresh button.{0}{0}" +
			"4. Click the Alphabetic toolbar button.{0}{0}" +
			"5. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Name label remains highlighted.{0}{0}" +
			"2. From step 2, the grid items are displayed in the " +
			"following order:{0}{0}" +
			"   Company{0}" +
			"   HouseNumber{0}" +
			"   Name{0}" +
			"   Street{0}" +
			"   Targets{0}{0}" +
			"3. On step 3 and 5, the Alphabetic item is selected " +
			"in the listbox.",
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
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on the HouseNumber label.{0}{0}" +
			"2. Click the NoSort item in the listbox.{0}{0}" +
			"3. Click the Modify button.{0}{0}" +
			"4. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The HouseNumber label remains highlighted.{0}{0}" +
			"2. From step 3:{0}{0}" +
			"   * None of the sorting buttons in the toolbar are pushed.{0}" +
			"   * The grid items are displayed in the following order:{0}{0}" +
			"      Targets{0}" +
			"      Name{0}" +
			"      Company{0}" +
			"      Street{0}" +
			"      HouseNumber{0}{0}" +
			"3. The NoSort item remains selected in the listbox.",
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
		_bugDescriptionText5.Dock = DockStyle.Fill;
		_bugDescriptionText5.Multiline = true;
		_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on the Company label.{0}{0}" +
			"2. Click the Alpabetic button in the toolbar.{0}{0}" +
			"3. Click the Categorized item in the listbox.{0}{0}" +
			"4. Click the Modify button.{0}{0}" +
			"5. Click the Refresh button.{0}{0}" +
			"6. Click the Categorized button in the toolbar.{0}{0}" +
			"7. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Company label remains highlighted.{0}{0}" +
			"2. From step 4:{0}{0}" +
			"   * The Categorized item is selected in the listbox.{0}" +
			"   * The Categorized button in the toolbar is pushed.{0}" +
			"   * The grid items are displayed in the following order:{0}{0}" +
			"      [Address]{0}" +
			"      HouseNumber{0}" +
			"      Street{0}{0}" +
			"      [Personal]{0}" +
			"      Company{0}" +
			"      Name{0}{0}" +
			"      [UI]{0}" +
			"      Targets",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		// 
		// _bugDescriptionText6
		// 
		_bugDescriptionText6 = new TextBox ();
		_bugDescriptionText6.Dock = DockStyle.Fill;
		_bugDescriptionText6.Multiline = true;
		_bugDescriptionText6.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on the Company label.{0}{0}" +
			"2. Click the Alphabetic button in the toolbar.{0}{0}" +
			"3. Click the Categorized button in the toolbar.{0}{0}" +
			"4. Click the Categorized item in the listbox.{0}{0}" +
			"5. Click the Modify button.{0}{0}" +
			"6. Click the Refresh button.{0}{0}" +
			"7. Click the Categorized button in the toolbar.{0}{0}" +
			"8. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Company label remains highlighted.{0}{0}" +
			"2. From step 6:{0}{0}" +
			"   * The Categorized item is selected in the listbox.{0}" +
			"   * The Categorized button in the toolbar is pushed.{0}" +
			"   * The grid items are displayed in the following order:{0}{0}" +
			"      [Address]{0}" +
			"      HouseNumber{0}" +
			"      Street{0}{0}" +
			"      [Personal]{0}" +
			"      Company{0}" +
			"      Name{0}{0}" +
			"      [UI]{0}" +
			"      Targets",
			Environment.NewLine);
		// 
		// _tabPage6
		// 
		_tabPage6 = new TabPage ();
		_tabPage6.Text = "#6";
		_tabPage6.Controls.Add (_bugDescriptionText6);
		_tabControl.Controls.Add (_tabPage6);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (420, 540);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82196";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TextBox _bugDescriptionText6;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TabPage _tabPage6;
}
