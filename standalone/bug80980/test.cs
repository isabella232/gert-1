using System;
using System.Drawing;
using System.IO;

public class Program
{
	static int Main ()
	{
		string imageFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"bad.jpg");
		try {
			Image.FromFile (imageFile);
			return 1;
		} catch (OutOfMemoryException) {
			return 0;
		}
	}
}
