using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
	static decimal [][] values = {
		new decimal [] { -1m, -1m },
		new decimal [] { 1m, 1m },
		new decimal [] { -10.1234m, -10.1234m },
		new decimal [] { 10.1234m, 10.1234m },
		new decimal [] { -2000000000m, -214748m },
		new decimal [] { 2000000000m, 214748m },
		new decimal [] { -200000000.2345m, -214748.3648m },
		new decimal [] { 200000000.2345m, 214748.3647m },
		new decimal [] { 0m, 0m }
		};

	[STAThread]
	static int Main (string [] args)
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		if (args.Length != 1) {
			Console.WriteLine ("Please specify test to run.");
			return 1;
		}

		switch (args [0]) {
		case "clear":
			Clear ();
			break;
		case "read":
			Read ();
			break;
		case "write":
			Write ();
			break;
		}

		return 0;
	}

	static void Clear ()
	{
		SqlConnection myConnection = new SqlConnection (CreateConnectionString ());
		myConnection.Open ();

		SqlCommand command = null;

		try {
			command = new SqlCommand (drop_stored_procedure, myConnection);
			command.ExecuteNonQuery ();

			command = new SqlCommand (drop_table, myConnection);
			command.ExecuteNonQuery ();
		} finally {
			if (command != null)
				command.Dispose ();
			myConnection.Close ();
		}
	}

	static void Read ()
	{
		SqlConnection myConnection = new SqlConnection (CreateConnectionString ());
		myConnection.Open ();

		SqlDataReader dr = null;
		SqlCommand command;

		try {
			command = new SqlCommand ("SELECT * FROM bug428139 ORDER BY Id ASC", myConnection);
			dr = command.ExecuteReader ();

			for (int i = 0; i < values.Length; i++) {
				Assert.IsTrue (dr.Read (), "#A1:" + i);
				Assert.AreEqual (i + 1, dr.GetInt32 (0), "#A2:" + i);
				Assert.AreEqual (typeof (decimal), dr.GetFieldType (1), "#A3:" + i);
				Assert.AreEqual (values [i][0], dr.GetDecimal (1), "#A4:" + i);
				Assert.AreEqual (typeof (decimal), dr.GetFieldType (2), "#A5:" + i);
				Assert.AreEqual (values [i] [1], dr.GetDecimal (2), "#A6:" + i);
			}

			Assert.IsTrue (dr.Read (), "#B1");
			Assert.AreEqual (values.Length, dr.GetInt32 (0), "#B2");
			Assert.AreEqual (typeof (decimal), dr.GetFieldType (1), "#B3");
			Assert.IsTrue (dr.IsDBNull (1), "#B4");
			Assert.AreEqual (typeof (decimal), dr.GetFieldType (1), "#B5");
			Assert.IsTrue (dr.IsDBNull (1), "#B6");
		} finally {
			if (dr != null)
				dr.Close ();
			myConnection.Close ();
		}
	}

	static void Write ()
	{
		SqlConnection myConnection = new SqlConnection (CreateConnectionString ());
		myConnection.Open ();

		SqlCommand command = null;

		try {
			command = new SqlCommand (create_table, myConnection);
			command.ExecuteNonQuery ();

			command = new SqlCommand (create_stored_procedure, myConnection);
			command.ExecuteNonQuery ();

			command = new SqlCommand ("sp_bug428139", myConnection);
			command.CommandType = CommandType.StoredProcedure;
			SqlParameter paramId = command.Parameters.Add ("@Id", SqlDbType.Int);
			SqlParameter paramMon = command.Parameters.Add ("@Mon", SqlDbType.Money);
			SqlParameter paramSMon = command.Parameters.Add ("@SMon", SqlDbType.SmallMoney);

			for (int i = 0; i < values.Length; i++) {
				paramId.Value = i + 1;
				paramMon.Value = values [i][0];
				paramSMon.Value = values [i][1];
				command.ExecuteNonQuery ();
			}

			paramId.Value = values.Length;
			paramMon.Value = DBNull.Value;
			paramSMon.Value = DBNull.Value;
			command.ExecuteNonQuery ();
		} finally {
			if (command != null)
				command.Dispose ();
			myConnection.Close ();
		}
	}

	const string drop_table = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug428139]') AND type = N'U')
			DROP TABLE [dbo].[bug428139]";

	const string create_table = @"
			CREATE TABLE bug428139
			(
				Id int,
				Mon MONEY NULL,
				SMon SMALLMONEY NULL
			)";

	const string drop_stored_procedure = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_bug428139]') AND type in (N'P', N'PC'))
			DROP PROCEDURE [dbo].[sp_bug428139]";

	const string create_stored_procedure = @"
			CREATE PROCEDURE sp_bug428139
			(
				@Id int,
				@Mon MONEY,
				@SMon SMALLMONEY
			)
			AS
				SET NOCOUNT ON
				INSERT INTO bug428139 VALUES (@Id, @Mon, @SMon)";

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
