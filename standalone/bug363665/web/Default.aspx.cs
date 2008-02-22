using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MonoLab
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			List<MonoItem> list = new List<MonoItem>();
			list.Add(new MonoItem("Mono", 1));
			list.Add(new MonoItem("Develop", 2));

			rptMono.ItemTemplate = LoadTemplate("RepeaterTemplate.ascx");
			rptMono.DataSource = list;
			rptMono.DataBind();
		}
	}
}
