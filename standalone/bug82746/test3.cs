using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyFileVersion ("4.3.2.1")]
[assembly: AssemblyVersion ("5.6.7.8")]

class Program
{
	static int Main ()
	{
		if (Application.ProductVersion != "4.3.2.1")
			return 1;
		return 0;
	}
}
