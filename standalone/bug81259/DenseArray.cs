using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class DenseArray<T> : Array<T>, IEnumerable<T>
{
	protected T [] data;

	public override int Size
	{
		get
		{
			return data.Length;
		}
	}

	public DenseArray (params int [] shape) : base (shape)
	{
		data = new T [SizeFromShape (shape)];
	}

	public DenseArray (Array<T> array) : base (array)
	{
		DenseArray<T> dense = array as DenseArray<T>;

		if (dense == null) {
			data = new T [array.Size];
			this.Fill (array);
		} else {
			data = (T []) dense.data.Clone ();
		}
	}

	public DenseArray (System.Array array) : base (array)
	{
		if (array.Length > 0) {
			this.data = new T [array.Length];
		} else {
			this.data = new T [1];
		}

		try {
			for (int index = 0; index < data.Length; ++index) {
				T value = (T) array.GetValue (PositionFromIndex (index, Shape));
				data [index] = value;
			}
		} catch (System.InvalidCastException e) {
			throw e;
		}
	}

	public override Array<T> Fill (ICollection<T> values)
	{
		if (values == null) {
			throw new ArgumentNullException ("values");
		}

		if (Size % values.Count != 0) {
			throw new IncompatibleArrayShapeException (
				"array size must be divisible by values.Count");
		}

		int numRepeats = Size / values.Count;
		int offset = 0;

		for (int i = 0; i < numRepeats; ++i) {
			values.CopyTo (data, offset);
			offset += values.Count;
		}

		return this;
	}

	internal protected override T UnsafeGetValue (int [] position)
	{
		Debug.Assert (position != null);
		return data [IndexFromPosition (position, Shape)];
	}


	internal protected override void UnsafeSetValue (T value, int [] position)
	{
		Debug.Assert (position != null);
		data [IndexFromPosition (position, Shape)] = value;
	}

	public override IEnumerator<T> GetEnumerator ()
	{
		foreach (T value in ((IEnumerable) this)) {
			yield return value;
		}
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		return data.GetEnumerator ();
	}

	public override string ToString ()
	{
		return string.Empty;
	}
}
