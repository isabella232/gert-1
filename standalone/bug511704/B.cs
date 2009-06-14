using System.Runtime.CompilerServices;

#if V2
[assembly: TypeForwardedTo (typeof (Foo))]
#else
public class Foo
{
	public string Company
	{
		get
		{
			return "Novell";
		}
	}

	public class Bar
	{
		public string Country
		{
			get
			{
				return "U.S.";
			}
		}
	}
}
#endif

public class Orange
{
}
