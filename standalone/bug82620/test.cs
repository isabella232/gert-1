using System;
using System.Data;

public class Test
{
	public static void Main ()
	{
		DataTable table = new DataTable ("Appointments");
		DataRow row;
		DataTable raw = new DataTable ();
		row = table.NewRow ();
		row ["provider"] += " (" + raw.Rows [0] ["ProvAbbr"].ToString () + ")";
	}
}
