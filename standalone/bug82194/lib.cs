using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
	public class ObjectContainer<T> where T : class, new ()
	{
		private Dictionary<string, T> _objects = new Dictionary<string, T> ();

		public Dictionary<string, T> Objects {
			get { return _objects; }
		}
	}

	public class DocumentObject : ObjectContainer<DomainObject>
	{
	}

	public class DomainObject : ObjectContainer<DomainObject>
	{
	}
}
