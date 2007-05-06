using System.Windows.Forms;

class Program
{
	static int Main ()
	{
		TextBox textBox = new TextBox ();
		textBox.CreateControl ();
		if (textBox.ClientRectangle.Height != 16)
			return 1;
		textBox.BorderStyle = BorderStyle.FixedSingle;
		if (textBox.ClientRectangle.Height != 20)
			return 2;
		return 0;
	}
}
