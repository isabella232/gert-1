using System;
using System.Text.RegularExpressions;

class Program
{
	static void Main ()
	{
		Regex re = new Regex ("\\bModul:(.*)");
		Match m = re.Match ("Modul: Stammdaten");
		Assert.IsTrue (m.Success, "#1");
		Assert.AreEqual (2, m.Groups.Count, "#2");
		Assert.AreEqual ("Modul: Stammdaten", m.Groups [0].Value, "#3");
		Assert.AreEqual (" Stammdaten", m.Groups [1].Value, "#4");
	}
}
