using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService (Namespace = "http://tempuri.org/")]
#if NET_2_0
[WebServiceBinding (ConformsTo = WsiProfiles.BasicProfile1_1)]
#endif
public class Service : WebService
{
	[WebMethod (EnableSession=true)]
	public int GetSessionCounter ()
	{
		object val = Session ["Counter"];
		if (val == null) {
			Session ["Counter"] = 1;
			return 1;
		} else {
			int counter = ((int) val) + 1;
			Session ["Counter"] = counter;
			return counter;
		}
	}

	[WebMethod]
	public int GetApplicationCounter ()
	{
		object val = Application ["Counter"];
		if (val == null) {
			Application ["Counter"] = 1;
			return 1;
		} else {
			int counter = ((int) val) + 1;
			Application ["Counter"] = counter;
			return counter;
		}
	}

	[WebMethod]
	public bool HasApplication ()
	{
		return Application != null;
	}

	[WebMethod]
	public bool HasSession ()
	{
		return Session != null;
	}
}
