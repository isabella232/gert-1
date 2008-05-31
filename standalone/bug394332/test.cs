using System;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox1
		// 
		_textBox1 = new TextBox ();
		_textBox1.TabIndex = 0;
		_textBox1.Leave += new EventHandler (TextBox1_Leave);
		Controls.Add (_textBox1);
		// 
		// _textBox2
		// 
		_textBox2 = new TextBox ();
		_textBox2.TabIndex = 1;
		Controls.Add (_textBox2);
		// 
		// MainForm
		// 
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_timer = new Timer ();
		_timer.Interval = 200;
		_timer.Enabled = true;
		_timer.Tick += new EventHandler (Timer_Tick);
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		_textBox2.Focus ();
	}

	void TextBox1_Leave (object sender, EventArgs e)
	{
		Assert.IsFalse (_textBox1.Focused, "#A1");
		Assert.IsTrue (_textBox2.Focused, "#A2");
		Controls.Remove (_textBox2);
		Assert.IsTrue (_textBox1.Focused, "#B1");
		Assert.IsFalse (_textBox2.Focused, "#B2");

		Close ();
	}

	private TextBox _textBox1;
	private TextBox _textBox2;
	private Timer _timer;
}
