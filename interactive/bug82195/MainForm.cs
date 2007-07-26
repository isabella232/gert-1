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
		ClientSize = new Size (350, 300);
		Location = new Point (250, 100);
		SizeGripStyle = SizeGripStyle.Show;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82195";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_propertyGrid.SelectedObject = new DocumenterConfig ();

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
			"Steps to execute:{0}{0}" +
			"1. Add a path to the ReferencePaths property.{0}{0}" +
			"2. Expand the ReferencePaths property.{0}{0}" +
			"3. Remove the path from the ReferencePaths property.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No errors have been logged to the console.{0}{0}" +
			"2. The removed path is no longer displayed in the PropertyGrid.",
			Environment.NewLine);
		_tabPage1.Controls.Add (_bugDescriptionText1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (350, 300);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #820195";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
