using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class CreatePage : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
	}

	protected void ObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
	{
		GridView1.PageSize = 1; 
	}
}

