using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BusinessEntity
/// </summary>
public class BusinessEntity
{
	private string m_data1 = string.Empty;
	private string m_data2 = string.Empty;

	public string Data1
	{
		get { return m_data1; }
		set { m_data1 = value; }
	}

	public string Data2
	{
		get { return m_data2; }
		set { m_data2 = value; }
	}
}
