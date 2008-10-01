using System;

class Client
{
	String id = string.Empty;

	public delegate void delStatus (String id, String text);

	public Client (String id)
	{
		this.id = id;
	}

	public String Id
	{
		get { return this.id; }
		set { this.id = value; }
	}
}
