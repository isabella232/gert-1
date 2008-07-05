using System;
using System.Data.SqlClient;

class Program
{
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		string server;
		string connectionString;
		DateTime start;
		TimeSpan elapsed;

		server = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (server == null)
			throw new ArgumentException ("The MONO_TESTS_SQL_HOST environment variable is not set.");

		connectionString = CreateConnectionString (server);

		start = DateTime.Now;

		try {
			using (SqlConnection sqlConnection = new SqlConnection (connectionString)) {
				sqlConnection.Open ();
			}
			Assert.Fail ("#A");
		} catch (SqlException) {
			// Cannot open database "DoesNotExist" requested by the login. The login failed.
			// Login failed for user 'sa'
		}

		try {
			using (SqlConnection sqlConnection = new SqlConnection (connectionString)) {
				sqlConnection.Open ();
			}
			Assert.Fail ("#B");
		} catch (SqlException) {
		}

		elapsed = DateTime.Now - start;

		Assert.IsTrue (elapsed.TotalMilliseconds < 5000, "#C:" + elapsed.TotalMilliseconds);

		connectionString = CreateConnectionString ("ZZZ");

		start = DateTime.Now;

		try {
			using (SqlConnection sqlConnection = new SqlConnection (connectionString)) {
				sqlConnection.Open ();
			}
			return 4;
		} catch (SqlException) {
			// An error has occurred while establishing a connection
			// to the server.  When connecting to SQL Server 2005,
			// this failure may be caused by the fact that under the
			// default settings SQL Server does not allow remote
			// connections. (provider: Named Pipes Provider, error:
			// 40 - Could not open a connection to SQL Server)
		}

		try {
			using (SqlConnection sqlConnection = new SqlConnection (connectionString)) {
				sqlConnection.Open ();
			}
			return 5;
		} catch (SqlException) {
			// An error has occurred while establishing a connection
			// to the server.  When connecting to SQL Server 2005,
			// this failure may be caused by the fact that under the
			// default settings SQL Server does not allow remote
			// connections. (provider: Named Pipes Provider, error:
			// 40 - Could not open a connection to SQL Server)
		}

		elapsed = DateTime.Now - start;

		Assert.IsTrue (elapsed.TotalMilliseconds > 30000, "#F1:" + elapsed.TotalMilliseconds);
		Assert.IsTrue (elapsed.TotalMilliseconds < 80000, "#F2:" + elapsed.TotalMilliseconds);

		return 0;
	}

	static string CreateConnectionString (string server)
	{
		string user = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (user == null)
			throw new ArgumentException ("The MONO_TESTS_SQL_USER environment variable is not set.");

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd == null)
			throw new ArgumentException ("The MONO_TESTS_SQL_PWD environment variable is not set.");

		return string.Format ("Server={0};Database=DoesNotExist;Pooling=true;" +
			"Connection Lifetime=60;Connect Timeout=25;Max Pool Size=1;UID={1};" +
			"Password={2}", server, user, pwd);
	}
}
