
using System;
using System.Runtime.InteropServices;
using System.Threading;

public delegate void FooHandler (int foo);

public class Foo {

	[DllImport ("foo")]
	private static extern void foo_start_crash (FooHandler handler);

	private static FooHandler fooref;
	private static bool ok;

	static int Main() {
		fooref = new FooHandler (OnFoo);
		foo_start_crash (fooref);
		while (!ok) {
			Thread.Sleep (2000);
		}
		if (_foo != 22)
			return 1;
		return 0;
	}

	static void OnFoo (int foo) {
		_foo = foo;
		ok = true;
	}

	static int _foo = 0;
}
