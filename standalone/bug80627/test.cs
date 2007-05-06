using System;

public class T
{
	public int this [params int [] x] {
		get {
			foreach (int i in x) {
				Console.WriteLine (i);
			}
			return 0;
		}
		set {
			foreach (int i in x) {
				Console.WriteLine (i);
			}
		}
	}

	static void Main (string [] args)
	{
		T t = new T ();
		Console.WriteLine (t [1, 2, 3, 4, 5]);
		t [1, 2, 3, 4, 5] = 2;
		Console.WriteLine (t [1, 2, 3, 4, 5]);
	}
}
