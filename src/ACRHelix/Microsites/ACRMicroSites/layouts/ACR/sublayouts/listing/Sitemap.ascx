<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sitemap.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.listing.Sitemap" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACR.Constants" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>

<div class="content">
                <ul>
				    <asp:Repeater ID="TopNav" runat="server" OnItemDataBound="TopNavItemDataBound">
                        <ItemTemplate>
                            <li id="listItemTop" runat="server">
                                <a href="<%# ItemHelper.GetExtensionlessUrl(Container.DataItem as Item) %>">
                                    <%# ItemHelper.GetFieldValueOrItemName(Container.DataItem as Item, Types.Fields.NavNameOverride) %>
                                </a>
   								<asp:Repeater ID="Nested" runat="server" OnItemDataBound="Nested_ItemDataBound">
									<HeaderTemplate><ul></HeaderTemplate>
                                    <ItemTemplate>
										<li id="listItemSecondaryTop" runat="server">
											<a href="<%# ItemHelper.GetExtensionlessUrl(Container.DataItem as Item) %>">
											    <%# ItemHelper.GetFieldValueOrItemName(Container.DataItem as Item, Types.Fields.NavNameOverride) %>
											</a>
                                            <asp:Repeater ID="Nested" runat="server">
									            <HeaderTemplate><ul></HeaderTemplate>
                                                <ItemTemplate>
										            <li>
											            <a href="<%# ItemHelper.GetIndexAnchorUrl(Container.DataItem as Item, (Container.ItemIndex + 1)) %>">
											                <%# ItemHelper.GetFieldValueOrItemName(Container.DataItem as Item, Types.Fields.NavNameOverride) %>
											            </a>
										            </li>
                                                </ItemTemplate>
                                                <FooterTemplate></ul></FooterTemplate>
                                            </asp:Repeater>
										</li>
                                    </ItemTemplate>
                                    <FooterTemplate></ul></FooterTemplate>
                                </asp:Repeater>
                                <section class="navSupport">
                                    <h3><asp:Literal runat="server" ID="NavContentTitle" /></h3>
                                    <asp:Literal ID="NavSupportingLinks" runat="server" />
                                </section>
						    </li>     
                        </ItemTemplate>
                    </asp:Repeater>
			    </ul>
    </div>