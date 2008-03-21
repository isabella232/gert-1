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

			Assert.AreEqual ("nvarchar", reader.GetDataTypeName (0), "#B1");
			Assert.AreEqual ("text1", reader.GetName (0), "#B2");
			Assert.AreEqual (new string ('ф', 270), reader.GetValue (0), "#B3");

			Assert.AreEqual ("ntext", reader.GetDataTypeName (1), "#C1");
			Assert.AreEqual ("text2", reader.GetName (1), "#C2");
			Assert.AreEqual (new string ('ф', 270), reader.GetValue (1), "#C3");

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
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug324990]') AND type = N'U')
			DROP TABLE [dbo].[bug324990]";

	const string create_table = @"
		CREATE TABLE bug324990
		(
			text1 nvarchar (280),
			text2 ntext
		)";

	const string select_data = @"SELECT * FROM bug324990";
	static string insert_data = @"INSERT INTO bug324990 VALUES (" +
		"N'" + new string('ф', 270) + "'," +
		"N'" + new string ('ф', 270) + "')";
	const string delete_data = @"DELETE FROM bug324990";
}
