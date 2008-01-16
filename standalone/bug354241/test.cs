class Program
{
	static void Main (string [] args)
	{
		new ClassWithHeftyConstructor (0.1, 0.2, 0.3, 0.4, 0.5, 0.6,
			0.7, 0.8, 0.9, 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7);
	}
}

public class ClassWithHeftyConstructor
{
	public ClassWithHeftyConstructor (double a, double b, double c, double d,
		double e, double f, double g, double h, double i, double j,
		double k, double l, double m, double n, double o, double p,
		double q)
	{
		Assert.AreEqual (0.1, a, "#a");
		Assert.AreEqual (0.2, b, "#b");
		Assert.AreEqual (0.3, c, "#c");
		Assert.AreEqual (0.4, d, "#d");
		Assert.AreEqual (0.5, e, "#e");
		Assert.AreEqual (0.6, f, "#f");
		Assert.AreEqual (0.7, g, "#g");
		Assert.AreEqual (0.8, h, "#h");
		Assert.AreEqual (0.9, i, "#i");
		Assert.AreEqual (1.0, j, "#j");
		Assert.AreEqual (1.1, k, "#k");
		Assert.AreEqual (1.2, l, "#l");
		Assert.AreEqual (1.3, m, "#m");
		Assert.AreEqual (1.4, n, "#n");
		Assert.AreEqual (1.5, o, "#o");
		Assert.AreEqual (1.6, p, "#p");
		Assert.AreEqual (1.7, q, "#q");
	}
}
