<%@ WebHandler Language="C#" Class="SimpleAsyncHandler" %>

using System;
using System.Globalization;
using System.Web;
using System.Threading;

public class SimpleAsyncHandler : IHttpHandler
{
	public bool IsReusable {
		get { return false; }
	}

	public void ProcessRequest (HttpContext context)
	{
		//context.Response.Headers.Clear ();
		context.Response.AppendHeader ("Not-Modified-Since", "Sun, 08 Feb 2009 08:49:26 GMT");
		context.Response.AppendHeader ("ETag", "898bbr2347056cc2e096afc66e104653");
		context.Response.StatusCode = 304;
		context.Response.Flush ();
	}
}
