using System;
using System.Web.Services;

public class TimeService : WebService
{
	[WebMethod]
	public DateTime GetTime ()
	{
		return DateTime.Now;
	}
}
