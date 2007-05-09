using System;
using System.IO;

using Mono.Cecil;

class Program
{
	static void Main (string [] args)
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyDefinition asm = AssemblyFactory.GetAssembly (Path.Combine (dir, "WindowsApp1.exe"));
		AssemblyFactory.SaveAssembly (asm, Path.Combine (dir, "WindowsApp2.exe"));
	}
}
