using System;
using System.Collections;
using System.Data;

class Program
{
	static void Main (string [] args)
	{
		DataSet ds = new DataSet ();

		DataTable tabTable = ds.Tables.Add ("Tab");

		// add TabId column to Tab table
		DataColumn tabIdColumnTab = new DataColumn ("TabId", typeof (int));
		tabIdColumnTab.AutoIncrement = true;
		tabIdColumnTab.AllowDBNull = false;
		tabTable.Columns.Add (tabIdColumnTab);

		DataTable moduleTable = ds.Tables.Add ("Module");

		// add TabId column to Module table
		DataColumn tabIdColumnModule = new DataColumn ("TabId", typeof (int), null, System.Data.MappingType.Hidden);
		moduleTable.Columns.Add (tabIdColumnModule);

		// add ModuleId column to Module table
		DataColumn moduleIdColumnModule = new DataColumn ("ModuleId", typeof (int), null, System.Data.MappingType.Attribute);
		moduleIdColumnModule.AllowDBNull = false;
		moduleIdColumnModule.Unique = true;
		moduleTable.Columns.Add (moduleIdColumnModule);

		ds.EnforceConstraints = false;
		moduleTable.Constraints.Add (new ForeignKeyConstraint ("Tab_Module", tabTable.Columns ["TabId"], moduleTable.Columns ["TabId"]));

		moduleTable.ParentRelations.Add ("Tab_Module", tabIdColumnTab, tabIdColumnModule);

		DataRow tabRow = tabTable.Rows.Add (new object [0]);

		DataRow moduleRow = moduleTable.NewRow ();
		moduleRow.SetParentRow (tabRow, moduleTable.ParentRelations ["Tab_Module"]);
	}
}

