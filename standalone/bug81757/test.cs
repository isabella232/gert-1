using System;
using System.Drawing;
using System.Resources;

class test
{
	static int Main ()
	{
		ResourceManager resources = new System.Resources.ResourceManager (typeof (test));
		Size size = (Size) resources.GetObject ("imageList.ImageSize");
		if (size != new Size (16, 16))
			return 1;
		return 0;
	}
}
