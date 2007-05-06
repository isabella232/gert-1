using System;
using System.IO;
using System.Text;
using System.Reflection;

public class RunInOtherDomain : MarshalByRefObject
{
	static public void Run (string assPath)
	{
		AppDomain _appDomain = AppDomain.CreateDomain ("PreProcessor.PreProcessor");
		try {
			// see http://blogs.msdn.com/suzcook/archive/2003/06/12/57169.aspx
			object obj = _appDomain.CreateInstanceFrom (Assembly.GetExecutingAssembly ().Location,
				"RunInOtherDomain").Unwrap ();

			if (obj == null) {
				throw new TypeLoadException ("no object loaded");
			}

			RunInOtherDomain runInOtherDomain = obj as RunInOtherDomain;
			if (runInOtherDomain == null) {
				StringBuilder sb = new StringBuilder ();
				throw new TypeLoadException ("incorrect type.  Object is " + obj.ToString () + " (of type " + obj.GetType () + ")\n"
					+ sb.ToString ());
			}

			runInOtherDomain.RunHelper (assPath);

		} catch (Exception e) {
			StringBuilder msg = new StringBuilder ();
			msg.Append ("Error loading PreProcessor plugin PreProcessor from " + assPath + ": ");
			msg.Append (e.Message);
			if (e.InnerException != null) {
				msg.Append ("\n");
				msg.Append (e.InnerException.Message);
			}
			throw new TypeLoadException (msg.ToString ());
		} finally {
			AppDomain.Unload (_appDomain);
		}
	}

	public void RunHelper (string assPath)
	{
		// assPath = Assembly.GetExecutingAssembly ().Location;
		object obj = Activator.CreateInstanceFrom (assPath, "PreProcessor").Unwrap ();

		if (obj == null) {
			throw new TypeLoadException ("Error loading PreProcessor plugin PreProcessor from " + assPath
				+ ": no object loaded");
		}

		MethodInfo meth = obj.GetType ().GetMethod ("CreateAdditionalFiles");

		meth.Invoke (obj, new object [] { new string [] { "foo" } });
	}

	public void CreateAdditionalFiles (string [] inputFiles)
	{
		Console.WriteLine ("PreProcessor.PreProcessor 1");
	}

	[STAThread]
	static void Main (string [] args)
	{
		for (int i = 0; i < 10; i++) {
			string assPath = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "PreProcess.dll");
			RunInOtherDomain.Run (assPath);
		}
	}
}
