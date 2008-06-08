using System;
using System.Web;

public class DynamicSiteMapProvider : StaticSiteMapProvider
{
	object rootNodeLock = new object ();
	SiteMapNode rootNode = null;
	static int [] ids = new int [] { 0, 1, 2, 3 };

	public override SiteMapNode RootNode {
		get { return BuildSiteMap (); }
	}

	protected override SiteMapNode GetRootNodeCore ()
	{
		return BuildSiteMap ();
	}

	protected override void Clear ()
	{
		lock (rootNodeLock) {
			rootNode = null;
			base.Clear ();
		}
	}

	public void Refresh ()
	{
		foreach (SiteMapNode child in new SiteMapNodeCollection (rootNode.ChildNodes))
			RemoveNode (child);

		Populate ();
	}

	public override SiteMapNode BuildSiteMap ()
	{
		lock (rootNodeLock) {
			if (rootNode == null) {
				rootNode = new SiteMapNode (this, "DynamicRoot", String.Empty, "Dynamic");
				Populate ();
				AddNode (rootNode);
			}
			return rootNode;
		}
	}

	void Populate ()
	{
		foreach (int id in ids)
			AddNode (new SiteMapNode (this, id.ToString (), "~/link.aspx?id=" + id, "Link" + id), rootNode);
	}
}
