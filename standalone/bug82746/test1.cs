using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyFileVersion ("4.3.2.1")]
[assembly: AssemblyInformationalVersion ("1.2.3.4")]
[assembly: AssemblyVersion ("5.6.7.8")]

class Program
{
	static void Main ()
	{
		Assert.AreEqual ("1.2.3.4", Application.ProductVersion, "#1");
	}
}
