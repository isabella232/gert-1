using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
	static void Main ()
	{
		TestA ();
		TestB ();
	}

	static void TestA ()
	{
		Dictionary<int, Item> d = new Dictionary<int, Item> ();

		Item itemA = new Item ();
		Item itemB = new Item ();
		Item itemC = new Item ();
		d.Add (1, itemA);
		d.Add (2, itemB);
		d.Add (3, itemC);
		ForceCollect ();
		Assert.AreEqual (3, Item.Count, "#A1");

		d.Remove (2);
		ForceCollect ();
		Assert.AreEqual (2, Item.Count, "#A2");

		d.Clear ();
		ForceCollect ();
		Assert.AreEqual (0, Item.Count, "#A3");
	}

	static void TestB ()
	{
		Dictionary<int, Item> d = new Dictionary<int, Item> ();

		Item itemA = new Item ();
		Item itemB = new Item ();
		Item itemC = new Item ();
		d.Add (1, itemA);
		d.Add (2, itemB);
		d.Add (3, itemC);
		ForceCollect ();
		Assert.AreEqual (3, Item.Count, "#B1");

		d.Remove (2);
		itemB = null;
		ForceCollect ();
		Assert.AreEqual (2, Item.Count, "#B2");

		d.Clear ();
		itemA = null;
		itemC = null;
		ForceCollect ();
		Assert.AreEqual (0, Item.Count, "#B3");
	}

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
