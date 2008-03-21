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
			Assert.AreEqual (7, reader.FieldCount, "#A2");

			Assert.AreEqual ("int", reader.GetDataTypeName (0), "#B1");
			Assert.AreEqual ("id", reader.GetName (0), "#B2");
			Assert.AreEqual (5, reader.GetValue (0), "#B3");

			Assert.AreEqual ("nvarchar", reader.GetDataTypeName (1), "#C1");
			Assert.AreEqual ("nфme", reader.GetName (1), "#C2");
			Assert.AreEqual ("aфbиcсdвeуfа", reader.GetValue (1), "#C3");

			Assert.AreEqual ("varchar", reader.GetDataTypeName (2), "#D1");
			Assert.AreEqual ("firstName", reader.GetName (2), "#D2");
			Assert.AreEqual ("Eric", reader.GetValue (2), "#D3");

			Assert.AreEqual ("nchar", reader.GetDataTypeName (3), "#E1");
			Assert.AreEqual ("initials", reader.GetName (3), "#E2");
			Assert.AreEqual ("вeуf ", reader.GetValue (3), "#E3");

			Assert.AreEqual ("ntext", reader.GetDataTypeName (4), "#F1");
			Assert.AreEqual ("comment", reader.GetName (4), "#F2");
			Assert.AreEqual ("some long text that does not meфn a thing", reader.GetValue (4), "#F3");

			Assert.AreEqual ("char", reader.GetDataTypeName (5), "#G1");
			Assert.AreEqual ("town", reader.GetName (5), "#G2");
			Assert.AreEqual ("Hasselt   ", reader.GetValue (5), "#G3");

			Assert.AreEqual ("text", reader.GetDataTypeName (6), "#H1");
			Assert.AreEqual ("description", reader.GetName (6), "#H2");
			Assert.AreEqual ("more text without any meaning", reader.GetValue (6), "#H3");

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
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug372823]') AND type = N'U')
			DROP TABLE [dbo].[bug372823]";

	const string create_table = @"
		CREATE TABLE bug372823
		(
			id int,
			nфme nvarchar (12),
			firstName varchar (10),
			initials nchar (5),
			comment ntext,
			town char (10),
			description text
		)";

	const string select_data = @"SELECT * FROM bug372823";
	const string insert_data = @"INSERT INTO bug372823 (id, nфme, firstName, " +
		"initials, comment, town, description) VALUES (5, N'aфbиcсdвeуfа', " +
		"'Eric', N'вeуf', N'some long text that does not meфn a thing', " +
		"'Hasselt', 'more text without any meaning')";
	const string delete_data = @"DELETE FROM bug372823";
}
