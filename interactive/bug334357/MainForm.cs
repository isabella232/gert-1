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
		_tableLayoutPanel.AutoScroll = true;
		_tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_tableLayoutPanel.ColumnCount = 1;
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle (SizeType.Percent, 100F));
		_tableLayoutPanel.Dock = DockStyle.Fill;
		_tableLayoutPanel.RowCount = 5;
		_tableLayoutPanel.RowStyles.Add (new RowStyle ());
		_tableLayoutPanel.RowStyles.Add (new RowStyle ());
		_tableLayoutPanel.RowStyles.Add (new RowStyle ());
		_tableLayoutPanel.RowStyles.Add (new RowStyle ());
		_tableLayoutPanel.RowStyles.Add (new RowStyle ());
		_tableLayoutPanel.TabIndex = 0;
		Controls.Add (_tableLayoutPanel);
		// 
		// Form2
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (401, 368);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #334357";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		AddButton (15);
		AddButton (14);
		AddButton (13);
		AddButton (12);
		AddButton (11);
		AddButton (10);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void AddButton (int row)
	{
		Button button = new Button ();
		button.Dock = DockStyle.Top;
		button.Height = 200;
		button.Text = row.ToString ();
		button.Click += new EventHandler (Button_Click);
		_tableLayoutPanel.Controls.Add (button, 0, row);
	}

	void Button_Click (object sender, EventArgs args)
	{
		((Control) sender).Visible = false;
	}

	private TableLayoutPanel _tableLayoutPanel;
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
			"1. Six buttons are added to the TableLayoutPanel.{0}{0}" +
			"2. The buttons are added in order (10 -> 15).{0}{0}" +
			"3. Button 15 is scrolled into view.",
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
		ClientSize = new Size (300, 170);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #334357";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
