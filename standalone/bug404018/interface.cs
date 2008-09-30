using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace BaseLib
{
	public abstract class BaseRemoteObject : MarshalByRefObject, IMessage
	{
		public abstract IDictionary Properties {
			get;
		}
	}
}
