<%@ WebHandler Language="C#" Class="HttpRuntimeConfig" %>

using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

public class HttpRuntimeConfig : IHttpHandler
{
	public bool IsReusable {
		get { return false; }
	}

	public void ProcessRequest (HttpContext context)
	{
		object runtimeConf = ConfigurationSettings.GetConfig ("system.web/httpRuntime");
		WriteValue (context, runtimeConf, "ApartmentThreading");
		WriteValue (context, runtimeConf, "AppRequestQueueLimit");
		WriteValue (context, runtimeConf, "DelayNotificationTimeout");
		WriteValue (context, runtimeConf, "EnableHeaderChecking");
		WriteValue (context, runtimeConf, "EnableKernelOutputCache");
		WriteValue (context, runtimeConf, "ExecutionTimeout");
		WriteValue (context, runtimeConf, "MaxRequestLength");
		WriteValue (context, runtimeConf, "MaxWaitChangeNotification");
		WriteValue (context, runtimeConf, "MinFreeThreads");
		WriteValue (context, runtimeConf, "MinLocalRequestFreeThreads");
		WriteValue (context, runtimeConf, "SendCacheControlHeader");
		WriteValue (context, runtimeConf, "ShutdownTimeout");
		WriteValue (context, runtimeConf, "UseFullyQualifiedRedirectUrl");
		WriteValue (context, runtimeConf, "WaitChangeNotification");
	}

	static void WriteValue (HttpContext context, object config, string name)
	{
		object value;
		Type configType = config.GetType ();
		BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public |
			BindingFlags.Instance;

		if (RunningOnMono) {
			FieldInfo fi = configType.GetField (name, flags);
			if (fi != null)
				value = fi.GetValue (config);
			else
				value = "UNKNOWN";
		} else {
			PropertyInfo pi = configType.GetProperty (name, flags);
			if (pi != null)
				value = pi.GetValue (config, null);
			else
				value = "UNKNOWN";
		}

		if (value == null)
			value = "NULL";

		context.Response.Write (string.Format (CultureInfo.InvariantCulture,
			"<p>{0}={1}|{2}</p>", name, value.GetType ().FullName, value));
	}

	static bool RunningOnMono {
		get {
			return (Type.GetType("System.MonoType", false) != null);
		}
	}
}
