using System.Collections.Generic;

class Container
{
	public Container ()
	{
		Bag = new Bag<string> ();
		Bag.Name = "WHATEVER";
	}

	public Bag<string> Bag;
}

public class Bag<T>
{
	public T Name;

	public override string ToString ()
	{
		return Name.ToString ();
	}
}
