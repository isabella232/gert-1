using System.Reflection;
using System.Windows.Forms;

class Program
{
	static void Main ()
	{
		Assert.AreEqual ("0.0.0.0", Application.ProductVersion, "#1");
	}
}
