using log4net;
using System;

[assembly: CLSCompliant(true)]

public class EntryPoint
{
	public static void Main() {
		ILog logger = LogManager.GetLogger("whatever");
		logger.Debug("test");
	}
}

