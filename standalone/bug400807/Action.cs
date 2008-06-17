namespace Mono.Web.UI
{
	public delegate void Action ();

	public class Exec
	{
		public static void Run ()
		{
			output = "ok";
		}

		public static string Render ()
		{
			return output;
		}

		private static string output;
	}
}
