<%@ Page Language="C#" Src="default11.aspx.cs" Inherits="_Default" %>
<html><head><title>Bug #77573 test</title></head>
<body>
  <form runat="server">
    <asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="True"
		  PageSize="20" AllowPaging="True" CssClass="datatable">
      <PagerStyle Mode="NumericPages">
      </PagerStyle>
    </asp:DataGrid>
  </form>
</body>
</html>
