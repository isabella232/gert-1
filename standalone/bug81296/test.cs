#define TRACE

using System;
using System.Diagnostics;

class Program
{
	static int Main (string [] args)
	{
		TraceSwitch ts = new TraceSwitch ("t", "t");
		if (ts.Level != TraceLevel.Error)
			return 1;
		Trace.AutoFlush = true;
		Trace.Write ("WORKS FINE");
		return 0;
	}
}

