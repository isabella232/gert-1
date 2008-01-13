using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting;
using System.Text;

namespace MyDemo.Remoting
{
	public static class RemotingTypeCache
	{
		private static Dictionary<Type, string> _clientUrls;

		public static T GetObject<T> ()
		{
			EnsureClientUrls ();

			string url;
			if (!_clientUrls.TryGetValue (typeof (T), out url))
				throw new ArgumentException (string.Format (CultureInfo.CurrentUICulture, "Type \"{0}\" is not a well-known client remoting type", typeof (T).FullName), "T");

			return (T) Activator.GetObject (typeof (T), url);
		}

		private static void EnsureClientUrls ()
		{
			if (null != _clientUrls)
				return;

			_clientUrls = new Dictionary<Type, string> ();
			foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes ()) {
				if (null == entry.ObjectType || null == entry.ObjectUrl)
					throw new Exception ("Invalid well-known client type entry");
				_clientUrls.Add (entry.ObjectType, entry.ObjectUrl);
			}
		}
	}
}
