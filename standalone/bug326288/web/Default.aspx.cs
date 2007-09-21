using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class _Default : Page
{
	protected HtmlForm form1;
	protected DropDownList MonthList;

	protected void Page_Load (object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

		DateTimeFormatInfo dfi = CultureInfo.CurrentCulture.DateTimeFormat;

		for (int i = 1; i < 13; i++) {
			ListItem item = new ListItem (dfi.GetMonthName (i),
				i.ToString (CultureInfo.InvariantCulture));
			item.Attributes.Add ("title", "tooltip of " +
				i.ToString (CultureInfo.InvariantCulture));
			MonthList.Items.Add (item);
		}
	}
}
