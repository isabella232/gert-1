Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
	Inherits Form

	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		_titleLabel = New Label
		_titleValue = New TextBox
		_nameLabel = New Label
		_nameValue = New TextBox
		_municipalityLabel = New Label
		_municipalityValue = New TextBox
		_zipCodeLabel = New Label
		_zipCodeValue = New TextBox
		_countryLabel = New Label
		_countryValue = New TextBox
		_saveButton = New Button
		ListBox1 = New ListBox
		' 
		' _tableLayoutPanel
		' 
		_tableLayoutPanel = New TableLayoutPanel
		_tableLayoutPanel.ColumnCount = 4
		_tableLayoutPanel.ColumnStyles.Add(New ColumnStyle)
		_tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
		_tableLayoutPanel.ColumnStyles.Add(New ColumnStyle)
		_tableLayoutPanel.ColumnStyles.Add(New ColumnStyle)
		_tableLayoutPanel.Controls.Add (_titleLabel, 0, 0)
		_tableLayoutPanel.Controls.Add (_titleValue, 1, 0)
		_tableLayoutPanel.Controls.Add (_nameLabel, 0, 1)
		_tableLayoutPanel.Controls.Add (_nameValue, 1, 1)
		_tableLayoutPanel.Controls.Add (_municipalityLabel, 0, 2)
		_tableLayoutPanel.Controls.Add (_municipalityValue, 1, 2)
		_tableLayoutPanel.Controls.Add (_zipCodeLabel, 2, 2)
		_tableLayoutPanel.Controls.Add (_zipCodeValue, 3, 2)
		_tableLayoutPanel.Controls.Add (_countryLabel, 0, 3)
		_tableLayoutPanel.Controls.Add (_countryValue, 1, 3)
		_tableLayoutPanel.Controls.Add (_saveButton, 0, 4)
		_tableLayoutPanel.Controls.Add (ListBox1, 0, 5)
		_tableLayoutPanel.Dock = DockStyle.Fill
		_tableLayoutPanel.Location = New Point(0, 0)
		_tableLayoutPanel.Name = "_tableLayoutPanel"
		_tableLayoutPanel.RowCount = 6
		_tableLayoutPanel.RowStyles.Add (New RowStyle)
		_tableLayoutPanel.RowStyles.Add (New RowStyle)
		_tableLayoutPanel.RowStyles.Add (New RowStyle)
		_tableLayoutPanel.RowStyles.Add (New RowStyle)
		_tableLayoutPanel.RowStyles.Add (New RowStyle)
		_tableLayoutPanel.RowStyles.Add (New RowStyle(SizeType.Percent, 100.0!))
		_tableLayoutPanel.Size = New Size (612, 311)
		_tableLayoutPanel.TabIndex = 0
		' 
		' _titleLabel
		' 
		_titleLabel.AutoSize = True
		_titleLabel.Location = New Point(3, 0)
		_titleLabel.Size = New Size (51, 17)
		_titleLabel.TabIndex = 0
		_titleLabel.Text = "Title"
		' 
		' _titleValue
		' 
		_tableLayoutPanel.SetColumnSpan (_titleValue, 3)
		_titleValue.Location = New Point (60, 3)
		_titleValue.Size = New Size (100, 22)
		_titleValue.TabIndex = 1
		' 
		' _nameLabel
		' 
		_nameLabel.AutoSize = True
		_nameLabel.Location = New Point (3, 28)
		_nameLabel.Size = New Size (51, 17)
		_nameLabel.TabIndex = 2
		_nameLabel.Text = "Name"
		'
		'_nameValue
		'
		_nameValue.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
					Or AnchorStyles.Right), AnchorStyles)
		_tableLayoutPanel.SetColumnSpan(_nameValue, 3)
		_nameValue.Location = New Point(60, 31)
		_nameValue.Size = New Size(549, 22)
		_nameValue.TabIndex = 3
		' 
		' _municipalityLabel
		' 
		_municipalityLabel.AutoSize = True
		_municipalityLabel.Location = New Point(3, 56)
		_municipalityLabel.Size = New Size(51, 17)
		_municipalityLabel.TabIndex = 4
		_municipalityLabel.Text = "Municipality"
		' 
		' _municipalityValue
		' 
		_municipalityValue.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
					Or AnchorStyles.Right), AnchorStyles)
		_municipalityValue.Location = New Point (60, 59)
		_municipalityValue.Size = New Size (386, 22)
		_municipalityValue.TabIndex = 5
		' 
		' _zipCodeLabel
		' 
		_zipCodeLabel.AutoSize = True
		_zipCodeLabel.Location = New Point (452, 56)
		_zipCodeLabel.Size = New Size (51, 17)
		_zipCodeLabel.TabIndex = 6
		_zipCodeLabel.Text = "ZipCode"
		' 
		' _zipCodeValue
		' 
		_zipCodeValue.Location = New Point (509, 59)
		_zipCodeValue.Size = New Size (100, 22)
		_zipCodeValue.TabIndex = 7
		' 
		' _countryLabel
		' 
		_countryLabel.AutoSize = True
		_countryLabel.Location = New Point (3, 84)
		_countryLabel.Size = New Size (51, 17)
		_countryLabel.TabIndex = 8
		_countryLabel.Text = "Country"
		' 
		' _countryValue
		' 
		_tableLayoutPanel.SetColumnSpan (_countryValue, 3)
		_countryValue.Location = New Point (60, 87)
		_countryValue.Size = New Size (100, 22)
		_countryValue.TabIndex = 9
		' 
		' _saveButton
		' 
		_saveButton.Anchor = AnchorStyles.Top
		_tableLayoutPanel.SetColumnSpan (_saveButton, 4)
		_saveButton.Location = New Point (268, 115)
		_saveButton.Size = New Size (75, 23)
		_saveButton.TabIndex = 10
		_saveButton.Text = "Save"
		_saveButton.UseVisualStyleBackColor = True
		' 
		' ListBox1
		' 
		_tableLayoutPanel.SetColumnSpan(ListBox1, 4)
		ListBox1.Dock = DockStyle.Fill
		ListBox1.FormattingEnabled = True
		ListBox1.ItemHeight = 16
		ListBox1.Location = New Point(3, 144)
		ListBox1.Name = "ListBox1"
		ListBox1.Size = New Size(606, 164)
		ListBox1.TabIndex = 11
		' 
		' MainForm
		' 
		AutoScaleDimensions = New SizeF (8.0!, 16.0!)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size (612, 311)
		Location = new Point (125, 100)
		StartPosition = FormStartPosition.Manual
		Text = "bug #355408"
		Controls.Add (_tableLayoutPanel)
	End Sub

	Friend WithEvents _tableLayoutPanel As TableLayoutPanel
	Friend WithEvents _titleLabel As Label
	Friend WithEvents _titleValue As TextBox
	Friend WithEvents _nameLabel As Label
	Friend WithEvents _nameValue As TextBox
	Friend WithEvents _municipalityLabel As Label
	Friend WithEvents _municipalityValue As TextBox
	Friend WithEvents _zipCodeLabel As Label
	Friend WithEvents _zipCodeValue As TextBox
	Friend WithEvents _countryLabel As Label
	Friend WithEvents _countryValue As TextBox
	Friend WithEvents _saveButton As Button
	Friend WithEvents ListBox1 As ListBox

	Private Sub MainForm_Load (ByVal sender As Object, Byval e As EventArgs) Handles MyBase.Load
		Dim instructionsForm As New InstructionsForm ()
		instructionsForm.Show ()
	End Sub

