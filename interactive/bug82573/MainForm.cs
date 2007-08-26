using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGridView
		// 
		_dataGridView = new DataGridView ();
		_dataGridView.Dock = DockStyle.Top;
		_dataGridView.Height = 150;
		Controls.Add (_dataGridView);
		// 
		// _addingNewGroupBox
		// 
		_addingNewGroupBox = new GroupBox ();
		_addingNewGroupBox.Dock = DockStyle.Bottom;
		_addingNewGroupBox.Height = 70;
		_addingNewGroupBox.Text = "AddingNew";
		Controls.Add (_addingNewGroupBox);
		// 
		// _bindingListAddNew
		// 
		_bindingListAddNew = new CheckBox ();
		_bindingListAddNew.Location = new Point (8, 16);
		_bindingListAddNew.Text = "BindingList";
		_bindingListAddNew.CheckedChanged += new EventHandler (DataGridView_Refresh);
		_addingNewGroupBox.Controls.Add (_bindingListAddNew);
		// 
		// _bindingSourceAddNew
		// 
		_bindingSourceAddNew = new CheckBox ();
		_bindingSourceAddNew.Location = new Point (8, 38);
		_bindingSourceAddNew.Text = "BindingSource";
		_bindingSourceAddNew.CheckedChanged += new EventHandler (DataGridView_Refresh);
		_addingNewGroupBox.Controls.Add (_bindingSourceAddNew);
		// 
		// _contentGroupBox
		// 
		_contentGroupBox = new GroupBox ();
		_contentGroupBox.Dock = DockStyle.Bottom;
		_contentGroupBox.Height = 70;
		_contentGroupBox.Text = "Content";
		Controls.Add (_contentGroupBox);
		// 
		// _emptyRadioButton
		// 
		_emptyRadioButton = new RadioButton ();
		_emptyRadioButton.Checked = true;
		_emptyRadioButton.Location = new Point (8, 16);
		_emptyRadioButton.Text = "Empty";
		_emptyRadioButton.CheckedChanged += new EventHandler (DataGridView_Refresh);
		_contentGroupBox.Controls.Add (_emptyRadioButton);
		// 
		// _filledRadioButton
		// 
		_filledRadioButton = new RadioButton ();
		_filledRadioButton.Location = new Point (8, 38);
		_filledRadioButton.Text = "Filled";
		_filledRadioButton.CheckedChanged += new EventHandler (DataGridView_Refresh);
		_contentGroupBox.Controls.Add (_filledRadioButton);
		// 
		// _listTypeGroupBox
		// 
		_listTypeGroupBox = new GroupBox ();
		_listTypeGroupBox.Dock = DockStyle.Bottom;
		_listTypeGroupBox.Height = 70;
		_listTypeGroupBox.Text = "ListType";
		Controls.Add (_listTypeGroupBox);
		// 
		// _arrayRadioButton
		// 
		_arrayRadioButton = new RadioButton ();
		_arrayRadioButton.Checked = true;
		_arrayRadioButton.Location = new Point (8, 16);
		_arrayRadioButton.Text = "Array";
		_arrayRadioButton.CheckedChanged += new EventHandler (DataGridView_Refresh);
		_listTypeGroupBox.Controls.Add (_arrayRadioButton);
		// 
		// _listRadioButton
		// 
		_listRadioButton = new RadioButton ();
		_listRadioButton.Location = new Point (8, 38);
		_listRadioButton.Text = "List";
		_listRadioButton.CheckedChanged += new EventHandler (DataGridView_Refresh);
		_listTypeGroupBox.Controls.Add (_listRadioButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 370);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82573";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		DataGridView_Refresh (sender, e);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void BindingList_AddingNew (object sender, AddingNewEventArgs e)
	{
		e.NewObject = new Customer ("List");
	}

	void BindingSource_AddingNew (object sender, AddingNewEventArgs e)
	{
		e.NewObject = new Customer ("Source");
	}

	void DataGridView_Refresh (object sender, EventArgs e)
	{
		BindingSource bindingSource = new BindingSource ();
		if (_bindingSourceAddNew.Checked)
			bindingSource.AddingNew += new AddingNewEventHandler (BindingSource_AddingNew);

		IList<Customer> list;

		if (_arrayRadioButton.Checked) {
			if (_emptyRadioButton.Checked) {
				list = new Customer [0];
			} else {
				list = new Customer [5];
				list [0] = new Customer ("Rolf");
				list [1] = new Customer ("Miguel");
				list [2] = new Customer ("Everaldo");
				list [3] = new Customer ("Jackson");
				list [4] = new Customer ("Chris");
			}
		} else {
			list = new List<Customer> ();
			if (!_emptyRadioButton.Checked) {
				list.Add (new Customer ("Rolf"));
				list.Add (new Customer ("Miguel"));
				list.Add (new Customer ("Everaldo"));
				list.Add (new Customer ("Jackson"));
				list.Add (new Customer ("Chris"));
			}
		}

		BindingList<Customer> bindingList = new BindingList<Customer> (list);
		if (_bindingListAddNew.Checked)
			bindingList.AddingNew += new AddingNewEventHandler (BindingList_AddingNew);
		bindingSource.DataSource = bindingList;
		_dataGridView.DataSource = bindingSource;
	}

	private DataGridView _dataGridView;
	private GroupBox _addingNewGroupBox;
	private CheckBox _bindingListAddNew;
	private CheckBox _bindingSourceAddNew;
	private GroupBox _contentGroupBox;
	private RadioButton _emptyRadioButton;
	private RadioButton _filledRadioButton;
	private GroupBox _listTypeGroupBox;
	private RadioButton _arrayRadioButton;
	private RadioButton _listRadioButton;
}

