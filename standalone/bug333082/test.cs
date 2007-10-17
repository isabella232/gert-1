using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
	[STAThread]
	static int Main ()
	{
		SqlConnection conn = new SqlConnection (CreateConnectionString ());
		conn.Open ();

		IsolationLevel level = GetIsolationLevel (conn, null);
		if (level != IsolationLevel.ReadCommitted)
			return 1;

		ChangeIsolationLevel (conn, null, "SERIALIZABLE");

		level = GetIsolationLevel (conn, null);
		if (level != IsolationLevel.Serializable)
			return 2;

		SqlTransaction trans = conn.BeginTransaction ();
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.ReadCommitted)
			return 3;
		if (trans.IsolationLevel != IsolationLevel.ReadCommitted)
			return 4;
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.Serializable)
			return 5;
		if (trans.IsolationLevel != IsolationLevel.ReadCommitted)
			return 6;
		trans.Rollback ();

#if NET_2_0
		trans = conn.BeginTransaction (IsolationLevel.Unspecified);
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.ReadCommitted)
			return 7;
		if (trans.IsolationLevel != IsolationLevel.ReadCommitted)
			return 8;
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.Serializable)
			return 9;
		if (trans.IsolationLevel != IsolationLevel.ReadCommitted)
			return 10;
		trans.Rollback ();
#endif

		trans = conn.BeginTransaction (IsolationLevel.RepeatableRead);
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.RepeatableRead)
			return 11;
		if (trans.IsolationLevel != IsolationLevel.RepeatableRead)
			return 12;
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.Serializable)
			return 13;
		if (trans.IsolationLevel != IsolationLevel.RepeatableRead)
			return 14;
		trans.Rollback ();

#if NET_2_0
		trans = conn.BeginTransaction (IsolationLevel.Snapshot);
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.Snapshot)
			return 15;
		if (trans.IsolationLevel != IsolationLevel.Snapshot)
			return 16;
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		if (level != IsolationLevel.Serializable)
			return 17;
		if (trans.IsolationLevel != IsolationLevel.Snapshot)
			return 18;
		trans.Rollback ();
#endif

		return 0;
	}

	static IsolationLevel GetIsolationLevel (SqlConnection conn, SqlTransaction trans)
	{
		SqlCommand cmd = new SqlCommand ("DBCC USEROPTIONS", conn, trans);

		using (SqlDataReader dr = cmd.ExecuteReader ()) {
			while (dr.Read ()) {
				string setOption = dr.GetString (0);
				if (setOption != "isolation level")
					continue;

				string isolationLevel = dr.GetString (1);
				switch (isolationLevel) {
				case "read committed":
					return IsolationLevel.ReadCommitted;
				case "repeatable read":
					return IsolationLevel.RepeatableRead;
				case "serializable":
					return IsolationLevel.Serializable;
#if NET_2_0
				case "snapshot":
					return IsolationLevel.Snapshot;
#endif
				default:
					throw new Exception (isolationLevel);
				}
			}
			throw new Exception ("Unable to determine isolation level.");
		}
	}

	static void ChangeIsolationLevel (SqlConnection conn, SqlTransaction trans, string isolationLevel)
	{
		SqlCommand cmd = new SqlCommand ("SET TRANSACTION ISOLATION LEVEL "
			+ isolationLevel, conn, trans);
		cmd.ExecuteNonQuery ();
	}

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
