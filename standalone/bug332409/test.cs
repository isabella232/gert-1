using System;
using System.Windows.Forms;

class Program
{
	static int Main ()
	{
		Form form = new Form ();
		form.KeyDown += new KeyEventHandler (Form_KeyDown);
		form.Show ();
		SendKeys.SendWait ("a");

		if (_keyDown == null)
			return 1;
		if (_keyDown != "A")
			return 2;
		return 0;
	}

	static void Form_KeyDown (object sender, KeyEventArgs e)
	{
		_keyDown = e.KeyData.ToString ();
	}

	private static string _keyDown;
}
