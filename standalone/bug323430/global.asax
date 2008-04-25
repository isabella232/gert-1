<% @Application Language="C#" %>
<script runat="server">
void Application_Start(object o, EventArgs e) {
	Console.Error.WriteLine("app started.");
}

void Application_End(object o, EventArgs e) {
	Console.Error.WriteLine("app ended.");
	Console.Error.WriteLine();
}

void Session_Start(object o, EventArgs e) {
	Console.Error.WriteLine("session started.");
}

void Session_End(object o, EventArgs e) {
	Console.Error.WriteLine("session ended.");
}

void Application_Error(Object sender, EventArgs e) {
	Console.Error.WriteLine("app error!");
	Console.Error.WriteLine(Server.GetLastError());
}
</script>
