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
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		OdbcConnection conn = new OdbcConnection (CreateOdbcConnectionString ());
		conn.Open ();

		OdbcCommand cmd = new OdbcCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		cmd = new OdbcCommand (create_table, conn);
		cmd.ExecuteNonQuery ();

		cmd = new OdbcCommand (insert_data, conn);
		cmd.ExecuteNonQuery ();

		cmd = new OdbcCommand ("SELECT * FROM bug324025", conn);
		OdbcDataReader dr = null;

		try {
			dr = cmd.ExecuteReader ();
			if (!dr.Read ())
				return 1;
			Assert.AreEqual ("de Icaza", dr.GetString (0), "#A1");
			Assert.AreEqual ("Miguel    ", dr.GetString (1), "#A2");
			Assert.AreEqual ("445.340", dr.GetString (2), "#A3");
			Assert.AreEqual ("1956-10-30 14:01:29.000", dr.GetString (3), "#A4");
			Assert.AreEqual ("Boston", dr.GetString (4), "#A5");
			Assert.AreEqual ("0", dr.GetString (5), "#A6");

			if (!dr.Read ())
				return 2;
			Assert.AreEqual ("Pobst", dr.GetString (0), "#B1");
			Assert.AreEqual ("Jonathan  ", dr.GetString (1), "#B2");
			Assert.AreEqual ("543.334", dr.GetString (2), "#B3");
			Assert.AreEqual ("2004-05-16 07:31:44.457", dr.GetString (3), "#B4");
			Assert.AreEqual ("Orléans", dr.GetString (4), "#B5");
			Assert.AreEqual ("1", dr.GetString (5), "#B6");

			if (dr.Read ())
				return 3;
		} finally {
			if (dr != null)
				dr.Close ();
			cmd = new OdbcCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		cmd = new OdbcCommand (create_table, conn);
		cmd.ExecuteNonQuery ();

		cmd = new OdbcCommand (insert_data, conn);
		cmd.ExecuteNonQuery ();

		cmd = new OdbcCommand ("SELECT * FROM bug324025", conn);

		try {
			dr = cmd.ExecuteReader ();
			if (!dr.Read ())
				return 1;

			try {
				dr.GetByte (2);
				Assert.Fail ("#C1");
			} catch (OdbcException ex) {
				Assert.IsNull (ex.InnerException, "#C2");
				Assert.AreEqual ("ERROR [22003] [Microsoft][ODBC SQL Server Driver]Numeric value out of range", ex.Message, "#C3");
			}

			try {
				dr.GetInt32 (2);
				Assert.Fail ("#D1");
			} catch (OdbcException ex) {
				Assert.IsNull (ex.InnerException, "#D2");
			}

			if (!dr.Read ())
				return 2;

			if (dr.Read ())
				return 3;
		} finally {
			if (dr != null)
				dr.Close ();
			cmd = new OdbcCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		conn.Dispose ();

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
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug324025]') AND type = N'U')
			DROP TABLE [dbo].[bug324025]";

	const string create_table = @"
		CREATE TABLE bug324025
		(
			Name varchar(20),
			FirstName char (10),
			Income decimal (9,3),
			BirthDate datetime,
			BirthPlace nvarchar (20),
			Married bit
		)";

	const string insert_data = @"
		INSERT INTO bug324025 VALUES (N'de Icaza', N'Miguel', 445.34, '19561030 14:01:29', N'Boston', 0);
		INSERT INTO bug324025 VALUES (N'Pobst', N'Jonathan', 543.334, '20040516 07:31:44.457', N'Orléans', 1);";
}
