using System;
using System.Security;
using System.Security.Permissions;

public class Program
{
	[PrincipalPermission (SecurityAction.Demand, Name = "root")]
	public void Execute ()
	{
		Console.WriteLine ("Welcome {0}", Environment.UserName);
	}

	static void Main ()
	{
		try {
			new Program ().Execute ();
		} catch (SecurityException) {
		}
	}
}
