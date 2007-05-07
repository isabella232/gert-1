class Program
{
	static int Main ()
	{
		string s1 = null;
		string r1 = s1 as string ?? "abc";
		if (r1 == null || r1 != "abc")
			return 1;

		string s2 = "def";
		string r2 = s2 as string ?? "ghi";
		if (r2 == null || r2 != "def")
			return 1;
		return 0;
	}
}
