using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof (MainForm));
		TopBarPanel = new Panel ();
		CheckinLabel = new Label ();
		CheckoutLabel = new Label ();
		UpdateActionLabel = new Label ();
		panel15 = new Panel ();
		ViewChangedActionLabel = new Label ();
		ViewPrivatesActionLabel = new Label ();
		ViewAllCheckoutsActionLabel = new Label ();
		ViewCheckoutsActionLabel = new Label ();
		panel16 = new Panel ();
		ViewHyperlinksActionLabel = new Label ();
		ViewAttributesActionLabel = new Label ();
		ViewWorkspacesActionLabel = new Label ();
		ViewMarkersActionLabel = new Label ();
		ViewBranchesActionLabel = new Label ();
		ViewItemsActionLabel = new Label ();
		label10 = new Label ();
		RefreshActionLabel = new Label ();
		label3 = new Label ();
		TopBarPanel.SuspendLayout ();
		panel15.SuspendLayout ();
		panel16.SuspendLayout ();
		SuspendLayout ();
		// 
		// TopBarPanel
		// 
		TopBarPanel.BackColor = Color.White;
		TopBarPanel.BackgroundImage = ((Image) (resources.GetObject ("TopBarPanel.BackgroundImage")));
		TopBarPanel.Controls.Add (CheckinLabel);
		TopBarPanel.Controls.Add (CheckoutLabel);
		TopBarPanel.Controls.Add (UpdateActionLabel);
		TopBarPanel.Controls.Add (panel15);
		TopBarPanel.Controls.Add (ViewCheckoutsActionLabel);
		TopBarPanel.Controls.Add (panel16);
		TopBarPanel.Controls.Add (ViewMarkersActionLabel);
		TopBarPanel.Controls.Add (ViewBranchesActionLabel);
		TopBarPanel.Controls.Add (ViewItemsActionLabel);
		TopBarPanel.Controls.Add (label10);
		TopBarPanel.Controls.Add (RefreshActionLabel);
		TopBarPanel.Controls.Add (label3);
		TopBarPanel.Dock = DockStyle.Top;
		TopBarPanel.Location = new Point (0, 0);
		TopBarPanel.Size = new Size (720, 82);
		TopBarPanel.TabIndex = 6;
		// 
		// CheckinLabel
		// 
		CheckinLabel.BackColor = Color.Transparent;
		CheckinLabel.Cursor = Cursors.Hand;
		CheckinLabel.Dock = DockStyle.Left;
		CheckinLabel.Image = ((Image) (resources.GetObject ("CheckinLabel.Image")));
		CheckinLabel.ImeMode = ImeMode.NoControl;
		CheckinLabel.Location = new Point (666, 0);
		CheckinLabel.Size = new Size (56, 82);
		CheckinLabel.TabIndex = 14;
		CheckinLabel.Text = "Check in";
		CheckinLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// CheckoutLabel
		// 
		CheckoutLabel.BackColor = Color.Transparent;
		CheckoutLabel.Cursor = Cursors.Hand;
		CheckoutLabel.Dock = DockStyle.Left;
		CheckoutLabel.Image = ((Image) (resources.GetObject ("CheckoutLabel.Image")));
		CheckoutLabel.ImeMode = ImeMode.NoControl;
		CheckoutLabel.Location = new Point (604, 0);
		CheckoutLabel.Size = new Size (62, 82);
		CheckoutLabel.TabIndex = 13;
		CheckoutLabel.Text = "Check out";
		CheckoutLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// UpdateActionLabel
		// 
		UpdateActionLabel.BackColor = Color.Transparent;
		UpdateActionLabel.Cursor = Cursors.Hand;
		UpdateActionLabel.Dock = DockStyle.Left;
		UpdateActionLabel.Image = ((Image) (resources.GetObject ("UpdateActionLabel.Image")));
		UpdateActionLabel.ImeMode = ImeMode.NoControl;
		UpdateActionLabel.Location = new Point (548, 0);
		UpdateActionLabel.Size = new Size (56, 82);
		UpdateActionLabel.TabIndex = 11;
		UpdateActionLabel.Text = "Update";
		UpdateActionLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// panel15
		// 
		panel15.BackColor = Color.Transparent;
		panel15.Controls.Add (ViewChangedActionLabel);
		panel15.Controls.Add (ViewPrivatesActionLabel);
		panel15.Controls.Add (ViewAllCheckoutsActionLabel);
		panel15.Dock = DockStyle.Left;
		panel15.Location = new Point (416, 0);
		panel15.Size = new Size (132, 82);
		panel15.TabIndex = 10;
		// 
		// ViewChangedActionLabel
		// 
		ViewChangedActionLabel.Cursor = Cursors.Hand;
		ViewChangedActionLabel.Dock = DockStyle.Top;
		ViewChangedActionLabel.Image = ((Image) (resources.GetObject ("ViewChangedActionLabel.Image")));
		ViewChangedActionLabel.ImageAlign = ContentAlignment.MiddleLeft;
		ViewChangedActionLabel.ImeMode = ImeMode.NoControl;
		ViewChangedActionLabel.Location = new Point (0, 48);
		ViewChangedActionLabel.Size = new Size (132, 24);
		ViewChangedActionLabel.TabIndex = 2;
		ViewChangedActionLabel.Text = "        View changed";
		ViewChangedActionLabel.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// ViewPrivatesActionLabel
		// 
		ViewPrivatesActionLabel.Cursor = Cursors.Hand;
		ViewPrivatesActionLabel.Dock = DockStyle.Top;
		ViewPrivatesActionLabel.Image = ((Image) (resources.GetObject ("ViewPrivatesActionLabel.Image")));
		ViewPrivatesActionLabel.ImageAlign = ContentAlignment.MiddleLeft;
		ViewPrivatesActionLabel.ImeMode = ImeMode.NoControl;
		ViewPrivatesActionLabel.Location = new Point (0, 24);
		ViewPrivatesActionLabel.Size = new Size (132, 24);
		ViewPrivatesActionLabel.TabIndex = 1;
		ViewPrivatesActionLabel.Text = "        View privates";
		ViewPrivatesActionLabel.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// ViewAllCheckoutsActionLabel
		// 
		ViewAllCheckoutsActionLabel.Cursor = Cursors.Hand;
		ViewAllCheckoutsActionLabel.Dock = DockStyle.Top;
		ViewAllCheckoutsActionLabel.Image = ((Image) (resources.GetObject ("ViewAllCheckoutsActionLabel.Image")));
		ViewAllCheckoutsActionLabel.ImageAlign = ContentAlignment.MiddleLeft;
		ViewAllCheckoutsActionLabel.ImeMode = ImeMode.NoControl;
		ViewAllCheckoutsActionLabel.Location = new Point (0, 0);
		ViewAllCheckoutsActionLabel.Size = new Size (132, 24);
		ViewAllCheckoutsActionLabel.TabIndex = 0;
		ViewAllCheckoutsActionLabel.Text = "        View all checkouts";
		ViewAllCheckoutsActionLabel.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// ViewCheckoutsActionLabel
		// 
		ViewCheckoutsActionLabel.BackColor = Color.Transparent;
		ViewCheckoutsActionLabel.Cursor = Cursors.Hand;
		ViewCheckoutsActionLabel.Dock = DockStyle.Left;
		ViewCheckoutsActionLabel.Image = ((Image) (resources.GetObject ("ViewCheckoutsActionLabel.Image")));
		ViewCheckoutsActionLabel.ImeMode = ImeMode.NoControl;
		ViewCheckoutsActionLabel.Location = new Point (360, 0);
		ViewCheckoutsActionLabel.Size = new Size (56, 82);
		ViewCheckoutsActionLabel.TabIndex = 9;
		ViewCheckoutsActionLabel.Text = "View COs";
		ViewCheckoutsActionLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// panel16
		// 
		panel16.BackColor = Color.Transparent;
		panel16.Controls.Add (ViewHyperlinksActionLabel);
		panel16.Controls.Add (ViewAttributesActionLabel);
		panel16.Controls.Add (ViewWorkspacesActionLabel);
		panel16.Dock = DockStyle.Left;
		panel16.DockPadding.All = 5;
		panel16.Location = new Point (236, 0);
		panel16.Size = new Size (124, 82);
		panel16.TabIndex = 8;
		// 
		// ViewHyperlinksActionLabel
		// 
		ViewHyperlinksActionLabel.Cursor = Cursors.Hand;
		ViewHyperlinksActionLabel.Dock = DockStyle.Top;
		ViewHyperlinksActionLabel.Enabled = false;
		ViewHyperlinksActionLabel.Image = ((Image) (resources.GetObject ("ViewHyperlinksActionLabel.Image")));
		ViewHyperlinksActionLabel.ImageAlign = ContentAlignment.MiddleLeft;
		ViewHyperlinksActionLabel.ImeMode = ImeMode.NoControl;
		ViewHyperlinksActionLabel.Location = new Point (5, 53);
		ViewHyperlinksActionLabel.Size = new Size (114, 24);
		ViewHyperlinksActionLabel.TabIndex = 2;
		ViewHyperlinksActionLabel.Text = "        View Hyperlinks";
		ViewHyperlinksActionLabel.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// ViewAttributesActionLabel
		// 
		ViewAttributesActionLabel.Cursor = Cursors.Hand;
		ViewAttributesActionLabel.Dock = DockStyle.Top;
		ViewAttributesActionLabel.Enabled = false;
		ViewAttributesActionLabel.Image = ((Image) (resources.GetObject ("ViewAttributesActionLabel.Image")));
		ViewAttributesActionLabel.ImageAlign = ContentAlignment.MiddleLeft;
		ViewAttributesActionLabel.ImeMode = ImeMode.NoControl;
		ViewAttributesActionLabel.Location = new Point (5, 29);
		ViewAttributesActionLabel.Size = new Size (114, 24);
		ViewAttributesActionLabel.TabIndex = 1;
		ViewAttributesActionLabel.Text = "        View Attributes";
		ViewAttributesActionLabel.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// ViewWorkspacesActionLabel
		// 
		ViewWorkspacesActionLabel.Cursor = Cursors.Hand;
		ViewWorkspacesActionLabel.Dock = DockStyle.Top;
		ViewWorkspacesActionLabel.Image = ((Image) (resources.GetObject ("ViewWorkspacesActionLabel.Image")));
		ViewWorkspacesActionLabel.ImageAlign = ContentAlignment.MiddleLeft;
		ViewWorkspacesActionLabel.ImeMode = ImeMode.NoControl;
		ViewWorkspacesActionLabel.Location = new Point (5, 5);
		ViewWorkspacesActionLabel.Size = new Size (114, 24);
		ViewWorkspacesActionLabel.TabIndex = 0;
		ViewWorkspacesActionLabel.Text = "        Workspaces";
		ViewWorkspacesActionLabel.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// ViewMarkersActionLabel
		// 
		ViewMarkersActionLabel.BackColor = Color.Transparent;
		ViewMarkersActionLabel.Cursor = Cursors.Hand;
		ViewMarkersActionLabel.Dock = DockStyle.Left;
		ViewMarkersActionLabel.Image = ((Image) (resources.GetObject ("ViewMarkersActionLabel.Image")));
		ViewMarkersActionLabel.ImeMode = ImeMode.NoControl;
		ViewMarkersActionLabel.Location = new Point (180, 0);
		ViewMarkersActionLabel.Size = new Size (56, 82);
		ViewMarkersActionLabel.TabIndex = 7;
		ViewMarkersActionLabel.Text = "Markers";
		ViewMarkersActionLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// ViewBranchesActionLabel
		// 
		ViewBranchesActionLabel.BackColor = Color.Transparent;
		ViewBranchesActionLabel.Cursor = Cursors.Hand;
		ViewBranchesActionLabel.Dock = DockStyle.Left;
		ViewBranchesActionLabel.Image = ((Image) (resources.GetObject ("ViewBranchesActionLabel.Image")));
		ViewBranchesActionLabel.ImeMode = ImeMode.NoControl;
		ViewBranchesActionLabel.Location = new Point (124, 0);
		ViewBranchesActionLabel.Size = new Size (56, 82);
		ViewBranchesActionLabel.TabIndex = 6;
		ViewBranchesActionLabel.Text = "Branches";
		ViewBranchesActionLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// ViewItemsActionLabel
		// 
		ViewItemsActionLabel.BackColor = Color.Transparent;
		ViewItemsActionLabel.Cursor = Cursors.Hand;
		ViewItemsActionLabel.Dock = DockStyle.Left;
		ViewItemsActionLabel.Image = ((Image) (resources.GetObject ("ViewItemsActionLabel.Image")));
		ViewItemsActionLabel.ImeMode = ImeMode.NoControl;
		ViewItemsActionLabel.Location = new Point (68, 0);
		ViewItemsActionLabel.Size = new Size (56, 82);
		ViewItemsActionLabel.TabIndex = 5;
		ViewItemsActionLabel.Text = "Items";
		ViewItemsActionLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// label10
		// 
		label10.BackColor = Color.Transparent;
		label10.Dock = DockStyle.Left;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point (60, 0);
		label10.Size = new Size (8, 82);
		label10.TabIndex = 4;
		// 
		// RefreshActionLabel
		// 
		RefreshActionLabel.BackColor = Color.Transparent;
		RefreshActionLabel.Cursor = Cursors.Hand;
		RefreshActionLabel.Dock = DockStyle.Left;
		RefreshActionLabel.Image = ((Image) (resources.GetObject ("RefreshActionLabel.Image")));
		RefreshActionLabel.ImeMode = ImeMode.NoControl;
		RefreshActionLabel.Location = new Point (4, 0);
		RefreshActionLabel.Size = new Size (56, 82);
		RefreshActionLabel.TabIndex = 3;
		RefreshActionLabel.Text = "Refresh";
		RefreshActionLabel.TextAlign = ContentAlignment.BottomCenter;
		// 
		// label3
		// 
		label3.BackColor = Color.Transparent;
		label3.Dock = DockStyle.Left;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point (0, 0);
		label3.Size = new Size (4, 82);
		label3.TabIndex = 2;
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Size = new Size (20, 140);
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. There should be no small white artifacts around:{0}{0}" +
			"    The Refresh arrows.{0}" +
			"    The Workspaces icon.{0}" +
			"    The Update icon.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (720, 240);
		Controls.Add (TopBarPanel);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79297";
		TopBarPanel.ResumeLayout (false);
		panel15.ResumeLayout (false);
		panel16.ResumeLayout (false);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private Panel TopBarPanel;
	private Label CheckinLabel;
	private Label CheckoutLabel;
	private Label UpdateActionLabel;
	private Panel panel15;
	private Label ViewChangedActionLabel;
	private Label ViewPrivatesActionLabel;
	private Label ViewAllCheckoutsActionLabel;
	private Label ViewCheckoutsActionLabel;
	private Panel panel16;
	private Label ViewHyperlinksActionLabel;
	private Label ViewAttributesActionLabel;
	private Label ViewWorkspacesActionLabel;
	private Label ViewMarkersActionLabel;
	private Label ViewBranchesActionLabel;
	private Label ViewItemsActionLabel;
	private Label label10;
	private Label RefreshActionLabel;
	private Label label3;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
