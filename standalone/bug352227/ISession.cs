using System;

namespace MyDemo.Remoting
{
	public interface ISession
	{
		void RefreshConfiguration ();
		void Start ();
		void Stop ();
	}
}
