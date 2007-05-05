using System;
using System.Configuration;

public class EntryPoint {
	private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public static void Main() {
		ObsoleteAttribute obsoleteAttr = (ObsoleteAttribute)
			Attribute.GetCustomAttribute(typeof(String),
			typeof(ObsoleteAttribute), true);
		if (obsoleteAttr != null) {
			logger.Error ("what the hell");
		}
	}
}
