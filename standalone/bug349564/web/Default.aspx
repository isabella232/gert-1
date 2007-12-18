<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
	protected override void OnLoad (EventArgs e)
	{
		HttpCookie cookie;

		cookie = Request.Cookies ["DOESNOTEXIST"];
		if (cookie != null)
			throw new Exception ("#A1");
		cookie = Request.Cookies ["DOESNOTEXIST"];
		if (cookie != null)
			throw new Exception ("#A2");

		cookie = Response.Cookies ["DOESNOTEXIST"];
		if (cookie == null)
			throw new Exception ("#B1");
		if (!object.ReferenceEquals(cookie, Response.Cookies ["DOESNOTEXIST"]))
			throw new Exception ("#B2");
		if (cookie.Domain != null)
			throw new Exception ("#B3");
		if (cookie.Expires != DateTime.MinValue)
			throw new Exception ("#B4:" + cookie.Expires.ToString ("dd/MM/yyyy HH:mm:ss"));
		if (cookie.HasKeys)
			throw new Exception ("#B5");
		if (cookie.HttpOnly)
			throw new Exception ("#B6");
		if (cookie.Name != "DOESNOTEXIST")
			throw new Exception ("#B7");
		if (cookie.Path != "/")
			throw new Exception ("#B8:" + cookie.Path);
		if (cookie.Secure)
			throw new Exception ("#B9");
		if (cookie.Value != string.Empty)
			throw new Exception ("#B10:" + cookie.Value);
		if (cookie.Values.Count != 0)
			throw new Exception ("#B11");

		cookie = Request.Cookies.Get ("NEVEREXISTED");
		if (cookie != null)
			throw new Exception ("#C1");
		cookie = Request.Cookies.Get ("NEVEREXISTED");
		if (cookie != null)
			throw new Exception ("#C2");

		cookie = Response.Cookies.Get ("NEVEREXISTED");
		if (cookie == null)
			throw new Exception ("#D1");
		if (!object.ReferenceEquals(cookie, Response.Cookies.Get ("NEVEREXISTED")))
			throw new Exception ("#D2");
		if (cookie.Domain != null)
			throw new Exception ("#D3");
		if (cookie.Expires != DateTime.MinValue)
			throw new Exception ("#D4:" + cookie.Expires.ToString ("dd/MM/yyyy HH:mm:ss"));
		if (cookie.HasKeys)
			throw new Exception ("#D5");
		if (cookie.HttpOnly)
			throw new Exception ("#D6");
		if (cookie.Name != "NEVEREXISTED")
			throw new Exception ("#D7");
		if (cookie.Path != "/")
			throw new Exception ("#D8:" + cookie.Path);
		if (cookie.Secure)
			throw new Exception ("#D9");
		if (cookie.Value != string.Empty)
			throw new Exception ("#D10:" + cookie.Value);
		if (cookie.Values.Count != 0)
			throw new Exception ("#D11");

		Label1.Text = "OK";
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
</head>
<body>
	<form id="Form1" runat="server">
		<div>
			<asp:Label ID="Label1" runat="server" />
	</form>
</body>
</html>
