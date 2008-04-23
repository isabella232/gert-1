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
		SqlCommand cmd;
		DateTime start;
		TimeSpan executionTime;
		
		cmd = new SqlCommand (create_table, conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		cmd = new SqlCommand ("INSERT INTO bug381151 VALUES ('Mono')", conn);
		cmd.CommandTimeout = 2000;
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		Thread tlock = null;

		try {
			tlock = new Thread (new ThreadStart (TableLock));
			tlock.Start ();

			Thread.Sleep (100);

			start = DateTime.Now;

			cmd = new SqlCommand ("SELECT * FROM bug381151", conn);
			cmd.CommandTimeout = 2;
			try {
				cmd.ExecuteNonQuery ();
				return 1;
			} catch (SqlException) {
			}

			executionTime = DateTime.Now - start;
			Assert.IsTrue (executionTime.TotalSeconds >= 2, "#A1");
			Assert.IsTrue (executionTime.TotalSeconds < 4, "#A2");
			start = DateTime.Now;

			SqlDataAdapter dta = new SqlDataAdapter (cmd);
			try {
				dta.Fill (new DataSet ());
				return 2;
			} catch (SqlException) {
			}

			executionTime = DateTime.Now - start;
			Assert.IsTrue (executionTime.TotalSeconds >= 2, "#B1");
			Assert.IsTrue (executionTime.TotalSeconds < 4, "#B2");
			start = DateTime.Now;

			try {
				cmd.ExecuteReader ();
				return 3;
			} catch (SqlException) {
			}

			executionTime = DateTime.Now - start;
			Assert.IsTrue (executionTime.TotalSeconds >= 2, "#C1");
			Assert.IsTrue (executionTime.TotalSeconds < 4, "#C2");
			start = DateTime.Now;

			try {
				cmd.ExecuteNonQuery ();
				return 3;
			} catch (SqlException) {
			}

			executionTime = DateTime.Now - start;
			Assert.IsTrue (executionTime.TotalSeconds >= 2, "#D1");
			Assert.IsTrue (executionTime.TotalSeconds < 4, "#D2");
			start = DateTime.Now;

			tlock.Join ();

			cmd = new SqlCommand ("SELECT * FROM bug381151", conn);
			cmd.CommandTimeout = 2;
			using (SqlDataReader dr = cmd.ExecuteReader ()) {
				Assert.IsTrue (dr.Read (), "#E1");
				Assert.AreEqual ("Mono", dr.GetString (0), "#E2");
				Assert.IsFalse (dr.Read (), "#E3");
				cmd.Dispose ();
			}

			conn.Close ();

			start = DateTime.Now;

			DataSet ds = new DataSet ();
			dta.Fill (ds);
			Assert.AreEqual (1, ds.Tables.Count, "#F1");
			Assert.AreEqual (1, ds.Tables [0].Rows.Count, "#F2");
			Assert.AreEqual ("Mono", ds.Tables [0].Rows [0] [0], "#F3");
		} finally {
			if (tlock.ThreadState != ThreadState.Stopped)
				tlock.Join ();
		}

		return 0;
	}

	static void TableLock ()
	{
		using (SqlConnection conn = new SqlConnection (CreateConnectionString ("Mono"))) {
			conn.Open ();

			SqlTransaction trans = conn.BeginTransaction (IsolationLevel.Serializable);
			SqlCommand cmd = new SqlCommand ("UPDATE bug381151 SET Name = Name",
				trans.Connection, trans);
			cmd.ExecuteNonQuery ();

			Thread.Sleep (15000);
		}
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
		CREATE TABLE bug381151
		(
			Name varchar(20),
		)";
}
