<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="CreatePage" %>

<html>
<head id="head1" runat="server">
</head>
<body>
	<form id="form1" runat="server">
		<asp:ObjectDataSource ID="EventObjectDataSource" runat="server" TypeName="BusinessLayer"
			DataObjectTypeName="SailEventScheduler.Contracts.DataModel.EventEntity" InsertMethod="InsertEvent">
		</asp:ObjectDataSource>
		<asp:ObjectDataSource ID="EventCategoryObjectDataSource" runat="server" TypeName="BusinessLayer"
			SelectMethod="SelectEntity"></asp:ObjectDataSource>
		<asp:DetailsView ID="InsertEventDetailsView" runat="server" AutoGenerateRows="False"
			HeaderText="Create new Event" DataSourceID="EventObjectDataSource" DefaultMode="Insert">
			<Fields>
				<asp:TemplateField HeaderText="Category:">
					<InsertItemTemplate>
						<asp:DropDownList ID="CategoryDropDownList" runat="server" DataSourceID="EventCategoryObjectDataSource"
							DataValueField="Data1" DataTextField="Data2" AppendDataBoundItems="True">
							<asp:ListItem Selected="True" Value="" Text="(Select)" />
						</asp:DropDownList>
					</InsertItemTemplate>
				</asp:TemplateField>
				<asp:CommandField ButtonType="Button" ShowInsertButton="True" />
			</Fields>
		</asp:DetailsView>
	</form>
</body>
</html>
