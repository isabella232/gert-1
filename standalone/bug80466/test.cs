using System.Windows.Forms;

class Program
{
	static int Main ()
	{
		ListBox l = new ListBox ();
		for (int Height = 0; Height < 100; Height++) {
			l.Height = Height;
			if (l.Height != Height)
				return 1;
		}
		return 0;
	}
}
