using System;
using System.Globalization;

class Assert
{
	public static void AreEqual (string x, string y, string msg)
	{
		if (x == null && y == null)
			return;
		if ((x == null || y == null) || !x.Equals (y))
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x, y, msg));
	}

	public static void AreEqual (object x, object y, string msg)
	{
		if (x == null && y == null)
			return;
		if ((x == null || y == null) || !x.Equals (y))
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x, y, msg));
	}

	public static void Fail (string msg)
	{
		throw new Exception (msg);
	}

	public static void IsFalse (bool value, string msg)
	{
		if (value)
			throw new Exception (msg);
	}

	public static void IsTrue (bool value, string msg)
	{
		if (!value)
			throw new Exception (msg);
	}

	public static void IsNotNull (object value, string msg)
	{
		if (value == null)
			throw new Exception (msg);
	}

	public static void IsNull (object value, string msg)
	{
		if (value != null)
			throw new Exception (msg);
	}
}
