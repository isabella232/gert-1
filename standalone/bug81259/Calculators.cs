public interface ICalculator<T>
{
	T UnaryPlus (T x);
	T UnaryMinus (T x);

	T Plus (T x, T y);
	T Minus (T x, T y);
	T Times (T x, T y);
	T Divide (T x, T y);
	T Mod (T x, T y);
}

public struct DoubleCalculator : ICalculator<double>
{
	public double UnaryPlus (double x) { return +x; }
	public double UnaryMinus (double x) { return -x; }

	public double Plus (double x, double y) { return x + y; }
	public double Minus (double x, double y) { return x - y; }
	public double Times (double x, double y) { return x * y; }
	public double Divide (double x, double y) { return x / y; }
	public double Mod (double x, double y) { return x % y; }
}
