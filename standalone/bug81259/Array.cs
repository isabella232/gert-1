using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public abstract class Array<T> : ICollection<T>
{
	protected int [] shape;

	public int Dimension
	{
		get
		{
			return shape.Length;
		}
	}

	public int [] Shape
	{
		get
		{
			return shape;
		}
	}

	public virtual int Size
	{
		get
		{
			return SizeFromShape (Shape);
		}
	}

	public virtual int Count
	{
		get
		{
			return Size;
		}
	}

	public virtual bool IsReadOnly
	{
		get { return true; }
	}

	protected Array (Array<T> array)
	{
		if (array == null) {
			throw new ArgumentNullException ("array");
		}

		this.shape = (int []) array.Shape.Clone ();
	}


	protected Array (System.Array array)
	{
		if (array == null) {
			throw new ArgumentNullException ("array");
		}

		int [] shape = new int [array.Rank];

		for (int i = 0; i < array.Rank; ++i) {
			shape [i] = array.GetLength (i);
		}

		this.shape = shape;
	}

	protected Array (params int [] shape)
	{
		if (shape == null) {
			throw new ArgumentNullException ("shape");
		}

		if (!IsValidShape (shape)) {
			throw new InvalidArrayShapeException (shape.ToString ());
		}

		this.shape = (int []) shape.Clone ();
	}

	public virtual T this [params int [] position]
	{
		get
		{
			if (position == null) {
				throw new ArgumentNullException ("position");
			}

			if (position.Length == 1) {
				RangeCheck (position [0]);
				return UnsafeGetValue (position [0]);
			} else {
				RangeCheck (position);
				return UnsafeGetValue (position);
			}
		}

		set
		{
			if (position == null) {
				throw new ArgumentNullException ("position");
			}

			if (position.Length == 1) {
				RangeCheck (position [0]);
				UnsafeSetValue (value, position [0]);
			} else {
				RangeCheck (position);
				UnsafeSetValue (value, position);
			}
		}
	}

	public virtual Array<T> Fill (T value)
	{
		for (int i = 0; i < Size; ++i) {
			UnsafeSetValue (value, i);
		}

		return this;
	}

	public virtual Array<T> Fill (ICollection<T> values)
	{
		if (values == null) {
			throw new ArgumentNullException ("values");
		}

		if (Size % values.Count != 0) {
			throw new IncompatibleArrayShapeException (
				"array size must be divisible by values.Count");
		}

		int numRepeats = Size / values.Count;
		int index = 0;

		for (int i = 0; i < numRepeats; ++i) {
			foreach (T v in values) {
				UnsafeSetValue (v, index);
				++index;
			}
		}

		Debug.Assert (index == Size);

		return this;
	}

	public virtual Array<T> Fill (IEnumerator<T> values)
	{
		if (values == null) {
			throw new ArgumentNullException ("values");
		}

		int index = 0;

		while (values.MoveNext ()) {
			UnsafeSetValue (values.Current, index);
			++index;
		}

		if (index != Size) {
			throw new PrematureValuesEndException (index, Size);
		}

		return this;
	}

	private void RangeCheck (int [] position)
	{
		if (position.Length != Dimension) {
			throw new IncompatibleDimensionException (
				"position was \"" + position.ToString () + "\" "
				+ "but should have been "
				+ Dimension);
		}


		if (!IsValidPosition (position, Shape)) {
			throw new System.IndexOutOfRangeException ();
		}
	}

	private void RangeCheck (int index)
	{
		if (!IsValidIndex (index, Shape)) {
			throw new System.IndexOutOfRangeException ();
		}
	}

	internal protected abstract T UnsafeGetValue (int [] position);

	internal protected virtual T UnsafeGetValue (int index)
	{
		return UnsafeGetValue (PositionFromIndex (index, Shape));
	}

	internal protected abstract void UnsafeSetValue (T value, int [] position);

	protected virtual void UnsafeSetValue (T value, int index)
	{
		UnsafeSetValue (value, PositionFromIndex (index, Shape));
	}

	public virtual IEnumerable<Array<T>> Subarrays (params int [] margin)
	{
		yield return this;
	}

	public virtual IEnumerator<T> GetEnumerator ()
	{
		for (int i = 0; i < Size; ++i) {
			yield return UnsafeGetValue (i);
		}
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		foreach (T value in ((IEnumerable<T>) this)) {
			yield return value;
		}
	}

	public Array<T> Transform (Converter<T, T> converter)
	{
		if (converter == null) {
			throw new ArgumentNullException ("converter");
		}

		for (int i = 0; i < Size; ++i) {
			UnsafeSetValue (converter (UnsafeGetValue (i)), i);
		}

		return this;
	}

	public Array<T> Map (Converter<T, T> converter)
	{
		if (converter == null) {
			throw new ArgumentNullException ("converter");
		}

		DenseArray<T> result = new DenseArray<T> (Shape);

		for (int i = 0; i < Size; ++i) {
			result.UnsafeSetValue (converter (UnsafeGetValue (i)), i);
		}

		return result;
	}

	public Array<S> Map<S> (Converter<T, S> converter)
	{
		if (converter == null) {
			throw new ArgumentNullException ("converter");
		}

		DenseArray<S> result = new DenseArray<S> (Shape);

		for (int i = 0; i < Size; ++i) {
			S transformed = converter (UnsafeGetValue (i));
			result.UnsafeSetValue (transformed, i);
		}

		return result;
	}

	public void Add (T value)
	{
		throw new System.NotSupportedException ();
	}

	public void Clear ()
	{
		throw new System.NotSupportedException ();
	}

	public bool Contains (T value)
	{
		foreach (T item in this) {
			if (Comparer<T>.Default.Compare (value, item) == 0) {
				return true;
			}
		}

		return false;
	}

	public void CopyTo (T [] array, int index)
	{
		if (array == null) {
			throw new ArgumentNullException ("array");
		}

		if (index < 0) {
			throw new IndexOutOfRangeException ();
		}

		if (index + Size > array.Length) {
			throw new IndexOutOfRangeException ();
		}

		foreach (T value in this) {
			array [index] = value;
			++index;
		}
	}

	public bool Remove (T value)
	{
		throw new System.NotSupportedException ();
	}

	public static explicit operator T (Array<T> array)
	{
		if (array.Dimension != 0) {
			throw new InvalidCastException (
				"Cannot cast a " + array.Dimension
				+ "-dimensional array to a scalar");
		}

		return array [0];
	}

	public static implicit operator Array<T> (T value)
	{
		Array<T> result = new DenseArray<T> ();
		result [0] = value;
		return result;
	}

	public static bool IsValidShape (params int [] shape)
	{
		if (shape == null) {
			throw new ArgumentNullException ("shape");
		}

		for (int i = 0; i < shape.Length; ++i) {
			if (shape [i] < 0) {
				return false;
			}
		}

		return true;
	}

	static public int SizeFromShape (params int [] shape)
	{
		if (shape == null) {
			throw new ArgumentNullException ("shape");
		}

		int result = 1;

		foreach (int s in shape) {
			result *= s;
		}

		return result;
	}

	static public int IndexFromPosition (int [] position, int [] shape)
	{
		Debug.Assert (position != null);
		Debug.Assert (shape != null);
		Debug.Assert (position.Length == shape.Length);
		Debug.Assert (IsValidShape (shape));
		Debug.Assert (IsValidPosition (position, shape));

		int index = 0;

		if (shape.Length > 0) {
			int size = shape [0];
			index = position [0];

			for (int i = 1; i < position.Length; ++i) {
				index = index + position [i] * size;
				size = size * shape [i];
			}
		}

		Debug.Assert (position.Equals (PositionFromIndex (index, shape)));

		return index;
	}

	static public int [] PositionFromIndex (int index, int [] shape)
	{
		Debug.Assert (shape != null);
		Debug.Assert (IsValidShape (shape));
		Debug.Assert (index >= 0);
		Debug.Assert (index < SizeFromShape (shape));

		int [] position = new int [shape.Length];

		if (shape.Length == 1) {
			position [0] = index;
		} else if (shape.Length > 1) {
			for (int i = 0; i < shape.Length; ++i) {
				position [i] = index % shape [i];
				index = index / shape [i];
			}
		}

		return position;
	}

	static public bool IsValidPosition (int [] position, int [] shape)
	{
		Debug.Assert (position != null);
		Debug.Assert (shape != null);
		Debug.Assert (IsValidShape (shape));

		for (int i = 0; i < shape.Length; ++i) {
			if ((position [i] < 0) || (position [i] >= shape [i])) {
				return false;
			}
		}

		return true;
	}

	static public bool IsValidIndex (int index, int [] shape)
	{
		Debug.Assert (shape != null);
		Debug.Assert (IsValidShape (shape));

		if ((index < 0) || (index >= SizeFromShape (shape))) {
			return false;
		} else {
			return true;
		}
	}
}
