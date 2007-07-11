using System;
using System.Collections;
using System.Collections.Generic;

public static class Utility
{
	struct CollectionAdaptor<T> : ICollection<T>
	{
		readonly ICollection collection;

		public CollectionAdaptor (ICollection collection)
		{
			this.collection = collection;
		}

		public int Count
		{
			get { return collection.Count; }
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public void Add (T value)
		{
			throw new NotSupportedException ();
		}

		public void Clear ()
		{
			throw new NotSupportedException ();
		}

		public bool Contains (T value)
		{
			try {
				foreach (object o in collection) {
					if (Comparer<T>.Default.Compare (value, (T) o) == 0) {
						return true;
					}
				}
			} catch (InvalidCastException) { }

			return false;
		}

		public void CopyTo (T [] array, int index)
		{
			collection.CopyTo (array, index);
		}

		public bool Remove (T value)
		{
			throw new NotSupportedException ();
		}

		public IEnumerator<T> GetEnumerator ()
		{
			IEnumerator e = collection.GetEnumerator ();

			while (e.MoveNext ()) {
				yield return (T) e.Current;
			}
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return collection.GetEnumerator ();
		}
	}

	static public ICollection<T> CastToGeneric<T> (ICollection collection)
	{
		return new CollectionAdaptor<T> (collection);
	}
}
