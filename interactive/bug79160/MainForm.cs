using System;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _label
		// 
		_label = new Label ();
		_label.Text = "Form should not have an icon (in upper left corner).";
		_label.AutoSize = true;
		Controls.Add (_label);
		// 
		// MainForm
		// 
		FormBorderStyle = FormBorderStyle.FixedDialog;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79160";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private Label _label;
}
