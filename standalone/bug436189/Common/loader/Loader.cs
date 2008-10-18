using System;
using System.IO;
using System.Reflection;

public delegate void LoaderFinished ();

public class Loader
{
	public void Run (LoaderFinished finished)
	{
		AppDomain current = AppDomain.CurrentDomain;
		string baseDir = Path.GetDirectoryName (Assembly.GetCallingAssembly().Location);
		string commonDir = Path.Combine (baseDir, "Common");

		string [] files = Directory.GetFiles (Path.Combine (commonDir, "test-object"), "*.dll");

		foreach (string file in files) {
			string path = Path.GetDirectoryName (file);
			current.AppendPrivatePath (path);
		}
		
		if (finished != null)
			finished ();
	}
}
