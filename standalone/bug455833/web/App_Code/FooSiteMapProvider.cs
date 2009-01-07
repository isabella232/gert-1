using System;
using System.Web;
using System.Collections.Specialized;

namespace Bug
{
	public class FooSiteMapProvider : StaticSiteMapProvider
	{
		SiteMapNode rootNode;


		public override void Initialize (string name, NameValueCollection attributes)
		{
			base.Initialize (name, attributes);

		}

		public override SiteMapNode BuildSiteMap ()
		{
			if (rootNode == null) {
				rootNode = new SiteMapNode (this, "foo", "~/foo.aspx", "foo", "");
			}
			return rootNode;
		}

		protected override SiteMapNode GetRootNodeCore ()
		{
			return RootNode;
		}

		public override SiteMapNode RootNode
		{
			get
			{
				return BuildSiteMap ();
			}
		}
	}
}
