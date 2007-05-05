using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;

public class bug76757Test
{
	static int Main ()
	{
		AppDomain domain = null;
		
		domain = AppDomain.CreateDomain ("bug 76757 domain");
		try {
			ObjectHandle obj = domain.CreateInstanceFrom (Assembly.GetExecutingAssembly ().CodeBase,
				typeof (Bug76757Handler1).FullName,
				false,
				BindingFlags.Public | BindingFlags.Instance,
				null,
				new object [0],
				CultureInfo.InvariantCulture,
				null,
				AppDomain.CurrentDomain.Evidence);
			Bug76757Handler1 handler = (Bug76757Handler1) obj.Unwrap ();
			handler.Run ();
			return 1;
		} catch (FileNotFoundException ex) {
			if (ex.FileName == null) {
				Console.WriteLine ("FileNotFoundException.FileName is NULL.");
				return 1;
			}
			if (ex.FileName == "library, Version=1.2.3.4, Culture=neutral") {
				return 0;
			}
			Console.WriteLine ("FileNotFoundException.FileName does not match.");
			Console.WriteLine ("expected: library, Version=1.2.3.4, Culture=neutral");
			Console.WriteLine ("but was: " + ex.FileName);
			return 1;
		} finally {
			AppDomain.Unload (domain);
		}
	}

	[Serializable ()]
	private class Bug76757Handler1
	{
		public Bug76757Handler1 ()
		{
		}

		public void Run ()
		{
			new Library.Person ();
		}
	}
}
