public class Program
{
	static int Main ()
	{
		Working ();
		NotWorking ();
		return 0;
	}

	public static unsafe void NotWorking ()
	{
		double* to = stackalloc double [2];
		to [0] = to [1] = 0;
	}

	public static unsafe void Working ()
	{
		double* to = stackalloc double [2];
		to [0] = 0;
		to [1] = 0;
	}
}
