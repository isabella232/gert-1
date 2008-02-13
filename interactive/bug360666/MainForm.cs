using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _propertyGrid
		// 
		_propertyGrid = new PropertyGrid ();
		_propertyGrid.Dock = DockStyle.Fill;
		Controls.Add (_propertyGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #360666";
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

		_propertyGrid.SelectedObject = new Config ();
	}

	private PropertyGrid _propertyGrid;
}

public class Config
{
	private PersonList _members = new PersonList ();

	public PersonList Members {
		get { return _members; }
		set { _members = value; }
	}
}

[Editor ("DoesNotEverExist, Dunno, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null" , typeof (UITypeEditor))]
public class PersonList : ICollection, IList
{
	int IList.Add (object item)
	{
		return -1;
	}

	public void Insert (int index, object item)
	{
	}

	public void Remove (object x)
	{
	}

	public void RemoveAt (int i)
	{
	}

	public bool Contains (object a)
	{
		return false;
	}

	public IEnumerator GetEnumerator ()
	{
		return new ArrayList ().GetEnumerator ();
	}

	public void CopyTo (Array array, int index)
	{
	}

	public bool IsSynchronized
	{
		get { return false; }
	}

	public bool IsFixedSize
	{
		get { return false; }
	}

	public object this [int index]
	{
		get { return null; }
		set { }
	}

	public bool IsReadOnly
	{
		get { return false; }
	}

	public object SyncRoot
	{
		get { return this; }
	}


	public int Count
	{
		get { return 0; }
	}

	public void Clear ()
	{
	}

	public int IndexOf (object a)
	{
		return 0;
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
			"1. Click the edit button for the Members item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The default collection editor is displayed.",
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
		Text = "Instructions - bug #360666";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
