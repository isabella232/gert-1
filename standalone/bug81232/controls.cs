using System;
using System.Web;
using System.Web.UI;

namespace MonoPortal.Web
{
	public class ControlA : Control
	{
		protected override void Render (HtmlTextWriter output)
		{
			output.Write (".Control!A.");
		}
	}
}

namespace MonoPortal.Web.UI
{
	public class ControlB : Control
	{
		protected override void Render (HtmlTextWriter output)
		{
			output.Write (".Control!B.");
		}
	}
}
