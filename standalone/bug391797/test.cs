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
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

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

			return RunTest (conn);
		} finally {
			if (conn != null) {
#if NET_2_0
				SqlConnection.ClearPool (conn);
#endif
				conn.Dispose ();
			}

			cmd = new SqlCommand (drop_database, master);
			cmd.ExecuteNonQuery ();

			master.Dispose ();
		}
	}

	static int RunTest (SqlConnection conn)
	{
		SqlCommand cmd = new SqlCommand (create_table, conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		cmd = new SqlCommand ("INSERT INTO bug381118 VALUES ('A', NULL, NULL, NULL, NULL, NULL, NULL, NULL)", conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		cmd = new SqlCommand ("INSERT INTO bug381118 VALUES ('B', 80, 25, 180, 55666, 555.28, 66678.33, 9998864.64)", conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		cmd = new SqlCommand ("SELECT * FROM bug381118", conn);

		using (SqlDataReader dr = cmd.ExecuteReader ()) {
			Assert.IsTrue (dr.Read (), "#A");

			Assert.AreEqual ("nvarchar", dr.GetDataTypeName  (0), "#B1");
			Assert.AreEqual ("A", dr.GetString (0), "#B2");
			Assert.IsFalse (dr.IsDBNull (0), "#B3");

			Assert.AreEqual ("smallint", dr.GetDataTypeName (1), "#C1");
			Assert.AreEqual (DBNull.Value, dr.GetValue (1), "#C2");
			Assert.IsTrue (dr.IsDBNull (1), "#C3");

			Assert.AreEqual ("tinyint", dr.GetDataTypeName (2), "#D1");
			Assert.AreEqual (DBNull.Value, dr.GetValue (2), "#D2");
			Assert.IsTrue (dr.IsDBNull (2), "#D3");

			Assert.AreEqual ("int", dr.GetDataTypeName (3), "#E1");
			Assert.AreEqual (DBNull.Value, dr.GetValue (3), "#E2");
			Assert.IsTrue (dr.IsDBNull (3), "#E3");

#if MONO
			Assert.AreEqual ("decimal", dr.GetDataTypeName (4), "#F1");
#else
			Assert.AreEqual ("bigint", dr.GetDataTypeName (4), "#F1");
#endif
			Assert.AreEqual (DBNull.Value, dr.GetValue (4), "#F2");
			Assert.IsTrue (dr.IsDBNull (4), "#F3");

			Assert.AreEqual ("decimal", dr.GetDataTypeName (5), "#G1");
			Assert.AreEqual (DBNull.Value, dr.GetValue (5), "#G2");
			Assert.IsTrue (dr.IsDBNull (5), "#G3");

			Assert.AreEqual ("decimal", dr.GetDataTypeName (6), "#H1");
			Assert.AreEqual (DBNull.Value, dr.GetValue (6), "#H2");
			Assert.IsTrue (dr.IsDBNull (6), "#H3");

			Assert.AreEqual ("decimal", dr.GetDataTypeName (7), "#I1");
			Assert.AreEqual (DBNull.Value, dr.GetValue (7), "#I2");
			Assert.IsTrue (dr.IsDBNull (7), "#I3");

			Assert.IsTrue (dr.Read (), "#J");

			Assert.AreEqual ("nvarchar", dr.GetDataTypeName (0), "#K1");
			Assert.AreEqual ("B", dr.GetString (0), "#K2");
			Assert.IsFalse (dr.IsDBNull (0), "#K3");

			Assert.AreEqual ("smallint", dr.GetDataTypeName (1), "#L1");
			Assert.AreEqual ((short) 80, dr.GetValue (1), "#L2");
			Assert.IsFalse (dr.IsDBNull (1), "#L3");

			Assert.AreEqual ("tinyint", dr.GetDataTypeName (2), "#M1");
			Assert.AreEqual ((byte) 25, dr.GetValue (2), "#M2");
			Assert.IsFalse (dr.IsDBNull (2), "#M3");

			Assert.AreEqual ("int", dr.GetDataTypeName (3), "#N1");
			Assert.AreEqual (180, dr.GetValue (3), "#N2");
			Assert.IsFalse (dr.IsDBNull (3), "#N3");

#if MONO
			Assert.AreEqual ("decimal", dr.GetDataTypeName (4), "#O1");
#else
			Assert.AreEqual ("bigint", dr.GetDataTypeName (4), "#O1");
#endif
			Assert.AreEqual (55666L, dr.GetValue (4), "#O2");
			Assert.IsFalse (dr.IsDBNull (4), "#O3");
			Assert.AreEqual (55666L, dr.GetInt64 (4), "#O4");

			Assert.AreEqual ("decimal", dr.GetDataTypeName (5), "#P1");
			Assert.AreEqual (555.28m, dr.GetValue (5), "#P2");
			Assert.IsFalse (dr.IsDBNull (5), "#P3");

			Assert.AreEqual ("decimal", dr.GetDataTypeName (6), "#Q1");
#if MONO
			Assert.AreEqual (66678L, dr.GetValue (6), "#Q2");
#else
			Assert.AreEqual (66678m, dr.GetValue (6), "#Q2");
#endif
			Assert.IsFalse (dr.IsDBNull (6), "#Q3");

			Assert.AreEqual ("decimal", dr.GetDataTypeName (7), "#R1");
#if MONO
			Assert.AreEqual (9998865L, dr.GetValue (7), "#R2");
#else
			Assert.AreEqual (9998865m, dr.GetValue (7), "#R2");
#endif
			Assert.IsFalse (dr.IsDBNull (7), "#R3");
		}

		return 0;
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

	const string drop_database = @"
		IF EXISTS (SELECT * FROM sys.databases WHERE name = N'Mono')
			DROP DATABASE Mono";

	const string create_database = "CREATE DATABASE Mono";

	const string create_table = @"
		CREATE TABLE bug381118
		(
			Name nvarchar(20),
			Weight smallint NULL,
			Age tinyint NULL,
			Height int NULL,
			Income bigint NULL,
			AverageIncome decimal (9, 2) NULL,
			AverageExpenses decimal (14, 0) NULL,
			TotalExpenses decimal (19, 0) NULL
		)";
}
