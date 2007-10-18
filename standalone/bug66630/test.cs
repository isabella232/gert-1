using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		using (SqlConnection myConnection = new SqlConnection (CreateConnectionString ())) {
			SqlCommand command = new SqlCommand (drop_stored_procedure, myConnection);
			myConnection.Open ();
			command.ExecuteNonQuery ();

			command = new SqlCommand (create_stored_procedure, myConnection);
			command.ExecuteNonQuery ();

			command = new SqlCommand ("bug66630", myConnection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add ("@UserAccountStatus", SqlDbType.SmallInt).Value = UserAccountStatus.ApprovalPending;
			command.Prepare ();
			SqlDataReader dr = command.ExecuteReader ();
			if (!dr.Read ())
				return 1;
			if (dr.GetInt32 (0) != 1)
				return 2;
			if (dr.GetInt32 (1) != 0)
				return 3;
			dr.Close ();

			// clean-up
			command = new SqlCommand (drop_stored_procedure, myConnection);
			command.ExecuteNonQuery ();

			return 0;
		}
	}

	const string drop_stored_procedure = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug66630]') AND type in (N'P', N'PC'))
			DROP PROCEDURE [dbo].[bug66630]";

	const string create_stored_procedure = @"
			CREATE PROCEDURE bug66630
			(
				@UserAccountStatus smallint = 1
			)
			AS
			BEGIN
			SELECT 1, 0
			END";

	static string CreateConnectionString ()
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
}

public enum UserAccountStatus
{
	ApprovalPending = 0,
	Approved = 1,
	Banned = 2,
	Disapproved = 3
}
