using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form {
	public MainForm ()
	{
		// 
		// _textBox;
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Top;
		_textBox.Height = 100;
		_textBox.Multiline = true;
		_textBox.KeyDown += new KeyEventHandler (TextBox_KeyDown);
		_textBox.KeyPress += new KeyPressEventHandler (TextBox_KeyPress);
		Controls.Add (_textBox);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 150;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81692";
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

	void TextBox_KeyDown (Object sender, KeyEventArgs e)
	{
		_eventsText.AppendText ("TextBox => KeyDown (" + e.KeyCode + ")"
			+ Environment.NewLine);
		if (e.KeyCode == Keys.G)
			e.SuppressKeyPress = true;
	}

	void TextBox_KeyPress (Object sender, KeyPressEventArgs e)
	{
		_eventsText.AppendText ("TextBox => KeyPress ("  + e.KeyChar + ")"
			+ Environment.NewLine);
	}

	private TextBox _textBox;
	private TextBox _eventsText;
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
			"Steps to execute:{0}{0}" +
			"1. Click inside the top TextBox.{0}{0}" +
			"2. Press the following keys:{0}{0}" +
			"   A{0}" +
			"   D{0}" +
			"   G{0}" +
			"   H{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The TextBox contains the following text:{0}{0}" +
			"   adh{0}{0}" +
			"2. The following events have fired:{0}{0}" +
			"   * TextBox => KeyDown (A){0}" +
			"   * TextBox => KeyPress (a){0}" +
			"   * TextBox => KeyDown (D){0}" +
			"   * TextBox => KeyPress (d){0}" +
			"   * TextBox => KeyDown (G){0}" +
			"   * TextBox => KeyDown (H){0}" +
			"   * TextBox => KeyPress (h)",
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
		ClientSize = new Size (360, 390);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81692";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
