using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

public class MainForm : Form
{
	public MainForm ()
	{
		SetStyle (ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
		// 
		// _propertyGrid
		// 
		_propertyGrid = new PropertyGrid ();
		_propertyGrid.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		_propertyGrid.CommandsVisibleIfAvailable = true;
		_propertyGrid.Dock = DockStyle.Fill;
		_propertyGrid.LargeButtons = false;
		_propertyGrid.LineColor = SystemColors.ScrollBar;
		_propertyGrid.TabIndex = 0;
		_propertyGrid.ViewBackColor = SystemColors.Window;
		_propertyGrid.ViewForeColor = SystemColors.WindowText;
		_propertyGrid.SelectedObject = new DocumenterConfig ();
		_propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler (PropertyGrid_PropertyValueChanged);
		Controls.Add (_propertyGrid);
		// 
		// MainForm
		// 
		AllowDrop = true;
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (350, 350);
		Location = new Point (250, 100);
		MinimumSize = new Size (350, 350);
		SizeGripStyle = SizeGripStyle.Show;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79829";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
		_propertyGrid.SelectedObject = new DocumenterConfig ();
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

	void PropertyGrid_PropertyValueChanged (object s, PropertyValueChangedEventArgs e)
	{
		_propertyGrid.Refresh ();
	}

	private PropertyGrid _propertyGrid;
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
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The ReferencePaths entry is highlighted with Control color " +
			"but does not have focus.{0}{0}" +
			"2. The \"(None)\" value of ReferencePaths is bold.",
			Environment.NewLine);
		_tabPage1.Controls.Add (_bugDescriptionText1);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the value of ReferencePaths.{0}{0}" +
			"2. Click the \"...\" button to edit the value.{0}{0}" +
			"3. Click Cancel in the ReferencePath Collection Editor form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value has not changed.",
			Environment.NewLine);
		_tabPage2.Controls.Add (_bugDescriptionText2);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Double-click the value of SdkDocLanguage several times.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value should be highlighted (selected).{0}{0}" +
			"2. The description is shown completely.",
			Environment.NewLine);
		_tabPage3.Controls.Add (_bugDescriptionText3);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabControl.Controls.Add (_tabPage4);
		// 
		// _bugDescriptionText4
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the value of ReferencePaths.{0}{0}" +
			"2. Click the \"...\" button to edit the value.{0}{0}" +
			"3. Click Add in the ReferencePath Collection Editor form.{0}{0}" +
			"4. Select two files and click Open.{0}{0}" +
			"5. Click on each file in the ReferencePath Collection Editor form.{0}{0}" +
			"6. Click the OK button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of ReferencePaths is now \"(Count=2)\" and can be " +
			"expanded to show information on the selected files.",
			Environment.NewLine);
		_tabPage4.Controls.Add (_bugDescriptionText4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79777";
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
