using System;
using System.Windows.Forms;

public class Program
{
	[STAThread]
	static void Main ()
	{
		TextBox textBox = new TextBox ();
		textBox.CreateControl ();
		for (int i = 1; i <= 1000; i++)
			textBox.AppendText (string.Format ("This is line {0}", i));

		RichTextBox rtb = new RichTextBox ();
		rtb.CreateControl ();
		for (int i = 1; i <= 1000; i++)
			rtb.AppendText (string.Format ("This is line {0}", i));
	}
}
