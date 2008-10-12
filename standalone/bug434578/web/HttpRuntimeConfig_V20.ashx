<%@ WebHandler Language="C#" Class="HttpRuntimeConfig" %>

using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Configuration;

public class HttpRuntimeConfig : IHttpHandler
{
	public bool IsReusable {
		get { return false; }
	}

	public void ProcessRequest (HttpContext context)
	{
			HttpRuntimeSection runtimeSection = (HttpRuntimeSection)
				ConfigurationManager.GetSection ("system.web/httpRuntime");

			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>ApartmentThreading={0}</p>", runtimeSection.ApartmentThreading));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>AppRequestQueueLimit={0}</p>", runtimeSection.AppRequestQueueLimit));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>DelayNotificationTimeout={0}</p>", runtimeSection.DelayNotificationTimeout));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>Enable={0}</p>", runtimeSection.Enable));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>EnableHeaderChecking={0}</p>", runtimeSection.EnableHeaderChecking));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>EnableKernelOutputCache={0}</p>", runtimeSection.EnableKernelOutputCache));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>EnableVersionHeader={0}</p>", runtimeSection.EnableVersionHeader));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>ExecutionTimeout={0}</p>", runtimeSection.ExecutionTimeout));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>MaxRequestLength={0}</p>", runtimeSection.MaxRequestLength));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>MaxWaitChangeNotification={0}</p>", runtimeSection.MaxWaitChangeNotification));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>MinFreeThreads={0}</p>", runtimeSection.MinFreeThreads));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>MinLocalRequestFreeThreads={0}</p>", runtimeSection.MinLocalRequestFreeThreads));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>RequestLengthDiskThreshold={0}</p>", runtimeSection.RequestLengthDiskThreshold));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>RequireRootedSaveAsPath={0}</p>", runtimeSection.RequireRootedSaveAsPath));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>SendCacheControlHeader={0}</p>", runtimeSection.SendCacheControlHeader));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>ShutdownTimeout={0}</p>", runtimeSection.ShutdownTimeout));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>UseFullyQualifiedRedirectUrl={0}</p>", runtimeSection.UseFullyQualifiedRedirectUrl));
			context.Response.Write (string.Format (CultureInfo.InvariantCulture,
				"<p>WaitChangeNotification={0}</p>", runtimeSection.WaitChangeNotification));
	}
}
