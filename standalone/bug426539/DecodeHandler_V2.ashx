<%@ WebHandler Language="C#" Class="DecodeHandler" %>

using System.IO;
using System.Web;

public class DecodeHandler : IHttpHandler
{
	public bool IsReusable {
		get { return false; }
	}

	public void ProcessRequest (HttpContext context)
	{
		StringWriter sw;

		context.Response.Write ("<t1>");
		context.Response.Write (HttpUtility.UrlEncode ("\u00FC"));
		context.Response.Write ("</t1>");

		context.Response.Write ("<t2>");
		context.Response.Write (context.Server.UrlEncode ("\u00FC"));
		context.Response.Write ("</t2>");

		context.Response.Write ("<t3>");
		context.Response.Write (context.Server.UrlPathEncode ("\u00FC"));
		context.Response.Write ("</t3>");

		sw = new StringWriter ();
		context.Server.UrlEncode ("\u00FC", sw);
		context.Response.Write ("<t4>");
		context.Response.Write (sw.ToString ());
		context.Response.Write ("</t4>");

		context.Response.Write ("<t5>");
		context.Response.Write (HttpUtility.UrlDecode ("%c3%bc") == "\u00FC");
		context.Response.Write ("</t5>");

		context.Response.Write ("<t6>");
		context.Response.Write (context.Server.UrlDecode ("%fc") == "\u00FC");
		context.Response.Write ("</t6>");

		sw = new StringWriter ();
		context.Server.UrlDecode ("%fc", sw);
		context.Response.Write ("<t7>");
		context.Response.Write (sw.ToString () == "\u00FC");
		context.Response.Write ("</t7>");
	}
}
