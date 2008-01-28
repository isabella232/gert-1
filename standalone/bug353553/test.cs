using System;
using System.Configuration;

static class Program
{
	static int Main ()
	{
		MySection mySection = (MySection) ConfigurationManager.GetSection ("my-section");
		if (mySection.MyProperty != "hello world")
			return 1;
		return 0;
	}
}

internal sealed class MySection : ConfigurationSection
{
	internal MySection ()
	{
	}

	[ConfigurationProperty ("my-property")]
	public string MyProperty {
		get {
			return (string) this ["my-property"];
		}
	}
}
