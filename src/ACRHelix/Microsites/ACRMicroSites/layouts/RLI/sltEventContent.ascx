<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltEventContent.ascx.cs" Inherits="ACR.layouts.RLI.sltEventContent" %>
<%@ Register TagPrefix="rli" TagName="AddThis" Src="~/controls/RLI/AddThisBodyWidget.ascx" %>

							<article>
								<h1><asp:Literal runat="server" ID="litTitle"/></h1>
								
								<h3><asp:Literal runat="server" ID="litSubtitle"></asp:Literal></h3>
								
								<p><asp:HyperLink runat="server" ID="hlRegister" CssClass="register"> Register Today &raquo;</asp:HyperLink></p>
								<asp:Literal runat="server" ID="litBody"></asp:Literal>

								<div class="addthis">
									<!--addthis code/tool here-->
									<rli:AddThis runat="server" />
								</div>
							</article>