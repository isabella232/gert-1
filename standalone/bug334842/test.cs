using System;
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
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		SqlCommand cmd;
		SqlConnection conn;

		conn = new SqlConnection (CreateConnectionString ("master"));
		conn.Open ();

		cmd = new SqlCommand (drop_database, conn);
		cmd.ExecuteNonQuery ();
		
		cmd = new SqlCommand (create_database, conn);
		cmd.ExecuteNonQuery ();

		conn.Dispose ();

		conn = new SqlConnection (CreateConnectionString ("Mono"));
		conn.Open ();

		cmd = new SqlCommand (create_table, conn);
		cmd.ExecuteNonQuery ();
		cmd.Dispose ();

		GetSchema_MetaDataCollections (conn);
		GetSchema_DataSourceInformation (conn);
		GetSchema_DataTypes (conn);
		GetSchema_Restrictions (conn);
		GetSchema_CollectionName_NotDefined (conn);

		conn.Dispose ();

		return 0;
	}

	static void GetSchema_MetaDataCollections (SqlConnection conn)
	{
		object [][] expectedColumns = {
			new object [] { "CollectionName", typeof (string) },
			new object [] { "NumberOfRestrictions", typeof (int) },
			new object [] { "NumberOfIdentifierParts", typeof (int) }
		};

		object [][] expectedRows = {
			new object [] { "MetaDataCollections", 0, 0 },
			new object [] { "DataSourceInformation", 0, 0 },
			new object [] { "DataTypes", 0, 0 },
			new object [] { "Restrictions", 0, 0 },
			new object [] { "ReservedWords", 0, 0 },
			new object [] { "Users", 1, 1 },
			new object [] { "Databases", 1, 1 },
			new object [] { "Tables", 4, 3 },
			new object [] { "Columns", 4, 4 },
			new object [] { "StructuredTypeMembers", 4, 4 },
			new object [] { "Views", 3, 3 },
			new object [] { "ViewColumns", 4, 4 },
			new object [] { "ProcedureParameters", 4, 1 },
			new object [] { "Procedures", 4, 3 },
			new object [] { "ForeignKeys", 4, 3 },
			new object [] { "IndexColumns", 5, 4 },
			new object [] { "Indexes", 4, 3 },
			new object [] { "UserDefinedTypes", 2, 1 }
		};

		using (DataTable dt = conn.GetSchema ()) {
			Assert.IsNotNull (dt, "#A1");
			Assert.AreEqual ("MetaDataCollections", dt.TableName, "#A2");
			Assert.AreEqual (expectedColumns.Length, dt.Columns.Count, "#A3");
			Assert.AreEqual (expectedRows.Length, dt.Rows.Count, "#A4");

			for (int i = 0; i < expectedColumns.Length; i++) {
				DataColumn column = dt.Columns [i];
				object [] expectedColumn = expectedColumns [i];
				Assert.AreEqual (expectedColumn [0], column.ColumnName, "#A5:" + i);
				Assert.AreEqual (expectedColumn [1], column.DataType, "#A6:" + i);
			}

			for (int i = 0; i < expectedRows.Length; i++) {
				DataRow row = dt.Rows [i];
				object [] expectedRow = expectedRows [i];
				for (int j = 0; j < expectedColumns.Length; j++) 
					Assert.AreEqual (expectedRow [j], row [j], "#A7: " + i + "," + j);
			}
		}
	}

	static void GetSchema_DataSourceInformation (SqlConnection conn)
	{
		object [] [] expectedColumns = {
			new object [] { "CompositeIdentifierSeparatorPattern", typeof (string) },
			new object [] { "DataSourceProductName", typeof(string) },
			new object [] { "DataSourceProductVersion", typeof(string) },
			new object [] { "DataSourceProductVersionNormalized", typeof(string) },
			new object [] { "GroupByBehavior", typeof(GroupByBehavior) },
			new object [] { "IdentifierPattern", typeof(string) },
			new object [] { "IdentifierCase", typeof(IdentifierCase) },
			new object [] { "OrderByColumnsInSelect", typeof(bool) },
			new object [] { "ParameterMarkerFormat", typeof(string) },
			new object [] { "ParameterMarkerPattern", typeof(string) },
			new object [] { "ParameterNameMaxLength", typeof(int) },
			new object [] { "ParameterNamePattern", typeof(string) },
			new object [] { "QuotedIdentifierPattern", typeof(string) },
			new object [] { "QuotedIdentifierCase", typeof(IdentifierCase) },
			new object [] { "StatementSeparatorPattern", typeof(string) },
			new object [] { "StringLiteralPattern", typeof(string) },
			new object [] { "SupportedJoinOperators", typeof(SupportedJoinOperators) },
		};

		SqlCommand cmd = new SqlCommand ("SELECT SERVERPROPERTY('productversion')", conn);
		Version sql_version = new Version ((string) cmd.ExecuteScalar ());
		string productVersion = string.Format ("{0:00}.{1:00}.{2:0000}", 
			sql_version.Major, sql_version.Minor, sql_version.Build);

		object [] [] expectedRows = {
			new object [] {"\\.", "Microsoft SQL Server", productVersion, productVersion, 2,
				@"(^\[\p{Lo}\p{Lu}\p{Ll}_@#][\p{Lo}\p{Lu}\p{Ll}\p{Nd}@$#_]*$)|(^\[[^\]\0]|\]\]+\]$)|(^\""[^\""\0]|\""\""+\""$)",
				1, false, "{0}", @"@[\p{Lo}\p{Lu}\p{Ll}\p{Lm}_@#][\p{Lo}\p{Lu}\p{Ll}\p{Lm}\p{Nd}\uff3f_@#\$]*(?=\s+|$)",
				128, @"^[\p{Lo}\p{Lu}\p{Ll}\p{Lm}_@#][\p{Lo}\p{Lu}\p{Ll}\p{Lm}\p{Nd}\uff3f_@#\$]*(?=\s+|$)",
				@"(([^\[]|\]\])*)", 1, ";", "'(([^']|'')*)'", 15 }
		};

		using (DataTable dt = conn.GetSchema ("DataSourceInformation")) {
			Assert.IsNotNull (dt, "#A1");
			Assert.AreEqual ("DataSourceInformation", dt.TableName, "#A2");
			Assert.AreEqual (expectedColumns.Length, dt.Columns.Count, "#A3");
			Assert.AreEqual (expectedRows.Length, dt.Rows.Count, "#A4");

			for (int i = 0; i < expectedColumns.Length; i++) {
				DataColumn column = dt.Columns [i];
				object [] expectedColumn = expectedColumns [i];
				Assert.AreEqual (expectedColumn [0], column.ColumnName, "#A5:" + i);
				Assert.AreEqual (expectedColumn [1], column.DataType, "#A6:" + i);
			}

			for (int i = 0; i < expectedRows.Length; i++) {
				DataRow row = dt.Rows [i];
				object [] expectedRow = expectedRows [i];
				for (int j = 0; j < expectedColumns.Length; j++)
					Assert.AreEqual (expectedRow [j], row [j], "#A7: " + i + "," + j);
			}
		}
	}

	static void GetSchema_DataTypes (SqlConnection conn)
	{
		object [][] expectedColumns = {
			new object [] { "TypeName", typeof(string) },
			new object [] { "ProviderDbType", typeof(int) },
			new object [] { "ColumnSize", typeof(long) },
			new object [] { "CreateFormat", typeof(string) },
			new object [] { "CreateParameters", typeof(string) },
			new object [] { "DataType", typeof(string) },
			new object [] { "IsAutoIncrementable", typeof(bool) },
			new object [] { "IsBestMatch", typeof(bool) },
			new object [] { "IsCaseSensitive", typeof(bool) },
			new object [] { "IsFixedLength", typeof(bool) },
			new object [] { "IsFixedPrecisionScale", typeof(bool) },
			new object [] { "IsLong", typeof(bool) },
			new object [] { "IsNullable", typeof(bool) },
			new object [] { "IsSearchable", typeof(bool) },
			new object [] { "IsSearchableWithLike", typeof(bool) },
			new object [] { "IsUnsigned", typeof(bool) },
			new object [] { "MaximumScale", typeof(short) },
			new object [] { "MinimumScale", typeof(short) },
			new object [] { "IsConcurrencyType", typeof(bool) },
			new object [] { "IsLiteralSupported", typeof(bool) },
			new object [] { "LiteralPrefix", typeof(string) },
			new object [] { "LiteralSuffix", typeof(string) }
		};

		object [][] expectedRows = {
			new object [] {"smallint", 16, 5L, "smallint", DBNull.Value, "System.Int16", true, true,
				false, true, true, false, true, true, false, false, DBNull.Value,
				DBNull.Value, false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"int", 8, 10L, "int", DBNull.Value, "System.Int32",
				true, true, false, true, true, false, true, true, false,
				false, DBNull.Value, DBNull.Value, false, DBNull.Value,
				DBNull.Value, DBNull.Value},
			new object [] {"real", 13, 7L, "real", DBNull.Value,
				"System.Single", false, true, false, true, false, false,
				true, true, false, false, DBNull.Value, DBNull.Value,
				false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"float", 6, 53L, "float({0})",
				"number of bits used to store the mantissa", "System.Double",
				false, true, false, true, false, false, true, true,
				false, false, DBNull.Value, DBNull.Value, false,
				DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"money", 9, 19L, "money", DBNull.Value,
				"System.Decimal", false, false, false, true, true,
				false, true, true, false, false, DBNull.Value,
				DBNull.Value, false, DBNull.Value, DBNull.Value,
				DBNull.Value},
			new object [] {"smallmoney", 17, 10L, "smallmoney", DBNull.Value,
				"System.Decimal", false, false, false, true, true, false,
				true, true, false, false, DBNull.Value, DBNull.Value,
				false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"bit", 2, 1L, "bit", DBNull.Value, "System.Boolean",
				false, false, false, true, false, false, true, true,
				false, DBNull.Value, DBNull.Value, DBNull.Value,
				false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"tinyint", 20, 3L, "tinyint", DBNull.Value,
				"System.SByte", true, true, false, true, true, false,
				true, true, false, true, DBNull.Value, DBNull.Value,
				false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"bigint", 0, 19L, "bigint", DBNull.Value,
				"System.Int64", true, true, false, true, true, false,
				true, true, false, false, DBNull.Value, DBNull.Value,
				false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"timestamp", 19, 8L, "timestamp", DBNull.Value,
				"System.Byte[]", false, false, false, true, false, false,
				false, true, false, DBNull.Value, DBNull.Value,
				DBNull.Value, true, DBNull.Value, "0x", DBNull.Value},
			new object [] {"binary", 1, 8000L, "binary({0})", "length",
				"System.Byte[]", false, true, false, true, false, false,
				true, true, false, DBNull.Value, DBNull.Value,
				DBNull.Value, false, DBNull.Value, "0x", DBNull.Value},
			new object [] {"image", 7, 2147483647L, "image", DBNull.Value,
				"System.Byte[]", false, true, false, false, false, true,
				true, false, false, DBNull.Value, DBNull.Value,
				DBNull.Value, false, DBNull.Value, "0x", DBNull.Value},
			new object [] {"text", 18, 2147483647L, "text", DBNull.Value,
				"System.String", false, true, false, false, false, true,
				true, false, true, DBNull.Value, DBNull.Value,
				DBNull.Value, false, DBNull.Value, "'", "'"},
			new object [] {"ntext", 11, 1073741823L, "ntext", DBNull.Value,
				"System.String", false, true, false, false, false, true,
				true, false, true, DBNull.Value, DBNull.Value,
				DBNull.Value, false, DBNull.Value, "N'", "'"},
			new object [] {"decimal", 5, 38L, "decimal({0}, {1})",
				"precision,scale", "System.Decimal", true, true, false,
				true, false, false, true, true, false, false, (short) 38,
				(short) 0, false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"numeric", 5, 38L, "numeric({0}, {1})",
				"precision,scale", "System.Decimal", true, true, false,
				true, false, false, true, true, false, false, (short) 38,
				(short) 0, false, DBNull.Value, DBNull.Value, DBNull.Value},
			new object [] {"datetime", 4, 23L, "datetime", DBNull.Value,
				"System.DateTime", false, true, false, true, false, false,
				true, true, true, DBNull.Value, DBNull.Value,
				DBNull.Value, false, DBNull.Value, "{ts '", "'}"},
			new object [] {"smalldatetime", 15, 16L, "smalldatetime", DBNull.Value,
				"System.DateTime", false, true, false, true, false, false,
				true, true, true, DBNull.Value, DBNull.Value,
				DBNull.Value, false, DBNull.Value, "{ts '", "'}"},
			new object [] {"sql_variant", 23, DBNull.Value, "sql_variant",
				DBNull.Value, "System.Object", false, true, false, false, false,
				false, true, true, false, DBNull.Value, DBNull.Value,
				DBNull.Value, false, false, DBNull.Value, DBNull.Value},
			new object [] {"xml", 25, 2147483647L, "xml", DBNull.Value,
				"System.String", false, false, false, false, false, true,
				true, false, false, DBNull.Value, DBNull.Value,
				DBNull.Value, false, false, DBNull.Value, DBNull.Value},
			new object [] {"varchar", 22, 2147483647L, "varchar({0})",
				"max length", "System.String", false, true, false, false,
				false, false, true, true, true, DBNull.Value,
				DBNull.Value, DBNull.Value, false, DBNull.Value, "'", "'"},
			new object [] {"char", 3, 2147483647L, "char({0})", "length",
				"System.String", false, true, false, true, false, false,
				true, true, true, DBNull.Value, DBNull.Value, DBNull.Value,
				false, DBNull.Value, "'", "'"},
			new object [] {"nchar", 10, 1073741823L, "nchar({0})", "length",
				"System.String", false, true, false, true, false, false,
				true, true, true, DBNull.Value, DBNull.Value, DBNull.Value,
				false, DBNull.Value, "N'", "'"},
			new object [] {"nvarchar", 12, 1073741823L, "nvarchar({0})", "max length",
				"System.String", false, true, false, false, false, false, true, true,
				true, DBNull.Value, DBNull.Value, DBNull.Value, false,
				DBNull.Value, "N'", "'"},
			new object [] {"varbinary", 21, 1073741823L, "varbinary({0})",
				"max length", "System.Byte[]", false, true, false, false,
				false, false, true, true, false, DBNull.Value, DBNull.Value,
				DBNull.Value, false, DBNull.Value, "0x", DBNull.Value},
			new object [] {"uniqueidentifier", 14, 16L, "uniqueidentifier", DBNull.Value,
				"System.Guid", false, true, false, true, false, false, true,
				true, false, DBNull.Value, DBNull.Value, DBNull.Value, false,
				DBNull.Value, "'", "'"},
			new object [] {"date", 31, 3L, "date", DBNull.Value,
				"System.DateTime", false, false, false, true, true, false,
				true, true, true, DBNull.Value, DBNull.Value, DBNull.Value,
				false, DBNull.Value, "{ts '", "'}"},
			new object [] {"time", 32, 5L, "time({0})", "scale",
				"System.TimeSpan", false, false, false, false, false, false,
				true, true, true, DBNull.Value, (short) 7, (short) 0,
				false, DBNull.Value, "{ts '", "'}"},
			new object [] {"datetime2", 33, 8L, "datetime2({0})", "scale",
				"System.DateTime", false, true, false, false, false, false,
				true, true, true, DBNull.Value, (short) 7, (short) 0,
				false, DBNull.Value, "{ts '", "'}"},
			new object [] {"datetimeoffset", 34, 10L, "datetimeoffset({0})",
				"scale", "System.DateTimeOffset", false, true, false, false,
				false, false, true, true, true, DBNull.Value, (short) 7, (short) 0,
				false, DBNull.Value, "{ts '", "'}"},
		};

		using (DataTable dt = conn.GetSchema ("DataTypes")) {
			Assert.IsNotNull (dt, "#A1");
			Assert.AreEqual ("DataTypes", dt.TableName, "#A2");
			Assert.AreEqual (expectedColumns.Length, dt.Columns.Count, "#A3");
			Assert.AreEqual (expectedRows.Length, dt.Rows.Count, "#A4");

			for (int i = 0; i < expectedColumns.Length; i++) {
				DataColumn column = dt.Columns [i];
				object [] expectedColumn = expectedColumns [i];
				Assert.AreEqual (expectedColumn [0], column.ColumnName, "#A5:" + i);
				Assert.AreEqual (expectedColumn [1], column.DataType, "#A6:" + i);
			}

			for (int i = 0; i < expectedRows.Length; i++) {
				DataRow row = dt.Rows [i];
				object [] expectedRow = expectedRows [i];
				for (int j = 0; j < expectedColumns.Length; j++)
					Assert.AreEqual (expectedRow [j], row [j], "#A7: " + i + "," + j);
			}
		}
	}

	static void GetSchema_Restrictions (SqlConnection conn)
	{
		object [][] expectedColumns = {
			new object [] { "CollectionName", typeof (string) },
			new object [] { "RestrictionName", typeof(string) },
			new object [] { "ParameterName", typeof(string) },
			new object [] { "RestrictionDefault", typeof(string) },
			new object [] { "RestrictionNumber", typeof(int) }
		};

		object [][] expectedRows = {
			new object [] {"Users", "User_Name", "@Name", "name", 1},
			new object [] {"Databases", "Name", "@Name", "Name", 1},

			new object [] {"Tables", "Catalog", "@Catalog", "TABLE_CATALOG", 1},
			new object [] {"Tables", "Owner", "@Owner", "TABLE_SCHEMA", 2},
			new object [] {"Tables", "Table", "@Name", "TABLE_NAME", 3},
			new object [] {"Tables", "TableType", "@TableType", "TABLE_TYPE", 4},

			new object [] {"Columns", "Catalog", "@Catalog", "TABLE_CATALOG", 1},
			new object [] {"Columns", "Owner", "@Owner", "TABLE_SCHEMA", 2},
			new object [] {"Columns", "Table", "@Table", "TABLE_NAME", 3},
			new object [] {"Columns", "Column", "@Column", "COLUMN_NAME", 4},

			new object [] {"StructuredTypeMembers", "Catalog", "@Catalog", "TYPE_CATALOG", 1},
			new object [] {"StructuredTypeMembers", "Owner", "@Owner", "TYPE_SCHEMA", 2},
			new object [] {"StructuredTypeMembers", "Type", "@Type", "TYPE_NAME", 3},
			new object [] {"StructuredTypeMembers", "Member", "@Member", "MEMBER_NAME", 4},

			new object [] {"Views", "Catalog", "@Catalog", "TABLE_CATALOG", 1},
			new object [] {"Views", "Owner", "@Owner", "TABLE_SCHEMA", 2},
			new object [] {"Views", "Table", "@Table", "TABLE_NAME", 3},

			new object [] {"ViewColumns", "Catalog", "@Catalog", "VIEW_CATALOG", 1},
			new object [] {"ViewColumns", "Owner", "@Owner", "VIEW_SCHEMA", 2},
			new object [] {"ViewColumns", "Table", "@Table", "VIEW_NAME", 3},
			new object [] {"ViewColumns", "Column", "@Column", "COLUMN_NAME", 4},

			new object [] {"ProcedureParameters", "Catalog", "@Catalog", "SPECIFIC_CATALOG", 1},
			new object [] {"ProcedureParameters", "Owner", "@Owner", "SPECIFIC_SCHEMA", 2},
			new object [] {"ProcedureParameters", "Name", "@Name", "SPECIFIC_NAME", 3},
			new object [] {"ProcedureParameters", "Parameter", "@Parameter", "PARAMETER_NAME", 4},

			new object [] {"Procedures", "Catalog", "@Catalog", "SPECIFIC_CATALOG", 1},
			new object [] {"Procedures", "Owner", "@Owner", "SPECIFIC_SCHEMA", 2},
			new object [] {"Procedures", "Name", "@Name", "SPECIFIC_NAME", 3},
			new object [] {"Procedures", "Type", "@Type", "ROUTINE_TYPE", 4},

			new object [] {"IndexColumns", "Catalog", "@Catalog", "db_name()", 1},
			new object [] {"IndexColumns", "Owner", "@Owner", "user_name()", 2},
			new object [] {"IndexColumns", "Table", "@Table", "o.name", 3},
			new object [] {"IndexColumns", "ConstraintName", "@ConstraintName", "x.name", 4},
			new object [] {"IndexColumns", "Column", "@Column", "c.name", 5},

			new object [] {"Indexes", "Catalog", "@Catalog", "db_name()", 1},
			new object [] {"Indexes", "Owner", "@Owner", "user_name()", 2},
			new object [] {"Indexes", "Table", "@Table", "o.name", 3},
			new object [] {"Indexes", "Name", "@Name", "x.name", 4},

			new object [] {"UserDefinedTypes", "assembly_name", "@AssemblyName", "assemblies.name", 1},
			new object [] {"UserDefinedTypes", "udt_name", "@UDTName", "types.assembly_class", 2},

			new object [] {"ForeignKeys", "Catalog", "@Catalog", "CONSTRAINT_CATALOG", 1},
			new object [] {"ForeignKeys", "Owner", "@Owner", "CONSTRAINT_SCHEMA", 2},
			new object [] {"ForeignKeys", "Table", "@Table", "TABLE_NAME", 3},
			new object [] {"ForeignKeys", "Name", "@Name", "CONSTRAINT_NAME", 4},
		};

		using (DataTable dt = conn.GetSchema ("Restrictions")) {
			Assert.IsNotNull (dt, "#A1");
			Assert.AreEqual ("Restrictions", dt.TableName, "#A2");
			Assert.AreEqual (expectedColumns.Length, dt.Columns.Count, "#A3");
			Assert.AreEqual (expectedRows.Length, dt.Rows.Count, "#A4");

			for (int i = 0; i < expectedColumns.Length; i++) {
				DataColumn column = dt.Columns [i];
				object [] expectedColumn = expectedColumns [i];
				Assert.AreEqual (expectedColumn [0], column.ColumnName, "#A5:" + i);
				Assert.AreEqual (expectedColumn [1], column.DataType, "#A6:" + i);
			}

			for (int i = 0; i < expectedRows.Length; i++) {
				DataRow row = dt.Rows [i];
				object [] expectedRow = expectedRows [i];
				for (int j = 0; j < expectedColumns.Length; j++)
					Assert.AreEqual (expectedRow [j], row [j], "#A7: " + i + "," + j);
			}
		}
	}

	static void GetSchema_CollectionName_NotDefined (SqlConnection conn)
	{
		try {
			conn.GetSchema ((string) null);
			Assert.Fail ("#A1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#A2");
			Assert.IsNull (ex.InnerException, "#A3");
			Assert.IsNotNull (ex.Message, "#A4");
			Assert.AreEqual ("The requested collection () is not defined.", ex.Message, "#A5");
			Assert.IsNull (ex.ParamName, "#A6");
		}

		try {
			conn.GetSchema ((string) null, new string [0]);
			Assert.Fail ("#B1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
			Assert.AreEqual ("The requested collection () is not defined.", ex.Message, "#B5");
			Assert.IsNull (ex.ParamName, "#B6");
		}

		try {
			conn.GetSchema ("Mono");
			Assert.Fail ("#C1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#C2");
			Assert.IsNull (ex.InnerException, "#C3");
			Assert.IsNotNull (ex.Message, "#C4");
			Assert.AreEqual ("The requested collection (Mono) is not defined.", ex.Message, "#C5");
			Assert.IsNull (ex.ParamName, "#C6");
		}
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
		return sb.ToString ();
	}

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	const string drop_database = @"
		IF EXISTS (SELECT * FROM sys.databases WHERE name = N'Mono')
			DROP DATABASE Mono";

	const string create_database = "CREATE DATABASE Mono";

	const string create_table = @"
		CREATE TABLE bugnew
		(
			Name varchar(20),
			FirstName varchar (10)
		)";
}
