using System;

namespace Mono.Design
{
	public class NameAttribute : Attribute
	{
		public NameAttribute (string name)
		{
			_name = name;
		}

		public string Name
		{
			get { return _name; }
		}

		private string _name;
	}
}
