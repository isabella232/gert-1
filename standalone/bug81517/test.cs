namespace Test
{
	public class Test<T> where T : Test<T>
	{
		private int someData;

		public void Copy (T other)
		{
			someData = other.someData;
		}
	}
}
