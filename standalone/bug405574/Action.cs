using System;
using System.Configuration;

namespace Mono.Web.UI
{
	public class Action
	{
		public static string GetConfigPath ()
		{
			return ConfigurationManager.OpenExeConfiguration ("").FilePath;
		}
	}
}
