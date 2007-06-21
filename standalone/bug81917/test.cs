public class Program
{
	public struct foo_t
	{
		public fixed char b [16];
	}

	unsafe static void Main ()
	{
		foo_t bar;
		char* b_ptr = bar.b;
	}
}
