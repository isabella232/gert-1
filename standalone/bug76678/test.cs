class Program
{
	static void Main () 
	{
		FixVolatileData (1);
	}

	private static void FixVolatileData(int flags)
	{
		object forceCreation;

		if (flags > 0) {
			forceCreation = "";
		}
	}
}
