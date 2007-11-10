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
		Person personA = new Person ("de Icaza", "Miguel",
			new DateTime (1925, 1, 31, 5, 8, 29, 998),
			new DateTime (1925, 1, 31, 5, 8, 0),
			new DateTime (2004, 4, 20, 3, 43, 55, 567));
		Person personB = new Person ("Pobst", "Jonathan",
			new DateTime (2007, 12, 01, 7, 9, 29, 999),
			new DateTime (2007, 12, 01, 7, 10, 0),
			new DateTime (2006, 12, 30, 23, 05, 1, 3));
		Person personC = new Person ("Toshok", "Chris",
			new DateTime (1973, 8, 13, 0, 0, 0),
			new DateTime (1973, 8, 13, 0, 0, 0),
			new DateTime (2004, 4, 20, 3, 43, 55, 563));
		Person personD = new Person ("Harper", "Jackson",
			new DateTime (1973, 8, 13, 0, 0, 59, 2),
			new DateTime (1973, 8, 13, 0, 1, 0),
			new DateTime (2004, 4, 20, 3, 43, 54, 0));
		persons.AddRange (new Person [] { personA, personB, personC, personD });

		SqlCommand cmd = new SqlCommand (create_table, conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		cmd = new SqlCommand ("INSERT INTO bug323646 VALUES (@name, @firstName, @birthDate, @created)", conn);
		foreach (Person person in persons) {
			cmd.Parameters.Add (CreateParameter ("@name", person.Name));
			cmd.Parameters.Add (CreateParameter ("@firstName", person.FirstName));
			cmd.Parameters.Add (CreateParameter ("@BirthdatE", person.BirthDate));
			cmd.Parameters.Add (CreateParameter ("@created", person.Created));
			cmd.ExecuteNonQuery ();
			cmd.Parameters.Clear ();
		}
		cmd.Dispose ();

		cmd = new SqlCommand ("SELECT * FROM bug323646 WHERE Created = @created", conn);
		cmd.Parameters.Add (CreateParameter ("@created", DateTime.Now));

		using (SqlDataReader dr = cmd.ExecuteReader ()) {
			Assert.IsFalse (dr.Read (), "#A");
		}

		foreach (Person person in persons) {
			cmd.Parameters ["@created"].Value = person.Created;

			using (SqlDataReader dr = cmd.ExecuteReader ()) {
				Assert.IsTrue (dr.Read (), "#B1");
				Assert.AreEqual (person.Name, dr.GetString (0), "#B2");
				Assert.AreEqual (person.FirstName, dr.GetString (1), "#B3");

				DateTime birthDate = (DateTime) dr.GetValue (2);
				Assert.AreEqual (person.ExpectedBirthDate, birthDate, "#B4");
				Assert.AreEqual (person.Created, dr.GetDateTime (3), "#B5");
				Assert.IsFalse (dr.Read (), "#B6");
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

	const string create_table = @"
		CREATE TABLE bug323646
		(
			Name varchar(20),
			FirstName varchar (10),
			BirthDate smalldatetime,
			Created datetime
		)";
}

class Person
{
	public Person (string name, string firstName, DateTime birthDate, DateTime expectedBirthDate, DateTime created)
	{
		_name = name;
		_firstName = firstName;
		_birthDate = birthDate;
		_expectedBirthDate = expectedBirthDate;
		_created = created;
	}

	public string Name {
		get { return _name; }
	}

	public string FirstName {
		get { return _firstName; }
	}

	public DateTime BirthDate {
		get { return _birthDate; }
	}

	public DateTime ExpectedBirthDate {
		get { return _expectedBirthDate; }
	}

	public DateTime Created {
		get { return _created; }
	}

	private string _name;
	private string _firstName;
	private DateTime _birthDate;
	private DateTime _expectedBirthDate;
	private DateTime _created;
}
