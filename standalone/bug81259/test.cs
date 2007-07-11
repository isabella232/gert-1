using System;

class Program
{
	static int Main ()
	{
		Array<double> a = new DenseArray<double> (5, 3, 4, 2);
		Sequence s = new Sequence (-1, 1, a.Size);
		a.Fill (s);
		Array<float> b = a.Map<float> (delegate (double x) {
			return (float) (1000 * Math.Sin (x));
		});

		if (a.Shape == b.Shape)
			return 1;

		for (int i = 0; i < b.Size; ++i)
			if (((float) (1000 * Math.Sin (s [i]))) != b [i])
				continue;
		return 0;
	}
}
