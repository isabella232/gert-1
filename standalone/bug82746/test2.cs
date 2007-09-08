using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyVersion ("5.6.7.8")]

class Program
{
	static int Main ()
	{
		if (Application.ProductVersion != "5.6.7.8")
			return 1;
		return 0;
	}
}
