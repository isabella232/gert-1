using System;
using System.Linq.Expressions;

class M
{
	static int Main ()
	{
		for (int i = 0; i < 20000; i++) {
			LambdaExpression l1 = Expression.Lambda (Expression.Constant (true));
			LambdaExpression l2 = Expression.Lambda (Expression.Constant (1));

			Delegate f1 = l1.Compile ();
			Delegate f2 = l2.Compile ();

			if (f1.DynamicInvoke (null).GetType () != typeof (bool))
				return 1;
			if (f2.DynamicInvoke (null).GetType () != typeof (int))
				return 2;
		}

		return 0;
	}
}
