using System;
using System.Web;

public class Global : HttpApplication
{
	public Global ()
	{
		this.BeginRequest += new EventHandler (OnBeginRequest);
		this.EndRequest += new EventHandler (OnEndRequest);
	}

	public void OnBeginRequest (object sender, EventArgs e)
	{
		_Default.BeginRequest ();
	}

	public void OnEndRequest (object sender, EventArgs e)
	{
		_Default.EndRequest ();
	}
}
