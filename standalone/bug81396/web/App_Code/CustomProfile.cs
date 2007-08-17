using System.Web.Profile;

public class CustomProfile : ProfileBase
{
	public CustomProfile ()
	{
	}

	public string CustomData
	{
		get { return "blabla"; }
	}
}
