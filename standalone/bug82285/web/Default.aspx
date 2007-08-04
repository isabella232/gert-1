<%@ Page Language="C#" %>
<% @Register Tagprefix="hf" tagname="Test1" src="Test1.ascx" %>
<% @Register Tagprefix="hf" tagname="Test2" src="Test2.ascx" %>
<% @Register Tagprefix="hf" tagname="Test3" src="Test3.ascx" %>
<hf:Test1 runat="server" /><hf:Test2 runat="server" /><hf:Test3 runat="server" />
