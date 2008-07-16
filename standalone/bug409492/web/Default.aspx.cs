using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load (object sender, EventArgs e)
	{
		XmlDataSource xmlds = new XmlDataSource ();

		xmlds.DataFile = "./dialogbeispiel.xml";
		XmlDocument xmldoc = xmlds.GetXmlDocument ();
		XmlNodeList xmlnl = xmldoc.GetElementsByTagName ("button");

		foreach (XmlNode node in xmlnl) {
			Button tmp = new Button ();
			tmp.Text = node.FirstChild.InnerText;
			tmp.ID = node.ChildNodes [1].InnerText;
			PlaceHolder1.Controls.Add (tmp);
		}
	}
}
