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
		Assert.AreEqual (-1, cmd.ExecuteNonQuery (), "#1");

		try {
			cmd = new OdbcCommand (create_table, conn);
			Assert.AreEqual (-1, cmd.ExecuteNonQuery (), "#2");

			cmd = new OdbcCommand (insert_data, conn);
			Assert.AreEqual (2, cmd.ExecuteNonQuery (), "#3");

			using (OdbcDataReader dr = cmd.ExecuteReader ()) {
				Assert.IsFalse (dr.NextResult (), "#4");
				Assert.AreEqual (2, dr.RecordsAffected, "#5");
			}

			cmd = new OdbcCommand (modify_data, conn);
			using (OdbcDataReader dr = cmd.ExecuteReader ()) {
				Assert.AreEqual (6, dr.RecordsAffected, "#6");
			}
		} finally {
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
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug341726]') AND type = N'U')
			DROP TABLE [dbo].[bug341726]";

	const string create_table = @"
		CREATE TABLE bug341726
		(
			Name varchar(20),
			FirstName varchar (10)
		)";

	const string insert_data = @"
		INSERT INTO bug341726 VALUES (N'de Icaza', N'Miguel');
		INSERT INTO bug341726 VALUES (N'Pobst', N'Jonathan');";

	const string modify_data = @"
		INSERT INTO bug341726 VALUES (N'Toshok', N'Chris');
		DELETE FROM bug341726;";
}
