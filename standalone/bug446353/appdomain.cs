using System;
using System.IO;
using System.Reflection;
using System.Text;

class Program
{
	static void Main ()
	{
		string resultFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"result");

		Assembly a = Assembly.GetEntryAssembly ();

		using (StreamWriter sw = new StreamWriter (resultFile, true, Encoding.UTF8)) {
			sw.WriteLine (a.CodeBase);
			sw.Write (a.Location);
		}
	}
}
