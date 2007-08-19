using System;
using System.Globalization;
using System.Windows.Forms;

class Program
{
	static void Main ()
	{
		string expected = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The message box is displayed in the task bar.",
			Environment.NewLine);
		MessageBox.Show (expected, "bug #82457", MessageBoxButtons.OK);
	}
}
