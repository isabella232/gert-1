using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// tabControl1
		// 
		tabControl1 = new TabControl ();
		tabControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		tabControl1.Location = new Point (6, 6);
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.Size = new Size (390, 400);
		tabControl1.TabIndex = 5;
		// 
		// tabUpdates
		// 
		tabUpdates = new TabPage ();
		tabUpdates.Location = new Point (4, 22);
		tabUpdates.Name = "tabUpdates";
		tabUpdates.Padding = new Padding (3);
		tabUpdates.Size = new Size (384, 506);
		tabUpdates.TabIndex = 3;
		tabUpdates.Text = "Updates";
		tabUpdates.UseVisualStyleBackColor = true;
		tabControl1.Controls.Add (tabUpdates);
		// 
		// flowLayoutPanel11
		// 
		flowLayoutPanel11 = new FlowLayoutPanel ();
		flowLayoutPanel11.AutoSize = true;
		flowLayoutPanel11.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		flowLayoutPanel11.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel11.Location = new Point (3, 3);
		flowLayoutPanel11.Size = new Size (478, 481);
		flowLayoutPanel11.TabIndex = 9;
		tabUpdates.Controls.Add (flowLayoutPanel11);
		// 
		// flowLayoutPanel20
		// 
		flowLayoutPanel20 = new FlowLayoutPanel ();
		flowLayoutPanel20.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		flowLayoutPanel20.AutoSize = true;
		flowLayoutPanel20.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		flowLayoutPanel20.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel20.Location = new Point (3, 75);
		flowLayoutPanel20.Size = new Size (200, 23);
		flowLayoutPanel20.TabIndex = 4;
		// 
		// cbKeepCharacterPlans
		// 
		cbKeepCharacterPlans = new CheckBox ();
		cbKeepCharacterPlans.AutoSize = true;
		cbKeepCharacterPlans.Location = new Point (3, 3);
		cbKeepCharacterPlans.Size = new Size (100, 17);
		cbKeepCharacterPlans.TabIndex = 1;
		cbKeepCharacterPlans.Text = "Keep plans";
		cbKeepCharacterPlans.UseVisualStyleBackColor = true;
		flowLayoutPanel20.Controls.Add (cbKeepCharacterPlans);
		// 
		// flowLayoutPanel19
		// 
		flowLayoutPanel19 = new FlowLayoutPanel ();
		flowLayoutPanel19.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		flowLayoutPanel19.AutoSize = true;
		flowLayoutPanel19.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		flowLayoutPanel19.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel19.Location = new Point (45, 33);
		flowLayoutPanel19.Size = new Size (0, 0);
		flowLayoutPanel19.TabIndex = 3;
		// 
		// flowLayoutPanel18
		// 
		flowLayoutPanel18 = new FlowLayoutPanel ();
		flowLayoutPanel18.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		flowLayoutPanel18.AutoSize = true;
		flowLayoutPanel18.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		flowLayoutPanel18.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel18.Location = new Point (3, 46);
		flowLayoutPanel18.Size = new Size (153, 23);
		flowLayoutPanel18.TabIndex = 2;
		// 
		// cbDeleteCharactersSilently
		// 
		cbDeleteCharactersSilently = new CheckBox ();
		cbDeleteCharactersSilently.AutoSize = true;
		cbDeleteCharactersSilently.Location = new Point (3, 3);
		cbDeleteCharactersSilently.Size = new Size (147, 17);
		cbDeleteCharactersSilently.TabIndex = 1;
		cbDeleteCharactersSilently.Text = "Delete characters";
		cbDeleteCharactersSilently.UseVisualStyleBackColor = true;
		flowLayoutPanel18.Controls.Add (cbDeleteCharactersSilently);
		// 
		// flowLayoutPanel17
		// 
		flowLayoutPanel17 = new FlowLayoutPanel ();
		flowLayoutPanel17.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		flowLayoutPanel17.AutoSize = true;
		flowLayoutPanel17.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		flowLayoutPanel17.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel17.Location = new Point (14, 19);
		flowLayoutPanel17.Size = new Size (0, 0);
		flowLayoutPanel17.TabIndex = 1;
		// 
		// flowLayoutPanel12
		// 
		flowLayoutPanel12 = new FlowLayoutPanel ();
		flowLayoutPanel12.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		flowLayoutPanel12.AutoSize = true;
		flowLayoutPanel12.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		flowLayoutPanel12.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel12.Location = new Point (3, 17);
		flowLayoutPanel12.Size = new Size (194, 23);
		flowLayoutPanel12.TabIndex = 0;
		// 
		// cbAutomaticEOSkillUpdate
		// 
		cbAutomaticEOSkillUpdate = new CheckBox ();
		cbAutomaticEOSkillUpdate.AutoSize = true;
		cbAutomaticEOSkillUpdate.Location = new Point (3, 3);
		cbAutomaticEOSkillUpdate.Size = new Size (200, 17);
		cbAutomaticEOSkillUpdate.TabIndex = 1;
		cbAutomaticEOSkillUpdate.Text = "Disable XML update";
		cbAutomaticEOSkillUpdate.UseVisualStyleBackColor = true;
		flowLayoutPanel12.Controls.Add (cbAutomaticEOSkillUpdate);
		// 
		// groupBox9
		// 
		groupBox9 = new GroupBox ();
		groupBox9.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		groupBox9.Controls.Add (flowLayoutPanel12);
		groupBox9.Controls.Add (flowLayoutPanel17);
		groupBox9.Controls.Add (flowLayoutPanel19);
		groupBox9.Controls.Add (flowLayoutPanel20);
		groupBox9.Controls.Add (flowLayoutPanel18);
		groupBox9.AutoSize = true;
		groupBox9.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		groupBox9.Location = new Point (3, 3);
		groupBox9.Size = new Size (600, 318);
		groupBox9.TabIndex = 9;
		groupBox9.TabStop = false;
		groupBox9.Text = "XML Update";
		flowLayoutPanel11.Controls.Add (groupBox9);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
		ClientSize = new Size (400, 410);
		Controls.Add (tabControl1);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82488";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private CheckBox cbAutomaticEOSkillUpdate;
	private CheckBox cbDeleteCharactersSilently;
	private CheckBox cbKeepCharacterPlans;
	private TabControl tabControl1;
	private TabPage tabUpdates;
	private GroupBox groupBox9;
	private FlowLayoutPanel flowLayoutPanel11;
	private FlowLayoutPanel flowLayoutPanel12;
	private FlowLayoutPanel flowLayoutPanel17;
	private FlowLayoutPanel flowLayoutPanel18;
	private FlowLayoutPanel flowLayoutPanel19;
	private FlowLayoutPanel flowLayoutPanel20;
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
			"1. A GroupBox containing three checkboxes is displayed " +
			"on the Updates tab.{0}{0}" +
			"Note:{0}" +
			"The text of the checkboxes may be cut-off.",
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
		ClientSize = new Size (300, 135);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82488";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
