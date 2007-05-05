using System.Collections;

/// <summary>
///   <para><see cref="IDictionary.this[object]" /></para>
///   <para><see cref="B.this" /></para>
///   <para><see cref="A.this[string]" /></para>
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

	private class B
	{
		public object this[int index]
		{
			get { return null; }
		}
	}
}
