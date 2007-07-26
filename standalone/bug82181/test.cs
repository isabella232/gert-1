class Program
{
	public static bool Check (string name, string [] names)
	{
		foreach (string partial in names) {
			if (name.IndexOf (partial) == -1)
				return true;
		}

		return false;
	}
}
