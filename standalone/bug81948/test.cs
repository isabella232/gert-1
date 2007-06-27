using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
	static int Main ()
	{
		IEnumeratorEx<string> e = new StringEnumeratorEx (
			new string [] { "hello", "mono", "!" });
		e.MoveNext ();
		string part = e.Current.Substring (2);
		if (part != "llo")
			return 1;
		return 0;
	}
}

interface IEnumeratorEx<T> : IEnumerator<T>
{
	T Next
	{
		get;
	}

	bool IsLast
	{
		get;
	}

	T GetRemainingFromNext ();
}

internal sealed class StringEnumeratorEx : IEnumeratorEx<string>
{
	private string [] _data;
	private int _index;
	private int _endIndex;

	public StringEnumeratorEx (string [] value)
	{
		if (value == null) {
			throw new ArgumentNullException ("value");
		}
		this._data = value;
		this._index = -1;
		this._endIndex = value.Length;
	}

	public string Current
	{
		get
		{
			if (this._index == -1) {
				throw new InvalidOperationException ();
			}
			if (this._index >= this._endIndex) {
				throw new InvalidOperationException ();
			}
			return this._data [this._index];
		}
	}

	object IEnumerator.Current
	{
		get { return this.Current; }
	}

	public string Next
	{
		get
		{
			if (this._index == -1) {
				throw new InvalidOperationException ();
			}
			if (this._index > this._endIndex) {
				throw new InvalidOperationException ();
			}
			if (IsLast) {
				return null;
			}
			return this._data [this._index + 1];
		}
	}

	public bool IsLast
	{
		get { return (this._index == this._endIndex - 1); }
	}

	public void Reset ()
	{
		this._index = -1;
	}

	public bool MoveNext ()
	{
		if (this._index < this._endIndex) {
			this._index++;
			return (this._index < this._endIndex);
		}
		return false;
	}

	public string GetRemainingFromNext ()
	{
		throw new NotImplementedException ();
	}

	public void Dispose ()
	{
	}
}
