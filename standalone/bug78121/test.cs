using System.Windows.Forms;

public class Test {
	static void Main() {
		TabControl tab = new TabControl ();
		tab.Controls.Add (new TabPage ());
		tab.TabPages.Clear();
	}
}
