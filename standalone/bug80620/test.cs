using System.Windows.Forms;

class Test
{
	static int Main ()
	{
		TextBox t = new TextBox ();
		t.CreateControl ();
		if (t.ClientRectangle != new TextBox ().ClientRectangle)
			return 1;
		return 0;
	}
}
