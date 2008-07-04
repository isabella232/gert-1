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

		SqlConnection conn = new SqlConnection (CreateSqlConnectionString ());
		conn.Open ();

		SqlCommand cmd = new SqlCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		try {
			cmd = new SqlCommand (create_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new SqlCommand (insert_data, conn);
			cmd.ExecuteNonQuery ();

			SqlDataAdapter da = new SqlDataAdapter ();

			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			DataTable dtA = new DataTable ();
			DataTable dtB = new DataTable ();

			cmd = new SqlCommand ("SELECT FirstName, Name, Weight, Age, Id FROM bug406556", conn);
			da.SelectCommand = cmd;
			da.Fill (dtA);

			Assert.AreEqual (5, dtA.Columns.Count, "#A1");
			Assert.AreEqual (2, dtA.Rows.Count, "#A2");
#if NET_2_0 && !MONO
			Assert.AreEqual ("bug406556", dtA.TableName, "#A3");
#else
			Assert.AreEqual (string.Empty, dtA.TableName, "#A3");
#endif

			DataRow dr;
			DataColumn col;

			col = dtA.Columns [0];
			Assert.IsTrue (col.AllowDBNull, "#B1");
			Assert.AreEqual ("FirstName", col.ColumnName, "#B2");
			Assert.AreEqual (typeof (string), col.DataType, "#B3");
			Assert.AreEqual (DBNull.Value, col.DefaultValue, "#B4");
			Assert.AreEqual (15, col.MaxLength, "#B5");
			Assert.AreEqual (0, col.Ordinal, "#B6");

			col = dtA.Columns [1];
			Assert.IsFalse (col.AllowDBNull, "#C1");
			Assert.AreEqual ("Name", col.ColumnName, "#C2");
			Assert.AreEqual (typeof (string), col.DataType, "#C3");
			Assert.AreEqual (DBNull.Value, col.DefaultValue, "#C4");
			Assert.AreEqual (20, col.MaxLength, "#C5");
			Assert.AreEqual (1, col.Ordinal, "#C6");

			col = dtA.Columns [2];
			Assert.IsFalse (col.AllowDBNull, "#D1");
			Assert.AreEqual ("Weight", col.ColumnName, "#D2");
			Assert.AreEqual (typeof (int), col.DataType, "#D3");
			Assert.AreEqual (DBNull.Value, col.DefaultValue, "#D4");
			Assert.AreEqual (-1, col.MaxLength, "#D5");
			Assert.AreEqual (2, col.Ordinal, "#D6");

			col = dtA.Columns [3];
			Assert.IsTrue (col.AllowDBNull, "#E1");
			Assert.AreEqual ("Age", col.ColumnName, "#E2");
			Assert.AreEqual (typeof (int), col.DataType, "#E3");
			Assert.AreEqual (DBNull.Value, col.DefaultValue, "#E4");
			Assert.AreEqual (-1, col.MaxLength, "#E5");
			Assert.AreEqual (3, col.Ordinal, "#E6");

			col = dtA.Columns [4];
			Assert.IsFalse (col.AllowDBNull, "#F1");
			Assert.AreEqual ("Id", col.ColumnName, "#F2");
			Assert.AreEqual (typeof (int), col.DataType, "#F3");
			Assert.AreEqual (DBNull.Value, col.DefaultValue, "#F4");
			Assert.AreEqual (-1, col.MaxLength, "#F5");
			Assert.AreEqual (4, col.Ordinal, "#F6");

			dr = dtA.Rows [0];

			Assert.AreEqual ("Miguel", dr [0], "#G1");
			Assert.AreEqual ("de Icaza", dr [1], "#G2");
			Assert.AreEqual (66, dr [2], "#G3");
			Assert.AreEqual (24, dr [3], "#G4");
			Assert.AreEqual (1, dr [4], "#G5");

			dr [0] = "Atsushi";
			dr [1] = "Eno";
			dr [2] = 62;
			dr [3] = 25;

			Assert.AreEqual ("Atsushi", dr [0], "#H1");
			Assert.AreEqual ("Eno", dr [1], "#H2");
			Assert.AreEqual (62, dr [2], "#H3");
			Assert.AreEqual (25, dr [3], "#H4");
			Assert.AreEqual (1, dr [4], "#H5");

			dr = dtA.Rows [1];

			Assert.AreEqual ("Jonathan", dr [0], "#I1");
			Assert.AreEqual ("Pobst", dr [1], "#I2");
			Assert.AreEqual (68, dr [2], "#I3");
			Assert.AreEqual (33, dr [3], "#I4");
			Assert.AreEqual (2, dr [4], "#I5");

			dr [0] = "Jackson";
			dr [1] = "Harper";
			dr [2] = 72;
			dr [3] = 28;

			Assert.AreEqual ("Jackson", dr [0], "#J1");
			Assert.AreEqual ("Harper", dr [1], "#J2");
			Assert.AreEqual (72, dr [2], "#J3");
			Assert.AreEqual (28, dr [3], "#J4");
			Assert.AreEqual (2, dr [4], "#J5");

			da.Fill (dtB);

			Assert.AreEqual (5, dtB.Columns.Count, "#K1");
			Assert.AreEqual (2, dtB.Rows.Count, "#K2");
#if NET_2_0 && !MONO
			Assert.AreEqual ("bug406556", dtB.TableName, "#K3");
#else
			Assert.AreEqual (string.Empty, dtB.TableName, "#K3");
#endif

			dr = dtB.Rows [0];

			Assert.AreEqual ("Miguel", dr [0], "#L1");
			Assert.AreEqual ("de Icaza", dr [1], "#L2");
			Assert.AreEqual (66, dr [2], "#L3");
			Assert.AreEqual (24, dr [3], "#L4");
			Assert.AreEqual (1, dr [4], "#L5");

			dr = dtB.Rows [1];

			Assert.AreEqual ("Jonathan", dr [0], "#M1");
			Assert.AreEqual ("Pobst", dr [1], "#M2");
			Assert.AreEqual (68, dr [2], "#M3");
			Assert.AreEqual (33, dr [3], "#M4");
			Assert.AreEqual (2, dr [4], "#M5");

			SqlCommandBuilder builder = new SqlCommandBuilder (da);
			da.UpdateCommand = builder.GetUpdateCommand ();
			da.Update (dtA);

			dtB = new DataTable ();
			da.Fill (dtB);

			Assert.AreEqual (5, dtB.Columns.Count, "#N1");
			Assert.AreEqual (2, dtB.Rows.Count, "#N2");
#if NET_2_0 && !MONO
			Assert.AreEqual ("bug406556", dtB.TableName, "#N3");
#else
			Assert.AreEqual (string.Empty, dtB.TableName, "#N3");
#endif

			dr = dtB.Rows [0];

			Assert.AreEqual ("Atsushi", dr [0], "#O1");
			Assert.AreEqual ("Eno", dr [1], "#O2");
			Assert.AreEqual (62, dr [2], "#O3");
			Assert.AreEqual (25, dr [3], "#O4");

			dr = dtB.Rows [1];

			Assert.AreEqual ("Jackson", dr [0], "#P1");
			Assert.AreEqual ("Harper", dr [1], "#P2");
			Assert.AreEqual (72, dr [2], "#P3");
			Assert.AreEqual (28, dr [3], "#P4");

			dr = dtA.Rows [0];

			dr [0] = null;
			dr [1] = "Toshok";
			dr [2] = 59;
			dr [3] = DBNull.Value;

			dr = dtA.Rows [1];

			dr [0] = DBNull.Value;
			dr [1] = "Vargaz";
			dr [2] = 54;
			dr [3] = DBNull.Value;

			da.Update (dtA);

			dtB = new DataTable ();
			da.Fill (dtB);

			Assert.AreEqual (5, dtB.Columns.Count, "#Q1");
			Assert.AreEqual (2, dtB.Rows.Count, "#Q2");
#if NET_2_0 && !MONO
			Assert.AreEqual ("bug406556", dtB.TableName, "#Q3");
#else
			Assert.AreEqual (string.Empty, dtB.TableName, "#Q3");
#endif

			dr = dtB.Rows [0];

			Assert.AreEqual (DBNull.Value, dr [0], "#R1");
			Assert.AreEqual ("Toshok", dr [1], "#R2");
			Assert.AreEqual (59, dr [2], "#R3");
			Assert.AreEqual (DBNull.Value, dr [3], "#R4");

			dr = dtB.Rows [1];

			Assert.AreEqual (DBNull.Value, dr [0], "#S1");
			Assert.AreEqual ("Vargaz", dr [1], "#S2");
			Assert.AreEqual (54, dr [2], "#S3");
			Assert.AreEqual (DBNull.Value, dr [3], "#S4");

			SqlDataReader reader = cmd.ExecuteReader ();

			DataTable schema = reader.GetSchemaTable ();
			Assert.IsNotNull (schema, "#T1");
			Assert.AreEqual (5, schema.Rows.Count, "#T2");
#if NET_2_0 && !MONO
			Assert.AreEqual (30, schema.Columns.Count, "#T3");
#else
			Assert.AreEqual (23, schema.Columns.Count, "#T3");
#endif
			reader.Close ();

			dr = schema.Rows [0];

			Assert.AreEqual ("FirstName", dr ["ColumnName"], "#U1");
			Assert.AreEqual (0, dr ["ColumnOrdinal"], "#U2");
			Assert.AreEqual (false, dr ["IsUnique"], "#U3");
			Assert.AreEqual (false, dr ["IsAutoIncrement"], "#U4");
			Assert.AreEqual (false, dr ["IsRowVersion"], "#U5");
#if MONO
			Assert.AreEqual (false, dr ["IsHidden"], "#U6");
#else
			Assert.AreEqual (DBNull.Value, dr ["IsHidden"], "#U6");
#endif
			Assert.AreEqual (false, dr ["IsIdentity"], "#U7");
			Assert.AreEqual (15, dr ["ColumnSize"], "#U8");
#if MONO
			Assert.AreEqual ((short) 0, dr ["NumericPrecision"], "#U9");
			Assert.AreEqual ((short) 0, dr ["NumericScale"], "#U10");
#else
			Assert.AreEqual ((short) 255, dr ["NumericPrecision"], "#U9");
			Assert.AreEqual ((short) 255, dr ["NumericScale"], "#U10");
#endif
			Assert.AreEqual (DBNull.Value, dr ["IsKey"], "#U11");
			Assert.AreEqual (DBNull.Value, dr ["IsAliased"], "#U12");
			Assert.AreEqual (DBNull.Value, dr ["IsExpression"], "#U13");
			Assert.AreEqual (false, dr ["IsReadOnly"], "#U14");
			Assert.AreEqual (DBNull.Value, dr ["BaseServerName"], "#U15");
			Assert.AreEqual (DBNull.Value, dr ["BaseCatalogName"], "#U16");
			Assert.AreEqual ("FirstName", dr ["BaseColumnName"], "#U17");
			Assert.AreEqual (DBNull.Value, dr ["BaseSchemaName"], "#U18");
			Assert.AreEqual (DBNull.Value, dr ["BaseTableName"], "#U19");
			Assert.AreEqual (true, dr ["AllowDBNull"], "#U20");
			Assert.AreEqual (typeof (string), dr ["DataType"], "#U21");
			Assert.AreEqual (22, dr ["ProviderType"], "#U22");
			Assert.AreEqual (false, dr ["IsLong"], "#U23");

			dr = schema.Rows [1];

			Assert.AreEqual ("Name", dr ["ColumnName"], "#V1");
			Assert.AreEqual (1, dr ["ColumnOrdinal"], "#V2");
			Assert.AreEqual (false, dr ["IsUnique"], "#V3");
			Assert.AreEqual (false, dr ["IsAutoIncrement"], "#V4");
			Assert.AreEqual (false, dr ["IsRowVersion"], "#V5");
#if MONO
			Assert.AreEqual (false, dr ["IsHidden"], "#V6");
#else
			Assert.AreEqual (DBNull.Value, dr ["IsHidden"], "#V6");
#endif
			Assert.AreEqual (false, dr ["IsIdentity"], "#V7");
			Assert.AreEqual (20, dr ["ColumnSize"], "#V8");
#if MONO
			Assert.AreEqual ((short) 0, dr ["NumericPrecision"], "#V9");
			Assert.AreEqual ((short) 0, dr ["NumericScale"], "#V10");
#else
			Assert.AreEqual ((short) 255, dr ["NumericPrecision"], "#V9");
			Assert.AreEqual ((short) 255, dr ["NumericScale"], "#V10");
#endif
			Assert.AreEqual (DBNull.Value, dr ["IsKey"], "#V11");
			Assert.AreEqual (DBNull.Value, dr ["IsAliased"], "#V12");
			Assert.AreEqual (DBNull.Value, dr ["IsExpression"], "#V13");
			Assert.AreEqual (false, dr ["IsReadOnly"], "#V14");
			Assert.AreEqual (DBNull.Value, dr ["BaseServerName"], "#V15");
			Assert.AreEqual (DBNull.Value, dr ["BaseCatalogName"], "#V16");
			Assert.AreEqual ("Name", dr ["BaseColumnName"], "#V17");
			Assert.AreEqual (DBNull.Value, dr ["BaseSchemaName"], "#V18");
			Assert.AreEqual (DBNull.Value, dr ["BaseTableName"], "#V19");
			Assert.AreEqual (false, dr ["AllowDBNull"], "#V20");
			Assert.AreEqual (typeof (string), dr ["DataType"], "#V21");
			Assert.AreEqual (22, dr ["ProviderType"], "#V22");
			Assert.AreEqual (false, dr ["IsLong"], "#V23");

			dr = schema.Rows [2];

			Assert.AreEqual ("Weight", dr ["ColumnName"], "#W1");
			Assert.AreEqual (2, dr ["ColumnOrdinal"], "#W2");
			Assert.AreEqual (false, dr ["IsUnique"], "#W3");
			Assert.AreEqual (false, dr ["IsAutoIncrement"], "#W4");
			Assert.AreEqual (false, dr ["IsRowVersion"], "#W5");
#if MONO
			Assert.AreEqual (false, dr ["IsHidden"], "#W6");
#else
			Assert.AreEqual (DBNull.Value, dr ["IsHidden"], "#W6");
#endif
			Assert.AreEqual (false, dr ["IsIdentity"], "#W7");
			Assert.AreEqual (4, dr ["ColumnSize"], "#W8");
#if MONO
			Assert.AreEqual ((short) 0, dr ["NumericPrecision"], "#W9");
			Assert.AreEqual ((short) 0, dr ["NumericScale"], "#W10");
#else
			Assert.AreEqual ((short) 10, dr ["NumericPrecision"], "#W9");
			Assert.AreEqual ((short) 255, dr ["NumericScale"], "#W10");
#endif
			Assert.AreEqual (DBNull.Value, dr ["IsKey"], "#W11");
			Assert.AreEqual (DBNull.Value, dr ["IsAliased"], "#W12");
			Assert.AreEqual (DBNull.Value, dr ["IsExpression"], "#W13");
			Assert.AreEqual (false, dr ["IsReadOnly"], "#W14");
			Assert.AreEqual (DBNull.Value, dr ["BaseServerName"], "#W15");
			Assert.AreEqual (DBNull.Value, dr ["BaseCatalogName"], "#W16");
			Assert.AreEqual ("Weight", dr ["BaseColumnName"], "#W17");
			Assert.AreEqual (DBNull.Value, dr ["BaseSchemaName"], "#W18");
			Assert.AreEqual (DBNull.Value, dr ["BaseTableName"], "#W19");
			Assert.AreEqual (false, dr ["AllowDBNull"], "#W20");
			Assert.AreEqual (typeof (int), dr ["DataType"], "#W21");
			Assert.AreEqual (8, dr ["ProviderType"], "#W22");
			Assert.AreEqual (false, dr ["IsLong"], "#W23");

			dr = schema.Rows [3];

			Assert.AreEqual ("Age", dr ["ColumnName"], "#X1");
			Assert.AreEqual (3, dr ["ColumnOrdinal"], "#X2");
			Assert.AreEqual (false, dr ["IsUnique"], "#X3");
			Assert.AreEqual (false, dr ["IsAutoIncrement"], "#X4");
			Assert.AreEqual (false, dr ["IsRowVersion"], "#X5");
#if MONO
			Assert.AreEqual (false, dr ["IsHidden"], "#X6");
#else
			Assert.AreEqual (DBNull.Value, dr ["IsHidden"], "#X6");
#endif
			Assert.AreEqual (false, dr ["IsIdentity"], "#X7");
			Assert.AreEqual (4, dr ["ColumnSize"], "#X8");
#if MONO
			Assert.AreEqual ((short) 0, dr ["NumericPrecision"], "#X9");
			Assert.AreEqual ((short) 0, dr ["NumericScale"], "#X10");
#else
			Assert.AreEqual ((short) 10, dr ["NumericPrecision"], "#X9");
			Assert.AreEqual ((short) 255, dr ["NumericScale"], "#X10");
#endif
			Assert.AreEqual (DBNull.Value, dr ["IsKey"], "#X11");
			Assert.AreEqual (DBNull.Value, dr ["IsAliased"], "#X12");
			Assert.AreEqual (DBNull.Value, dr ["IsExpression"], "#X13");
			Assert.AreEqual (false, dr ["IsReadOnly"], "#X14");
			Assert.AreEqual (DBNull.Value, dr ["BaseServerName"], "#X15");
			Assert.AreEqual (DBNull.Value, dr ["BaseCatalogName"], "#X16");
			Assert.AreEqual ("Age", dr ["BaseColumnName"], "#X17");
			Assert.AreEqual (DBNull.Value, dr ["BaseSchemaName"], "#X18");
			Assert.AreEqual (DBNull.Value, dr ["BaseTableName"], "#X19");
			Assert.AreEqual (true, dr ["AllowDBNull"], "#X20");
			Assert.AreEqual (typeof (int), dr ["DataType"], "#X21");
			Assert.AreEqual (8, dr ["ProviderType"], "#X22");
			Assert.AreEqual (false, dr ["IsLong"], "#X23");

			dr = schema.Rows [4];

			Assert.AreEqual ("Id", dr ["ColumnName"], "#Y1");
			Assert.AreEqual (4, dr ["ColumnOrdinal"], "#Y2");
			Assert.AreEqual (false, dr ["IsUnique"], "#Y3");
			Assert.AreEqual (true, dr ["IsAutoIncrement"], "#Y4");
			Assert.AreEqual (false, dr ["IsRowVersion"], "#Y5");
#if MONO
			Assert.AreEqual (false, dr ["IsHidden"], "#Y6");
#else
			Assert.AreEqual (DBNull.Value, dr ["IsHidden"], "#Y6");
#endif
			Assert.AreEqual (true, dr ["IsIdentity"], "#Y7");
			Assert.AreEqual (4, dr ["ColumnSize"], "#Y8");
#if MONO
			Assert.AreEqual ((short) 0, dr ["NumericPrecision"], "#Y9");
			Assert.AreEqual ((short) 0, dr ["NumericScale"], "#Y10");
#else
			Assert.AreEqual ((short) 10, dr ["NumericPrecision"], "#Y9");
			Assert.AreEqual ((short) 255, dr ["NumericScale"], "#Y10");
#endif
			Assert.AreEqual (DBNull.Value, dr ["IsKey"], "#Y11");
			Assert.AreEqual (DBNull.Value, dr ["IsAliased"], "#Y12");
			Assert.AreEqual (DBNull.Value, dr ["IsExpression"], "#Y13");
			Assert.AreEqual (true, dr ["IsReadOnly"], "#Y14");
			Assert.AreEqual (DBNull.Value, dr ["BaseServerName"], "#Y15");
			Assert.AreEqual (DBNull.Value, dr ["BaseCatalogName"], "#Y16");
			Assert.AreEqual ("Id", dr ["BaseColumnName"], "#Y17");
			Assert.AreEqual (DBNull.Value, dr ["BaseSchemaName"], "#Y18");
			Assert.AreEqual (DBNull.Value, dr ["BaseTableName"], "#Y19");
			Assert.AreEqual (false, dr ["AllowDBNull"], "#Y20");
			Assert.AreEqual (typeof (int), dr ["DataType"], "#Y21");
			Assert.AreEqual (8, dr ["ProviderType"], "#Y22");
			Assert.AreEqual (false, dr ["IsLong"], "#Y23");

			da.Dispose ();
		} finally {
			cmd = new SqlCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
		}

		conn.Dispose ();

		return 0;
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

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	const string drop_table = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug406556]') AND type = N'U')
			DROP TABLE [dbo].[bug406556]";

	const string create_table = @"
		CREATE TABLE bug406556
		(
			Id int IDENTITY (1,1),
			Name varchar(20) NOT NULL,
			FirstName varchar(15) NULL,
			Age integer NULL,
			Weight integer NOT NULL
		)

	ALTER TABLE bug406556 
	ADD CONSTRAINT pk_bug406556 PRIMARY KEY (Id)";

	const string insert_data = @"
		INSERT INTO bug406556 VALUES (N'de Icaza', N'Miguel', 24, 66);
		INSERT INTO bug406556 VALUES (N'Pobst', N'Jonathan', 33, 68);";
}
