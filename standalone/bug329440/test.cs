using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Threading;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		SqlConnection conn = new SqlConnection (CreateSqlConnectionString ());
		conn.Open ();

		SqlCommand cmd = new SqlCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		try {
			cmd = new SqlCommand (create_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (insert_data, conn);
			cmd.ExecuteNonQuery ();

			SqlDataAdapter da = new SqlDataAdapter ();
			DataSet ds = new DataSet ();

			cmd = new SqlCommand ("SELECT * FROM bug329440", conn);
			da.SelectCommand = cmd;
			da.Fill (ds);
			da.Dispose ();
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		conn.Dispose ();

		return 0;
	}

	static string CreateSqlConnectionString ()
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
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug329440]') AND type = N'U')
			DROP TABLE [dbo].[bug329440]";

	const string create_table = @"
		CREATE TABLE bug329440
		(
			Name varchar(20),
			FirstName varchar (10)
		)";

	const string insert_data = @"
		INSERT INTO bug329440 VALUES (N'de Icaza', N'Miguel');
		INSERT INTO bug329440 VALUES (N'Pobst', N'Jonathan');";
}
