using System.Drawing;
using System.Windows.Forms;

class Program
{
	static int Main ()
	{
		Bitmap b = new Bitmap (1, 1);
		b.SetPixel (0, 0, Color.FromArgb (0, 128, 0));

		ImageList il = new ImageList ();
		il.Images.Add (b);

		if (Color.FromArgb (0, 128, 0) != (il.Images [0] as Bitmap).GetPixel (0, 0))
			return 1;
		return 0;
	}
}
