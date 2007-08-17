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
			"context menu with these options:{0}{0}" +
			"   * Move{0}" +
			"   * Close{0}{0}" +
			"2. The message box is displayed in the task bar.",
			Environment.NewLine);
		MessageBox.Show (expected, "bug #82457", MessageBoxButtons.OK);
	}
}

