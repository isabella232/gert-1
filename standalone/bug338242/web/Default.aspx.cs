using System;
using System.Web;
#if NET_2_0
using System.Web.Profile;
#endif
using System.Web.UI;

public class _Default : Page
{
	public HttpApplication ApplicationInstance
	{
		get { return HttpContext.Current.ApplicationInstance; }
	}

#if NET_2_0
	public DefaultProfile Profile
	{
		get { return (DefaultProfile) HttpContext.Current.Profile; }
	}
#endif
}
