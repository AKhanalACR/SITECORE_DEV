<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Main.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.navigation.Main" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACR.Constants" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
            <nav id="main-nav">
			    <ul>
				    <asp:Repeater ID="TopNav" runat="server" OnItemDataBound="TopNavItemDataBound">
                        <ItemTemplate>
                            <li id="listItemTop" runat="server">
                                <a href="<%# ItemHelper.GetExtensionlessUrl(Container.DataItem as Item) %>">
                                    <%# ItemHelper.GetFieldValueOrItemName(Container.DataItem as Item, Types.Fields.NavNameOverride) %>
                                </a>
   								<asp:Repeater ID="Flyout" runat="server" OnItemDataBound="Flyout_ItemDataBound">
									<HeaderTemplate><ul style="display: none;"></HeaderTemplate>
                                    <ItemTemplate>
										<li id="listItemSecondaryTop" runat="server">
											<a href="<%# ItemHelper.GetExtensionlessUrl(Container.DataItem as Item) %>">
											    <%# ItemHelper.GetFieldValueOrItemName(Container.DataItem as Item, Types.Fields.NavNameOverride) %>
											</a>
                                            <asp:Repeater ID="Flyout" runat="server">
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
                                    <span class="supportTitle"><asp:Literal ID="NavContent" runat="server" /></span>
                                    <asp:Literal ID="NavSupportingLinks" runat="server" />
                                </section>
						    </li>     
                        </ItemTemplate>
                    </asp:Repeater>
			    </ul>
			
			    <div id="main-nav-bottom-mobile" class="show-on-ipad mobile-only">
				    <div id="inner-bottom-mobile">
					     <span class="supportTitle"><asp:Literal ID="NavContent" runat="server" /></span>
				    </div>
			    </div>
		    </nav>