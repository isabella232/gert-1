using System;
using System.Collections;

class Program
{
	static void Main ()
	{
		IDictionary vars = Environment.GetEnvironmentVariables ();
		/*
		foreach (DictionaryEntry de in vars)
			Console.WriteLine (de.Key);
		 * */
		Assert.IsNotNull (vars ["Mono_bug333740a"], "#A1");
		Assert.AreEqual ("oK", vars ["Mono_bug333740a"], "#A2");
		Assert.IsNull (vars ["mono_bug333740a"], "#A3");
		Assert.IsNull (vars ["MONO_BUG333740A"], "#A4");

		Assert.IsNotNull (vars ["MONO_BUG333740B"], "#B1");
		Assert.AreEqual ("FinE", vars ["MONO_BUG333740B"], "#B2");
		Assert.IsNull (vars ["Mono_BUG333740b"], "#B3");
		Assert.IsNull (vars ["mono_bug333740b"], "#B4");

		Assert.IsNotNull (vars ["mono_bug333740c"], "#C1");
		Assert.AreEqual ("good", vars ["mono_bug333740c"], "#C2");
		Assert.IsNull (vars ["Mono_Bug333740c"], "#C3");
		Assert.IsNull (vars ["MONO_BUG333740C"], "#C4");
	}
}
