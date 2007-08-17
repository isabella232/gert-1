namespace Mono.Library
{
	public interface Itest
	{
		void f (int a);
	}

	public abstract class A : Itest
	{
		int a;

		public virtual void f (int a)
		{
			this.a = a;
		}

		public int Name {
			get { return a; }
		}
	}

	public class B : A, Itest
	{
	}
}
