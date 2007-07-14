using System;
using System.Text;
using System.Collections;

class Program
{
	static void Main ()
	{
		IDHashtable dd = new IDHashtable ();
		Random r = new Random (1000);
		for (int n = 0; n < 10000; n++) {
			int v = r.Next (0, 1000);
			dd [v] = v;
			v = r.Next (0, 1000);
			dd.Remove (v);
		}
	}
}

class IDHashtable : Hashtable
{
	class IDComparer : IComparer
	{
		public int Compare (object x, object y)
		{
			if ((int) x == (int) y)
				return 0;
			else
				return 1;
		}
	}

	class IDHashCodeProvider : IHashCodeProvider
	{
		public int GetHashCode (object o)
		{
			return (int) o;
		}
	}

	public IDHashtable () : base (new IDHashCodeProvider (), new IDComparer ())
	{
	}
}
