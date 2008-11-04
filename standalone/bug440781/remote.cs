using System;

public class RemoteTester : MarshalByRefObject
{
	public string GetBaseDirectory ()
	{
		return AppDomain.CurrentDomain.BaseDirectory;
	}
}
