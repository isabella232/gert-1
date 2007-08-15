using System;
using System.Diagnostics;

class Program
{
	static int Main (string [] args)
	{
		string st = Environment.StackTrace;

		int index1 = st.IndexOf ("System.Environment.get_StackTrace()");
		if (index1 == -1) {
			Console.WriteLine (st);
			return 1;
		}

#if MONO
		int index2 = st.IndexOf ("Program.Main(System.String[] args)");
#else
		int index2 = st.IndexOf ("Program.Main(String[] args)");
#endif
		if (index2 == -1 || index2 <= index1) {
			Console.WriteLine (st);
			return 2;
		}

		return 0;
	}
}
