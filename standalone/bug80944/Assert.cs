using System;
using System.Globalization;

public class Assert
{
	public static void AreEqual (string a, string b, string comment)
	{
		if (a != b) {
			throw new AssertException (string.Format (CultureInfo.InvariantCulture,
				"Expected {0} but was {1}: {2}", a, b, comment));
		}
	}

	public static void AreEqual (int a, int b, string comment)
	{
		if (a != b) {
			throw new AssertException (string.Format (CultureInfo.InvariantCulture,
				"Expected {0} but was {1}: {2}", a, b, comment));
		}
	}

	public static void IsTrue (bool value, string comment)
	{
		if (!value) {
			throw new AssertException (string.Format (CultureInfo.InvariantCulture,
				"Value is not true: {0}", comment));
		}
	}

	public static void IsFalse (bool value, string comment)
	{
		if (value) {
			throw new AssertException (string.Format (CultureInfo.InvariantCulture,
				"Value is not false: {0}", comment));
		}
	}

	public static void IsNull (object x, string comment)
	{
		if (x != null) {
			throw new AssertException ("Value is not null: " + comment);
		}
	}

	public static void IsNotNull (object x, string comment)
	{
		if (x == null) {
			throw new AssertException ("Value is null: " + comment);
		}
	}
}

public class AssertException : Exception
{
	public AssertException (string message)
		: base (message)
	{
	}
}
