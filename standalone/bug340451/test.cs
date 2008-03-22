using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Text;

class Program
{
	[STAThread]
	static void Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_ODBC") == null)
			return;

		OdbcConnection conn = new OdbcConnection (CreateOdbcConnectionString ());
		conn.Open ();

		string dbName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_DB");
		Assert.AreEqual (dbName, conn.Database, "#1");

		OdbcCommand cmd = new OdbcCommand ("CREATE DATABASE aфbиc", conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		try {
			Assert.AreEqual (dbName, conn.Database, "#2");
			conn.ChangeDatabase ("aфbиc");
			Assert.AreEqual ("aфbиc", conn.Database, "#3");
			conn.ChangeDatabase (dbName);
			Assert.AreEqual (dbName, conn.Database, "#4");
		} finally {
			conn.Dispose ();

			conn = new OdbcConnection (CreateOdbcConnectionString ());
			conn.Open ();

			cmd = new OdbcCommand ("DROP DATABASE aфbиc", conn);
			cmd.ExecuteNonQuery ();
			cmd.Dispose ();
		}
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
}
