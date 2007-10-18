using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		SqlConnection conn = new SqlConnection (CreateConnectionString ());
		conn.Open ();

		SqlCommand cmd = new SqlCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		try {
			SqlTransaction trans = conn.BeginTransaction ();

			cmd = new SqlCommand (create_table, conn, trans);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (insert_data, conn, trans);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand ("SELECT Name, FirstName FROM [bug325397]", conn, trans);
			SqlDataAdapter adapter = new SqlDataAdapter (cmd);
			DataSet ds = new DataSet ();
			adapter.Fill (ds);

			if (ds.Tables.Count != 1)
				return 1;
			if (ds.Tables [0].Rows.Count != 2)
				return 2;

			trans.Commit ();
			trans.Dispose ();
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			SqlTransaction trans = conn.BeginTransaction ();

			cmd = new SqlCommand (create_table, conn, trans);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (insert_data, conn, trans);
			cmd.ExecuteNonQuery ();

			trans.Dispose ();

			cmd = new SqlCommand (create_table, conn);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		conn.Dispose ();
		return 0;
	}

	static string CreateConnectionString ()
	{
		StringBuilder sb = new StringBuilder ();

		string serverName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (serverName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_HOST");

		string dbName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_DB");
		if (dbName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_DB");

		sb.AppendFormat ("server={0};database={1};", serverName, dbName);

		string userName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (userName != null)
			sb.AppendFormat ("user id={0};", userName);

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd != null)
			sb.AppendFormat ("pwd={0};", pwd);
		return sb.ToString ();
	}

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	const string drop_table = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug325397]') AND type = N'U')
			DROP TABLE [dbo].[bug325397]";

	const string create_table = @"
		CREATE TABLE bug325397
		(
			Name varchar(20),
			FirstName varchar (10)
		)";

	const string insert_data = @"
		INSERT INTO bug325397 VALUES (N'de Icaza', N'Miguel');
		INSERT INTO bug325397 VALUES (N'Pobst', N'Jonathan');";
}
