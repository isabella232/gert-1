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
		_tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
		_tableLayoutPanel.ColumnCount = 3;
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle ());
		_tableLayoutPanel.Dock = DockStyle.Fill;
		_tableLayoutPanel.RowCount = 2;
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Percent, 50F));
		Controls.Add (_tableLayoutPanel);
		// 
		// _buttonA
		// 
		_buttonA = new Button ();
		_buttonA.TabIndex = 1;
		_buttonA.Text = "Button A";
		_buttonA.UseVisualStyleBackColor = true;
		_tableLayoutPanel.Controls.Add (_buttonA, 0, 1);
		// 
		// _buttonB
		// 
		_buttonB = new Button ();
		_buttonB.TabIndex = 4;
		_buttonB.Text = "Button B";
		_buttonB.UseVisualStyleBackColor = true;
		_tableLayoutPanel.Controls.Add (_buttonB, 2, 1);
		// 
		// _label
		// 
		_label = new Label ();
		_label.AutoSize = true;
		_label.Dock = DockStyle.Fill;
		_label.TabIndex = 6;
		_label.Text = "Label";
		_tableLayoutPanel.Controls.Add (_label, 1, 1);
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Fill;
		_textBox.Multiline = true;
		_textBox.TabIndex = 7;
		_tableLayoutPanel.Controls.Add (_textBox, 1, 0);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (292, 300);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81843";
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

	private TableLayoutPanel _tableLayoutPanel;
	private Button _buttonA;
	private Label _label;
	private TextBox _textBox;
	private Button _buttonB;
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
			"1. The layout of the form is divided in three columns and two " +
			"rows.{0}{0}" +
			"2. The cells contain the following controls:{0}{0}" +
			"   * top left: (empty){0}" +
			"   * top center: TextBox{0}" +
			"   * top right: (empty){0}" +
			"   * bottom left: Button A{0}" +
			"   * bottom center: Label{0}" +
			"   * bottom right: Button B",
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
		Text = "Instructions - bug #81843";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
