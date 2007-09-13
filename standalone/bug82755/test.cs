using System;
using System.Data;

class Program
{
	static int Main ()
	{
		DataTable dt = new DataTable ();
		dt.Columns.Add (new DataColumn ("expr"));
		dt.Columns ["expr"].Caption += "" + dt.Columns + "" + dt.Columns;
		if (dt.Columns ["expr"].Caption != "exprSystem.Data.DataColumnCollectionSystem.Data.DataColumnCollection")
			return 1;
		return 0;
	}
}
