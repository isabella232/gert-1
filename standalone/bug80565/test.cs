using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Resources;

public class Test
{
	static int Main ()
	{
		string resXFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"Resources.resources");
		ResourceReader rr = new ResourceReader (resXFile);
		int i = 0;
		foreach (DictionaryEntry de in rr) {
			Bitmap bmp = null;
			switch (i) {
			case 0:
				if ("VIA vzw" != (string) de.Key)
					return 1;
				bmp = (Bitmap) de.Value;
#if NET_2_0
				if (bmp.Height != 32)
					return 2;
				if (bmp.Width != 32)
					return 3;
#else
				if (bmp.Height != 96)
					return 2;
				if (bmp.Width != 96)
					return 3;
#endif
				break;
			case 1:
				if ("dbs" != (string) de.Key)
					return 4;
				bmp = (Bitmap) de.Value;
				if (bmp.Height != 16)
					return 5;
				if (bmp.Width != 16)
					return 6;
				break;
			default:
				return 1;
			}
			i++;
		}
		if (i != 2)
			return 2;
		return 0;
	}
}
