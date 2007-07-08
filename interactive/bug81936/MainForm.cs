using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		label3 = new Label ();
		label4 = new Label ();
		label5 = new Label ();
		label6 = new Label ();
		label7 = new Label ();
		label8 = new Label ();
		label9 = new Label ();
		label10 = new Label ();
		CbbCOMPorts = new ComboBox ();
		Label2 = new Label ();
		CmbSpeed = new ComboBox ();
		CmbEncod = new ComboBox ();
		CmbData = new ComboBox ();
		CmbParity = new ComboBox ();
		TxtWriteTimOut = new TextBox ();
		CmbBitStop = new ComboBox ();
		TxtWriteBuff = new TextBox ();
		TxtReadBuff = new TextBox ();
		TxtReadTimout = new TextBox ();
		Label1 = new Label ();
		label11 = new Label ();
		CmbTypeCom = new ComboBox ();
		// 
		// _tableLayoutPanel
		// 
		_tableLayoutPanel = new TableLayoutPanel ();
		_tableLayoutPanel.SuspendLayout ();
		_tableLayoutPanel.ColumnCount = 3;
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle (SizeType.Absolute, 89F));
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle (SizeType.Absolute, 92F));
		_tableLayoutPanel.ColumnStyles.Add (new ColumnStyle (SizeType.Absolute, 196F));
		_tableLayoutPanel.Controls.Add (label3, 0, 9);
		_tableLayoutPanel.Controls.Add (label4, 0, 8);
		_tableLayoutPanel.Controls.Add (label5, 0, 7);
		_tableLayoutPanel.Controls.Add (label6, 0, 6);
		_tableLayoutPanel.Controls.Add (label7, 0, 5);
		_tableLayoutPanel.Controls.Add (label8, 0, 4);
		_tableLayoutPanel.Controls.Add (label9, 0, 3);
		_tableLayoutPanel.Controls.Add (label10, 0, 2);
		_tableLayoutPanel.Controls.Add (CbbCOMPorts, 1, 0);
		_tableLayoutPanel.Controls.Add (Label2, 2, 2);
		_tableLayoutPanel.Controls.Add (CmbSpeed, 1, 1);
		_tableLayoutPanel.Controls.Add (CmbEncod, 1, 9);
		_tableLayoutPanel.Controls.Add (CmbData, 1, 3);
		_tableLayoutPanel.Controls.Add (CmbParity, 1, 2);
		_tableLayoutPanel.Controls.Add (TxtWriteTimOut, 1, 8);
		_tableLayoutPanel.Controls.Add (CmbBitStop, 1, 4);
		_tableLayoutPanel.Controls.Add (TxtWriteBuff, 1, 7);
		_tableLayoutPanel.Controls.Add (TxtReadBuff, 1, 5);
		_tableLayoutPanel.Controls.Add (TxtReadTimout, 1, 6);
		_tableLayoutPanel.Controls.Add (Label1, 0, 0);
		_tableLayoutPanel.Controls.Add (label11, 0, 1);
		_tableLayoutPanel.Dock = DockStyle.Fill;
		_tableLayoutPanel.Location = new Point (3, 31);
		_tableLayoutPanel.RowCount = 11;
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.RowStyles.Add (new RowStyle (SizeType.Absolute, 28F));
		_tableLayoutPanel.Size = new Size (377, 312);
		Controls.Add (_tableLayoutPanel);
		// 
		// label3
		// 
		label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label3.AutoSize = true;
		label3.Location = new Point (3, 259);
		label3.Size = new Size (83, 13);
		label3.TabIndex = 32;
		label3.Text = "Encodage";
		// 
		// label4
		// 
		label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label4.AutoSize = true;
		label4.Location = new Point (3, 231);
		label4.Size = new Size (83, 13);
		label4.TabIndex = 33;
		label4.Text = "Writetimeout";
		// 
		// label5
		// 
		label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label5.AutoSize = true;
		label5.Location = new Point (3, 203);
		label5.Size = new Size (83, 13);
		label5.TabIndex = 34;
		label5.Text = "Writebuffersize" + Environment.NewLine;
		// 
		// label6
		// 
		label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label6.AutoSize = true;
		label6.Location = new Point (3, 175);
		label6.Size = new Size (83, 13);
		label6.TabIndex = 35;
		label6.Text = "Readtimeout" + Environment.NewLine;
		// 
		// label7
		// 
		label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label7.AutoSize = true;
		label7.Location = new Point (3, 147);
		label7.Size = new Size (83, 13);
		label7.TabIndex = 36;
		label7.Text = "Readbuffersize" + Environment.NewLine;
		// 
		// label8
		// 
		label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label8.AutoSize = true;
		label8.Location = new Point (3, 119);
		label8.Size = new Size (83, 13);
		label8.TabIndex = 37;
		label8.Text = "Bit de stop";
		// 
		// label9
		// 
		label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label9.AutoSize = true;
		label9.Location = new Point (3, 91);
		label9.Size = new Size (83, 13);
		label9.TabIndex = 38;
		label9.Text = "Donnée";
		// 
		// label10
		// 
		label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label10.AutoSize = true;
		label10.Location = new Point (3, 63);
		label10.Size = new Size (83, 13);
		label10.TabIndex = 39;
		label10.Text = "Parité";
		// 
		// CbbCOMPorts
		// 
		CbbCOMPorts.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CbbCOMPorts.FormattingEnabled = true;
		CbbCOMPorts.Location = new Point (92, 3);
		CbbCOMPorts.Size = new Size (86, 21);
		CbbCOMPorts.TabIndex = 1;
		CbbCOMPorts.Text = "/dev/ttyS70";
		// 
		// Label2
		// 
		Label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		Label2.AutoSize = true;
		Label2.Location = new Point (184, 63);
		Label2.Size = new Size (190, 13);
		Label2.TabIndex = 26;
		Label2.Text = "(Pair)";
		// 
		// CmbSpeed
		// 
		CmbSpeed.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CmbSpeed.FormattingEnabled = true;
		CmbSpeed.Items.AddRange (new object [] {
			"75",
			"110",
			"134",
			"150",
			"300",
			"600",
			"1200",
			"1800",
			"2400",
			"4800",
			"7200",
			"9600",
			"14400",
			"19200",
			"38400",
			"57600",
			"115200",
			"128000"});
		CmbSpeed.Location = new Point (92, 31);
		CmbSpeed.Size = new Size (86, 21);
		CmbSpeed.TabIndex = 21;
		CmbSpeed.Tag = "";
		CmbSpeed.Text = "115200";
		// 
		// CmbEncod
		// 
		CmbEncod.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CmbEncod.FormattingEnabled = true;
		CmbEncod.Items.AddRange (new object [] {
			"Default",
			"ASCII",
			"UTF8",
			"UTF32",
			"Unicode",
			"BigEndianUnicode"});
		CmbEncod.Location = new Point (92, 255);
		CmbEncod.Size = new Size (86, 21);
		CmbEncod.TabIndex = 28;
		CmbEncod.Text = "UTF8";
		// 
		// CmbData
		// 
		CmbData.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CmbData.FormattingEnabled = true;
		CmbData.Items.AddRange (new object [] {
			"8",
			"7",
			"6",
			"5",
			"11"});
		CmbData.Location = new Point (92, 87);
		CmbData.Size = new Size (86, 21);
		CmbData.TabIndex = 29;
		CmbData.Text = "8";
		// 
		// CmbParity
		// 
		CmbParity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CmbParity.FormattingEnabled = true;
		CmbParity.Items.AddRange (new object [] {
			"None",
			"Odd",
			"Even",
			"Mark",
			"Space"});
		CmbParity.Location = new Point (92, 59);
		CmbParity.Size = new Size (86, 21);
		CmbParity.TabIndex = 20;
		CmbParity.Text = "None";
		// 
		// TxtWriteTimOut
		// 
		TxtWriteTimOut.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		TxtWriteTimOut.Location = new Point (92, 228);
		TxtWriteTimOut.Size = new Size (86, 20);
		TxtWriteTimOut.TabIndex = 25;
		TxtWriteTimOut.Text = "500";
		TxtWriteTimOut.TextAlign = HorizontalAlignment.Right;
		// 
		// CmbBitStop
		// 
		CmbBitStop.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CmbBitStop.FormattingEnabled = true;
		CmbBitStop.Items.AddRange (new object [] {
			"None",
			"One",
			"Two",
			"OnePointFive"});
		CmbBitStop.Location = new Point (92, 115);
		CmbBitStop.Size = new Size (86, 21);
		CmbBitStop.TabIndex = 19;
		CmbBitStop.Text = "1";
		// 
		// TxtWriteBuff
		// 
		TxtWriteBuff.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		TxtWriteBuff.Location = new Point (92, 200);
		TxtWriteBuff.Size = new Size (86, 20);
		TxtWriteBuff.TabIndex = 24;
		TxtWriteBuff.Text = "512";
		TxtWriteBuff.TextAlign = HorizontalAlignment.Right;
		// 
		// TxtReadBuff
		// 
		TxtReadBuff.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		TxtReadBuff.Location = new Point (92, 144);
		TxtReadBuff.Size = new Size (86, 20);
		TxtReadBuff.TabIndex = 22;
		TxtReadBuff.Text = "1024";
		TxtReadBuff.TextAlign = HorizontalAlignment.Right;
		// 
		// TxtReadTimout
		// 
		TxtReadTimout.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		TxtReadTimout.Location = new Point (92, 172);
		TxtReadTimout.Size = new Size (86, 20);
		TxtReadTimout.TabIndex = 23;
		TxtReadTimout.Text = "500";
		TxtReadTimout.TextAlign = HorizontalAlignment.Right;
		// 
		// Label1
		// 
		Label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		Label1.AutoSize = true;
		Label1.Location = new Point (3, 7);
		Label1.Size = new Size (83, 13);
		Label1.TabIndex = 18;
		Label1.Text = "Port\r\n";
		// 
		// label11
		// 
		label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		label11.AutoSize = true;
		label11.Location = new Point (3, 35);
		label11.Size = new Size (83, 13);
		label11.TabIndex = 40;
		label11.Text = "Vitesse";
		// 
		// CmbTypeCom
		// 
		CmbTypeCom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
		CmbTypeCom.FormattingEnabled = true;
		CmbTypeCom.Items.AddRange (new object [] {
			"Bluetooth",
			"Serial"});
		CmbTypeCom.Location = new Point (154, 3);
		CmbTypeCom.Size = new Size (75, 21);
		CmbTypeCom.TabIndex = 3;
		CmbTypeCom.Text = "Bluetooth";
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (300, 290);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81936";
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

	private ComboBox CmbData;
	private ComboBox CmbEncod;
	private TextBox TxtWriteTimOut;
	private TextBox TxtWriteBuff;
	private TextBox TxtReadTimout;
	private TextBox TxtReadBuff;
	private ComboBox CmbBitStop;
	private ComboBox CmbParity;
	private ComboBox CmbSpeed;
	private ComboBox CmbTypeCom;
	private ComboBox CbbCOMPorts;
	private Label Label1;
	private Label Label2;
	private TableLayoutPanel _tableLayoutPanel;
	private Label label10;
	private Label label9;
	private Label label8;
	private Label label7;
	private Label label6;
	private Label label5;
	private Label label4;
	private Label label3;
	private Label label11;
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
			"1. The controls are layed out correctly on the form.",
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
		ClientSize = new Size (360, 85);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81936";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
