using System;
using System.Threading;

public delegate void VoidHandler ();
public delegate TResult ResultHandler<TResult> ();

class Result<T>
{
	public Result ()
	{
	}
}

class TaskBehaviour
{
	public Exception Execute (VoidHandler handler)
	{
		return new Exception ();
	}
}

class Program
{
	static Result<TResult> Fork<TResult> (ResultHandler<TResult> handler, Result<TResult> result)
	{
		if (handler == null) {
			throw new Exception ("null");
		}

		TaskBehaviour behaviour = new TaskBehaviour ();

		ThreadPool.QueueUserWorkItem (delegate (object unused) {
			try {
				TResult response = default (TResult);
				Exception exception = behaviour.Execute (delegate () {
					response = handler ();
				});
			} catch (Exception ) {
			} finally {
			}
		});

		return result;
	}
}
