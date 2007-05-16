using System;

class Program
{
	public delegate void ServiceExceptionEventHandler (Exception e);

	static void Main ()
	{
		if (ServiceException != null)
			ServiceException.Invoke (new Exception ());
	}

	public static event ServiceExceptionEventHandler ServiceException;
}
