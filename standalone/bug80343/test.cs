using System;
using System.Transactions;
using System.Threading;

class Program
{
	static int Main ()
	{
		using (TransactionScope scope = new TransactionScope ()) {
			if (Transaction.Current == null)
				return 1;
			Thread t = new Thread (Thread_Start);
			t.Start ();
			t.Join ();
			if (hasTransaction)
				return 2;

			scope.Complete ();
		}

		return 0;
	}

	static void Thread_Start ()
	{
		hasTransaction = (Transaction.Current != null);
	}

	private static bool hasTransaction = true;
}
