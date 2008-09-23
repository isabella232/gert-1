using System;

delegate TResult Getter<TArg, TResult> (TArg value);

public static class Program
{
	static void Main ()
	{
		var func = CreatePassThru1<string> ();
		Console.WriteLine (func ("Hello world"));

		func = CreatePassThru2<string> ();
		Console.WriteLine (func ("Hello world"));

		func = CreatePassThru3<string> ();
		Console.WriteLine (func ("Hello world"));
	}

	static Getter<T, T> CreatePassThru1<T> ()
	{
		return PassThru<T>;
	}

	static T PassThru<T> (T value)
	{
		return value;
	}

	static Getter<T, T> CreatePassThru2<T> ()
	{
		return (T value) => value;
	}

	static Getter<T, T> CreatePassThru3<T> ()
	{
		return delegate (T value) { return value; };
	}
}
