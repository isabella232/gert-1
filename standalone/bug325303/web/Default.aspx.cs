using System.Web.UI;
using System.Web.UI.HtmlControls;

public class _Default : Page
{
	protected HtmlTable Table1;

	protected override void Render (HtmlTextWriter writer)
	{
		HtmlTableRow row = new HtmlTableRow ();
		HtmlTableCell cell = new HtmlTableCell ();
		cell.InnerHtml = "Test cell is visible";
		row.Cells.Add (cell);
		Table1.Rows.Add (row);
		Table1.Visible = true;
		Table1.RenderControl (writer);
	}
}
