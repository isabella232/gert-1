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
			SqlDataReader dr;
			SqlCommand command;

			command = new SqlCommand (drop_stored_procedure, myConnection);
			myConnection.Open ();
			command.ExecuteNonQuery ();

			command = new SqlCommand (create_stored_procedure, myConnection);
			command.ExecuteNonQuery ();

			command = new SqlCommand ("bug324590", myConnection);
			command.CommandType = CommandType.StoredProcedure;
			SqlParameter param1 = command.Parameters.Add ("@Param1", SqlDbType.NVarChar);
			param1.Value = "data";
			SqlParameter param2 = command.Parameters.Add ("@Param2", SqlDbType.NVarChar);
			param2.Value = "mo, no";
			command.Prepare ();

			dr = command.ExecuteReader ();
			Assert.IsTrue (dr.Read (), "#A1");
			Assert.AreEqual ("datamo, no", dr.GetString (0), "#A2");
			Assert.IsFalse (dr.Read (), "#A3");
			dr.Close ();

			param2.Value = "mo,no";

			dr = command.ExecuteReader ();
			Assert.IsTrue (dr.Read (), "#B1");
			Assert.AreEqual ("datamo,no", dr.GetString (0), "#B2");
			Assert.IsFalse (dr.Read (), "#B3");
			dr.Close ();

			// clean-up
			command = new SqlCommand (drop_stored_procedure, myConnection);
			command.ExecuteNonQuery ();

			return 0;
		}
	}

	const string drop_stored_procedure = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug324590]') AND type in (N'P', N'PC'))
			DROP PROCEDURE [dbo].[bug324590]";

	const string create_stored_procedure = @"
			CREATE PROCEDURE bug324590
			(
				@Param1 nvarchar(255),
				@Param2 nvarchar(255)
			)
			AS
			BEGIN
				SELECT @Param1 + @Param2
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
