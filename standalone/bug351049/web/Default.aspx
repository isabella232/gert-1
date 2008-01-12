<%@ Page Language="C#" %>
<html>
<body>
	<%
		Response.Write ("<p>Total: " + Request.Form.Count + "</p>");
		foreach (string key in Request.Form.Keys) {
			string [] P = Request.Form.GetValues (key);
			Response.Write ("<p key=\"" + key + "\">Lenght: " + P.Length + "</p>");
			for (int i = 0; i < P.Length; i++)
				Response.Write ("<p key=\"" + key + "\">P[" + i + "]: " + P [i] + "</p>");
		}
	%>
</body>
</html>
