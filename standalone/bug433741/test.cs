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

			byte [] buffer;
			long read;

			buffer = new byte [8];
			read = reader.GetBytes (6, 3, buffer, 2, 4);
			Assert.AreEqual (4L, read, "#B1");
			Assert.AreEqual ((byte) 0, buffer [0], "#B2");
			Assert.AreEqual ((byte) 0, buffer [1], "#B3");
			Assert.AreEqual ((byte) 101, buffer [2], "#B4");
			Assert.AreEqual ((byte) 32, buffer [3], "#B5");
			Assert.AreEqual ((byte) 116, buffer [4], "#B6");
			Assert.AreEqual ((byte) 101, buffer [5], "#B7");
			Assert.AreEqual ((byte) 0, buffer [6], "#B8");
			Assert.AreEqual ((byte) 0, buffer [7], "#B9");

			buffer = new byte [8];
			buffer [1] = (byte) 5;
			buffer [7] = (byte) 4;
			read = reader.GetBytes (6, 3, buffer, 2, 4);
			Assert.AreEqual (4L, read, "#C1");
			Assert.AreEqual ((byte) 0, buffer [0], "#C2");
			Assert.AreEqual ((byte) 5, buffer [1], "#C3");
			Assert.AreEqual ((byte) 101, buffer [2], "#C4");
			Assert.AreEqual ((byte) 32, buffer [3], "#C5");
			Assert.AreEqual ((byte) 116, buffer [4], "#C6");
			Assert.AreEqual ((byte) 101, buffer [5], "#C7");
			Assert.AreEqual ((byte) 0, buffer [6], "#C8");
			Assert.AreEqual ((byte) 4, buffer [7], "#C9");

			buffer = new byte [8];
			read = reader.GetBytes (6, 8, buffer, 2, 6);
			Assert.AreEqual (6L, read, "#D1");
			Assert.AreEqual ((byte) 0, buffer [0], "#D2");
			Assert.AreEqual ((byte) 0, buffer [1], "#D3");
			Assert.AreEqual ((byte) 116, buffer [2], "#D4");
			Assert.AreEqual ((byte) 32, buffer [3], "#D5");
			Assert.AreEqual ((byte) 119, buffer [4], "#D6");
			Assert.AreEqual ((byte) 105, buffer [5], "#D7");
			Assert.AreEqual ((byte) 116, buffer [6], "#D8");
			Assert.AreEqual ((byte) 104, buffer [7], "#D9");

			buffer = new byte [8];
			read = reader.GetBytes (6, 27, buffer, 1, 26);
			Assert.AreEqual (2L, read, "#E1");
			Assert.AreEqual ((byte) 0, buffer [0], "#E2");
			Assert.AreEqual ((byte) 110, buffer [1], "#E3");
			Assert.AreEqual ((byte) 103, buffer [2], "#E4");
			Assert.AreEqual ((byte) 0, buffer [3], "#E5");
			Assert.AreEqual ((byte) 0, buffer [4], "#E6");
			Assert.AreEqual ((byte) 0, buffer [5], "#E7");
			Assert.AreEqual ((byte) 0, buffer [6], "#E8");
			Assert.AreEqual ((byte) 0, buffer [7], "#E9");

			buffer = new byte [0];
			read = reader.GetBytes (6, 27, buffer, 0, 0);
			Assert.AreEqual (0L, read, "#F");

			buffer = new byte [2];
			try {
				read = reader.GetBytes (6, 20, buffer, 0, 3);
				Assert.Fail ("#G1");
			} catch (ArgumentException ex) {
				// Destination array was not long enough.
				// Check destIndex and length, and the array's
				// lower bounds
				Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#G2");
				Assert.IsNull (ex.InnerException, "#G3");
				Assert.IsNotNull (ex.Message, "#G4");
				Assert.IsNull (ex.ParamName, "#G5");
			}

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
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug433741]') AND type = N'U')
			DROP TABLE [dbo].[bug433741]";

	const string create_table = @"
		CREATE TABLE bug433741
		(
			id int,
			nфme nvarchar (12),
			firstName varchar (10),
			initials nchar (5),
			comment ntext,
			town char (10),
			description text
		)";

	const string select_data = @"SELECT * FROM bug433741";
	const string insert_data = @"INSERT INTO bug433741 (id, nфme, firstName, " +
		"initials, comment, town, description) VALUES (5, N'aфbиcсdвeуfа', " +
		"'Eric', N'вeуf', N'some long text that does not meфn a thing', " +
		"'Hasselt', 'more text without any meaning')";
	const string delete_data = @"DELETE FROM bug433741";
}
