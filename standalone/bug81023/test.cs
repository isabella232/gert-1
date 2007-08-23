using System;
using System.Data;
using System.Data.Common;

public class Test
{
	static int Main ()
	{
		DataTable dt = DbProviderFactories.GetFactoryClasses ();
		if (dt.DataSet != null)
			return 1;
		if (dt.TableName != "DbProviderFactories") {
			Console.WriteLine ("#2: " + dt.TableName);
			return 2;
		}
		if (dt.Columns.Count != 4) {
			Console.WriteLine ("#3: " + dt.Columns.Count);
			return 3;
		}
		if (dt.Rows.Count < 2) {
			Console.WriteLine ("#4: " + dt.Rows.Count);
			return 4;
		}

		/*
		foreach (DataRow row in dt.Rows) {
			foreach (DataColumn column in dt.Columns) {
				Console.WriteLine (column.ColumnName + ": " + row [column]);
			}
			Console.WriteLine ("-");
		}*/

		return 0;
	}
}
