using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Resources;

class Program
{
	static void Main ()
	{
		int resCount = 0;
		string resFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"MainForm.resources");

		ResourceReader rr = new ResourceReader (resFile);
		foreach (DictionaryEntry de in rr) {
			Assert.AreEqual ("BtnOk.ImageAlign", de.Key, "#1");

			ContentAlignment align = (ContentAlignment) de.Value;
			Assert.AreEqual (ContentAlignment.MiddleLeft, align, "#2");
			resCount++;
		}

		Assert.AreEqual (1, resCount, "#3");
	}
}
