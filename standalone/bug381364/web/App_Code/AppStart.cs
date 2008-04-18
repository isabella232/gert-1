using System;
using System.IO;
using System.Web.Hosting;

using Clarius.Samples.Web.VirtualPathProvider;

public static class AppStart
{
	public static void AppInitialize ()
	{
		string baseDir = AppDomain.CurrentDomain.BaseDirectory;

		ZipFileVirtualPathProvider prov = new ZipFileVirtualPathProvider (
			Path.Combine (baseDir, "ZippedWebSite.zip"));
		HostingEnvironment.RegisterVirtualPathProvider (prov);
	}
}
