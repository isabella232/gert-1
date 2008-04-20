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
		ArrayList persons = new ArrayList ();
		persons.Add (new Person ("Miguel", 334343433L));
		persons.Add (new Person ("Atsushi", 5554444523L));

		SqlCommand cmd = new SqlCommand (create_table, conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		cmd = new SqlCommand ("INSERT INTO bug381118 (Income, Name) VALUES (@income, @name)", conn);
		foreach (Person person in persons) {
			cmd.Parameters.Add (CreateParameter ("@income", SqlDbType.BigInt, person.Income));
			cmd.Parameters.Add (CreateParameter ("@name", SqlDbType.NVarChar, person.Name));
			cmd.ExecuteNonQuery ();
			cmd.Parameters.Clear ();
		}

		cmd.Dispose ();

		cmd = new SqlCommand ("SELECT * FROM bug381118 WHERE Income = @income", conn);
		cmd.Parameters.Add (CreateParameter ("@income", SqlDbType.BigInt, 5554444523L));

		using (SqlDataReader dr = cmd.ExecuteReader ()) {
			Assert.IsTrue (dr.Read (), "#A1");
			Assert.AreEqual ("Atsushi", dr.GetString (0), "#A2");
			Console.WriteLine (dr.GetDataTypeName (1));
			Assert.AreEqual (5554444523L, dr.GetValue (1), "#A3");
		}

		cmd = new SqlCommand ("SELECT * FROM bug381118 WHERE Name = @name", conn);
		cmd.Parameters.Add (CreateParameter ("@name", SqlDbType.NVarChar, "eer"));

		foreach (Person person in persons) {
			cmd.Parameters ["@name"].Value = person.Name;

			using (SqlDataReader dr = cmd.ExecuteReader ()) {
				Assert.IsTrue (dr.Read (), "#B1");
				Assert.AreEqual (person.Name, dr.GetString (0), "#B2");
				Assert.AreEqual (person.Income, dr.GetValue (1), "#B3");
				Assert.IsFalse (dr.Read (), "#B4");
			}
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

	static SqlParameter CreateParameter (string name, SqlDbType dbType, object value)
	{
		SqlParameter param = new SqlParameter ();
		param.ParameterName = name;
		param.SqlDbType = dbType;
		param.Value = value;
		return param;
	}

	const string drop_database = @"
		IF EXISTS (SELECT * FROM sys.databases WHERE name = N'Mono')
			DROP DATABASE Mono";

	const string create_database = "CREATE DATABASE Mono";

	const string create_table = @"
		CREATE TABLE bug381118
		(
			Name varchar(20),
			Income bigint NULL
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
