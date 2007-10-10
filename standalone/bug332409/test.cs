using System.Windows.Forms;

class Program
{
	static void Main ()
	{
		Form a = new Form ();
		a.Show ();
		SendKeys.SendWait ("a");
	}
}
