using System.Net;

class Program
{
	static int Main ()
	{
		IPHostEntry entry = Dns.GetHostEntry ("127.0.0.1");
		Assert.IsNotNull (entry, "#1");
		Assert.IsNotNull (entry.AddressList, "#2");
		Assert.IsNotNull (entry.Aliases, "#3");
		Assert.IsNotNull (entry.HostName, "#4");
		return 0;
	}
}
