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

		start = DateTime.Now;

		cmd = new SqlCommand ("waitfor delay '00:00:10'", conn);
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

		cmd = new SqlCommand ("SELECT * FROM bug381151", conn);
		using (SqlDataReader dr = cmd.ExecuteReader ()) {
			Assert.IsTrue (dr.Read (), "#C1");
			Assert.AreEqual ("Mono", dr.GetString (0), "#C2");
			Assert.IsFalse (dr.Read (), "#C3");
			cmd.Dispose ();
		}

		conn.Close ();

		start = DateTime.Now;

		try {
			dta.Fill (new DataSet ());
			return 3;
		} catch (SqlException) {
		}

		executionTime = DateTime.Now - start;
		Assert.IsTrue (executionTime.TotalSeconds >= 2, "#D1");
		Assert.IsTrue (executionTime.TotalSeconds < 4, "#D2");

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
		CREATE TABLE bug381151
		(
			Name varchar(20),
		)";
}

class Person
{
#if NET_2_0
	public Person (string name, long? income)
#else
	public Person (string name, long income)
#endif
	{
		_name = name;
		_income = income;
	}

	public string Name {
		get { return _name; }
	}

#if NET_2_0
	public long? Income {
#else
	public long Income {
#endif
		get { return _income; }
	}

	private readonly string _name;
#if NET_2_0
	private readonly long? _income;
#else
	private readonly long _income;
#endif
}
