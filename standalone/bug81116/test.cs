using System.Collections.Generic;

public abstract class Monad<T,A> {
	public delegate T FunctionType(A input);
	public delegate T BoundFunctionType(T input);
	public abstract T Wrap(A wrappee);
	public abstract BoundFunctionType Bind(FunctionType f);
}

public class ListMonad<S> : Monad<List<S>,S> {
	public List<S> Wrap (S wrapee) {
		List<S> l = new List<S>();
		l.Add(wrapee);
		return l;
	}
	public BoundFunctionType Bind(FunctionType f) {
		return delegate (List<S> dataList) {
			List<S> returnList = new List<S>();
			foreach (S item in dataList) {
				foreach (S item2 in f(item)) {
					returnList.Add(item2);
				}
			}
			return returnList;
		};
	}
}

public static class MainClass {
	static void Main (string[] args) {
		List<int> tf = new List<int>();
		tf.Add(3); tf.Add(4);
		List<int> oT = new List<int>();
		oT.Add(1); oT.Add(2);
		ListMonad<int> _ = new ListMonad<int>();
	}
}
