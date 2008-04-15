<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Default.aspx.cs"
	Inherits="Default_aspx" Title="Welcome" %>

<%@ Register TagPrefix="uc1" TagName="FeaturedAd" Src="Controls/FeaturedAd.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CategoryBrowse" Src="Controls/CategoryBrowse.ascx" %>
<asp:Content ID="SecondBarContent" ContentPlaceHolderID="SecondBar" runat="server">
	<div id="crumbs_search">
		<p>
			Search:
		</p>
		<p>
			<asp:TextBox ID="CommonSearchTextBox" runat="server" CssClass="search_box" AccessKey="s"
				TabIndex="1"></asp:TextBox>
			<asp:Button ID="CommonSearchButton" runat="server" Text="Search" CssClass="submit"
				PostBackUrl="~/Search.aspx" />
		</p>
	</div>
	<div id="whats_new">
		<p>
			What's new:
		</p>
		<p>
			<asp:DropDownList ID="CommonWhatsNewRangeList" runat="server">
				<asp:ListItem Value="1" Selected="True">in the last 24 hours</asp:ListItem>
				<asp:ListItem Value="2">in the last 48 hours</asp:ListItem>
				<asp:ListItem Value="7">in the last week</asp:ListItem>
				<asp:ListItem Value="30">in the last month</asp:ListItem>
			</asp:DropDownList>
			<asp:Button ID="CommonWhatsNewButton" runat="server" Text="Go" CssClass="submit"
				PostBackUrl="~/Search.aspx" OnClick="CommonWhatsNewButton_Click" />
		</p>
	</div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="Main" runat="server">
	<div id="body">
		<div id="col_main_left">
			<uc1:FeaturedAd ID="FeaturedAd" runat="server" />
			<div id="announcements">
				<ul>
					<li>The latest activity relating to your ads and offers will appear on the My Ads &amp;
						Profile page. <a href="MyAds.aspx" title="My Ads & Profile">My Ads & Profile</a>
					</li>
					<li>Placing a new ad is fast and easy. <a href="PostAd.aspx" title="New Ad">Place a
						New Ad</a> </li>
				</ul>
			</div>
		</div>
		<div id="col_main_right">
			<h3 class="section">
				Browse Categories</h3>
			<div class="content_right">
				<uc1:CategoryBrowse ID="CategoryBrowser" runat="server" AutoNavigate="True"></uc1:CategoryBrowse>
			</div>
		</div>
	</div>
</asp:Content>
