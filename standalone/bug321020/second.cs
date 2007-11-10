using System;
#if FIRST_DEP
using FirstNS;
#endif

namespace SecondNS
{
	public class SecondClass
	{
		public void Operation ()
		{
#if FIRST_DEP
			FirstClass fc = new FirstClass ();
			MyDlgt dlgt = new MyDlgt (DoNothing);
			fc.Foo (dlgt);
#endif
		}

		public void DoNothing ()
		{
		}

		public delegate void MyDlgt ();
	}
}