class Customer
{
	public Customer (string name)
	{
		_name = name;
	}

	public string Name {
		get { return _name; }
		set { _name = value; }
	}

	private string _name;
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
			"1. Only the columnheader of the DataGridView, with a " +
			"Name column, is displayed.",
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
			"1. Check BindingList.{0}{0}" +
			"2. Check or uncheck BindingSource.{0}{0}" +
			"3. Check Empty.{0}{0}" +
			"4. Check Array or List.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The column header and an empty new row are displayed.",
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
			"1. Uncheck BindingList.{0}{0}" +
			"2. Check or uncheck BindingSource.{0}{0}" +
			"3. Check Filled.{0}{0}" +
			"4. Check Array or List.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, only the columnheader of the DataGridView, " +
			"with a Name column, is displayed.{0}{0}" +
			"2. On step 4 and 5, the column header and the following " +
			"rows are displayed:{0}{0}" +
			"   * Rolf{0}" +
			"   * Miguel{0}" +
			"   * Everaldo{0}" +
			"   * Jackson{0}" +
			"   * Chris{0}{0}" +
			"3. No empty data row is displayed.",
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
			"1. Check BindingList.{0}{0}" +
			"2. Check or uncheck BindingSource.{0}{0}" +
			"3. Check Filled.{0}{0}" +
			"4. Check List.{0}{0}" +
			"5. Click in the Name cell of the new row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Before step 5, an empty new row is displayed " +
			"below the following rows:{0}{0}" +
			"   * Rolf{0}" +
			"   * Miguel{0}" +
			"   * Everaldo{0}" +
			"   * Jackson{0}" +
			"   * Chris{0}{0}" +
			"2. On step 5, the value of the Name cell in the new " +
			" is \"List\".",
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
			"1. Check BindingList.{0}{0}" +
			"2. Check or uncheck BindingSource.{0}{0}" +
			"3. Check Filled.{0}{0}" +
			"4. Check Array.{0}{0}" +
			"5. Click in the Name cell of the new row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Before step 5, an empty new row is displayed " +
			"below the following rows:{0}{0}" +
			"   * Rolf{0}" +
			"   * Miguel{0}" +
			"   * Everaldo{0}" +
			"   * Jackson{0}" +
			"   * Chris{0}{0}" +
			"2. On step 5, an unhandled exception is reported since " +
			"the collection is readonly.",
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
		ClientSize = new Size (300, 375);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82573";
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
