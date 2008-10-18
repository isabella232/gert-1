using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main (string [] args)
	{
		string baseDir = Path.GetDirectoryName (Assembly.GetCallingAssembly().Location);
		AppDomain current = AppDomain.CurrentDomain;
		current.AppendPrivatePath (baseDir);
	
		Loader loader = new Loader ();
		loader.Run (new LoaderFinished (CreateObject));
	}

	static void CreateObject ()
	{
		ShowLogin showLogin = new ShowLogin ();
		showLogin.Do ();
	}
}
