<%@ Page Language="C#" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Text" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>bug #333745</title>
	<script runat="server">
		void Page_Load (object o, EventArgs e)
		{
			StringBuilder sb = new StringBuilder ();
			MembershipProviderCollection providers = Membership.Providers;

			sb.AppendFormat ("|Total providers|{0}|Total providers|", providers.Count);
			sb.AppendFormat ("|Default provider|{0}|Default provider|", Membership.Provider.Name);
			foreach (MembershipProvider provider in providers)
				sb.AppendFormat ("|Provider|{0}|Provider|", provider.Name);

			MembershipSection section = (MembershipSection) WebConfigurationManager.GetSection
				("system.web/membership");

			sb.AppendFormat ("|Config Total providers|{0}|Config Total providers|", section.Providers.Count);
			sb.AppendFormat ("|Config Default provider|{0}|Config Default provider|", section.DefaultProvider);
			for (int i = 0; i < section.Providers.Count; i++)
				sb.AppendFormat ("|Config Provider|{0}|Config Provider|", section.Providers [i].Name);

			Providers.Text = sb.ToString ();
		}
	</script>
</head>
<body>
	<form action="Default.aspx" runat="server">
		<asp:Label ID="Providers" runat="server" />
	</form>
</body>
</html>
