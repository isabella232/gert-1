using System.Collections.Generic;

public class BaseClass<T, O>
{
	public class NestedClassInsideBaseClass<K, V>
	{
	}

	public List<NestedClassInsideBaseClass<T, O>> Items
	{
		get { return null; }
	}
}

public class DerivedClass : BaseClass<int, string>
{
	public DerivedClass ()
	{
		foreach (NestedClassInsideBaseClass<int, string> oPair
				 in this.Items) {
		}
	}
}
