using System;
using System.Globalization;
using System.Windows.Forms;

class Program
{
	static void Main ()
	{
		string expected = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. An \"Information\" icon is displayed.{0}{0}" +
			"2. There's some vertical spacing between the text " +
			"and the OK button.",
			Environment.NewLine);
		MessageBox.Show (expected, "bug #82468", MessageBoxButtons.OK,
			MessageBoxIcon.Information);
	}
}

