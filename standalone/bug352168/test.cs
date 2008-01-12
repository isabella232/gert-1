using System;

class Program
{
	static void Main (string [] args)
	{
		Do (delegate () {
			try {
				return false;
			} catch (Exception e) {
				throw e;
			}
		});
	}
	
	static object Do (DoIt d)
	{
		return d ();
	}

	delegate bool DoIt ();
}
