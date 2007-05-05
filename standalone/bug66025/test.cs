using System;
using System.Reflection;

public class ConsoleStub
{
	public static int Main (string [] args)
	{
		try {
			Console.WriteLine ("A");
		} catch (Exception ex) {
			Console.WriteLine ("B:" + ex.ToString ());
		} finally {
			Console.WriteLine (type.FullName);
		}

		return 1;
	}

	private static readonly Type type = System.Reflection.MethodBase.
		GetCurrentMethod ().DeclaringType;
}
