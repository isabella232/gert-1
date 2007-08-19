using System;
using System.Globalization;
using System.Windows.Forms;

class Program
{
	static void Main ()
	{
		string expected = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. Right-clicking the title bar displays a " +
			"context menu where these options are either disabled " +
			"or not visible at all:{0}{0}" +
			"   * Minimize{0}" +
			"   * Maximize{0}" +
			"   * (Re)Size",
			Environment.NewLine);
		MessageBox.Show (expected, "bug #82483", MessageBoxButtons.OK);
	}
}
