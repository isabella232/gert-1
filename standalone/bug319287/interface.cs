using System;

namespace BaseLib
{
	public abstract class BaseRemoteObject : MarshalByRefObject
	{
		public abstract void setValue (int pValue);
		public Test test = null;
		public abstract int getValue ();
		public abstract string getText ();
	}

	[Serializable]
	public class Test
	{
		public String t = null;
	}
}
