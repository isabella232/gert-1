using System;
using System.Text;

namespace Common
{
	public interface ISayHello
	{
		string SayHello();
	}

	public sealed class HelloClass : MarshalByRefObject, ISayHello
	{
		public HelloClass ()
		{
		}

		string ISayHello.SayHello ()
		{
			return "Hello";
		}

		public byte [] SayHello ()
		{
			return Encoding.UTF8.GetBytes ("Hello");
		}
	}
}
