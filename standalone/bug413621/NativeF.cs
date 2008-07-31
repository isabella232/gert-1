using System;
using System.Runtime.InteropServices;

public class TestNative
{
	[DllImport ("complex")]
	private static extern unsafe void addComplexS (int l, void* x, FComplex y, void* z);

	internal struct FComplex
	{
		public float real;
		public float imag;
		public FComplex (float _re, float _im)
		{ real = _re; imag = _im; }
	}

	public static unsafe void Main (string [] args)
	{
		FComplex xF = new FComplex ((float) 41, (float) 41);
		FComplex [] xxF = new FComplex [10], yyF = new FComplex [10];

		for (int i = 0; i < xxF.Length; i++) xxF [i] = new FComplex ((float) i, (float) 2 * i);

		fixed (void* xxf = xxF, yyf = yyF)
			addComplexS (xxF.Length, xxf, xF, yyf);

		fixed (void* xxf = xxF, yyf = yyF)
			addComplexS (xxF.Length, xxf, xF, yyf);
	}
}
