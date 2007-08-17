using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

class Program
{
	static int Main ()
	{
		DataList user_list = new DataList ();
		List<string> str = new List<string> ();
		str.Add ("foo");
		user_list.DataSource = str;
		user_list.DataBind ();

		StringWriter sw = new StringWriter ();
		HtmlTextWriter h = new HtmlTextWriter (sw);
		user_list.RenderControl (h);

		string expected = string.Format ("<table cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse;\">{0}"
			+ "\t<tr>{0}"
			+ "\t\t<td></td>{0}"
			+ "\t</tr>{0}"
			+ "</table>", Environment.NewLine);

		if (sw.ToString () != expected) {
			Console.WriteLine (sw.ToString ());
			return 1;
		}

		return 0;
	}
}
