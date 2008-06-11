using System.Windows.Forms;

class Program
{
	static void Main ()
	{
		WebBrowser wb = new WebBrowser ();
		wb.Navigate ("http://www.mono-project.com");
		wb.Dispose ();
	}
}
