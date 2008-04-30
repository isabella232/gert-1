using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
	static void Main ()
	{
		TestList ();
		TestDictionary ();
#if NET_3_5
		TestHashSet ();
#endif

		ForceCollect ();
		Assert.AreEqual (0, Item.Count, "End Result");
	}

	static void TestList ()
	{
		List<Item> l = new List<Item> ();

		int initial = Item.Count;
		l.Add (new Item ());
		l.Add (new Item ());
		l.Add (new Item ());
		ForceCollect ();
		Assert.AreEqual (initial + 3, Item.Count, "#A1");

		initial = Item.Count;
		l.RemoveAt (0);
		ForceCollect ();
		Assert.AreEqual (initial - 1, Item.Count, "#A2");

		initial = Item.Count;
		l.Clear ();
		ForceCollect ();
		Assert.AreEqual (initial - 2, Item.Count, "#A3");
	}

	static void TestDictionary ()
	{
		Dictionary<int, Item> d = new Dictionary<int, Item> ();

		int initial = Item.Count;
		d.Add (1, new Item ());
		d.Add (2, new Item ());
		d.Add (3, new Item ());
		ForceCollect ();
		Assert.AreEqual (initial + 3, Item.Count, "#B1");

		initial = Item.Count;
		d.Remove (2);
		ForceCollect ();
		Assert.AreEqual (initial - 1, Item.Count, "#B2");

		initial = Item.Count;
		d.Clear ();
		ForceCollect ();
		Assert.AreEqual (initial - 2, Item.Count, "#B3");
	}

#if NET_3_5
	static void TestHashSet ()
	{
		HashSet <Item> h= new HashSet <Item> ();

		int initial = Item.Count;

		Item itemA = new Item ();
		Item itemB = new Item ();
		Item itemC = new Item ();
		h.Add (itemA);
		h.Add (itemB);
		h.Add (itemC);
		ForceCollect ();
		Assert.AreEqual (initial + 3, Item.Count, "#C1");

		initial = Item.Count;
		h.Remove (itemB);
		itemB = null;
		ForceCollect ();
		Assert.AreEqual (initial - 1, Item.Count, "#C2");

		initial = Item.Count;
		h.Clear ();
		itemA = null;
		itemC = null;
		ForceCollect ();
		Assert.AreEqual (initial - 2, Item.Count, "#C3");
	}
#endif

	static void ForceCollect ()
	{
		GC.Collect ();
		Thread.Sleep (200);
	}
}

internal class Item
{
	~Item ()
	{
		--ms_instanceCount;
	}

	public Item ()
	{
		++ms_instanceCount;
	}

	public static int Count
	{
		get { return ms_instanceCount; }
	}

	private static int ms_instanceCount;
}
