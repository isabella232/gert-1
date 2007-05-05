using System;
using System.Reflection;

public class EntryPoint {
	private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public static void Main() {
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

		Console.WriteLine("Loaded assemblies:");

		foreach (Assembly assembly in assemblies) {
			Console.WriteLine(assembly.GetName().FullName);
		}
	
		logger.Debug ("");
	}
}
