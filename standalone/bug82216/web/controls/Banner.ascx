<% @ Control Language="C#" ClassName="Banner" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    
    public string Text
    {
        get {
            return Label1.Text;
        }
        set {
            Label1.Text = "Custom" + value;
        }
    }
</script>
<asp:Label ID="Label1" runat="server" />
