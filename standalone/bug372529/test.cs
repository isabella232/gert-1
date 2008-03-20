using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Text;
using System.Threading;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_ODBC") == null)
			return 0;

		OdbcConnection conn = new OdbcConnection (CreateOdbcConnectionString ());
		conn.Open ();

		OdbcCommand cmd = new OdbcCommand (drop_table, conn);
		cmd.ExecuteNonQuery ();

		OdbcDataReader reader = null;

		try {
			cmd = new OdbcCommand (create_table, conn);
			cmd.ExecuteNonQuery ();

			cmd = new OdbcCommand (insert_data, conn);

			OdbcParameter paramName = cmd.CreateParameter ();
			paramName.ParameterName = "name";
			paramName.DbType = DbType.String;
			paramName.Value = "Drieфen";
			cmd.Parameters.Add (paramName);

			OdbcParameter paramInitials = cmd.CreateParameter ();
			paramInitials.ParameterName = "Initials";
			paramInitials.DbType = DbType.String;
			paramInitials.Value = "GфD";
			cmd.Parameters.Add (paramInitials);

			OdbcParameter paramFirstName = cmd.CreateParameter ();
			paramFirstName.ParameterName = "FirstName";
			paramFirstName.DbType = DbType.String;
			paramFirstName.Value = "Gert";
			cmd.Parameters.Add (paramFirstName);

			OdbcParameter paramIncome = cmd.CreateParameter ();
			paramIncome.ParameterName = "Income";
			paramIncome.DbType = DbType.Decimal;
			paramIncome.Scale = 3;
			paramIncome.Value = 5566.6557f;
			cmd.Parameters.Add (paramIncome);

			OdbcParameter paramBirthDate = cmd.CreateParameter ();
			paramBirthDate.ParameterName = "BirthDate";
			paramBirthDate.DbType = DbType.DateTime;
			paramBirthDate.Value = new DateTime (1973, 8, 13);
			cmd.Parameters.Add (paramBirthDate);

			OdbcParameter paramMarried = cmd.CreateParameter ();
			paramMarried.ParameterName = "Married";
			paramMarried.DbType = DbType.Boolean;
			paramMarried.Value = false;
			cmd.Parameters.Add (paramMarried);

			OdbcParameter paramZipCode = cmd.CreateParameter ();
			paramZipCode.ParameterName = "ZipCode";
			paramZipCode.DbType = DbType.Int32;
			paramZipCode.Value = 3510;
			cmd.Parameters.Add (paramZipCode);

			OdbcParameter paramTown = cmd.CreateParameter ();
			paramTown.ParameterName = "Town";
			paramTown.DbType = DbType.StringFixedLength;
			paramTown.Value = "Kermt";
			cmd.Parameters.Add (paramTown);

			cmd.ExecuteNonQuery ();
			cmd.Dispose ();

			cmd = new OdbcCommand (select_data, conn);
			reader = cmd.ExecuteReader ();
			Assert.IsTrue (reader.Read (), "#A1");
			Assert.AreEqual (8, reader.FieldCount, "#A2");

			Assert.AreEqual ("nvarchar", reader.GetDataTypeName (0), "#B1");
			Assert.AreEqual ("Drieфen", reader.GetValue (0), "#B2");

			Assert.AreEqual ("nchar", reader.GetDataTypeName (1), "#C1");
			Assert.AreEqual ("GфD  ", reader.GetValue (1), "#C2");

			Assert.AreEqual ("varchar", reader.GetDataTypeName (2), "#D1");
			Assert.AreEqual ("Gert", reader.GetValue (2), "#D2");

			Assert.AreEqual ("decimal", reader.GetDataTypeName (3), "#E1");
			Assert.AreEqual (5566.6560m, reader.GetValue (3), "#E2");

			Assert.AreEqual ("datetime", reader.GetDataTypeName (4), "#F1");
			Assert.AreEqual (new DateTime (1973, 8, 13), reader.GetValue (4), "#F2");

			Assert.AreEqual ("bit", reader.GetDataTypeName (5), "#G1");
			Assert.AreEqual (false, reader.GetValue (5), "#G2");

			Assert.AreEqual ("int", reader.GetDataTypeName (6), "#H1");
			Assert.AreEqual (3510, reader.GetValue (6), "#H2");

			Assert.AreEqual ("char", reader.GetDataTypeName (7), "#I1");
			Assert.AreEqual ("Kermt          ", reader.GetValue (7), "#I2");

			reader.Close ();
			cmd.Dispose ();
		} finally {
			if (reader != null)
				reader.Close ();

			cmd = new OdbcCommand (drop_table, conn);
			cmd.ExecuteNonQuery ();
			cmd.Dispose ();

			conn.Dispose ();
		}

		return 0;
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

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}

	const string drop_table = @"
		IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bug372529]') AND type = N'U')
			DROP TABLE [dbo].[bug372529]";

	const string create_table = @"
		CREATE TABLE bug372529
		(
			Name nvarchar (20),
			Initials nchar (5),
			FirstName varchar (10),
			Income decimal (9,4),
			BirthDate datetime,
			Married bit,
			ZipCode int,
			Town char (15)
		)";

	const string select_data = @"SELECT * FROM bug372529";
	const string insert_data = @"INSERT INTO bug372529 VALUES (?,?,?,?,?,?,?,?)";
	const string delete_data = @"DELETE FROM bug372529";
}
