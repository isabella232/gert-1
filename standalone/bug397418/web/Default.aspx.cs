using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public class _Default : Page
{
	protected Label Label1;
	protected Label Label2;
	protected Label Label3;
	protected Label Label4;

	protected void Page_Load (object sender, EventArgs e)
	{
		XmlDocument doc;
		
		doc = new XmlDocument ();
		doc.Load (Server.MapPath ("/") + "1.xml");
		Label1.Text = doc.DocumentElement.LocalName;

		doc = new XmlDocument ();
		doc.Load (Server.MapPath ("/xml/") + "1.xml");
		Label2.Text = doc.DocumentElement.LocalName;

		doc = new XmlDocument ();
		doc.Load (Server.MapPath ("1.xml"));
		Label3.Text = doc.DocumentElement.LocalName;

		doc = new XmlDocument ();
		doc.Load (Server.MapPath ("xml/") + "1.xml");
		Label4.Text = doc.DocumentElement.LocalName;
	}
}
