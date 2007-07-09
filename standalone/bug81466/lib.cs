using System;

namespace MainSpace
{
	public interface IA
	{
	}

	public interface IB
	{
		bool Test ();
	}

	public interface IC : IA, IB
	{
	}

	public interface ID : IC
	{
	}

	public class A : IA
	{
	}

	public class AC : A, IC
	{
		public virtual bool Test ()
		{
			Console.WriteLine ("AC.Test()");
			return true;
		}
	}

	public class CD : AC, ID
	{
	}
}
