<%@ Page Language="C#" %>
<html>
<body>
	<%
		string[] P=Request.Params.GetValues("Pippo");
		Response.Write("<p>Lenght: " + P.Length + "</p>");
		for (int i = 0; i < P.Length; i++)
			Response.Write("<p>P[" + i + "]: " + P [i] + "</p>");
	%>
</body>
</html>
