using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Scea.Collections
{
	[Serializable]
	public class Multimap<Key, Value>
	{
		public IEnumerable<Value> Find (Key key)
		{
			if (key == null)
				throw new ArgumentNullException ("key");

			object values;
			if (!m_keyValues.TryGetValue (key, out values))
				return s_emptyArray;

			IEnumerable<Value> result = values as IEnumerable<Value>;
			if (result == null) {
				result = new Value [] { (Value) values };
			}
			return result;
		}

		public IEnumerable<Value> this [Key key]
		{
			get
			{
				return Find (key);
			}
		}

		public void Add (Key key, Value value)
		{
			object values;
			if (!m_keyValues.TryGetValue (key, out values))
				m_keyValues [key] = value;
			else {
				List<Value> valuesArray = values as List<Value>;
				if (valuesArray == null) {
					m_keyValues.Remove (key);
					valuesArray = new List<Value> (2);
					m_keyValues.Add (key, valuesArray);
					valuesArray.Add ((Value) values);
				}
				valuesArray.Add (value);
			}
		}

		private Dictionary<Key, object> m_keyValues = new Dictionary<Key, object> ();
		private static Value [] s_emptyArray = new Value [0];
	}
}

