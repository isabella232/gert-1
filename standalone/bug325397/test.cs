using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
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

		RunSqlTest ();
		RunOdbcTest ();
#if !MONO
		RunOleDbTest ();
#endif

		return 0;
	}

	static void RunSqlTest ()
	{
		SqlConnection conn = new SqlConnection (CreateSqlConnectionString ());
		conn.Open ();

		SqlCommand cmd = new SqlCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		try {
			using (SqlTransaction trans = conn.BeginTransaction ()) {
				cmd = new SqlCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();

				trans.Commit ();

				Assert.IsNull (trans.Connection, "Connection");

				try {
					trans.Commit ();
					Assert.Fail ("#A1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#A2");
					Assert.IsNull (ex.InnerException, "#A3");
					Assert.IsNotNull (ex.Message, "#A4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#A5");
				}

				try {
					trans.Rollback ();
					Assert.Fail ("#B1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#B2");
					Assert.IsNull (ex.InnerException, "#B3");
					Assert.IsNotNull (ex.Message, "#B4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#B5");
				}

				try {
					trans.Save (string.Empty);
					Assert.Fail ("#C1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#C2");
					Assert.IsNull (ex.InnerException, "#C3");
					Assert.IsNotNull (ex.Message, "#C4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#C5");
				}

				try {
					Assert.Fail ("#D1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#D2");
					Assert.IsNull (ex.InnerException, "#D3");
					Assert.IsNotNull (ex.Message, "#D4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#D5");
				}
			}

			cmd = new SqlCommand (insert_data, conn, null);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			using (SqlTransaction trans = conn.BeginTransaction ()) {
				cmd = new SqlCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();

				trans.Rollback ();

				Assert.IsNull (trans.Connection, "Connection");

				try {
					trans.Rollback ();
					Assert.Fail ("#E1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#E2");
					Assert.IsNull (ex.InnerException, "#E3");
					Assert.IsNotNull (ex.Message, "#E4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#E5");
				}

				try {
					trans.Commit ();
					Assert.Fail ("#F1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#F2");
					Assert.IsNull (ex.InnerException, "#F3");
					Assert.IsNotNull (ex.Message, "#F4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#F5");
				}

				try {
					trans.Save (string.Empty);
					Assert.Fail ("#G1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#G2");
					Assert.IsNull (ex.InnerException, "#G3");
					Assert.IsNotNull (ex.Message, "#G4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#G5");
				}

				try {
					Assert.Fail ("#H1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#H2");
					Assert.IsNull (ex.InnerException, "#H3");
					Assert.IsNotNull (ex.Message, "#H4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#H5");
				}
			}

			cmd = new SqlCommand (create_table, conn, null);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			SqlTransaction trans = conn.BeginTransaction ();
			cmd = new SqlCommand (create_table, conn, trans);
			cmd.ExecuteNonQuery ();
			trans.Dispose ();
			trans.Dispose ();

			Assert.IsNull (trans.Connection, "Connection");

			cmd = new SqlCommand (create_table, conn, null);
			cmd.ExecuteNonQuery ();

#if NET_2_0
			trans.Rollback ();
#else
			try {
				trans.Rollback ();
				Assert.Fail ("#I1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#I2");
				Assert.IsNull (ex.InnerException, "#I3");
				Assert.IsNotNull (ex.Message, "#I4");
				Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#I5");
			}
#endif

			try {
				trans.Commit ();
				Assert.Fail ("#J1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#J2");
				Assert.IsNull (ex.InnerException, "#J3");
				Assert.IsNotNull (ex.Message, "#J4");
				Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#J5");
			}

			try {
				trans.Save (string.Empty);
				Assert.Fail ("#K1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#K2");
				Assert.IsNull (ex.InnerException, "#K3");
				Assert.IsNotNull (ex.Message, "#K4");
				Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#K5");
			}

			try {
				Assert.Fail ("#L1: " + trans.IsolationLevel);
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#L2");
				Assert.IsNull (ex.InnerException, "#L3");
				Assert.IsNotNull (ex.Message, "#L4");
				Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#L5");
			}
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			using (SqlTransaction trans = conn.BeginTransaction ()) {
				cmd = new SqlCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();
				trans.Save ("A");
				trans.Save ("A");

				Assert.IsNotNull (trans.Connection, "Connection");

				trans.Commit ();

				cmd = new SqlCommand (insert_data, conn, null);
				cmd.ExecuteNonQuery ();

				try {
					trans.Rollback ();
					Assert.Fail ("#M1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#M2");
					Assert.IsNull (ex.InnerException, "#M3");
					Assert.IsNotNull (ex.Message, "#M4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#M5");
				}

				try {
					trans.Save (string.Empty);
					Assert.Fail ("#N1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#N2");
					Assert.IsNull (ex.InnerException, "#N3");
					Assert.IsNotNull (ex.Message, "#N4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#N5");
				}

				try {
					Assert.Fail ("#O1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#O2");
					Assert.IsNull (ex.InnerException, "#O3");
					Assert.IsNotNull (ex.Message, "#O4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#O5");
				}
			}
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			using (SqlTransaction trans = conn.BeginTransaction ()) {
				cmd = new SqlCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();
				trans.Save ("A");

				Assert.IsNotNull (trans.Connection, "Connection");

				trans.Rollback ();

				cmd = new SqlCommand (create_table, conn, null);
				cmd.ExecuteNonQuery ();

				try {
					trans.Commit ();
					Assert.Fail ("#P1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#P2");
					Assert.IsNull (ex.InnerException, "#P3");
					Assert.IsNotNull (ex.Message, "#P4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#P5");
				}

				try {
					trans.Save (string.Empty);
					Assert.Fail ("#Q1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#Q2");
					Assert.IsNull (ex.InnerException, "#Q3");
					Assert.IsNotNull (ex.Message, "#Q4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#Q5");
				}

				try {
					Assert.Fail ("#R1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#R2");
					Assert.IsNull (ex.InnerException, "#R3");
					Assert.IsNotNull (ex.Message, "#R4");
					Assert.AreEqual ("This SqlTransaction has completed; it is no longer usable.", ex.Message, "#R5");
				}
			}
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		conn.Dispose ();
	}

	static string CreateSqlConnectionString ()
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

	static void RunOdbcTest ()
	{
		OdbcConnection conn = new OdbcConnection (CreateOdbcConnectionString ());
		conn.Open ();

		OdbcCommand cmd = new OdbcCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		try {
			using (OdbcTransaction trans = conn.BeginTransaction ()) {
				cmd = new OdbcCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();

				trans.Commit ();

				Assert.IsNull (trans.Connection, "Connection");

				try {
					trans.Commit ();
					Assert.Fail ("#A1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#A2");
					Assert.IsNull (ex.InnerException, "#A3");
					Assert.IsNotNull (ex.Message, "#A4");
					Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#A5");
				}

				try {
					trans.Rollback ();
					Assert.Fail ("#B1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#B2");
					Assert.IsNull (ex.InnerException, "#B3");
					Assert.IsNotNull (ex.Message, "#B4");
					Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#B5");
				}

				try {
					Assert.Fail ("#C1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#C2");
					Assert.IsNull (ex.InnerException, "#C3");
					Assert.IsNotNull (ex.Message, "#C4");
					Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#C5");
				}
			}

			cmd = new OdbcCommand (insert_data, conn, null);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new OdbcCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			using (OdbcTransaction trans = conn.BeginTransaction ()) {
				cmd = new OdbcCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();

				trans.Rollback ();

				Assert.IsNull (trans.Connection, "Connection");

				try {
					trans.Rollback ();
					Assert.Fail ("#D1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#D2");
					Assert.IsNull (ex.InnerException, "#D3");
					Assert.IsNotNull (ex.Message, "#D4");
					Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#D5");
				}

				try {
					trans.Commit ();
					Assert.Fail ("#E1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#E2");
					Assert.IsNull (ex.InnerException, "#E3");
					Assert.IsNotNull (ex.Message, "#E4");
					Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#E5");
				}

				try {
					Assert.Fail ("#F1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#F2");
					Assert.IsNull (ex.InnerException, "#F3");
					Assert.IsNotNull (ex.Message, "#F4");
					Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#F5");
				}
			}

			cmd = new OdbcCommand (create_table, conn, null);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new OdbcCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			OdbcTransaction trans = conn.BeginTransaction ();
			cmd = new OdbcCommand (create_table, conn, trans);
			cmd.ExecuteNonQuery ();
			((IDisposable) trans).Dispose ();
			((IDisposable) trans).Dispose ();

			Assert.IsNull (trans.Connection, "Connection");

			cmd = new OdbcCommand (create_table, conn, null);
			cmd.ExecuteNonQuery ();

			try {
				trans.Rollback ();
				Assert.Fail ("#G1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#G2");
				Assert.IsNull (ex.InnerException, "#G3");
				Assert.IsNotNull (ex.Message, "#G4");
				Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#G5");
			}

			try {
				trans.Commit ();
				Assert.Fail ("#H1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#H2");
				Assert.IsNull (ex.InnerException, "#H3");
				Assert.IsNotNull (ex.Message, "#H4");
				Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#H5");
			}

			try {
				Assert.Fail ("#I1: " + trans.IsolationLevel);
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#I2");
				Assert.IsNull (ex.InnerException, "#I3");
				Assert.IsNotNull (ex.Message, "#I4");
				Assert.AreEqual ("This OdbcTransaction has completed; it is no longer usable.", ex.Message, "#I5");
			}
		} finally {
			cmd = new OdbcCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		conn.Dispose ();
	}

	static string CreateOdbcConnectionString ()
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

#if !MONO
	static void RunOleDbTest ()
	{
		OleDbConnection conn = new OleDbConnection (CreateOleDbConnectionString ());
		conn.Open ();

		OleDbCommand cmd = new OleDbCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		try {
			using (OleDbTransaction trans = conn.BeginTransaction ()) {
				cmd = new OleDbCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();

				trans.Commit ();

				Assert.IsNull (trans.Connection, "Connection");

				try {
					trans.Commit ();
					Assert.Fail ("#A1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#A2");
					Assert.IsNull (ex.InnerException, "#A3");
					Assert.IsNotNull (ex.Message, "#A4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#A5");
				}

				try {
					trans.Rollback ();
					Assert.Fail ("#B1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#B2");
					Assert.IsNull (ex.InnerException, "#B3");
					Assert.IsNotNull (ex.Message, "#B4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#B5");
				}

				try {
					Assert.Fail ("#C1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#C2");
					Assert.IsNull (ex.InnerException, "#C3");
					Assert.IsNotNull (ex.Message, "#C4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#C5");
				}

				try {
					trans.Begin ();
					Assert.Fail ("#D1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#D2");
					Assert.IsNull (ex.InnerException, "#D3");
					Assert.IsNotNull (ex.Message, "#D4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#D5");
				}
			}

			cmd = new OleDbCommand (insert_data, conn, null);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new OleDbCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			using (OleDbTransaction trans = conn.BeginTransaction ()) {
				cmd = new OleDbCommand (create_table, conn, trans);
				cmd.ExecuteNonQuery ();

				trans.Rollback ();

				Assert.IsNull (trans.Connection, "Connection");

				try {
					trans.Rollback ();
					Assert.Fail ("#E1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#E2");
					Assert.IsNull (ex.InnerException, "#E3");
					Assert.IsNotNull (ex.Message, "#E4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#E5");
				}

				try {
					trans.Commit ();
					Assert.Fail ("#F1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#F2");
					Assert.IsNull (ex.InnerException, "#F3");
					Assert.IsNotNull (ex.Message, "#F4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#F5");
				}

				try {
					Assert.Fail ("#G1: " + trans.IsolationLevel);
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#G2");
					Assert.IsNull (ex.InnerException, "#G3");
					Assert.IsNotNull (ex.Message, "#G4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#G5");
				}

				try {
					trans.Begin ();
					Assert.Fail ("#H1");
				} catch (InvalidOperationException ex) {
					Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#H2");
					Assert.IsNull (ex.InnerException, "#H3");
					Assert.IsNotNull (ex.Message, "#H4");
					Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#H5");
				}
			}

			cmd = new OleDbCommand (create_table, conn, null);
			cmd.ExecuteNonQuery ();
		} finally {
			cmd = new OleDbCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		try {
			OleDbTransaction trans = conn.BeginTransaction ();
			cmd = new OleDbCommand (create_table, conn, trans);
			cmd.ExecuteNonQuery ();
			((IDisposable) trans).Dispose ();
			((IDisposable) trans).Dispose ();

			Assert.IsNull (trans.Connection, "Connection");

			cmd = new OleDbCommand (create_table, conn, null);
			cmd.ExecuteNonQuery ();

			try {
				trans.Rollback ();
				Assert.Fail ("#I1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#I2");
				Assert.IsNull (ex.InnerException, "#I3");
				Assert.IsNotNull (ex.Message, "#I4");
				Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#I5");
			}

			try {
				trans.Commit ();
				Assert.Fail ("#J1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#J2");
				Assert.IsNull (ex.InnerException, "#J3");
				Assert.IsNotNull (ex.Message, "#J4");
				Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#J5");
			}

			try {
				Assert.Fail ("#K1: " + trans.IsolationLevel);
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#K2");
				Assert.IsNull (ex.InnerException, "#K3");
				Assert.IsNotNull (ex.Message, "#K4");
				Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#K5");
			}

			try {
				trans.Begin ();
				Assert.Fail ("#L1");
			} catch (InvalidOperationException ex) {
				Assert.AreEqual (typeof (InvalidOperationException), ex.GetType (), "#L2");
				Assert.IsNull (ex.InnerException, "#L3");
				Assert.IsNotNull (ex.Message, "#L4");
				Assert.AreEqual ("This OleDbTransaction has completed; it is no longer usable.", ex.Message, "#L5");
			}
		} finally {
			cmd = new OleDbCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		conn.Dispose ();
	}

	static string CreateOleDbConnectionString ()
	{
#if NET_2_0
		OleDbConnectionStringBuilder csb = new OleDbConnectionStringBuilder ();
		csb.Provider = "sqloledb";
#else
		StringBuilder sb = new StringBuilder ();
		sb.Append ("Provider=sqloledb;");
#endif

		string serverName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (serverName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_HOST");
#if NET_2_0
		csb.DataSource = serverName;
#else
		sb.AppendFormat ("Data Source={0};", serverName);
#endif

		string dbName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_DB");
		if (dbName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_DB");
#if NET_2_0
		csb.Add ("Initial Catalog", dbName);
#else
		sb.AppendFormat ("Initial Catalog={0};", dbName);
#endif

		string userName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (userName != null)
#if NET_2_0
			csb.Add ("User id", userName);
#else
			sb.AppendFormat ("User id={0};", userName);
#endif

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd != null)
#if NET_2_0
			csb.Add ("Password", pwd);
#else
			sb.AppendFormat ("Password={0};", pwd);
#endif

#if NET_2_0
		return csb.ToString ();
#else
		return sb.ToString ();
#endif
	}
#endif

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	const string drop_table = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug325397]') AND type = N'U')
			DROP TABLE [dbo].[bug325397]";

	const string create_table = @"
		CREATE TABLE bug325397
		(
			Name varchar(20),
			FirstName varchar (10)
		)";

	const string insert_data = @"
		INSERT INTO bug325397 VALUES (N'de Icaza', N'Miguel');
		INSERT INTO bug325397 VALUES (N'Pobst', N'Jonathan');";
}
