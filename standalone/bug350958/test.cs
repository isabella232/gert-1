using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
	static int Main ()
	{
		Assembly self = Assembly.GetEntryAssembly ();
		try {
			X509Certificate x509 = X509Certificate.CreateFromSignedFile (self.Location);
			if (x509.GetHashCode () != 0)
				return 0;
			else
				return 1;
		} catch (COMException ce) {
			// using a test certificate without trusting the test root ? 
			Console.WriteLine (ce.Message);
			return 2;
		}
	}
}
