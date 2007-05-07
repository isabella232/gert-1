using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Program
{
	static int Main (string [] args)
	{
		Image img = Image.FromFile (Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"a.png"));
		string smg = ImageToString (img);
		if (smg == null)
			return 1;
		return 0;
	}

	static string ImageToString (Image img)
	{
		MemoryStream stream = new MemoryStream ();
		img.Save (stream, ImageFormat.Png);
		stream.Position = 0;
		int LengthOfBuffer = (int) stream.Length;
		byte [] buff = new byte [LengthOfBuffer];
		stream.Read (buff, 0, LengthOfBuffer);
		return Convert.ToBase64String (buff);
	}
}
