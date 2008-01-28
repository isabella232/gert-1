using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

static class Program
{
	static int Main ()
	{
		MySection mySection = (MySection) ConfigurationManager.GetSection ("my-section");
		if (mySection.MyProperty != "correct")
			return 1;
		return 0;
	}
}

internal sealed class MyPropertyConverter : TypeConverter
{
	internal MyPropertyConverter ()
	{
	}

	public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		string temp = value as string;
		if (null == temp)
			throw new Exception ();

		if (string.Compare ("hello world", temp, StringComparison.Ordinal) == 0)
			return "correct";

		throw new Exception ();
	}
}

internal sealed class MySection : ConfigurationSection
{
	internal MySection ()
	{
	}

	[ConfigurationProperty ("my-property")]
	[TypeConverter (typeof (MyPropertyConverter))]
	public string MyProperty {
		get {
			return (string) this ["my-property"];
		}
	}
}
