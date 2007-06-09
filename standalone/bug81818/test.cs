using System;

class Program
{
	public class A
	{
		public event EventHandler MouseClick;

		public virtual void Fire ()
		{
			if (MouseClick != null)
				MouseClick (this, new EventArgs ());
		}
	}

	public class B : A
	{
		public new event EventHandler MouseClick;

		public override void Fire ()
		{
			if (MouseClick != null)
				MouseClick (this, new EventArgs ());
		}
	}

	public class C : B
	{
		public new void MouseClick ()
		{
			Console.Write ("This should be printed");
		}
	}

	static void Main ()
	{
		C myclass = new C ();
		myclass.MouseClick ();
	}
}
