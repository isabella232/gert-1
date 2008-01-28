using System;
using System.ComponentModel;
using System.Configuration;

class Program
{
	static int Main ()
	{
		MySection mySection = (MySection) ConfigurationManager.GetSection ("my-section");
		if (mySection.MyProperty != typeof (string))
			return 1;
		return 0;
	}

	internal class MySection : ConfigurationSection
	{
		internal MySection ()
		{
		}

		[TypeConverter (typeof (TypeNameConverter))]
		[ConfigurationProperty ("my-property")]
		public Type MyProperty {
			get {
				return (Type) this ["my-property"];
			}
		}
	}
}
