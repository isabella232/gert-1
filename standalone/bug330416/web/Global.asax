<%@ Application language="C#" %>
<%@ Assembly Src="~/Util/Tracer.cs" %>
<%@ Import Namespace="Mono.Util" %>
<script runat="server">
	public override void Init()
	{
		Tracer.Debug ("OK");
		Bag.ItemCount = Bag.ItemCount + 1;
	}
</script>
