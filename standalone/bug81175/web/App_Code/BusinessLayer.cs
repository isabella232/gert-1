using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BusinessLayer
/// </summary>
public class BusinessLayer
{
	public BusinessLayer()
	{
	}

	public List<BusinessEntity> SelectEntity(int startIndex, int maxCount)
	{
		BusinessEntity item1 = new BusinessEntity();
		item1.Data1 = "Item 1";
		item1.Data2 = "Data 1";

		BusinessEntity item2 = new BusinessEntity();
		item2.Data1 = "Item 2";
		item2.Data2 = "Data 2";

		List<BusinessEntity> result = new List<BusinessEntity>(2);
		result.Add(item1);
		result.Add(item2);

		return result;
	}

	public int EntityCount(int startIndex, int maxCount)
	{
		return 4;
	}
}
