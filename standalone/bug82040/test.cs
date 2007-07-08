using System;
using System.Windows.Forms;

class Program
{
	[STAThread]
	static void Main ()
	{
		Form form = new Form ();
		form.ShowInTaskbar = false;

		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel ();
		tableLayoutPanel.ColumnCount = 3;
		tableLayoutPanel.Dock = DockStyle.Fill;
		tableLayoutPanel.RowCount = 11;
		form.Controls.Add (tableLayoutPanel);

		Timer timer = new Timer ();
		timer.Interval = 100;
		timer.Tick += delegate (object sender, EventArgs e) {
			form.Close ();
		};

		form.Load += delegate (object sender, EventArgs e) {
			timer.Enabled = true;
		};
		form.ShowDialog ();
	}
}
