using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _label
		// 
		_label = new Label ();
		_label.AutoSize = true;
		_label.Text = "FixedPanel:";
		_label.Location = new Point (5, 5);
		_label.TextAlign = ContentAlignment.MiddleLeft;
		Controls.Add (_label);
		// 
		// _fixedSplitterComboBox
		// 
		_fixedSplitterComboBox = new ComboBox ();
		_fixedSplitterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		_fixedSplitterComboBox.SelectedIndexChanged += FixedSplitterComboBox_SelectedIndexChanged;
		SetHorizAdjacent (_fixedSplitterComboBox, _label);
		Controls.Add (_fixedSplitterComboBox);
		// 
		// _swapOrientationButton
		// 
		_swapOrientationButton = new Button ();
		_swapOrientationButton.AutoSize = true;
		_swapOrientationButton.Text = "Swap orientation";
		_swapOrientationButton.Click += SwapOrientationButton_Click;
		SetHorizAdjacent (_swapOrientationButton, _fixedSplitterComboBox);
		Controls.Add (_swapOrientationButton);
		// 
		// _splitContainer
		// 
		_splitContainer = new SplitContainer ();
		_splitContainer.Location = new Point (0, _swapOrientationButton.Bottom + 5);
		_splitContainer.Width = ClientSize.Width;
		_splitContainer.Height = ClientSize.Height - _splitContainer.Top;
		_splitContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right |
			AnchorStyles.Top | AnchorStyles.Bottom;
		Controls.Add (_splitContainer);
		// 
		// _textBox1
		// 
		_textBox1 = new TextBox ();
		_textBox1.Dock = DockStyle.Fill;
		_textBox1.Multiline = true;
		_textBox1.Text = "Panel 1";
		_splitContainer.Panel1.Controls.Add (_textBox1);
		// 
		// _textBox2
		// 
		_textBox2 = new TextBox ();
		_textBox2.Dock = DockStyle.Fill;
		_textBox2.Multiline = true;
		_textBox2.Text = "Panel 2";
		_splitContainer.Panel2.Controls.Add (_textBox2);
		// 
		// MainForm
		// 
		ClientSize = new Size (_swapOrientationButton.Right + 5, ClientSize.Width);
		_splitContainer.SplitterDistance = ClientSize.Width / 2;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82763";
		Load += MainForm_Load;

	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs ea)
	{
		_fixedSplitterComboBox.DataSource = Enum.GetValues (typeof (FixedPanel));
		_fixedSplitterComboBox.SelectedItem = _splitContainer.FixedPanel;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void SwapOrientationButton_Click (object sender, EventArgs ea)
	{
		Orientation o = _splitContainer.Orientation;
		o = o == Orientation.Horizontal ? Orientation.Vertical : Orientation.Horizontal;
		_splitContainer.Orientation = o;
	}

	void FixedSplitterComboBox_SelectedIndexChanged (object sender, EventArgs ea)
	{
		FixedPanel fp = (FixedPanel) _fixedSplitterComboBox.SelectedValue;
		_splitContainer.FixedPanel = fp;

		string t1, t2;
		switch (_splitContainer.FixedPanel) {
		case FixedPanel.None:
			t1 = "GROWS";
			t2 = "GROWS";
			break;
		case FixedPanel.Panel1:
			t1 = "FIXED";
			t2 = "GROWS";
			break;
		case FixedPanel.Panel2:
			t1 = "GROWS";
			t2 = "FIXED";
			break;
		default:
			throw new InvalidOperationException ("Bad FixedPanel value.");
		}
		_splitContainer.Panel1.Controls [0].Text = "Panel 1 "
			+ Environment.NewLine + Environment.NewLine + t1;
		_splitContainer.Panel2.Controls [0].Text = "Panel 2 "
			+ Environment.NewLine + Environment.NewLine + t2;
	}

	void SetHorizAdjacent (Control newControl, Control previousControl)
	{
		int top = previousControl.Top;
		int left = previousControl.Right;
		left += Math.Max (newControl.Margin.Right, previousControl.Margin.Left);
		newControl.Location = new Point (left, top);
	}

	private Label _label;
	private Button _swapOrientationButton;
	private ComboBox _fixedSplitterComboBox;
	private SplitContainer _splitContainer;
	private TextBox _textBox1;
	private TextBox _textBox2;
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
			"1. Resize the form both vertically and horizonally.{0}{0}" +
			"2. Click the Swap Orientation button.{0}{0}" +
			"3. Repeat steps 1 and 2.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Both panels grow vertically and horizonally.",
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
			"1. Modify the value of FixedPanel to Panel1.{0}{0}" +
			"2. Resize the form both vertically and horizonally.{0}{0}" +
			"3. Click the Swap Orientation button.{0}{0}" +
			"4. Repeat steps 1 and 2.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only Panel 2 grows vertically and horizonally.",
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
			"1. Modify the value of FixedPanel to Panel2.{0}{0}" +
			"2. Resize the form both vertically and horizonally.{0}{0}" +
			"3. Click the Swap Orientation button.{0}{0}" +
			"4. Repeat steps 1 and 2.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only Panel 1 grows vertically and horizonally.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 230);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82763";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
