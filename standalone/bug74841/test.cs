using System;

class Program {
	static int Main()
	{
		if (Environment.OSVersion.Platform == PlatformID.Unix) {
			return 0;
		} else {
			return 1;
		}
	}
}
