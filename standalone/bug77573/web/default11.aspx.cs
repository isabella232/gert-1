using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public class _Default : System.Web.UI.Page
{
	public DataGrid DataGrid1;

	protected void Page_Load (object sender, EventArgs e)
	{
		DataGrid1.DataSource = GetDataSource ();
		DataGrid1.DataBind ();
	}

	DataTable GetDataSource ()
	{
		DataTable table = new DataTable ();
		DataColumn column;
		DataRow row;

		column = new DataColumn ();
		column.DataType = System.Type.GetType ("System.Int32");
		column.ColumnName = "id";
		column.ReadOnly = true;
		column.Unique = true;
		table.Columns.Add (column);

		column = new DataColumn ();
		column.DataType = System.Type.GetType ("System.String");
		column.ColumnName = "ParentItem";
		column.AutoIncrement = false;
		column.Caption = "ParentItem";
		column.ReadOnly = false;
		column.Unique = false;
		table.Columns.Add (column);

		DataColumn [] PrimaryKeyColumns = new DataColumn [1];
		PrimaryKeyColumns [0] = table.Columns ["id"];
		table.PrimaryKey = PrimaryKeyColumns;

		for (int i = 0; i <= 2; i++) {
			row = table.NewRow ();
			row ["id"] = i;
			row ["ParentItem"] = "ParentItem " + i;
			table.Rows.Add (row);
		}
		return table;
	}
}
