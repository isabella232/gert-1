<%@ Page Language="C#" AutoEventWireup="true" ClassName="ValidPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            var dt = new Date();
            document.write("<sc" + "ript src='script/somescript.js?" + dt.getTime() + "'></sc" + "ript>");
        </script>
        <p>OK</p>
    </form>
</body>
</html>
