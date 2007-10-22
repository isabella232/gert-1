using System;
using System.Threading;
using System.Runtime.CompilerServices;

class Program
{
	static void Main ()
	{
		Program p = new Program ();
		p.LockMethod ();
	}

	[MethodImpl (MethodImplOptions.Synchronized)]
	public virtual void LockMethod ()
	{
		Monitor.PulseAll (this);
	}
}
