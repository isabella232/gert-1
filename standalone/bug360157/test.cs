using System;
using System.Data.SqlClient;

class Program
{
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		string connectionString = CreateConnectionString ();

		DateTime start = DateTime.Now;

		try {
			using (SqlConnection sqlConnection = new SqlConnection (connectionString)) {
				sqlConnection.Open ();
			}
			return 1;
		} catch (SqlException) {
		}

		try {
			using (SqlConnection sqlConnection = new SqlConnection (connectionString)) {
				sqlConnection.Open ();
			}
			return 2;
		} catch (SqlException) {
		}

		TimeSpan elapsed = DateTime.Now - start;
		if (elapsed.TotalMilliseconds > 5000)
			return 3;

		return 0;
	}

	static string CreateConnectionString ()
	{
		string server = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (server == null)
			throw new ArgumentException ("The MONO_TESTS_SQL_HOST environment variable is not set.");

		string user = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (user == null)
			throw new ArgumentException ("The MONO_TESTS_SQL_USER environment variable is not set.");

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd == null)
			throw new ArgumentException ("The MONO_TESTS_SQL_PWD environment variable is not set.");

		return string.Format ("Server={0};Database=DoesNotExist;Pooling=true;" +
			"Connection Lifetime=60;Connect Timeout=500;Max Pool Size=1;UID={1};" +
			"Password={2}", server, user, pwd);
	}
}
