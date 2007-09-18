<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TestMono.aspx.vb" Inherits="TestMono.WebForm1"%>
<%@ Register TagPrefix="TESTMONO" TagName="Header" Src="_Header.ascx" %>
<%@ Register TagPrefix="TESTMONO" TagName="Footer" Src="_Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>TestMono</title>
</HEAD>
  <body><TESTMONO:Header id="header" runat=server></TESTMONO:Header>

    <form id="TestMono" runat="server">
Body 
    </form><TESTMONO:Footer id="footer" runat=server></TESTMONO:Footer>

  </body>
</HTML>
