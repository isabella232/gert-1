using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.IO;

public class MainForm
{
	static void Main ()
	{
		ResourceManager resMgr = new ResourceManager (typeof (MainForm));
		
		ImageList imgList = new ImageList ();
		imgList.ColorDepth = ColorDepth.Depth16Bit;
		imgList.ImageSize = new Size (16, 16);
		imgList.ImageStream = ((ImageListStreamer) (resMgr.GetObject ("Locs.ImageStream")));
		imgList.TransparentColor = Color.Transparent;
	}
}
