using System;
using System.Data;
using System.Data.Odbc;
using System.Text;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_SQL") == null)
			return 0;

		OdbcConnection conn;
		OdbcCommand cmd;

		conn = new OdbcConnection (CreateConnectionString ());
		conn.Open ();

		try {
			cmd = conn.CreateCommand ();
			cmd.CommandText = drop_table;
			cmd.ExecuteNonQuery ();

			cmd = conn.CreateCommand ();
			cmd.CommandText = create_table;
			cmd.ExecuteNonQuery ();

			cmd = conn.CreateCommand ();
			cmd.CommandText = insert_data;
			cmd.ExecuteNonQuery ();

			cmd = conn.CreateCommand();
			cmd.CommandText = "select * from bug318854";

			IDbDataAdapter da = new OdbcDataAdapter ();
			DataSet ds = new DataSet ();
			da.SelectCommand = cmd;
			if (da.Fill (ds) != 2)
				return 1;
			return 0;
		} finally {
			cmd = conn.CreateCommand ();
			cmd.CommandText = drop_table;
			cmd.ExecuteNonQuery ();

			conn.Dispose ();
		}
	}

	static string CreateConnectionString ()
	{
#if NET_2_0
		OdbcConnectionStringBuilder csb = new OdbcConnectionStringBuilder ();
		csb.Driver = "SQL Server";
#else
		StringBuilder sb = new StringBuilder ();
		sb.Append ("Driver={SQL Server};");
#endif

		string serverName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (serverName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_HOST");
#if NET_2_0
		csb.Add ("Server", serverName);
#else
		sb.AppendFormat ("Server={0};", serverName);
#endif

		string dbName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_DB");
		if (dbName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_DB");
#if NET_2_0
		csb.Add ("Database", dbName);
#else
		sb.AppendFormat ("Database={0};", dbName);
#endif

		string userName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (userName != null)
#if NET_2_0
			csb.Add ("Uid", userName);
#else
			sb.AppendFormat ("Uid={0};", userName);
#endif

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd != null)
#if NET_2_0
			csb.Add ("Pwd", pwd);
#else
			sb.AppendFormat ("Pwd={0};", pwd);
#endif

#if NET_2_0
		return csb.ToString ();
#else
		return sb.ToString ();
#endif
	}

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	const string drop_table = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug318854]') AND type = N'U')
			DROP TABLE [dbo].[bug318854]";

	const string create_table = @"
		CREATE TABLE bug318854 (
			StoreKey int NOT NULL,
			BatchNo int NOT NULL,
			RecordType smallint NOT NULL,
			RealField real
		);";

	const string insert_data = @"
		INSERT INTO bug318854 (StoreKey, BatchNo, RecordType, RealField)
		VALUES
		(1, 1, 145.334, 22);
		INSERT INTO bug318854 (StoreKey, BatchNo, RecordType, RealField)
		VALUES
		(3, 5, 156, 23);";
}
