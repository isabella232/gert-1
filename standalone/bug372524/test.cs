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

		OdbcCommand cmd = new OdbcCommand (drop_stored_procedure, conn);
		cmd.ExecuteNonQuery ();

		OdbcDataReader reader = null;

		try {
			cmd = new OdbcCommand (create_stored_procedure, conn);
			cmd.ExecuteNonQuery ();
			cmd.Dispose ();

			cmd = new OdbcCommand ("{ CALL bug372524(?, ?) }", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			OdbcParameter paramTown = cmd.Parameters.Add ("@Town",
				OdbcType.NVarChar, 19);
			paramTown.Direction = ParameterDirection.Output;

			OdbcParameter paramCountry = cmd.Parameters.Add ("@Country",
				OdbcType.NVarChar, 3);
			paramCountry.Direction = ParameterDirection.Output;
			paramCountry.Value = "whatever";

			reader = cmd.ExecuteReader ();
			Assert.IsFalse (reader.Read (), "#A1");
			Assert.IsNull (paramTown.Value, "#A2");
#if NET_2_0
			Assert.AreEqual ("whatever", paramCountry.Value, "#A3");
#else
			Assert.IsNull (paramCountry.Value, "#A3");
#endif
			reader.Close ();
			Assert.AreEqual ("aфbиcсdвeуfа", paramTown.Value, "#A4");
			Assert.AreEqual ("aфв", paramCountry.Value, "#A5");

			cmd = new OdbcCommand ("{ CALL bug372524(?, ?) }", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			paramTown = cmd.Parameters.Add ("@Town", OdbcType.NVarChar, 19);
			paramTown.Direction = ParameterDirection.Output;

			paramCountry = cmd.Parameters.Add ("@Country", OdbcType.NVarChar, 3);
			paramCountry.Direction = ParameterDirection.Output;
			paramCountry.Value = "whatever";

			Assert.AreEqual (-1, cmd.ExecuteNonQuery (), "#B1");
			Assert.AreEqual ("aфbиcсdвeуfа", paramTown.Value, "#B2");
			Assert.AreEqual ("aфв", paramCountry.Value, "#B3");
		} finally {
			if (reader != null)
				reader.Close ();

			cmd = new OdbcCommand (drop_stored_procedure, conn);
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

	const string drop_stored_procedure = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug372524]') AND type = N'P')
			DROP PROCEDURE [dbo].[bug372524]";


	const string create_stored_procedure = @"
		CREATE PROCEDURE [dbo].[bug372524]
			@Town nvarchar (255) OUTPUT,
			@Country nvarchar (123) OUTPUT
		AS
			SELECT @Town = N'aфbиcсdвeуfа'
			SELECT @Country = N'aфвeа'";
}
