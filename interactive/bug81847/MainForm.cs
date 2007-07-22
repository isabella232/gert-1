using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_treeView = new TreeView ();
		_treeView.Dock = DockStyle.Top;
		_treeView.Height = 80;
		_treeView.HideSelection = false;
		_treeView.TabIndex = 0;
		_treeView.AfterLabelEdit += new NodeLabelEditEventHandler (TreeView_AfterLabelEdit);
		_treeView.BeforeLabelEdit += new NodeLabelEditEventHandler (TreeView_BeforeLabelEdit);
		Controls.Add (_treeView);
		// 
		// _labelEditCheckBox
		// 
		_labelEditCheckBox = new CheckBox ();
		_labelEditCheckBox.Checked = _treeView.LabelEdit;
		_labelEditCheckBox.Location = new Point (8, 105);
		_labelEditCheckBox.Size = new Size (75, 20);
		_labelEditCheckBox.Text = "LabelEdit";
		_labelEditCheckBox.CheckedChanged += new EventHandler (LabelEditCheckBox_CheckedChanged);
		Controls.Add (_labelEditCheckBox);
		// 
		// _cancelGroupBox
		// 
		_cancelGroupBox = new GroupBox ();
		_cancelGroupBox.Location = new Point (85, 85);
		_cancelGroupBox.Size = new Size (115, 60);
		_cancelGroupBox.Text = "Cancel";
		Controls.Add (_cancelGroupBox);
		// 
		// _beforeCancelCheckBox
		// 
		_beforeCancelCheckBox = new CheckBox ();
		_beforeCancelCheckBox.Location = new Point (8, 16);
		_beforeCancelCheckBox.Size = new Size (100, 20);
		_beforeCancelCheckBox.Text = "Before";
		_cancelGroupBox.Controls.Add (_beforeCancelCheckBox);
		// 
		// _afterCancelCheckBox
		// 
		_afterCancelCheckBox = new CheckBox ();
		_afterCancelCheckBox.Location = new Point (8, 35);
		_afterCancelCheckBox.Size = new Size (100, 20);
		_afterCancelCheckBox.Text = "After";
		_cancelGroupBox.Controls.Add (_afterCancelCheckBox);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (215, 105);
		_resetButton.Size = new Size (70, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 135;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 290);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81847";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Init ();
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void TreeView_BeforeLabelEdit (object sender, NodeLabelEditEventArgs e)
	{
		string newLabel = e.Label == null ? "null" : e.Label;
		_eventsText.AppendText ("TreeView => BeforeLabelEdit (" + e.Node.Text +
			" => " + newLabel + ")" + Environment.NewLine);
		e.CancelEdit = _beforeCancelCheckBox.Checked;
	}

	void TreeView_AfterLabelEdit (object sender, NodeLabelEditEventArgs e)
	{
		string newLabel = e.Label == null ? "null" : e.Label;
		_eventsText.AppendText ("TreeView => AfterLabelEdit (" + e.Node.Text +
			" => " + newLabel + ")" + Environment.NewLine);
		e.CancelEdit = _afterCancelCheckBox.Checked;
	}

	void LabelEditCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_treeView.LabelEdit = _labelEditCheckBox.Checked;
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_treeView.Nodes.Clear ();
		_labelEditCheckBox.Checked = false;
		_beforeCancelCheckBox.Checked = false;
		_afterCancelCheckBox.Checked = false;
		_eventsText.Text = string.Empty;
		Init ();
	}

	void Init ()
	{
		_treeView.Nodes.Add (new TreeNode ("Node0"));
		_treeView.Nodes.Add (new TreeNode ("Node1"));
	}

	private TreeView _treeView;
	private CheckBox _labelEditCheckBox;
	private GroupBox _cancelGroupBox;
	private CheckBox _beforeCancelCheckBox;
	private CheckBox _afterCancelCheckBox;
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Check the LabelEdit checkbox.{0}{0}" +
			"3. Click the text of Node1 (2x).{0}{0}" +
			"4. Do not change the label.{0}{0}" +
			"5. Press Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   TreeView => BeforeLabelEdit (Node1 => null){0}" +
			"   TreeView => AfterLabelEdit (Node1 => null){0}{0}" +
			"2. The label of the node has not changed.",
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
			"1. Click the Reset button.{0}{0}" +
			"2. Check the LabelEdit checkbox.{0}{0}" +
			"3. Click the text of Node1 (2x).{0}{0}" +
			"4. Change the label to \"New\".{0}{0}" +
			"5. Press Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   TreeView => BeforeLabelEdit (Node1 => null){0}" +
			"   TreeView => AfterLabelEdit (Node1 => New){0}{0}" +
			"2. The label of the node has changed to \"New\".",
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
			"1. Click the Reset button.{0}{0}" +
			"2. Check the LabelEdit checkbox.{0}{0}" +
			"3. Click the text of Node1 (2x).{0}{0}" +
			"4. Change the label to \"New\".{0}{0}" +
			"5. Press Esc key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   TreeView => BeforeLabelEdit (Node1 => null){0}" +
			"   TreeView => AfterLabelEdit (Node1 => null){0}{0}" +
			"2. The label of the node has not changed.",
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
			"1. Click the Reset button.{0}{0}" +
			"2. Check the LabelEdit checkbox.{0}{0}" +
			"3. Click the text of Node1 (2x).{0}{0}" +
			"4. Press Right-Arrow key.{0}{0}" +
			"5. Press E key.{0}{0}" +
			"6. Press Backspace key.{0}{0}" +
			"7. Press Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   TreeView => BeforeLabelEdit (Node1 => null){0}" +
			"   TreeView => AfterLabelEdit (Node1 => Node1){0}{0}" +
			"2. The label of the node has not changed.",
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
			"1. Click the Reset button.{0}{0}" +
			"2. Check the LabelEdit checkbox.{0}{0}" +
			"3. Check the Before cancel checkbox.{0}{0}" +
			"4. Click the text of Node1 (2x).{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   TreeView => BeforeLabelEdit (Node1 => null){0}{0}" +
			"2. The label of the node cannot be edited.",
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
			"1. Click the Reset button.{0}{0}" +
			"2. Check the LabelEdit checkbox.{0}{0}" +
			"3. Check the After cancel checkbox.{0}{0}" +
			"4. Click the text of Node1 (2x).{0}{0}" +
			"5. Change the label to \"New\".{0}{0}" +
			"6. Press Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   TreeView => BeforeLabelEdit (Node1 => null){0}" +
			"   TreeView => AfterLabelEdit (Node1 => New){0}{0}" +
			"2. The label of the node has not changed.",
			Environment.NewLine);
		// 
		// _tabPage6
		// 
		_tabPage6 = new TabPage ();
		_tabPage6.Text = "#6";
		_tabPage6.Controls.Add (_bugDescriptionText6);
		_tabControl.Controls.Add (_tabPage6);
		// 
		// _bugDescriptionText7
		// 
		_bugDescriptionText7 = new TextBox ();
		_bugDescriptionText7.Dock = DockStyle.Fill;
		_bugDescriptionText7.Multiline = true;
		_bugDescriptionText7.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Click the text of Node1 (2x).{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No events have fired.{0}{0}" +
			"2. The label of the node cannot be edited.",
			Environment.NewLine);
		// 
		// _tabPage7
		// 
		_tabPage7 = new TabPage ();
		_tabPage7.Text = "#7";
		_tabPage7.Controls.Add (_bugDescriptionText7);
		_tabControl.Controls.Add (_tabPage7);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (330, 360);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81847";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TextBox _bugDescriptionText6;
	private TextBox _bugDescriptionText7;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TabPage _tabPage6;
	private TabPage _tabPage7;
}
