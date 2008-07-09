using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
	[STAThread]
	static void Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return;

		SqlCommand cmd;

		SqlConnection conn = new SqlConnection (CreateConnectionString ());
		conn.Open ();

		try {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (create_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (insert_data, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand ("SELECT Name, FirstName FROM [bug326011]", conn);

			SqlDataAdapter adapter = new SqlDataAdapter (cmd);
			DataSet ds = new DataSet ();
			adapter.Fill (ds);
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();

			if (conn != null)
				conn.Dispose ();
		}

		conn = new SqlConnection (CreateConnectionString ());
		conn.Open ();

		try {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (create_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (insert_data, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand ("SELECT Name, FirstName FROM [bug326011]", conn);

			SqlDataAdapter adapter = new SqlDataAdapter (cmd);
			DataSet ds = new DataSet ();
			adapter.Fill (ds);

			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();

			if (conn != null)
				conn.Dispose ();
		}
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
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug326011]') AND type = N'U')
			DROP TABLE [dbo].[bug326011]";

	const string create_table = @"
		CREATE TABLE bug326011
		(
			Name varchar(20),
			FirstName varchar (10)
		)";

	const string insert_data = @"
		INSERT INTO bug326011 VALUES (N'de Icaza', N'Miguel');
		INSERT INTO bug326011 VALUES (N'Pobst', N'Jonathan');";
}
