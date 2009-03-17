using System;
using System.Threading;
using System.Xml;

class Program
{
	static ManualResetEvent ev;

	static void Main ()
	{
		Thread [] threadList = new Thread [10];

		ev = new ManualResetEvent (false);

		for (int i = 0; i < threadList.Length; i++) {
			Thread thread = new Thread (new ThreadStart (SpawnLoad));
			threadList [i] = thread;
			thread.Start ();
		}

		ev.Set ();

		foreach (Thread t in threadList)
			t.Join ();
	}

	static void SpawnLoad ()
	{
		ev.WaitOne ();

		XmlDocument doc = new XmlDocument ();
		doc.Load ("TestFile.xml");
		XmlNode root = doc.DocumentElement;

		for (int j = 0; j < 200; j++) {
			for (int idNum = 0; idNum < 10; idNum++) {
				XmlNode item = null;
				item = root.SelectSingleNode ("./Item[@id=\"" + idNum + "\"]");
				Assert.IsNotNull (item, "Could not find a Item!");
			}
		}
	}
}
