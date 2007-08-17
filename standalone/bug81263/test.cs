using System;

class Program
{
	[STAThread]
	static void Main (string [] args)
	{
		new C ().f (2);
	}
}

public sealed class C : Mono.Library.B
{
	public override void f (int a)
	{
		base.f (a);
	}
}
