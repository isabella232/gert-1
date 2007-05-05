/// <summary>
///   <para><see cref="A.this" /></para>
/// </summary>
public class Test
{
	static void Main()
	{
	}

	private class A
	{
		public object this[int index]
		{
			get { return null; }
		}

		public object this[string index]
		{
			get { return null; }
		}
	}
}
