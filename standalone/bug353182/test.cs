using System;
using System.Collections.Generic;
using System.IO;

class Program
{
	static void Main ()
	{
		string file = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "test.cs");
		byte[] data = File.ReadAllBytes(file);
		/*
		if (data == null) {
		}*/

		Dictionary<char, byte> _widths = new Dictionary<char, byte> ();
		_widths [(char) 0] = (byte) 0;
	}
}
