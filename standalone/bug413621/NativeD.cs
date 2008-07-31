using System;
using System.Runtime.InteropServices;

public class TestNative
{
	[DllImport ("complex")]
	private static extern unsafe void addComplexD (int l, void* x, DComplex y, void* z);

	internal struct DComplex
	{
		public double real;
		public double imag;
		public DComplex (double _re, double _im)
		{ real = _re; imag = _im; }
	}

	public static unsafe void Main (string [] args)
	{
		DComplex xD = new DComplex (42, 42);
		DComplex [] xxD = new DComplex [10], yyD = new DComplex [10];

		for (int i = 0; i < xxD.Length; i++) xxD [i] = new DComplex ((double) i, (double) 2 * i);

		fixed (void* xxd = xxD, yyd = yyD)
			addComplexD (xxD.Length, xxd, xD, yyd);

		fixed (void* xxd = xxD, yyd = yyD)
			addComplexD (xxD.Length, xxd, xD, yyd);
	}
}
