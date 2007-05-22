<% @ Control Language="C#" ClassName="Banner" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Profile.ControlCustom;
    }
    
    public string Text
    {
        get {
            return Label1.Text;
        }
    }
</script>
<asp:Label ID="Label1" runat="server" />
