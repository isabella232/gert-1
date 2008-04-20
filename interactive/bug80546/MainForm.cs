using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _testControl
		// 
		_testControl = new TestControl ();
		_testControl.MouseEnter += new EventHandler (TestControl_MouseEnter);
		_testControl.MouseLeave += new EventHandler (TestControl_MouseLeave);
		Controls.Add (_testControl);
		// 
		// _resetButton
		//
		_resetButton = new Button ();
		_resetButton.Location = new Point (340, 8);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 200;
		_eventsText.Multiline = true;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 400);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #323234";
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
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
	}

	void TestControl_MouseEnter (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TestControl => MouseEnter" +
			Environment.NewLine);
	}

	void TestControl_MouseLeave (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TestControl => MouseLeave" +
			Environment.NewLine);
	}

	private TestControl _testControl;
	private Button _resetButton;
	private TextBox _eventsText;

	class TestControl : Control
	{
		public TestControl ()
		{
			BackColor = Color.Red;
			Size = new Size (100, 100);
			Cursor = Cursors.AppStarting;
		}
		protected override void OnMouseEnter (EventArgs e)
		{
			base.OnMouseEnter (e);
			BackColor = Color.Blue;
		}
		protected override void OnMouseLeave (EventArgs e)
		{
			base.OnMouseLeave (e);
			BackColor = Color.Red;
		}
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
			"1. Click the Reset button.{0}{0}" +
			"2. Click somewhere on the client area of the form that is not " +
			"red, and hold the mouse button down.{0}{0}" +
			"3. Move the mouse cursor over the red shape.{0}{0}" +
			"4. Move away from the red shape.{0}{0}" +
			"5. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The mouse cursor never changed, and the backcolor of the shape " +
			"did not change.{0}{0}" + 
			"2. The MouseEnter and MouseLeave events did not fire.",
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
			"2. Move the mouse cursor over the red shape.{0}{0}" +
			"3. Move the mouse cursor away from the red shape.{0}{0}" +
			"4. Click somewhere on the client area of the form that is not " +
			"red, and hold the mouse button down.{0}{0}" +
			"5. Move the mouse cursor over the red shape.{0}{0}" +
			"6. Move away from the red shape.{0}{0}" +
			"7. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * the mouse cursor changes.{0}" +
			"   * the backcolor of the shape turns blue.{0}" +
			"   * the MouseEnter event is fired.{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * the mouse cursor changes back to a normal pointer.{0}" +
			"   * the backcolor of the shape turns red again.{0}" +
			"   * the MouseLeave event is fired.{0}{0}" +
			"3. On step 5:{0}{0}" +
			"   * the mouse cursor does not change.{0}" +
			"   * the backcolor does not change.{0}" +
			"   * the MouseEnter and MouseLeave events do not fire.",
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
			"2. Click somewhere on the client area of the form that is not " +
			"red.{0}{0}" +
			"3. Hold the mouse button down.{0}{0}" +
			"4. Move the mouse cursor over the red shape.{0}{0}" +
			"5. Do not move the mouse cursor.{0}{0}" +
			"6. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 6:{0}{0}" +
			"   * the mouse cursor changes.{0}" +
			"   * the backcolor of the shape turns blue.{0}" +
			"   * the MouseEnter event is fired.",
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
		ClientSize = new Size (400, 520);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #323234";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
