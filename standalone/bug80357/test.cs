using System;

public class Test
{
	static void Main ()
	{
	}
}

public class A<T>
{
	public event EventHandler<EventArgs> KeyPress;

	public A ()
	{
		KeyPress += new EventHandler<EventArgs> (ListView_KeyPress);
	}

	private void ListView_KeyPress (object sender, EventArgs e)
	{
	}
}
