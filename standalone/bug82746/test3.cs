using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyFileVersion ("4.3.2.1")]
[assembly: AssemblyVersion ("5.6.7.8")]

class Program
{
	static void Main ()
	{
		Assert.AreEqual ("4.3.2.1", Application.ProductVersion, "#1");
	}
}
