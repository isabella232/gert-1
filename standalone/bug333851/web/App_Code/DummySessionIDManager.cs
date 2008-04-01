using System;
using System.Web;
using System.Web.SessionState;

namespace Test
{
	public class DummySessionIDManager : SessionIDManager
	{
		public override string CreateSessionID (HttpContext context)
		{
			throw new Exception ("Exception from DummySessionIDManager");
		}
	}
}
