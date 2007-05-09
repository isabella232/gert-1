<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="CreatePage" %>

<html>
<head id="head1" runat="server">
</head>
<body>
	<form id="form1" runat="server">
		<asp:ObjectDataSource ID="ObjectDataSource" runat="server" TypeName="BusinessLayer"
			SelectCountMethod="EntityCount" SelectMethod="SelectEntity" OnSelecting="ObjectDataSource_Selecting">
			<SelectParameters>
				<asp:Parameter Name="startIndex" Type="Int32" />
				<asp:Parameter Name="maxCount" Type="Int32" />
			</SelectParameters>
		</asp:ObjectDataSource>
		<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
			DataSourceID="ObjectDataSource" PageSize="1">
			<Columns>
				<asp:BoundField DataField="Data2" HeaderText="Data2" SortExpression="Data2" />
				<asp:BoundField DataField="Data1" HeaderText="Data1" SortExpression="Data1" />
			</Columns>
		</asp:GridView>
	</form>
</body>
</html>
