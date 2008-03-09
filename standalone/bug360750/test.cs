using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Threading;

class Program
{
	[STAThread]
	static void Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return;

		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		SqlConnection master = new SqlConnection (CreateConnectionString ("master"));
		master.Open ();

		SqlCommand cmd = new SqlCommand (drop_database, master);
		cmd.ExecuteNonQuery ();

		cmd = new SqlCommand (create_database, master);
		cmd.ExecuteNonQuery ();

		SqlConnection conn = null;

		try {
			conn = new SqlConnection (CreateConnectionString ("Mono"));
			conn.Open ();

			RunTest (conn);
		} finally {
			if (conn != null) {
				conn.Dispose ();
			}

			cmd = new SqlCommand (drop_database, master);
			cmd.ExecuteNonQuery ();

			master.Dispose ();
		}
	}

	static void RunTest (SqlConnection conn)
	{

		SqlCommand cmd = new SqlCommand (create_stored_procedure, conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		cmd = new SqlCommand ("bug360750", conn);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add (CreateParameter ("@Name", DBNull.Value));

		using (SqlDataReader dr = cmd.ExecuteReader (CommandBehavior.SingleRow)) {
			Assert.IsTrue (dr.Read (), "#A1");
			Assert.AreEqual (1, dr.FieldCount, "#A2");
			Assert.AreEqual (typeof (int), dr.GetFieldType (0), "#A3");
			Assert.AreEqual (string.Empty, dr.GetName (0), "#A4");
			Assert.AreEqual (1, dr.GetValue (0), "#A5");
		}

		cmd.Dispose ();

		cmd = new SqlCommand ("bug360750", conn);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add (CreateParameter ("@Name", "Mono"));

		using (SqlDataReader dr = cmd.ExecuteReader (CommandBehavior.SingleRow)) {
			Assert.IsTrue (dr.Read (), "#B1");
			Assert.AreEqual (1, dr.FieldCount, "#B2");
			Assert.AreEqual (typeof (int), dr.GetFieldType (0), "#B3");
			Assert.AreEqual (string.Empty, dr.GetName (0), "#B4");
			Assert.AreEqual (2, dr.GetValue (0), "#B5");
		}

		cmd.Dispose ();

		cmd = new SqlCommand ("bug360750", conn);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add (CreateParameter ("@Name", string.Empty));

		using (SqlDataReader dr = cmd.ExecuteReader (CommandBehavior.SingleRow)) {
			Assert.IsTrue (dr.Read (), "#C1");
			Assert.AreEqual (1, dr.FieldCount, "#C2");
			Assert.AreEqual (typeof (int), dr.GetFieldType (0), "#C3");
			Assert.AreEqual (string.Empty, dr.GetName (0), "#C4");
			Assert.AreEqual (3, dr.GetValue (0), "#C5");
		}

		cmd.Dispose ();

		cmd = new SqlCommand ("bug360750", conn);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add (CreateParameter ("@Name", "Rocks!"));

		using (SqlDataReader dr = cmd.ExecuteReader (CommandBehavior.SingleRow)) {
			Assert.IsTrue (dr.Read (), "#D1");
			Assert.AreEqual (1, dr.FieldCount, "#D2");
			Assert.AreEqual (typeof (int), dr.GetFieldType (0), "#D3");
			Assert.AreEqual (string.Empty, dr.GetName (0), "#D4");
			Assert.AreEqual (4, dr.GetValue (0), "#D5");
		}

		cmd.Dispose ();
	}

	static string CreateConnectionString (string dbName)
	{
		StringBuilder sb = new StringBuilder ();

		string serverName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (serverName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_HOST");

		sb.AppendFormat ("server={0};database={1};", serverName, dbName);

		string userName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (userName != null)
			sb.AppendFormat ("user id={0};", userName);

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd != null)
			sb.AppendFormat ("pwd={0};", pwd);

#if ONLY_1_1
		sb.Append ("Pooling=false;");
#endif
		return sb.ToString ();
	}

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	static SqlParameter CreateParameter (string name, object value)
	{
		SqlParameter param = new SqlParameter ();
		param.ParameterName = name;
		param.Value = value;
		return param;
	}

	const string drop_database = @"
		IF EXISTS (SELECT * FROM sys.databases WHERE name = N'Mono')
			DROP DATABASE Mono";

	const string create_database = "CREATE DATABASE Mono";

	const string create_stored_procedure = @"
		CREATE PROCEDURE [dbo].[bug360750] 
			@Name varchar (20)
		AS
			BEGIN
				SET NOCOUNT ON;
	
				IF @Name is null
					SELECT 1;
				ELSE IF @Name = 'Mono'
					SELECT 2;
				ELSE IF @Name = ''
					SELECT 3;
				ELSE
					SELECT 4;
			END";
}
