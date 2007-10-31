class Program
{
	public bool check (object from, object to)
	{
		if (from is int && to is int) return true;
		return false;
	}
}
