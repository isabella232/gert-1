using System;

public class MyClass
{
	public MyClass ()
	{
	}

	public string Run ()
	{
		return typeof (MyClass).Assembly.Location;
	}
}
