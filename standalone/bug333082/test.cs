using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

class Program
{
	[STAThread]
	static int Main ()
	{
		SqlConnection conn = new SqlConnection (CreateConnectionString ());
		conn.Open ();

		IsolationLevel level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.ReadCommitted, level, "#A");

		ChangeIsolationLevel (conn, null, "SERIALIZABLE");

		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#B");

		SqlTransaction trans = conn.BeginTransaction ();
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.ReadCommitted, level, "#C1");
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#C2");
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#C3");
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#C4");
		trans.Rollback ();

		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#D");

#if NET_2_0
		trans = conn.BeginTransaction (IsolationLevel.Unspecified);
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.ReadCommitted, level, "#E1");
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#E2");
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#E3");
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#E4");
		trans.Rollback ();
#else
		try {
			conn.BeginTransaction (IsolationLevel.Unspecified);
			Assert.Fail ("#E1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#E2");
			Assert.IsNull (ex.InnerException, "#E3");
			Assert.IsNotNull (ex.Message, "#E4");
			Assert.AreEqual ("Invalid IsolationLevel parameter: must be ReadCommitted, ReadUncommitted, RepeatableRead, or Serializable.", ex.Message, "#E5");
			Assert.IsNull (ex.ParamName, "#E6");
		}
#endif

		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#F");

		trans = conn.BeginTransaction (IsolationLevel.RepeatableRead);
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.RepeatableRead, level, "#G1");
		Assert.AreEqual (IsolationLevel.RepeatableRead, trans.IsolationLevel, "#G2");
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#G3");
		Assert.AreEqual (IsolationLevel.RepeatableRead, trans.IsolationLevel, "#G4");
		trans.Rollback ();

		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#H");

#if NET_2_0
		trans = conn.BeginTransaction (IsolationLevel.Snapshot);
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Snapshot, level, "#I1");
		Assert.AreEqual (IsolationLevel.Snapshot, trans.IsolationLevel, "#I2");
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#I3");
		Assert.AreEqual (IsolationLevel.Snapshot, trans.IsolationLevel, "#I4");
		trans.Rollback ();
#endif

		try {
			conn.BeginTransaction (IsolationLevel.Chaos);
			Assert.Fail ("#J1");
#if NET_2_0
		} catch (ArgumentOutOfRangeException ex) {
			Assert.AreEqual (typeof (ArgumentOutOfRangeException), ex.GetType (), "#J2");
			Assert.IsNull (ex.InnerException, "#J3");
			Assert.IsNotNull (ex.Message, "#J4");
			Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
				"The IsolationLevel enumeration value, 16, is " +
				"not supported by the .Net Framework SqlClient " +
				"Data Provider.{0}Parameter name: IsolationLevel",
				Environment.NewLine), ex.Message, "#J5");
			Assert.IsNotNull (ex.ParamName, "#J6");
			Assert.AreEqual ("IsolationLevel", ex.ParamName, "#J7");
		}
#else
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#J2");
			Assert.IsNull (ex.InnerException, "#J3");
			Assert.IsNotNull (ex.Message, "#J4");
			Assert.AreEqual ("Invalid IsolationLevel parameter: must be ReadCommitted, ReadUncommitted, RepeatableRead, or Serializable.", ex.Message, "#J5");
			Assert.IsNull (ex.ParamName, "#J6");
		}
#endif

		try {
			conn.BeginTransaction ((IsolationLevel) 666);
			Assert.Fail ("#K");
#if NET_2_0
		} catch (ArgumentOutOfRangeException ex) {
			Assert.AreEqual (typeof (ArgumentOutOfRangeException), ex.GetType (), "#K2");
			Assert.IsNull (ex.InnerException, "#K3");
			Assert.IsNotNull (ex.Message, "#K4");
			Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
				"The IsolationLevel enumeration value, 666, " +
				"is invalid.{0}Parameter name: IsolationLevel",
				Environment.NewLine), ex.Message, "#K5");
			Assert.IsNotNull (ex.ParamName, "#K6");
			Assert.AreEqual ("IsolationLevel", ex.ParamName, "#K7");
		}
#else
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#K2");
			Assert.IsNull (ex.InnerException, "#K3");
			Assert.IsNotNull (ex.Message, "#K4");
			Assert.AreEqual ("Invalid IsolationLevel parameter: must be ReadCommitted, ReadUncommitted, RepeatableRead, or Serializable.", ex.Message, "#K5");
			Assert.IsNull (ex.ParamName, "#K6");
		}
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
