using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Assembly a = Assembly.GetAssembly (typeof (Business));
		try {
			a.GetTypes ();
			Assert.Fail ("#1");
		} catch (ReflectionTypeLoadException ex) {
			Assert.AreEqual (typeof (ReflectionTypeLoadException), ex.GetType (), "#2");
			Assert.IsNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.Message, "#4");
		}
	}
}
