using System;
using System.Drawing;
using System.Drawing.Imaging;

public class Test
{
	public static void Main ()
	{
		Bitmap bmp = new Bitmap (400, 400);
		Graphics dc = Graphics.FromImage (bmp);
		Rectangle rect = new Rectangle (200, 600, 249, 250);
		dc.FillPie (Brushes.Green, rect, 380, -20);
		bmp.Save ("fillpie.png", ImageFormat.Png);
	}
}
