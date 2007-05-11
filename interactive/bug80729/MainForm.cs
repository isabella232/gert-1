using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _rightPanel
		// 
		_rightPanel = new Panel ();
		_rightPanel.Dock = DockStyle.Fill;
		_rightPanel.Width = 100;
		_rightPanel.TabIndex = 3;
		Controls.Add (_rightPanel);
		// 
		// _treeSplitter
		// 
		_treeSplitter = new Splitter ();
		_treeSplitter.ImeMode = ImeMode.NoControl;
		_treeSplitter.Location = new Point (240, 0);
		_treeSplitter.MinSize = 10;
		_treeSplitter.Size = new Size (6, 545);
		_treeSplitter.TabIndex = 2;
		_treeSplitter.TabStop = false;
		Controls.Add (_treeSplitter);
		// 
		// _leftPanel
		// 
		_leftPanel = new Panel ();
		_leftPanel.Dock = DockStyle.Left;
		_leftPanel.Width = 100;
		_leftPanel.TabIndex = 4;
		Controls.Add (_leftPanel);
		// 
		// _resultTabs
		// 
		_resultTabs = new ResultTabs ();
		_resultTabs.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		_resultTabs.Location = new Point (0, 120);
		_resultTabs.Size = new Size (498, 425);
		_resultTabs.TabIndex = 2;
		_rightPanel.Controls.Add (_resultTabs);
		// 
		// _treeView
		// 
		_treeView = new TreeView ();
		_treeView.Dock = DockStyle.Fill;
		_treeView.TabIndex = 0;
		_leftPanel.Controls.Add (_treeView);
		// 
		// _groupBox
		// 
		_groupBox = new GroupBox ();
		_groupBox.Dock = DockStyle.Top;
		_groupBox.Height = 120;
		_groupBox.TabIndex = 0;
		_groupBox.TabStop = false;
		_rightPanel.Controls.Add (_groupBox);
		// 
		// _runButton
		// 
		_runButton = new Button ();
		_runButton.ImeMode = ImeMode.NoControl;
		_runButton.Location = new Point (8, 18);
		_runButton.Size = new Size (88, 38);
		_runButton.TabIndex = 3;
		_runButton.Text = "&Run";
		_groupBox.Controls.Add (_runButton);
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80729";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_treeView.Nodes.Add ("Test");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private Panel _leftPanel;
	private TreeView _treeView;
	private Splitter _treeSplitter;
	private Panel _rightPanel;
	private ResultTabs _resultTabs;
	private GroupBox _groupBox;
	private Button _runButton;

	public class ResultTabs : UserControl
	{
		public ResultTabs ()
		{
			// 
			// _tabControl
			// 
			_tabControl = new TabControl ();
			_tabControl.Dock = DockStyle.Fill;
			_tabControl.SelectedIndex = 0;
			_tabControl.TabIndex = 3;
			Controls.Add (_tabControl);
			// 
			// _tabPage
			// 
			_tabPage = new TabPage ();
			_tabPage.Text = "Tab";
			_tabControl.Controls.Add (_tabPage);
		}

		private TabControl _tabControl;
		private TabPage _tabPage;
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. Focus is on the Run button.",
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
			"1. Switch to the main form.{0}{0}" +
			"2. Press Tab key.{0}{0}" +
			"3. Press Tab key.{0}{0}" +
			"4. Press Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, focus is on the TabControl.{0}{0}" +
			"2. On step 3, focus is on the Test node in the TreeView.{0}{0}" +
			"3. On step 4, focus is on the Run button.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 280);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80729";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
