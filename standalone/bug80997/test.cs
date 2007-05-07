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

		DataRow r = dt.Rows.Find ("MySql.Data.MySqlClient");
		if (r == null)
			return 4;

		if (r ["Name"].ToString () != "MySQL DataProvider")
			return 5;

		if (r ["Description"].ToString () != "MySQL Data Provider")
			return 6;

		if (r ["InvariantName"].ToString () != "MySql.Data.MySqlClient")
			return 7;

		if (r ["AssemblyQualifiedName"].ToString () != "MySql.Data.MySqlClient.MySqlClientFactory,MySql.Data, Version=5.0.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d")
			return 8;

		return 0;
	}
}
