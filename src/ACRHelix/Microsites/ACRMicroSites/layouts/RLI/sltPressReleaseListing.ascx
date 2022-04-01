<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltPressReleaseListing.ascx.cs" Inherits="ACR.layouts.RLI.sltPressReleaseListing" %>



							<article>
								<h1>News Releases</h1>

								<div class="list news">
									<section>
										<aside class="options">
											<asp:DropDownList runat="server" ID="ddlPressReleaseYear" AutoPostBack="True" OnSelectedIndexChanged="ddlPressReleaseYear_OnSelectedIndexChanged"></asp:DropDownList>
										</aside>
										<ul>
											<asp:Repeater runat="server" ID="rptPressReleases" OnItemDataBound="rptPressReleases_OnItemDataBound">
												<ItemTemplate>
											<li>
													
												<div class="date"><asp:Literal runat="server" ID="litDate"/></div>
													<asp:HyperLink runat="server" ID="hlTitle"></asp:HyperLink>
													</li>
												</ItemTemplate>
											</asp:Repeater>
										</ul>
									</section>
								</div>
								<div>
									<asp:Literal runat="server" ID="litBody"/>
								</div>

								

								
							</article>