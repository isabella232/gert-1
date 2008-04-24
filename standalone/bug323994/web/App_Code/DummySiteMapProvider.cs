using System;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Security.Permissions;
using System.Data.Common;
using System.Data;
using System.Web.Caching;

namespace MonoTests.Web
{
	public class DummySiteMapProvider : StaticSiteMapProvider
	{
		private Dictionary<int, SiteMapNode> _nodes = new Dictionary<int, SiteMapNode> (16);
		private string _rootTitle;
		private SiteMapNode _root;
		private readonly object _lock = new object ();

		public override void Initialize (string name, NameValueCollection config)
		{
			if (String.IsNullOrEmpty (name))
				name = "DummySiteMapProvider";

			// Add a default "description" attribute to config if the
			// attribute doesn't exist or is empty
			if (string.IsNullOrEmpty (config ["description"])) {
				config.Remove ("description");
				config.Add ("description", "Dummy site map provider");
			}

			_rootTitle = config ["rootTitle"];

			// Call the base class's Initialize method
			base.Initialize (name, config);
		}

		public override SiteMapNode BuildSiteMap ()
		{
			lock (_lock) {
				if (_root != null)
					return _root;

				// Create the root SiteMapNode and add it to the site map
				_root = CreateRootNode ();
				AddNode (_root, null);

				SiteMapNode swfNode = new SiteMapNode (this, "2", "~/Default.aspx",
					"Windows Forms", "Microsoft Windows Forms", null, null, null, null);
				_nodes.Add (2, swfNode);
				AddNode (swfNode, _root);

				return _root;
			}
		}

		protected override SiteMapNode GetRootNodeCore ()
		{
			lock (_lock) {
				BuildSiteMap ();
				return _root;
			}
		}

		SiteMapNode CreateRootNode ()
		{
			// Get title, URL, description, and roles from the DataReader
			string url = "mono/";
			string description = "Novell Mono";

			int id = 1;

			SiteMapNode node = new SiteMapNode (this, id.ToString (), url, _rootTitle, description,
				null, null, null, null);
			_nodes.Add (id, node);
			return node;
		}
	}
}
