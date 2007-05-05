using System;
using System.Windows.Forms;

class ListViewSort
{
	[STAThread]
	static void Main (string [] args)
	{
		ListView entryList = new ListView ();
		entryList.Sorting = System.Windows.Forms.SortOrder.Descending;

		entryList.BeginUpdate ();
		entryList.Columns.Add ("Type", 100, HorizontalAlignment.Left);

		ListViewItem item = new ListViewItem (new string [] { "A" });
		entryList.Items.Add (item);
		item = new ListViewItem (new string [] { "B" });
		entryList.Items.Add (item);
	}
}
