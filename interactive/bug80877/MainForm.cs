using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _xorControl1
		// 
		_xorControl1 = new XORControl ();
		_xorControl1.BackColor = Color.White;
		_xorControl1.Location = new Point (8, 50);
		_xorControl1.Size = new Size (100, 100);
		_xorControl1.TabIndex = 0;
		Controls.Add (_xorControl1);
		// 
		// _xorControl2
		// 
		_xorControl2 = new XORControl ();
		_xorControl2.BackColor = Color.White;
		_xorControl2.Location = new Point (120, 50);
		_xorControl2.Size = new Size (100, 100);
		_xorControl2.TabIndex = 0;
		Controls.Add (_xorControl2);
		// 
		// _sendMsgCheckBox
		// 
		_sendMsgCheckBox = new CheckBox ();
		_sendMsgCheckBox.Checked = true;
		_sendMsgCheckBox.CheckState = CheckState.Checked;
		_sendMsgCheckBox.Location = new Point (8, 8);
		_sendMsgCheckBox.Size = new Size (192, 24);
		_sendMsgCheckBox.TabIndex = 1;
		_sendMsgCheckBox.Text = "Send to other controls";
		Controls.Add (_sendMsgCheckBox);
		// 
		// _xorControl3
		// 
		_xorControl3 = new XORControl ();
		_xorControl3.BackColor = Color.White;
		_xorControl3.Location = new Point (232, 50);
		_xorControl3.Size = new Size (100, 100);
		_xorControl3.TabIndex = 2;
		Controls.Add (_xorControl3);
		// 
		// _clearButton
		// 
		_clearButton = new Button ();
		_clearButton.Location = new Point (260, 16);
		_clearButton.TabIndex = 3;
		_clearButton.Text = "Clear";
		_clearButton.Click += new EventHandler (ClearButton_Click);
		Controls.Add (_clearButton);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (350, 180);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80877";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	public void sendMessage (object sender, MouseEventArgs e)
	{
		if (_sendMsgCheckBox.Checked) {
			foreach (object o in Controls) {
				if (o is XORControl) {
					(o as XORControl).doMouseMove (sender, e);
				}
			}
		}
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ClearButton_Click (object sender, EventArgs e)
	{
		Invalidate (true);
	}

	private XORControl _xorControl1;
	private XORControl _xorControl2;
	private CheckBox _sendMsgCheckBox;
	private XORControl _xorControl3;
	private Button _clearButton;
}

public class XORControl : UserControl
{
	public XORControl ()
	{
		// 
		// XORControl
		// 
		BackColor = Color.White;
		Size = new Size (168, 168);
		MouseMove += new MouseEventHandler (XORControl_MouseMove);
	}

	void XORControl_MouseMove (object sender, MouseEventArgs e)
	{
		if (Parent is MainForm)
			(Parent as MainForm).sendMessage (sender, e);

		doMouseMove (sender, e);
	}

	public void doMouseMove (object sender, MouseEventArgs e)
	{
		int x = e.X;
		int y = e.Y;

		Point screenCenter = PointToScreen (new Point (x, y));

		Point top = new Point (screenCenter.X, screenCenter.Y - 10);
		Point bott = new Point (screenCenter.X, screenCenter.Y + 10);
		Point left = new Point (screenCenter.X - 10, screenCenter.Y);
		Point right = new Point (screenCenter.X + 10, screenCenter.Y);


		ControlPaint.DrawReversibleLine (screenCenter, top, Color.Black);
		ControlPaint.DrawReversibleLine (screenCenter, bott, Color.Black);
		ControlPaint.DrawReversibleLine (screenCenter, left, Color.Black);
		ControlPaint.DrawReversibleLine (screenCenter, right, Color.Black);
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
			"Steps to execute:{0}{0}" +
			"1. Click the Clear button.{0}{0}" +
			"2. Check the \"Send to other controls\" checkbox.{0}{0}" +
			"3. Move the mouse pointer over the first box.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Lines are drawn in boxes 2 and 3.",
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
			"1. Click the Clear button.{0}{0}" +
			"2. Uncheck the \"Send to other controls\" checkbox.{0}{0}" +
			"3. Move the mouse pointer over the first box.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Lines are drawn in the first box only.",
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
		ClientSize = new Size (300, 210);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80877";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
