using System;
using System.Threading;
using System.Windows.Forms;

class Filter : IMessageFilter
{
	static void Main ()
	{
		Filter filter = new Filter ();

		Application.AddMessageFilter (filter);
		Form form = new Form ();
		form.Show ();

		for (int i = 0; i < 5; i++) {
			Application.DoEvents ();
			Thread.Sleep (50);
		}

		form.Dispose ();

		Assert.IsTrue (filter.PreFilterInvoked > 0, "#1");
	}

	public int PreFilterInvoked;

	public bool PreFilterMessage (ref Message m)
	{
		PreFilterInvoked++;
		return false;
	}
}
