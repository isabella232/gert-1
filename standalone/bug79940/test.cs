using System;

namespace Test
{
	public interface MyInterface
	{
		void Func ();
	}

	public class Base
	{
		public virtual void Func<T> (T val) where T : MyInterface
		{
			val.Func ();
		}
	}

	public class Child : Base
	{
		public override void Func<T> (T val)
		{
			val.Func ();
		}
	}
}
