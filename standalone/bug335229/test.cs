using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_ODBC") == null)
			return 0;

		OdbcConnection conn = new OdbcConnection (CreateConnectionString ());
		conn.Open ();

#if !MONO
		IsolationLevel level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.ReadCommitted, level, "#A");
#endif

		ChangeIsolationLevel (conn, null, "SERIALIZABLE");

#if !MONO
		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#B");
#endif

		OdbcTransaction trans = conn.BeginTransaction ();
#if !MONO
		level = GetIsolationLevel (conn, trans);
#if NET_2_0
		Assert.AreEqual (IsolationLevel.Serializable, level, "#C1");
#else
		Assert.AreEqual (IsolationLevel.ReadCommitted, level, "#C1");
#endif
#endif
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#C2");
		ChangeIsolationLevel (conn, trans, "REPEATABLE READ");
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.RepeatableRead, level, "#C3");
#endif
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#C4");
		trans.Rollback ();

#if !MONO
		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.RepeatableRead, level, "#D");
#endif

		trans = conn.BeginTransaction (IsolationLevel.Unspecified);
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.RepeatableRead, level, "#E1");
#endif
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#E2");
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#E3");
#endif
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#E4");
		trans.Rollback ();

		ChangeIsolationLevel (conn, null, "REPEATABLE READ");

		trans = conn.BeginTransaction (IsolationLevel.Unspecified);
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.RepeatableRead, level, "#F1");
#endif
		ChangeIsolationLevel (conn, trans, "READ UNCOMMITTED");
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.ReadUncommitted, level, "#F3");
#endif
		Assert.AreEqual (IsolationLevel.ReadCommitted, trans.IsolationLevel, "#F4");
		trans.Rollback ();

#if !MONO
		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.ReadUncommitted, level, "#G");
#endif

		trans = conn.BeginTransaction (IsolationLevel.RepeatableRead);
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.RepeatableRead, level, "#H1");
#endif
		Assert.AreEqual (IsolationLevel.RepeatableRead, trans.IsolationLevel, "#H2");
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#H3");
#endif
		Assert.AreEqual (IsolationLevel.RepeatableRead, trans.IsolationLevel, "#H4");
		trans.Rollback ();

#if !MONO
		level = GetIsolationLevel (conn, null);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#I");
#endif

		// Snapshot is badly broken on MS.NET 2.0:
		//https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=305736
#if NET_2_0 && MONO
		trans = conn.BeginTransaction (IsolationLevel.Snapshot);
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Snapshot, level, "#J1");
#endif
		Assert.AreEqual (IsolationLevel.Snapshot, trans.IsolationLevel, "#J2");
		ChangeIsolationLevel (conn, trans, "SERIALIZABLE");
#if !MONO
		level = GetIsolationLevel (conn, trans);
		Assert.AreEqual (IsolationLevel.Serializable, level, "#J3");
#endif
		Assert.AreEqual (IsolationLevel.Snapshot, trans.IsolationLevel, "#J4");
		trans.Rollback ();
#endif

		try {
			conn.BeginTransaction (IsolationLevel.Chaos);
			Assert.Fail ("#K1");
#if NET_2_0
		} catch (ArgumentOutOfRangeException ex) {
			Assert.AreEqual (typeof (ArgumentOutOfRangeException), ex.GetType (), "#K2");
			Assert.IsNull (ex.InnerException, "#K3");
			Assert.IsNotNull (ex.Message, "#K4");
			Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
				"The IsolationLevel enumeration value, 16, is " +
				"not supported by the .Net Framework Odbc Data " +
				"Provider.{0}Parameter name: IsolationLevel",
				Environment.NewLine), ex.Message, "#K5");
			Assert.IsNotNull (ex.ParamName, "#K6");
			Assert.AreEqual ("IsolationLevel", ex.ParamName, "#K7");
		}
#else
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#K2");
			Assert.IsNull (ex.InnerException, "#K3");
			Assert.IsNotNull (ex.Message, "#K4");
			Assert.AreEqual ("Not supported isolationlevel - Chaos", ex.Message, "#K5");
			Assert.IsNull (ex.ParamName, "#K6");
		}
#endif

		try {
			conn.BeginTransaction ((IsolationLevel) 666);
			Assert.Fail ("#L");
#if NET_2_0
		} catch (ArgumentOutOfRangeException ex) {
			Assert.AreEqual (typeof (ArgumentOutOfRangeException), ex.GetType (), "#L2");
			Assert.IsNull (ex.InnerException, "#L3");
			Assert.IsNotNull (ex.Message, "#L4");
			Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
				"The IsolationLevel enumeration value, 666, " +
				"is invalid.{0}Parameter name: IsolationLevel",
				Environment.NewLine), ex.Message, "#L5");
			Assert.IsNotNull (ex.ParamName, "#L6");
			Assert.AreEqual ("IsolationLevel", ex.ParamName, "#L7");
		}
#else
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#L2");
			Assert.IsNull (ex.InnerException, "#L3");
			Assert.IsNotNull (ex.Message, "#L4");
			Assert.AreEqual ("Not supported isolationlevel - 666", ex.Message, "#L5");
			Assert.IsNull (ex.ParamName, "#L6");
		}
#endif

		return 0;
	}

#if !MONO
	static IsolationLevel GetIsolationLevel (OdbcConnection conn, OdbcTransaction trans)
	{
		OdbcCommand cmd = new OdbcCommand ("DBCC USEROPTIONS", conn, trans);

		using (OdbcDataReader dr = cmd.ExecuteReader ()) {
			while (dr.Read ()) {
				string setOption = dr.GetString (0);
				if (setOption != "isolation level")
					continue;

				string isolationLevel = dr.GetString (1);
				switch (isolationLevel) {
				case "read uncommitted":
					return IsolationLevel.ReadUncommitted;
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
#endif

	static void ChangeIsolationLevel (OdbcConnection conn, OdbcTransaction trans, string isolationLevel)
	{
		OdbcCommand cmd = new OdbcCommand ("SET TRANSACTION ISOLATION LEVEL "
			+ isolationLevel, conn, trans);
		cmd.ExecuteNonQuery ();
	}

	static string CreateConnectionString ()
	{
#if NET_2_0
		OdbcConnectionStringBuilder csb = new OdbcConnectionStringBuilder ();
		csb.Driver = "SQL Native Client";
#else
		StringBuilder sb = new StringBuilder ();
		sb.Append ("Driver={SQL Native Client};");
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
}
