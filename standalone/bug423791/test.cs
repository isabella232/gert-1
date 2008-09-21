using System;

static class Maybe
{
	public static Maybe<T> C<T> (T value)
	{
		return new Maybe<T> (value);
	}
}

sealed class Maybe<T> : IEquatable<Maybe<T>>
{
	T value;
	bool has_value;

	public Maybe (T value)
	{
		this.value = value;
		has_value = true;
	}

	public Maybe ()
	{
	}

	public bool HasValue
	{
		get { return has_value; }
	}

	public T Value
	{
		get
		{
			if (!has_value)
				throw new InvalidOperationException ("Maybe object must have a value.");
			return this.value;
		}
	}

	public override bool Equals (object obj)
	{
		if (obj == null)
			return has_value == false;
		Maybe<T> o = obj as Maybe<T>;
		if (o == null)
			return false;
		return Equals (o);
	}

	public bool Equals (Maybe<T> obj)
	{
		if (obj == null)
			return has_value == false;
		if (obj.has_value != has_value)
			return false;
		if (!has_value)
			return true;
		return obj.value.Equals (value);
	}

	public override int GetHashCode ()
	{
		if (!has_value)
			return 0;
		return value.GetHashCode ();
	}

	public T GetValueOrDefault ()
	{
		return GetValueOrDefault (default (T));
	}

	public T GetValueOrDefault (T defaultValue)
	{
		if (!has_value)
			return defaultValue;
		else
			return value;
	}

	public override string ToString ()
	{
		if (has_value)
			return value.ToString ();
		else
			return String.Empty;
	}

	public static implicit operator Maybe<T> (T value)
	{
		return new Maybe<T> (value);
	}

	public static explicit operator T (Maybe<T> value)
	{
		return value.Value;
	}
}

static class Extensions
{
	public static R Match<T, R> (this T self, params Func<T, Maybe<R>> [] matchers)
	{
		if (matchers == null)
			throw new ArgumentNullException ("matchers");
		foreach (var m in matchers) {
			var r = m (self);
			if (r != null && r.HasValue)
				return r.Value;
		}
		throw new InvalidOperationException ("no match");
	}
}

class Program
{
	static void Main ()
	{
		Assert.AreEqual ("bar!", "foo".Match (
				s => s.Length != 3 ? null : Maybe.C ("bar!"),
				s => Maybe.C (s)), "#1");
		Assert.AreEqual ("5", 5.Match<int, string> (
				v => v != 3 ? null : Maybe.C ("bar!"),
				v => Maybe.C (v.ToString ())), "#2");
	}
}
