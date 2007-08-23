using System.Drawing;
using System.Windows.Forms;

class Program
{
	static int Main ()
	{
		FlowLayoutPanel panel = new FlowLayoutPanel ();
		panel.Controls.AddRange (new Control [] { new TestControl (), new TestControl () });
		if (panel.PreferredSize != new Size (212, 106))
			return 1;
		return 0;
	}
}

class TestControl : Control
{
	protected override Size DefaultSize {
		get {
			return new Size (100, 100);
		}
	}
}
