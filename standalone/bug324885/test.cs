using System;

namespace AnyTest
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			B b = new B ();
			b.M ();
		}
	}

	abstract class A<T1, T2>
	{
		public void M ()
		{
			try {
				M2 ();
			} catch (Exception ex) {
				if (ex is NestedException)
					Assert.AreEqual ("AnyTest.A`2+NestedException[System.Int32,System.Int32]", ex.GetType ().ToString (), "#1");
				else
					Assert.Fail ("#1=" + ex.GetType ().ToString ());
			}
		}

		protected abstract void M2 ();

		protected class NestedException : Exception
		{
			public NestedException () : base () { }
		}
	}

	class B : A<int, int>
	{
		protected override void M2 ()
		{
			throw new NestedException ();
		}
	}
}
