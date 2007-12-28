using System;

public abstract class BusinessBase<TYPE> where TYPE : BusinessBase<TYPE>, new ()
{
	public static void Load<KEY> (KEY id)
	{
		TYPE instance = new TYPE ();
		instance = instance.DataSelect<KEY> (id);
	}

	protected abstract TYPE DataSelect<KEY> (KEY id);
}

public class Page : BusinessBase<Page>
{
	protected override Page DataSelect<Guid> (Guid k)
	{
		return new Page ();
	}
}

class D
{
	static void Main ()
	{
		Page.Load<Guid> (new Guid ());
	}
}
