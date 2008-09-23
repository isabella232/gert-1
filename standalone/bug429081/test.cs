using System;

delegate TResult FooFunc<TArg, TResult> (TArg arg);

interface IDataProducer<T>
{
}

interface IFuture<T>
{
}

class Bar
{
	public int Value { get; set; }
}

static class Program
{
	static void Main ()
	{
		IDataProducer<Bar> data = null;

		var result = data.Average (x => x.Value);
		if (result == null) {
		}
	}

	public static IFuture<double> Average<TSource> (this IDataProducer<TSource> source, FooFunc<TSource, int> selector)
	{
		throw new NotImplementedException ();
	}

	public static IFuture<double?> Average<TSource> (this IDataProducer<TSource> source, FooFunc<TSource, long?> selector)
	{
		throw new NotImplementedException ();
	}
}
