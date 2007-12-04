using System;
using System.Collections.Generic;

internal delegate void EmptyDelegate ();

class BaseObject
{
	static void Closure (EmptyDelegate x)
	{
	}

	public static List<T> Query<T> (out int? count) where T : BaseObject
	{
		count = 0;
		List<T> results = new List<T> ();
		Closure (delegate { results.Add (MakeSomething<T> ()); });
		return results;
	}

	static T MakeSomething<T> () where T : BaseObject
	{
		return null;
	}
}
