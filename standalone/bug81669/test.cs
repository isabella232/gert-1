using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

class Program
{
	static int Main (string [] args)
	{
		string icoFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"earth.ico");

		Icon ico1 = new Icon (icoFile);
		if (ico1.Size != new Size (32, 32))
			return 1;

#if NET_2_0
		Icon ico2 = new Icon (icoFile, 20, 40);
		if (ico2.Size != new Size (32, 32))
			return 2;

		Icon ico3 = new Icon (icoFile, new Size (20, 40));
		if (ico3.Size != new Size (32, 32))
			return 3;
#endif

		string curFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"text.cur");

		Cursor cursor = new Cursor (curFile);
		if (cursor.Size != new Size (32, 32))
			return 4;

		return 0;
	}
}
