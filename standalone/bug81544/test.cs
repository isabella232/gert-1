public class Test
{
	public delegate void TestDelegate (object sender, int value);
	public virtual event TestDelegate TestEvent;
}
