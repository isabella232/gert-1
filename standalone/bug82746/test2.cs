using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyVersion ("5.6.7.8")]

class Program
{
	static void Main ()
	{
		Assert.AreEqual ("5.6.7.8", Application.ProductVersion, "#1");
	}
}
