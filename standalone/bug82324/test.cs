class Program
{
	unsafe delegate void Foo (void* dummy);
	static unsafe void FooImplementation (void* dummy)
	{
	}
	static unsafe Foo Bar = new Foo (FooImplementation);
}
