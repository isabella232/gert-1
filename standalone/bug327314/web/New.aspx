<%@ Page Language="C#"%>
<html xmlns="http://www.w3.org/1999/xhtml">
	<script runat="server">
		protected override void OnLoad (EventArgs e)
		{
			if (Request.QueryString.ToString () != "name=er&address=ERE") {
				Response.Write ("A");
				return;
			}

			if (Request.ContentLength != 0) {
				Response.Write ("B:" + Request.ContentLength);
				return;
			}

			byte [] buffer = new byte [2048];
			int bytesRead = 1;
			int input = 0;
			
			while (bytesRead != 0) {
				bytesRead = Request.InputStream.Read (buffer, 0, buffer.Length);
				input += bytesRead;
			}

			if (input != 0) {
				Response.Write ("C:" + input);
				return;
			}

			if (Request.TotalBytes != 0) {
				Response.Write ("D:" + Request.TotalBytes);
				return;
			}

			if (Request.ContentType != "application/x-www-form-urlencoded") {
				Response.Write ("E:" + Request.ContentType);
				return;
			}

			if (Request.HttpMethod != "GET") {
				Response.Write ("F:" + Request.HttpMethod);
				return;
			}
			
			Response.Write ("<p>OK</p>");
		}
	</script>
</html>
