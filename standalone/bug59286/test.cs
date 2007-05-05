class A : T { }
class T
{
	static int Main ()
	{
		object o = (T [] []) (object) (new A [] [] { });
		if (o == null) {
			return 1;
		}
		return 0;
	}
}
