<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="Mono.Test._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="TestGrid" runat="server" DataSourceID="TestDataSource" AutoGenerateColumns="False" DataKeyNames="ID">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField DataField="Age" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="TestDataSource"
                              runat="server"
                              SelectMethod="GetAll"
                              SelectCountMethod="SelectCount"
                              TypeName="Mono.Test.Data.TestItemSource"
                              OnObjectCreating="TestDataSource_ObjectCreating">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
