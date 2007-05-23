using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	private Label _affectedFilesLabel;
	private ListView AffectedFiles;
	private ColumnHeader ItemColumn;

	private GroupBox _groupBox;
	private Panel _optionsPanel;
	private Button _optionsButton;
	private Panel OptionsPanel;
	private Panel panel4;
	private Panel panel5;
	bool bFormExpanded;

	private DialogResult mDialogResult = DialogResult.Cancel;

	public MainForm ()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof (MainForm));
		_affectedFilesLabel = new Label ();
		AffectedFiles = new ListView ();
		ItemColumn = new ColumnHeader ();
		_groupBox = new GroupBox ();
		_optionsPanel = new Panel ();
		_optionsButton = new Button ();
		OptionsPanel = new Panel ();
		panel4 = new Panel ();
		panel5 = new Panel ();
		_groupBox.SuspendLayout ();
		_optionsPanel.SuspendLayout ();
		OptionsPanel.SuspendLayout ();
		panel4.SuspendLayout ();
		panel5.SuspendLayout ();
		SuspendLayout ();
		// 
		// _affectedFilesLabel
		// 
		_affectedFilesLabel.AccessibleDescription = resources.GetString ("affectedFilesLabel.AccessibleDescription");
		_affectedFilesLabel.AccessibleName = resources.GetString ("affectedFilesLabel.AccessibleName");
		_affectedFilesLabel.Anchor = ((AnchorStyles) (resources.GetObject ("affectedFilesLabel.Anchor")));
		_affectedFilesLabel.AutoSize = ((bool) (resources.GetObject ("affectedFilesLabel.AutoSize")));
		_affectedFilesLabel.Dock = ((DockStyle) (resources.GetObject ("affectedFilesLabel.Dock")));
		_affectedFilesLabel.Enabled = ((bool) (resources.GetObject ("affectedFilesLabel.Enabled")));
		_affectedFilesLabel.Font = ((System.Drawing.Font) (resources.GetObject ("affectedFilesLabel.Font")));
		_affectedFilesLabel.Image = ((System.Drawing.Image) (resources.GetObject ("affectedFilesLabel.Image")));
		_affectedFilesLabel.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject ("affectedFilesLabel.ImageAlign")));
		_affectedFilesLabel.ImageIndex = ((int) (resources.GetObject ("affectedFilesLabel.ImageIndex")));
		_affectedFilesLabel.ImeMode = ((ImeMode) (resources.GetObject ("affectedFilesLabel.ImeMode")));
		_affectedFilesLabel.Location = ((System.Drawing.Point) (resources.GetObject ("affectedFilesLabel.Location")));
		_affectedFilesLabel.Name = "_affectedFilesLabel";
		_affectedFilesLabel.RightToLeft = ((RightToLeft) (resources.GetObject ("affectedFilesLabel.RightToLeft")));
		_affectedFilesLabel.Size = ((System.Drawing.Size) (resources.GetObject ("affectedFilesLabel.Size")));
		_affectedFilesLabel.TabIndex = ((int) (resources.GetObject ("affectedFilesLabel.TabIndex")));
		_affectedFilesLabel.Text = resources.GetString ("affectedFilesLabel.Text");
		_affectedFilesLabel.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject ("affectedFilesLabel.TextAlign")));
		_affectedFilesLabel.Visible = ((bool) (resources.GetObject ("affectedFilesLabel.Visible")));
		// 
		// AffectedFiles
		// 
		AffectedFiles.Anchor = ((AnchorStyles) (resources.GetObject ("AffectedFiles.Anchor")));
		AffectedFiles.FullRowSelect = true;
		AffectedFiles.HideSelection = false;
		AffectedFiles.Location = ((System.Drawing.Point) (resources.GetObject ("AffectedFiles.Location")));
		AffectedFiles.Size = new Size (195, 120);
		AffectedFiles.View = View.Details;
		// 
		// ItemColumn
		// 
		ItemColumn.Text = "Items";
		ItemColumn.Width = 150;
		AffectedFiles.Columns.Add (ItemColumn);
		// 
		// _groupBox
		// 
		_groupBox.FlatStyle = FlatStyle.System;
		_groupBox.Location = ((System.Drawing.Point) (resources.GetObject ("groupBox.Location")));
		_groupBox.Size = new Size (195, 100);
		_groupBox.TabStop = false;
		_groupBox.Text = "Group";
		// 
		// _optionsPanel
		// 
		_optionsPanel.AccessibleDescription = resources.GetString ("panel.AccessibleDescription");
		_optionsPanel.AccessibleName = resources.GetString ("panel.AccessibleName");
		_optionsPanel.Anchor = ((AnchorStyles) (resources.GetObject ("panel.Anchor")));
		_optionsPanel.AutoScroll = ((bool) (resources.GetObject ("panel.AutoScroll")));
		_optionsPanel.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject ("panel.AutoScrollMargin")));
		_optionsPanel.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject ("panel.AutoScrollMinSize")));
		_optionsPanel.BackgroundImage = ((System.Drawing.Image) (resources.GetObject ("panel.BackgroundImage")));
		_optionsPanel.Controls.Add (_optionsButton);
		_optionsPanel.Dock = ((DockStyle) (resources.GetObject ("panel.Dock")));
		_optionsPanel.Enabled = ((bool) (resources.GetObject ("panel.Enabled")));
		_optionsPanel.Font = ((System.Drawing.Font) (resources.GetObject ("panel.Font")));
		_optionsPanel.ImeMode = ((ImeMode) (resources.GetObject ("panel.ImeMode")));
		_optionsPanel.Location = ((System.Drawing.Point) (resources.GetObject ("panel.Location")));
		_optionsPanel.RightToLeft = ((RightToLeft) (resources.GetObject ("panel.RightToLeft")));
		_optionsPanel.Size = ((System.Drawing.Size) (resources.GetObject ("panel.Size")));
		_optionsPanel.TabIndex = ((int) (resources.GetObject ("panel.TabIndex")));
		_optionsPanel.Visible = ((bool) (resources.GetObject ("panel.Visible")));
		// 
		// _optionsButton
		// 
		_optionsButton.AccessibleDescription = resources.GetString ("_optionsButton.AccessibleDescription");
		_optionsButton.AccessibleName = resources.GetString ("_optionsButton.AccessibleName");
		_optionsButton.Anchor = ((AnchorStyles) (resources.GetObject ("_optionsButton.Anchor")));
		_optionsButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject ("_optionsButton.BackgroundImage")));
		_optionsButton.Dock = ((DockStyle) (resources.GetObject ("_optionsButton.Dock")));
		_optionsButton.Enabled = ((bool) (resources.GetObject ("_optionsButton.Enabled")));
		_optionsButton.FlatStyle = ((FlatStyle) (resources.GetObject ("_optionsButton.FlatStyle")));
		_optionsButton.Font = ((System.Drawing.Font) (resources.GetObject ("_optionsButton.Font")));
		_optionsButton.Image = ((System.Drawing.Image) (resources.GetObject ("_optionsButton.Image")));
		_optionsButton.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject ("_optionsButton.ImageAlign")));
		_optionsButton.ImageIndex = ((int) (resources.GetObject ("_optionsButton.ImageIndex")));
		_optionsButton.ImeMode = ((ImeMode) (resources.GetObject ("_optionsButton.ImeMode")));
		_optionsButton.Location = ((System.Drawing.Point) (resources.GetObject ("_optionsButton.Location")));
		_optionsButton.Name = "_optionsButton";
		_optionsButton.RightToLeft = ((RightToLeft) (resources.GetObject ("_optionsButton.RightToLeft")));
		_optionsButton.Size = ((System.Drawing.Size) (resources.GetObject ("_optionsButton.Size")));
		_optionsButton.TabIndex = ((int) (resources.GetObject ("_optionsButton.TabIndex")));
		_optionsButton.Text = resources.GetString ("_optionsButton.Text");
		_optionsButton.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject ("_optionsButton.TextAlign")));
		_optionsButton.Visible = ((bool) (resources.GetObject ("_optionsButton.Visible")));
		_optionsButton.Click += new System.EventHandler (OptionsButton_Click);
		// 
		// OptionsPanel
		// 
		OptionsPanel.AccessibleDescription = resources.GetString ("OptionsPanel.AccessibleDescription");
		OptionsPanel.AccessibleName = resources.GetString ("OptionsPanel.AccessibleName");
		OptionsPanel.Anchor = ((AnchorStyles) (resources.GetObject ("OptionsPanel.Anchor")));
		OptionsPanel.AutoScroll = ((bool) (resources.GetObject ("OptionsPanel.AutoScroll")));
		OptionsPanel.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject ("OptionsPanel.AutoScrollMargin")));
		OptionsPanel.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject ("OptionsPanel.AutoScrollMinSize")));
		OptionsPanel.BackgroundImage = ((System.Drawing.Image) (resources.GetObject ("OptionsPanel.BackgroundImage")));
		OptionsPanel.Controls.Add (_groupBox);
		OptionsPanel.Dock = ((DockStyle) (resources.GetObject ("OptionsPanel.Dock")));
		OptionsPanel.Enabled = ((bool) (resources.GetObject ("OptionsPanel.Enabled")));
		OptionsPanel.Font = ((System.Drawing.Font) (resources.GetObject ("OptionsPanel.Font")));
		OptionsPanel.ImeMode = ((ImeMode) (resources.GetObject ("OptionsPanel.ImeMode")));
		OptionsPanel.Location = ((System.Drawing.Point) (resources.GetObject ("OptionsPanel.Location")));
		OptionsPanel.RightToLeft = ((RightToLeft) (resources.GetObject ("OptionsPanel.RightToLeft")));
		OptionsPanel.Size = ((System.Drawing.Size) (resources.GetObject ("OptionsPanel.Size")));
		OptionsPanel.TabIndex = ((int) (resources.GetObject ("OptionsPanel.TabIndex")));
		OptionsPanel.Text = resources.GetString ("OptionsPanel.Text");
		OptionsPanel.Visible = ((bool) (resources.GetObject ("OptionsPanel.Visible")));
		// 
		// panel4
		// 
		panel4.AccessibleDescription = resources.GetString ("panel4.AccessibleDescription");
		panel4.AccessibleName = resources.GetString ("panel4.AccessibleName");
		panel4.Anchor = ((AnchorStyles) (resources.GetObject ("panel4.Anchor")));
		panel4.AutoScroll = ((bool) (resources.GetObject ("panel4.AutoScroll")));
		panel4.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject ("panel4.AutoScrollMargin")));
		panel4.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject ("panel4.AutoScrollMinSize")));
		panel4.BackgroundImage = ((System.Drawing.Image) (resources.GetObject ("panel4.BackgroundImage")));
		panel4.Controls.Add (AffectedFiles);
		panel4.Controls.Add (panel5);
		panel4.Dock = ((DockStyle) (resources.GetObject ("panel4.Dock")));
		panel4.DockPadding.Right = 15;
		panel4.Enabled = ((bool) (resources.GetObject ("panel4.Enabled")));
		panel4.Font = ((System.Drawing.Font) (resources.GetObject ("panel4.Font")));
		panel4.ImeMode = ((ImeMode) (resources.GetObject ("panel4.ImeMode")));
		panel4.Location = ((System.Drawing.Point) (resources.GetObject ("panel4.Location")));
		panel4.RightToLeft = ((RightToLeft) (resources.GetObject ("panel4.RightToLeft")));
		panel4.Size = ((System.Drawing.Size) (resources.GetObject ("panel4.Size")));
		panel4.TabIndex = ((int) (resources.GetObject ("panel4.TabIndex")));
		panel4.Text = resources.GetString ("panel4.Text");
		panel4.Visible = ((bool) (resources.GetObject ("panel4.Visible")));
		// 
		// panel5
		// 
		panel5.AccessibleDescription = resources.GetString ("panel5.AccessibleDescription");
		panel5.AccessibleName = resources.GetString ("panel5.AccessibleName");
		panel5.Anchor = ((AnchorStyles) (resources.GetObject ("panel5.Anchor")));
		panel5.AutoScroll = ((bool) (resources.GetObject ("panel5.AutoScroll")));
		panel5.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject ("panel5.AutoScrollMargin")));
		panel5.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject ("panel5.AutoScrollMinSize")));
		panel5.BackgroundImage = ((System.Drawing.Image) (resources.GetObject ("panel5.BackgroundImage")));
		panel5.Controls.Add (_affectedFilesLabel);
		panel5.Dock = ((DockStyle) (resources.GetObject ("panel5.Dock")));
		panel5.Enabled = ((bool) (resources.GetObject ("panel5.Enabled")));
		panel5.Font = ((System.Drawing.Font) (resources.GetObject ("panel5.Font")));
		panel5.ImeMode = ((ImeMode) (resources.GetObject ("panel5.ImeMode")));
		panel5.Location = ((System.Drawing.Point) (resources.GetObject ("panel5.Location")));
		panel5.RightToLeft = ((RightToLeft) (resources.GetObject ("panel5.RightToLeft")));
		panel5.Size = ((System.Drawing.Size) (resources.GetObject ("panel5.Size")));
		panel5.TabIndex = ((int) (resources.GetObject ("panel5.TabIndex")));
		panel5.Text = resources.GetString ("panel5.Text");
		panel5.Visible = ((bool) (resources.GetObject ("panel5.Visible")));
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Controls.Add (panel4);
		Controls.Add (OptionsPanel);
		Controls.Add (_optionsPanel);
		Location = new Point (200, 100);
		MinimizeBox = false;
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81718";
		Closing += new CancelEventHandler (MainForm_Closing);
		Load += new EventHandler (MainForm_Load);
		_groupBox.ResumeLayout (false);
		_optionsPanel.ResumeLayout (false);
		OptionsPanel.ResumeLayout (false);
		panel4.ResumeLayout (false);
		panel5.ResumeLayout (false);
		ResumeLayout (false);
	}

	void MainForm_Load (object sender, System.EventArgs e)
	{
		CollapseForm ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void OptionsButton_Click (object sender, System.EventArgs e)
	{
		if (!bFormExpanded) {
			ExpandForm ();
		} else {
			CollapseForm ();
		}
	}

	void ExpandForm ()
	{
		OptionsPanel.Visible = true;
		Size = new Size (Width, Height + OptionsPanel.Height);
		bFormExpanded = true;
	}

	void CollapseForm ()
	{
		Size = new Size (Width, Height - OptionsPanel.Height);
		OptionsPanel.Visible = false;
		bFormExpanded = false;
	}

	void MainForm_Closing (object sender, CancelEventArgs e)
	{
		DialogResult = mDialogResult;
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
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
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Options button.{0}{0}" +
			"2. Click the Options button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the Form expands and a GroupBox becomes visible.{0}{0}" +
			"2. On step 2:{0}{0}" +
			"   * the Form is restored to its original size and layout.{0}" +
			"   * the ListView and corresponding Label are fully visible.",
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
		ClientSize = new Size (330, 250);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81718";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
