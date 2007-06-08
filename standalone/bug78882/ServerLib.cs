using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Threading;

namespace Test
{
	public class BaseObj : MarshalByRefObject
	{
		public virtual SubT[] GetMembers<SubT>(bool recursive_search) where SubT : BaseObj
		{
			return new SubT[0];
		}
	}

	public class BaseList : BaseObj
	{
		public override SubT[] GetMembers<SubT>(bool recursive_search)
		{
			List<SubT> result = new List<SubT>();
			BaseObj x = new BaseObj();
			if (x is SubT)
				result.Add(x as SubT);
			return result.ToArray();
		}
	}

	public class ServerLib : MarshalByRefObject
	{
		public ServerLib(int port, string url)
		{
			RemotingHelper.Init(port);
			RemotingServices.Marshal(this, url);
		}

		public BaseList Test()
		{
			return new BaseList();
		}

		public void Run()
		{
			Thread.CurrentThread.Join();
		}
	}
}
