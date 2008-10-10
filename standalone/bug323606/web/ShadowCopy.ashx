<%@ WebHandler Language="C#" Class="ShadowCopyHandler" %>

using System;
using System.Globalization;
using System.Reflection;
using System.Web;
using System.Threading;

public class ShadowCopyHandler : IHttpHandler
{
	public bool IsReusable {
		get { return false; }
	}

	public void ProcessRequest (HttpContext context)
	{
		Assembly a = typeof (Foo).Assembly;

		context.Response.Write ("<p>Location=" + a.Location + "</p>");
		context.Response.Write ("<p>CodeBase=" + a.CodeBase + "</p>");
	}
}