End Class

Public Class InstructionsForm
	Inherits Form
	Public Sub New()
		' 
		' _tabControl
		' 
		_tabControl = new TabControl ()
		_tabControl.Dock = DockStyle.Fill
		Controls.Add (_tabControl)
		' 
		' _bugDescriptionText1
		' 
		_bugDescriptionText1 = new TextBox ()
		_bugDescriptionText1.Dock = DockStyle.Fill
		_bugDescriptionText1.Multiline = true
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture, _
			"Steps to execute:{0}{0}" & _
			"1. The textboxes for Title, Name, Municipality, ZipCode and " & _
			"Countrylabels are displayed.", _
			Environment.NewLine)
		' 
		' _tabPage1
		' 
		_tabPage1 = new TabPage ()
		_tabPage1.Text = "#1"
		_tabPage1.Controls.Add (_bugDescriptionText1)
		_tabControl.Controls.Add (_tabPage1)
		' 
		' InstructionsForm
		' 
		ClientSize = new Size (300, 120)
		Location = new Point (790, 100)
		StartPosition = FormStartPosition.Manual
		Text = "Instructions - bug #355408"
	End Sub

	Private _bugDescriptionText1 As TextBox
	Private _tabControl As TabControl
	Private _tabPage1 As TabPage
End Class
