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
		_propertyGrid.Dock = DockStyle.Fill;
		_propertyGrid.HelpVisible = false;
		_propertyGrid.SelectedObject = new Config ();
		Controls.Add (_propertyGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 150);
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
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private PropertyGrid _propertyGrid;
}

public class Config
{
	AttributeTargets[] _targets;
	[Editor(typeof(TargetsArrayEditor), typeof(UITypeEditor))]
	public AttributeTargets[] Targets {
		get { return _targets; }
		set { _targets = value; }
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
			"2. Switch to Alphabetic view.{0}{0}" +
			"3. Switch to Categorized view.{0}{0}" +
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
		// InstructionsForm
		// 
		ClientSize = new Size (360, 230);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82196";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
