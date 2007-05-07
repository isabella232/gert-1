public partial class Test<T> where T:new()
{
	public delegate void TestDelegate (object sender, T value);
	public virtual event TestDelegate TestEvent;

	public void Run ()
	{
		if (TestEvent != null)
			TestEvent (this, new T ());
	}
}
