using System.Drawing;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1)
			return 1;
		Image.FromFile (args [0]);
		return 0;
	}
}
