/// <summary />
public class EntryPoint
{
	static void Main()
	{
	}

	private class A
	{
		public virtual void Decide(int a)
		{
		}

		public virtual void Decide(string a)
		{
		}
	}

	/// <summary>
	/// <see cref="Decide" />
	/// </summary>
	private class B : A
	{
		public override void Decide(int a)
		{
		}

		public override void Decide(string a)
		{
		}
	}
}
