class SimpleIterator<T> : System.Collections.IEnumerator
{
	T x;
	public void Reset () { }
	public bool MoveNext () { return false; }
	public object Current
	{
		get { return x; }
	}
}
