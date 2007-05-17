using System;

class Program
{
	public virtual ServiceType GetService<ServiceType> (params object [] args)
		where ServiceType : class
	{
		return null;
	}

	static int Main ()
	{
		return 0;
	}
}
