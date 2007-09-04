using System.Collections;

class Program
{
	public static IEnumerable TestMethod ()
	{
		try {
			yield break;
		} finally { }
	}
}
