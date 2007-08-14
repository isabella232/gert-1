using System;
using System.Drawing;
using System.Globalization;

class Program
{
	[STAThread]
	static int Main ()
	{
		using (Image image = Image.FromFile ("peace.jpg")) {
			return (image.HorizontalResolution > 0) ? 0 : 1;
		}
	}
}
