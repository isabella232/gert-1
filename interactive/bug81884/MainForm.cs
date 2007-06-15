using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tableLayoutPanel
		// 
		_tableLayoutPanel = new TableLayoutPanel ();
		_tableLayoutPanel.ColumnCount = 3;
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.Dock = DockStyle.Top;
		_tableLayoutPanel.Height = 200;
		_tableLayoutPanel.RowCount = 2;
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		Controls.Add (_tableLayoutPanel);
		// 
		// _labelA
		// 
		_labelA = new Label ();
		_labelA.Dock = DockStyle.Fill;
		_labelA.Size = new Size (95, 20);
		_labelA.Text = "A";
		_tableLayoutPanel.Controls.Add (_labelA, 0, 0);
		// 
		// _labelB
		// 
		_labelB = new Label ();
		_labelB.Dock = DockStyle.Fill;
		_labelB.Size = new Size (95, 20);
		_labelB.Text = "B";
		_tableLayoutPanel.Controls.Add (_labelB, 1, 0);
		// 
		// _labelC
		// 
		_labelC = new Label ();
		_labelC.Dock = DockStyle.Fill;
		_labelC.Size = new Size (95, 20);
		_labelC.Text = "C";
		_tableLayoutPanel.Controls.Add (_labelC, 2, 0);
		// 
		// _labelD
		// 
		_labelD = new Label ();
		_labelD.Dock = DockStyle.Fill;
		_labelD.Size = new Size (95, 20);
		_labelD.Text = "D";
		_tableLayoutPanel.Controls.Add (_labelD, 0, 1);
		// 
		// _labelE
		// 
		_labelE = new Label ();
		_labelE.Dock = DockStyle.Fill;
		_labelE.Size = new Size (95, 20);
		_labelE.Text = "E";
		_tableLayoutPanel.Controls.Add (_labelE, 1, 1);
		// 
		// _labelF
		// 
		_labelF = new Label ();
		_labelF.Dock = DockStyle.Fill;
		_labelF.Size = new Size (95, 20);
		_labelF.Text = "F";
		_tableLayoutPanel.Controls.Add (_labelF, 2, 1);
		// 
		// _borderStyleGroupBox
		// 
		_borderStyleGroupBox = new GroupBox ();
		_borderStyleGroupBox.Dock = DockStyle.Bottom;
		_borderStyleGroupBox.Height = 100;
		_borderStyleGroupBox.Text = "CellBorderStyle";
		Controls.Add (_borderStyleGroupBox);
		// 
		// _insetBorderStyleRadioButton
		// 
		_insetBorderStyleRadioButton = new RadioButton ();
		_insetBorderStyleRadioButton.Location = new Point (8, 16);
		_insetBorderStyleRadioButton.Text = "Inset";
		_insetBorderStyleRadioButton.Size = new Size (95, 20);
		_insetBorderStyleRadioButton.CheckedChanged += new EventHandler (InsetBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_insetBorderStyleRadioButton);
		// 
		// _insetDoubleBorderStyleRadioButton
		// 
		_insetDoubleBorderStyleRadioButton = new RadioButton ();
		_insetDoubleBorderStyleRadioButton.Location = new Point (8, 36);
		_insetDoubleBorderStyleRadioButton.Text = "InsetDouble";
		_insetDoubleBorderStyleRadioButton.Size = new Size (95, 20);
		_insetDoubleBorderStyleRadioButton.CheckedChanged += new EventHandler (InsetDoubleBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_insetDoubleBorderStyleRadioButton);
		// 
		// _noneBorderStyleRadioButton
		// 
		_noneBorderStyleRadioButton = new RadioButton ();
		_noneBorderStyleRadioButton.Checked = true;
		_noneBorderStyleRadioButton.Location = new Point (8, 56);
		_noneBorderStyleRadioButton.Text = "None";
		_noneBorderStyleRadioButton.Size = new Size (95, 20);
		_noneBorderStyleRadioButton.CheckedChanged += new EventHandler (NoneBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_noneBorderStyleRadioButton);
		// 
		// _outsetBorderStyleRadioButton
		// 
		_outsetBorderStyleRadioButton = new RadioButton ();
		_outsetBorderStyleRadioButton.Location = new Point (8, 76);
		_outsetBorderStyleRadioButton.Text = "Outset";
		_outsetBorderStyleRadioButton.Size = new Size (95, 20);
		_outsetBorderStyleRadioButton.CheckedChanged += new EventHandler (OutsetBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_outsetBorderStyleRadioButton);
		// 
		// _outsetDoubleBorderStyleRadioButton
		// 
		_outsetDoubleBorderStyleRadioButton = new RadioButton ();
		_outsetDoubleBorderStyleRadioButton.Location = new Point (160, 16);
		_outsetDoubleBorderStyleRadioButton.Text = "OutsetDouble";
		_outsetDoubleBorderStyleRadioButton.Size = new Size (95, 20);
		_outsetDoubleBorderStyleRadioButton.CheckedChanged += new EventHandler (OutsetDoubleBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_outsetDoubleBorderStyleRadioButton);
		// 
		// _outsetPartialBorderStyleRadioButton
		// 
		_outsetPartialBorderStyleRadioButton = new RadioButton ();
		_outsetPartialBorderStyleRadioButton.Location = new Point (160, 36);
		_outsetPartialBorderStyleRadioButton.Text = "OutsetPartial";
		_outsetPartialBorderStyleRadioButton.Size = new Size (95, 20);
		_outsetPartialBorderStyleRadioButton.CheckedChanged += new EventHandler (OutsetPartialBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_outsetPartialBorderStyleRadioButton);
		// 
		// _singleBorderStyleRadioButton
		// 
		_singleBorderStyleRadioButton = new RadioButton ();
		_singleBorderStyleRadioButton.Location = new Point (160, 56);
		_singleBorderStyleRadioButton.Text = "Single";
		_singleBorderStyleRadioButton.Size = new Size (95, 20);
		_singleBorderStyleRadioButton.CheckedChanged += new EventHandler (SingleBorderStyleRadioButton_CheckedChanged);
		_borderStyleGroupBox.Controls.Add (_singleBorderStyleRadioButton);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (315, 310);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81884";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void InsetBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_insetBorderStyleRadioButton.Checked)
			_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
	}

	void InsetDoubleBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_insetDoubleBorderStyleRadioButton.Checked)
			_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
	}

	void NoneBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_noneBorderStyleRadioButton.Checked)
			_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
	}

	void OutsetBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_outsetBorderStyleRadioButton.Checked)
			_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
	}

	void OutsetDoubleBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_outsetDoubleBorderStyleRadioButton.Checked)
			_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
	}

	void OutsetPartialBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_outsetPartialBorderStyleRadioButton.Checked)
			_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
	}

	void SingleBorderStyleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_singleBorderStyleRadioButton.Checked)
			_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
	}

	private TableLayoutPanel _tableLayoutPanel;
	private Label _labelA;
	private Label _labelB;
	private Label _labelC;
	private Label _labelD;
	private Label _labelE;
	private Label _labelF;
	private GroupBox _borderStyleGroupBox;
	private RadioButton _insetBorderStyleRadioButton;
	private RadioButton _insetDoubleBorderStyleRadioButton;
	private RadioButton _noneBorderStyleRadioButton;
	private RadioButton _outsetBorderStyleRadioButton;
	private RadioButton _outsetDoubleBorderStyleRadioButton;
	private RadioButton _outsetPartialBorderStyleRadioButton;
	private RadioButton _singleBorderStyleRadioButton;
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
			"1. Select each of the possible CellBorderStyle values.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The border style of the cells in the TableLayoutPanel changes " +
			"accordingly.",
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
		ClientSize = new Size (350, 210);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81884";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
