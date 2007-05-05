class Repro
{
	private int[] stack = new int[1];
 	private int cc;
 	public int fc;
 	private int sp;

 	static int Main()
 	{
 		Repro r = new Repro();
 		r.foo();
		return r.stack[0] == 42 ? 0 : 1;
 	}

 	public void foo()
 	{
 		fc = cc = bar();
 		fc = stack[sp++] = cc;
 	}

	private int bar()
	{
		return 42;
	}
}
