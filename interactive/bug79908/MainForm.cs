using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _displayFormButton
		// 
		_displayFormButton = new Button ();
		_displayFormButton.Location = new Point (80, 8);
		_displayFormButton.Size = new Size (120, 23);
		_displayFormButton.Text = "Display Form";
		_displayFormButton.Click += new EventHandler (DisplayFormButton_Click);
		Controls.Add (_displayFormButton);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 260;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Repeat the followings steps:{0}{0}" +
			"1. Click the \"Display Form\" button.{0}{0}" +
			"2. Uncheck \"Override DialogResult\".{0}{0}" +
			"3. Click buttons from top row, except \"None\".{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Modal form is hidden.{0}{0}" +
			"2. Message box with \"Closed\" text is displayed once.{0}{0}" +
			"3. Message box with text matching the clicked button is displayed.",
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
			"1. Click the \"Display Form\" button.{0}{0}" +
			"2. Uncheck \"Override DialogResult\".{0}{0}" +
			"3. Click \"None\" and \"Explicit None\" buttons.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Nothing happens.",
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
			"1. Click \"Display Form\" button.{0}{0}" +
			"2. Uncheck \"Override DialogResult\".{0}{0}" +
			"3. Click \"Explicit Yes\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Modal form is hidden.{0}{0}" +
			"2. Message box with \"Closed\" text is displayed once.{0}{0}" +
			"3. Message box with text \"Result: Yes\" is displayed.",
			Environment.NewLine);
		// 
		// _tabPage"
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click \"Display Form\" button.{0}{0}" +
			"2. Check \"Override DialogResult\".{0}{0}" +
			"3. Click all buttons, exception \"None\" and \"Explicit None\".{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Modal form is hidden.{0}{0}" +
			"2. Message box with \"Closed\" text is displayed once.{0}{0}" +
			"3. Message box with text \"Result: Retry\" is displayed.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText5 = new TextBox ();
		_bugDescriptionText5.Dock = DockStyle.Fill;
		_bugDescriptionText5.Multiline = true;
		_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Display Form\" button.{0}{0}" +
			"2. Check \"Override DialogResult\".{0}{0}" +
			"3. Click \"None\" and \"Explicit None\" buttons.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Nothing happens.",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (292, 300);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79908";
	}

	[STAThread]
	public static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void DisplayFormButton_Click (object sender, EventArgs e)
	{
		if (_modalForm == null) {
			_modalForm = new ModalForm ();
		}
		MessageBox.Show ("Result: " + _modalForm.ShowDialog ());
	}

	private Button _displayFormButton;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private ModalForm _modalForm;
}

public class ModalForm : Form
{
	public ModalForm ()
	{
		// 
		// _overrideResultCheck
		// 
		_overrideResultCheck = new CheckBox ();
		_overrideResultCheck.Location = new Point (8, 40);
		_overrideResultCheck.Size = new Size (160, 23);
		_overrideResultCheck.Text = "Override DialogResult";
		Controls.Add (_overrideResultCheck);
		// 
		// _abortButton
		// 
		_abortButton = new Button ();
		_abortButton.DialogResult = DialogResult.Abort;
		_abortButton.Location = new Point (8, 8);
		_abortButton.Size = new Size (75, 23);
		_abortButton.Text = "Abort";
		Controls.Add (_abortButton);
		// 
		// _cancelButton
		// 
		_cancelButton = new Button ();
		_cancelButton.DialogResult = DialogResult.Cancel;
		_cancelButton.Location = new Point (88, 8);
		_cancelButton.Size = new Size (75, 23);
		_cancelButton.Text = "Cancel";
		Controls.Add (_cancelButton);
		// 
		// _ignoreButton
		// 
		_ignoreButton = new Button ();
		_ignoreButton.DialogResult = DialogResult.Ignore;
		_ignoreButton.Location = new Point (168, 8);
		_ignoreButton.Size = new Size (75, 23);
		_ignoreButton.Text = "Ignore";
		Controls.Add (_ignoreButton);
		// 
		// _noButton
		// 
		_noButton = new Button ();
		_noButton.DialogResult = DialogResult.No;
		_noButton.Location = new Point (248, 8);
		_noButton.Size = new Size (75, 23);
		_noButton.Text = "No";
		Controls.Add (_noButton);
		// 
		// _noneButton
		// 
		_noneButton = new Button ();
		_noneButton.DialogResult = DialogResult.None;
		_noneButton.Location = new Point (328, 8);
		_noneButton.Size = new Size (75, 23);
		_noneButton.Text = "None";
		Controls.Add (_noneButton);
		// 
		// _okButton
		// 
		_okButton = new Button ();
		_okButton.DialogResult = DialogResult.OK;
		_okButton.Location = new Point (408, 8);
		_okButton.Size = new Size (75, 23);
		_okButton.Text = "OK";
		Controls.Add (_okButton);
		// 
		// _retryButton
		// 
		_retryButton = new Button ();
		_retryButton.DialogResult = DialogResult.Retry;
		_retryButton.Location = new Point (488, 8);
		_retryButton.Size = new Size (75, 23);
		_retryButton.Text = "Retry";
		Controls.Add (_retryButton);
		// 
		// _yesButton
		// 
		_yesButton = new Button ();
		_yesButton.DialogResult = DialogResult.Yes;
		_yesButton.Location = new Point (568, 8);
		_yesButton.Size = new Size (75, 23);
		_yesButton.Text = "Yes";
		Controls.Add (_yesButton);
		// 
		// _explicitNoneButton
		// 
		_explicitNoneButton = new Button ();
		_explicitNoneButton.DialogResult = DialogResult.No;
		_explicitNoneButton.Location = new Point (510, 40);
		_explicitNoneButton.Size = new Size (130, 23);
		_explicitNoneButton.Text = "Explicit None";
		_explicitNoneButton.Click += new EventHandler (ExplicitNoneButton_Click);
		Controls.Add (_explicitNoneButton);
		// 
		// _explicitYesButton
		// 
		_explicitYesButton = new Button ();
		_explicitYesButton.DialogResult = DialogResult.Abort;
		_explicitYesButton.Location = new Point (280, 40);
		_explicitYesButton.Size = new Size (130, 23);
		_explicitYesButton.Text = "Explicit Yes";
		_explicitYesButton.Click += new EventHandler (ExplicitYesButton_Click);
		Controls.Add (_explicitYesButton);
		// 
		// ModalForm
		// 
		AcceptButton = _okButton;
		ClientSize = new Size (650, 100);
		Text = "Modal";
		Closing += new CancelEventHandler (ModalForm_Closing);
		Closed += new EventHandler (ModalForm_Closed);
	}

	void ModalForm_Closing (object sender, CancelEventArgs e)
	{
		if (_overrideResultCheck.Checked)
			DialogResult = DialogResult.Retry;
	}

	void ModalForm_Closed (object sender, EventArgs e)
	{
		MessageBox.Show ("Closed");
	}

	void ExplicitNoneButton_Click (object sender, EventArgs e)
	{
		DialogResult = DialogResult.None;
	}

	void ExplicitYesButton_Click (object sender, EventArgs e)
	{
		DialogResult = DialogResult.Yes;
	}

	private CheckBox _overrideResultCheck;
	private Button _abortButton;
	private Button _cancelButton;
	private Button _ignoreButton;
	private Button _noButton;
	private Button _noneButton;
	private Button _okButton;
	private Button _retryButton;
	private Button _yesButton;
	private Button _explicitNoneButton;
	private Button _explicitYesButton;
}
