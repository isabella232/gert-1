using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Text;

static class Program
{
	static int Main ()
	{
		MySection mySection = (MySection) ConfigurationManager.GetSection ("my-section");
		int itemCount = 0;
		foreach (MyElement element in mySection.MyCollection) {
			switch (itemCount++) {
			case 0:
				Assert.AreEqual ("first", element.Name, "#A1");
				Assert.AreEqual ("1st", element.Value, "#A2");
				break;
			case 1:
				Assert.AreEqual ("second", element.Name, "#B1");
				Assert.AreEqual ("2nd", element.Value, "#B2");
				break;
			case 2:
				Assert.AreEqual ("third", element.Name, "#C1");
				Assert.AreEqual ("3rd", element.Value, "#C2");
				break;
			}
		}

		if (itemCount != 3)
			return 1;
		return 0;
	}
}

public sealed class MyElement : ConfigurationElement
{
	public MyElement ()
	{
	}

	[ConfigurationProperty ("name")]
	public string Name {
		get {
			return (string) this ["name"];
		}
	}

	[ConfigurationProperty ("value")]
	public string Value {
		get {
			return (string) this ["value"];
		}
	}
}

[ConfigurationCollection (typeof (MyElement))]
public sealed class MyCollection : ConfigurationElementCollection
{
	internal MyCollection ()
	{
	}

	protected override ConfigurationElement CreateNewElement ()
	{
		return new MyElement ();
	}

	protected override object GetElementKey (ConfigurationElement element)
	{
		if (null == element)
			throw new ArgumentNullException ("element");

		return ((MyElement) element).Name;
	}
}

public sealed class MySection : ConfigurationSection
{
	public MySection ()
	{
	}

	[ConfigurationProperty ("my-collection")]
	public MyCollection MyCollection
	{
		get
		{
			return (MyCollection) this ["my-collection"];
		}
	}
}
