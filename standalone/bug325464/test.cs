using System;
using System.Globalization;
using System.IO;

class Program
{
	static void Main (string [] args)
	{
		TodoItems items = new TodoItems ();
		TodoItems.TodoItemsDataTable table = items._TodoItems;
		Assert.IsNotNull (table, "#1");
		Assert.AreEqual ("TodoItems", table.TableName, "#2");
	}
}
