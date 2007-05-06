using System.Windows.Forms;

class TestForm : Form
{
	static void Main ()
	{
		PropertyGrid p = new PropertyGrid ();
		p.SelectedObject = new DataGrid ();
	}
}
