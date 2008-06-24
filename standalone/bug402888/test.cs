// TypeLoadException?
using System;
using System.Collections.Generic;

static class Extensions
{
	public static IEnumerable<IEnumerable<TSource>> Transpose<TSource> (this IEnumerable<IEnumerable<TSource>> self)
	{
		IList<IList<TSource>> items = self as IList<IList<TSource>>;
		int max = 0;
		if (items == null) {
			items = new List<IList<TSource>> ();
			foreach (var outer in self) {
				List<TSource> c = new List<TSource> ();
				items.Add (c);
				foreach (var inner in outer) {
					c.Add (inner);
				}
				max = System.Math.Max (max, c.Count);
			}
		} else {
			for (int i = 0; i < items.Count; ++i)
				max = System.Math.Max (max, items [i].Count);
		}

		return CreateTransposeIterator (items, max);
	}

	private static IEnumerable<IEnumerable<TSource>> CreateTransposeIterator<TSource> (IList<IList<TSource>> items, int max)
	{
		for (int j = 0; j < max; ++j)
			yield return CreateTransposeColumnIterator (items, j);
	}

	private static IEnumerable<TSource> CreateTransposeColumnIterator<TSource> (IList<IList<TSource>> items, int column)
	{
		for (int i = 0; i < items.Count; ++i) {
			yield return (items [i].Count > column)
				? items [i] [column]
				: default (TSource);
		}
	}
	public static List<List<TSource>> ToList<TSource> (this IEnumerable<IEnumerable<TSource>> self)
	{
		List<List<TSource>> r = new List<List<TSource>> ();
		foreach (IEnumerable<TSource> row in self) {
			List<TSource> items = new List<TSource> ();
			r.Add (items);
			foreach (TSource item in row) {
				items.Add (item);
			}
		}
		return r;
	}
}

class Test
{
	static void Main ()
	{
		IEnumerable<IEnumerable<int>> a = new int [] []{
				new int[]{1, 2, 3},
				new int[]{4, 5, 6},
			};
		IEnumerable<IEnumerable<int>> b = a.Transpose ();
		List<List<int>> c = b.ToList ();

		Assert.AreEqual (3, c.Count, "#1");
		Assert.AreEqual (2, c [0].Count, "#2");
		Assert.AreEqual (1, c [0] [0], "#3");
		Assert.AreEqual (4, c [0] [1], "#4");
		Assert.AreEqual (2, c [1] [0], "#5");
		Assert.AreEqual (5, c [1] [1], "#6");
		Assert.AreEqual (3, c [2] [0], "#7");
		Assert.AreEqual (6, c [2] [1], "#8");
	}
}
