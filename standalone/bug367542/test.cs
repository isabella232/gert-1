public class NonGen
{
	public static int field = 123;
}

public class NonGenUser<T> where T : NonGen
{
	public int getNonGenField ()
	{
		return T.field;
	}
}
