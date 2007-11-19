using System;
using System.Drawing;

class Program
{
	static int Main ()
	{
		Image i = Image.FromFile ("accessories-character-map.png");
		if (ImageAnimator.CanAnimate (i))
			return 1;
		return 0;
	}
}
