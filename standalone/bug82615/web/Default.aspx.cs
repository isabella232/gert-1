using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class _Default : Page
{
	protected override void OnInit (EventArgs e)
	{
		base.OnInit (e);

		GridView1.RowCreated += new GridViewRowEventHandler (GridView1_RowCreated);
	}

	void GridView1_RowCreated (object sender, GridViewRowEventArgs e)
	{
		int visibleColumns = 0;
		foreach (DataControlField column in GridView1.Columns)
			if (column.Visible)
				visibleColumns++;

		label.Text = string.Format (CultureInfo.InvariantCulture,
			"VISIBLE COLUMNS: {0} | TOTAL COLUMNS: {1}",
			visibleColumns, e.Row.Cells.Count);
	}

	protected void Page_Load (object sender, EventArgs e)
	{
		DataTable tbl = new DataTable ();
		tbl.Columns.Add ("Field1", typeof (string));
		tbl.Columns.Add ("Field2", typeof (string));
		tbl.Columns.Add ("Field3", typeof (string));

		for (int i = 0; i < 4; i++) {	
			DataRow row = tbl.NewRow ();
			for (int j = 0; j < 3; j++)
				row [j] = j.ToString ();
			tbl.Rows.Add (row);
		}

		GridView1.DataSource = tbl;
		GridView1.DataBind ();
	}
}
