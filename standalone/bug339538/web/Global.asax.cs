using System;

public class _Global : System.Web.HttpApplication
{
	public override void Init ()
	{
		base.Init ();
		PreSendRequestHeaders += new EventHandler (Global_PreSendRequestHeaders);
	}

	void Global_PreSendRequestHeaders (object sender, EventArgs e)
	{
		if (Request.HttpMethod == "GET") {
			if (Response.StatusCode == 302) {
				Response.StatusCode = 201;
				Response.ClearContent ();
				string s = "output override: " + Response.RedirectLocation;
				for (int i = 0; i < s.Length; i++)
					Response.Output.Write (s [i]);
			} else if (Context.Error != null) {
				Response.StatusCode = 202;
				Response.ClearContent ();
				string s = "error override: " + Context.Error.ToString();
				for (int i = 0; i < s.Length; i++)
					Response.Output.Write (s [i]);
			}
		}

		throw new Exception ();
	}
}
