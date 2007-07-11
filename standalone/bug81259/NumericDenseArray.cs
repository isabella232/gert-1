using System;

public class NumericDenseArray<T, C> : DenseArray<T>
	where C : ICalculator<T>
{

	public NumericDenseArray (params int [] shape)
		: base (shape)
	{
	}

	public NumericDenseArray (Array<T> array)
		: base (array)
	{
	}

	public NumericDenseArray (System.Array array)
		: base (array)
	{
	}
}
