using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

class MonoEmbed
{
	[MethodImplAttribute (MethodImplOptions.InternalCall)]
	extern public static string gimme ();
	extern public static int gimme2 ();
}

public class Class1
{
	public static void Main (string [] args)
	{
		Console.WriteLine ("Hello From Test App");
		Console.WriteLine (MonoEmbed.gimme ());
		Console.WriteLine (MonoEmbed.gimme2 ());
	}
}
