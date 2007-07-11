using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Sequence : IList<double>
{
	private readonly double start;
	private readonly double end;
	private readonly int length;
	private readonly double stride;

	public double Start
	{
		get { return start; }
	}

	public double End
	{
		get { return end; }
	}

	public double Stride
	{
		get { return stride; }
	}

	public int Length
	{
		get { return length; }
	}

	public bool IsReadOnly
	{
		get { return true; }
	}

	public int Count
	{
		get
		{
			return length;
		}
	}

	public double this [int index]
	{
		get
		{
			if ((index < 0) || (index >= Length)) {
				throw new IndexOutOfRangeException ();
			}

			if (index == 0) {
				return Start;
			} else if (index == Length - 1) {
				return End;
			} else {
				return (index / (Length - 1)) * (End - Start) + Start;
			}
		}

		set
		{
			throw new System.NotSupportedException ();
		}
	}

	public Sequence (double start, double end, int length)
	{
		if (length < 0) {
			throw new ArgumentOutOfRangeException (
				"length is negative");
		}

		this.start = start;
		this.end = end;
		this.length = length;

		if (length == 0) {
			this.stride = 0;
		} else {
			this.stride = (end - start) / length;
		}
	}

	public void Add (double value)
	{
		throw new System.NotSupportedException ();
	}

	public void Add (object value)
	{
		throw new System.NotSupportedException ();
	}

	public void Clear ()
	{
		throw new System.NotSupportedException ();
	}

	public bool Contains (double value)
	{
		if (Stride > 0) {
			return ((value >= Start)
					&& (value <= End)
					&& ((value - Start) % Stride < 1e-7));
		} else {
			return ((value >= End)
					&& (value <= Start)
					&& (value - Start) % Stride < 1e-7);
		}
	}

	public int IndexOf (double value)
	{
		int result = -1;

		if (Contains (value)) {
			result = (int) ((value - Start) / Stride);
			Debug.Assert (Math.Abs (this [result] - value) < 1e-4);
		}

		return result;
	}

	public void Insert (int index, double value)
	{
		throw new System.NotSupportedException ();
	}

	public bool Remove (double value)
	{
		throw new System.NotSupportedException ();
	}

	public void RemoveAt (int index)
	{
		throw new System.NotSupportedException ();
	}

	public void CopyTo (double [] array, int index)
	{
		if (array == null) {
			throw new ArgumentNullException ("array");
		}

		if (index < 0) {
			throw new IndexOutOfRangeException ();
		}

		if ((array.Rank != 1)
			|| (index >= array.Length)
			|| (index + Count > array.Length)) {
			throw new ArgumentException ();
		}

		for (int i = 0; i < Count; ++i) {
			array [index + i] = this [i];
		}
	}

	public IEnumerator<double> GetEnumerator ()
	{
		for (int i = 0; i < Count; ++i) {
			yield return this [i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		foreach (int value in ((IEnumerable<double>) this)) {
			yield return value;
		}
	}

	public override string ToString ()
	{
		string result = ("Sequence(" + Start + " to " + End
			+ " of length " + Length + ")");

		return result;
	}
}
