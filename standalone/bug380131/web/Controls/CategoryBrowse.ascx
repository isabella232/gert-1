<%@ Control Language="C#" CodeFile="CategoryBrowse.ascx.cs" Inherits="CategoryBrowse_ascx" %>
<asp:DataList ID="TopCategoryList" runat="server" DataSourceID="TopCategoriesDS"
	CssClass="category_browse" HorizontalAlign="Center" RepeatColumns="2" OnItemDataBound="TopCategoryList_ItemDataBound"
	OnItemCommand="TopCategoryList_ItemCommand">
	<ItemStyle VerticalAlign="Top" HorizontalAlign="Left"></ItemStyle>
	<ItemTemplate>
		<h4>
			<asp:LinkButton ID="TopCategoryButton" runat="server" Text='<%# Eval("Name") %>'
				CommandArgument='<%# Eval("Id") %>' />
		</h4>
		(<%# Eval("NumActiveAds") %>)
		<asp:Repeater ID="NestedSubCategoryRepeater" runat="server" DataSourceID="NestedCategoryDS"
			OnItemCommand="NestedSubCategoryRepeater_ItemCommand" OnItemDataBound="NestedSubCategoryRepeater_ItemDataBound">
			<HeaderTemplate>
				<ul>
			</HeaderTemplate>
			<ItemTemplate>
				<li>
					<asp:LinkButton ID="SubCategoryButton" runat="server" Text='<%# Eval("Name") %>'
						CommandArgument='<%# Eval("Id") %>' />
					(<%# Eval("NumActiveAds") %>) </li>
				<asp:Repeater ID="NestedSubCategoryRepeater2" runat="server" OnItemCommand="NestedSubCategoryRepeater_ItemCommand"
					DataSourceID="NestedCategoryDS2">
					<HeaderTemplate>
						<ul>
					</HeaderTemplate>
					<ItemTemplate>
						<li>
							<asp:LinkButton ID="SubCategoryButton2" runat="server" Text='<%# Eval("Name") %>'
								CommandArgument='<%# Eval("Id") %>' />
							(<%# Eval("NumActiveAds") %>) </li>
					</ItemTemplate>
					<FooterTemplate>
						</ul>
					</FooterTemplate>
				</asp:Repeater>
				<asp:ObjectDataSource ID="NestedCategoryDS2" TypeName="AspNet.StarterKits.Classifieds.Web.CategoryCache"
					SelectMethod="GetBrowseCategoriesByParentId" runat="server">
					<SelectParameters>
						<asp:Parameter Type="Int32" Name="parentCategoryId"></asp:Parameter>
					</SelectParameters>
				</asp:ObjectDataSource>
				<!--  end new part -->
			</ItemTemplate>
			<FooterTemplate>
				</ul></FooterTemplate>
		</asp:Repeater>
		<asp:ObjectDataSource ID="NestedCategoryDS" TypeName="AspNet.StarterKits.Classifieds.Web.CategoryCache"
			SelectMethod="GetBrowseCategoriesByParentId" runat="server">
			<SelectParameters>
				<asp:Parameter Type="Int32" Name="parentCategoryId"></asp:Parameter>
			</SelectParameters>
		</asp:ObjectDataSource>
	</ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="TopCategoriesDS" runat="server" TypeName="AspNet.StarterKits.Classifieds.Web.CategoryCache"
	SelectMethod="GetBrowseCategoriesByParentId">
	<SelectParameters>
		<asp:Parameter Type="Int32" DefaultValue="0" Name="parentCategoryId"></asp:Parameter>
	</SelectParameters>
</asp:ObjectDataSource>
