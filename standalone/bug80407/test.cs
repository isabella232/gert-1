public class Test
{
	private C _vssItem = null;

	public string Spec {
		get { return _vssItem.Spec; }
	}

	public void Checkout ()
	{
		_vssItem.Checkout ();
	}
}

interface A
{
	void Checkout ();
	string Spec
	{
		get;
	}
}

interface B : A
{
	new void Checkout ();
	new string Spec
	{
		get;
	}
}

interface C : B
{
}
