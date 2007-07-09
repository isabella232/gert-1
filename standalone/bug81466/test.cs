using System;

namespace ImplSpace
{
	internal class TestImpl : MainSpace.CD
	{
		public override bool Test ()
		{
			Console.WriteLine ("TestImpl.Test()");
			return base.Test ();
		}
	}

	public class Program
	{
		static void Main ()
		{
			TestImpl ti = new TestImpl ();
			ti.Test ();
		}
	}
}
