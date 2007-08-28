using System;

public abstract class BusinessBase<TYPE, KEY> where TYPE : BusinessBase<TYPE, KEY>, new ()
{
	public static void Load (KEY id)
	{
		TYPE instance = new TYPE ();
		instance = instance.DataSelect (id);
	}

	protected abstract TYPE DataSelect (KEY id);
}

public class Page : BusinessBase<Page, Guid>
{
	protected override Page DataSelect (Guid k)
	{
		return new Page ();
	}
}

class D
{
	static void Main ()
	{
		Page.Load (new Guid ());
	}
}
