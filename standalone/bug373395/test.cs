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

		OdbcCommand cmd = null;

		try {
			cmd = new OdbcCommand ("SELECT * FROM nфme", conn);
			cmd.ExecuteNonQuery ();
			return 1;
		} catch (OdbcException ex) {
			Assert.AreEqual (typeof (OdbcException), ex.GetType (), "#A1");
			Assert.IsNull (ex.InnerException, "#A2");
			Assert.AreEqual ("ERROR [42S02] [Microsoft][ODBC SQL Server Driver][SQL Server]Invalid object name 'nфme'.", ex.Message, "#A3");
			Assert.AreEqual ("SQLSRV32.DLL", ex.Source, "#A4");
			Assert.AreEqual (1, ex.Errors.Count, "#A5");

			Assert.AreEqual ("[Microsoft][ODBC SQL Server Driver][SQL Server]Invalid object name 'nфme'.", ex.Errors [0].Message, "#B1");
			Assert.AreEqual (208, ex.Errors [0].NativeError, "#B2");
			Assert.AreEqual ("SQLSRV32.DLL", ex.Errors [0].Source, "#B3");
			Assert.AreEqual ("42S02", ex.Errors [0].SQLState, "#B4");
		} finally {
			if (cmd != null)
				cmd.Dispose ();
			conn.Dispose ();
		}

		conn = new OdbcConnection (CreateOdbcConnectionString ());
		conn.Open ();

		try {
			Assert.AreEqual ("SQLSRV32.DLL", conn.Driver, "#C1");
			conn.Close ();
			Assert.AreEqual (string.Empty, conn.Driver, "#C2");
		} finally {
			conn.Close ();
		}

		conn = new OdbcConnection (CreateOdbcConnectionString ());
		Assert.AreEqual (string.Empty, conn.Driver, "#D");

		conn = new OdbcConnection (CreateOdbcConnectionString ("dфtabasé"));

		try {
			conn.Open ();
			return 2;
		} catch (OdbcException ex) {
			Assert.AreEqual (typeof (OdbcException), ex.GetType (), "#E1");
			Assert.IsNull (ex.InnerException, "#E2");
#if MONO
			Assert.AreEqual ("ERROR [42000] [Microsoft][ODBC SQL Server Driver][SQL Server]Cannot open database \"dфtabasé\" requested by the login. The login failed.", ex.Message, "#E3");
#else
			Assert.AreEqual (string.Format ("{0}{1}{0}", "ERROR [42000] [Microsoft][ODBC SQL Server Driver][SQL Server]Cannot open database \"dфtabasé\" requested by the login. The login failed.", Environment.NewLine), ex.Message, "#E3");
#endif
			Assert.AreEqual (string.Empty, ex.Source, "#E4");
#if MONO
			Assert.AreEqual (1, ex.Errors.Count, "#E5");
#else
			Assert.AreEqual (2, ex.Errors.Count, "#E5");
#endif

			Assert.AreEqual ("[Microsoft][ODBC SQL Server Driver][SQL Server]Cannot open database \"dфtabasé\" requested by the login. The login failed.", ex.Errors [0].Message, "#F1");
			Assert.AreEqual (4060, ex.Errors [0].NativeError, "#F2");
			Assert.AreEqual (string.Empty, ex.Errors [0].Source, "#F3");
			Assert.AreEqual ("42000", ex.Errors [0].SQLState, "#F4");

#if !MONO
			Assert.AreEqual ("[Microsoft][ODBC SQL Server Driver][SQL Server]Cannot open database \"dфtabasé\" requested by the login. The login failed.", ex.Errors [1].Message, "#G1");
			Assert.AreEqual (4060, ex.Errors [1].NativeError, "#G2");
			Assert.AreEqual (string.Empty, ex.Errors [1].Source, "#G3");
			Assert.AreEqual ("42000", ex.Errors [1].SQLState, "#G4");
#endif
		} finally {
			if (cmd != null)
				cmd.Dispose ();
			conn.Dispose ();
		}

		return 0;
	}

	static string CreateOdbcConnectionString ()
	{
		string dbName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_DB");
		if (dbName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_DB");
		return CreateOdbcConnectionString (dbName);
	}

	static string CreateOdbcConnectionString (string dbName)
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
