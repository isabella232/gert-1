class Test
{
	struct MyStruct
	{
		public int this [int index]
		{
			get { return 123; }
			set { } // whatever
		}
	}

	public static void Main ()
	{
		MyStruct s = new MyStruct ();
		s [0] += 5;
	}
}
