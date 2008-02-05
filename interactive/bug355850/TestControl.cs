using System;
using System.Drawing;
using System.Windows.Forms;

public class TestControl : UserControl
{
	public TestControl ()
	{
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.BackColor = Color.Blue;
		_textBox.Dock = DockStyle.Fill;
		_textBox.Multiline = true;
		Controls.Add (_textBox);
		// 
		// TestControl
		// 
		Dock = DockStyle.Fill;
	}

	protected override void OnLoad (EventArgs e)
	{
		_textBox.Focus ();
		base.OnLoad (e);
	}

	private TextBox _textBox;
}
