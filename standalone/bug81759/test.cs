using System;
using System.Drawing;
using System.Resources;

class test
{
	static int Main ()
	{
		ResourceManager resources = new ResourceManager (typeof (test));
		Size size = (Size) resources.GetObject ("imageList.ImageSize");
		if (size != new Size (16, 16))
			return 2;
		return 0;
	}
}
