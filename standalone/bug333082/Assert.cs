using System;
using System.Data;
using System.Globalization;

class Assert
{
	public static void AreEqual (string x, string y, string msg)
	{
		if (x != y)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x, y, msg));
	}

	public static void AreEqual (IsolationLevel x, IsolationLevel y, string msg)
	{
		if (x != y)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x, y, msg));
	}

	public static void AreEqual (object x, object y, string msg)
	{
		if (x != y)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x, y, msg));
	}

	public static void Fail (string msg)
	{
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
