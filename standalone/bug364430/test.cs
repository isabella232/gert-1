using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Text;
using System.Threading;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_ODBC") == null)
			return 0;

		OdbcConnection conn = new OdbcConnection (CreateOdbcConnectionString ());
		conn.Open ();

		OdbcCommand cmd = new OdbcCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		OdbcDataReader reader = null;

		try {
			cmd = new OdbcCommand (create_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new OdbcCommand (insert_data, conn);
			cmd.ExecuteNonQuery ();
			cmd.Dispose ();

			cmd = new OdbcCommand (select_data, conn);
			reader = cmd.ExecuteReader ();
			Assert.IsTrue (reader.Read (), "#A1");
			Assert.AreEqual (2, reader.FieldCount, "#A2");
			Assert.AreEqual ("int", reader.GetDataTypeName (0), "#A3");
			Assert.AreEqual ("nvarchar", reader.GetDataTypeName (1), "#A4");
			Assert.AreEqual (5, reader.GetValue (0), "#A5");
			Assert.AreEqual ("aфbиcсdвeуfа", reader.GetValue (1), "#A6");
			reader.Close ();
			cmd.Dispose ();
		} finally {
			if (reader != null)
				reader.Close ();

			cmd = new OdbcCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
			cmd.Dispose ();

			conn.Dispose ();
		}

		return 0;
	}

	static string CreateOdbcConnectionString ()
	{
#if NET_2_0
		OdbcConnectionStringBuilder csb = new OdbcConnectionStringBuilder ();
		csb.Driver = "SQL Server";
#else
		StringBuilder sb = new StringBuilder ();
		sb.Append ("Driver={SQL Server};");
#endif

		string serverName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (serverName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_HOST");
#if NET_2_0
		csb.Add ("Server", serverName);
#else
		sb.AppendFormat ("Server={0};", serverName);
#endif

		string dbName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_DB");
		if (dbName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_DB");
#if NET_2_0
		csb.Add ("Database", dbName);
#else
		sb.AppendFormat ("Database={0};", dbName);
#endif

		string userName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (userName != null)
#if NET_2_0
			csb.Add ("Uid", userName);
#else
			sb.AppendFormat ("Uid={0};", userName);
#endif

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd != null)
#if NET_2_0
			csb.Add ("Pwd", pwd);
#else
			sb.AppendFormat ("Pwd={0};", pwd);
#endif

#if NET_2_0
		return csb.ToString ();
#else
		return sb.ToString ();
#endif
	}

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	const string drop_table = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug364430]') AND type = N'U')
			DROP TABLE [dbo].[bug364430]";

	const string create_table = @"
		CREATE TABLE bug364430
		(
			id int,
			name nvarchar (31)
		)";

	const string select_data = @"SELECT * FROM bug364430";
	const string insert_data = @"INSERT INTO bug364430 (id, name) VALUES (5, N'aфbиcсdвeуfа')";
	const string delete_data = @"DELETE FROM bug364430";
}
