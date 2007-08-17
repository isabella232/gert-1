<% @ Control Language="C#" ClassName="Mono.Web.UI.ValidControl" %>
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
            Label1.Text = value;
        }
    }
</script>
<asp:Label ID="Label1" runat="server" />
