<%@ WebHandler Language="C#" Class="SimpleAsyncHandler" %>

using System;
using System.Globalization;
using System.Web;
using System.Threading;

public class SimpleAsyncHandler : IHttpAsyncHandler
{
	private int invocationCount;
	
	public bool IsReusable {
		get { return false; }
	}

	public IAsyncResult BeginProcessRequest (HttpContext context, AsyncCallback cb, object extraData)
	{
		SimpleAsyncResult asyncResult = new SimpleAsyncResult ();
		cb (asyncResult);

		context.Response.Cache.SetNoStore ();
		context.Response.Write ("<p>ok</p>");

		return asyncResult;
	}

	public void EndProcessRequest (IAsyncResult result)
	{
	}

	public void ProcessRequest (HttpContext context)
	{
		throw new NotSupportedException ();
	}
}

public class SimpleAsyncResult : IAsyncResult
{
	public bool IsCompleted {
		get { return false; }
	}

	public object AsyncState {
		get { return null; }
	}

	public WaitHandle AsyncWaitHandle {
		get { return null; }
	}

	public bool CompletedSynchronously {
		get { return true; }
	}
}
