<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderNavigation.ascx.cs" Inherits="ACR.controls.MammographySavesLives.HeaderNavigation" %>

<div class="main-ribbon-wrapper">
	<div class="main-nav-bar">
		<div class="main-nav-wrapper">
			<ul class="main-nav-list">
				<asp:Repeater ID="rptNav" runat="server">
					<ItemTemplate>
						<li class="main-nav-item" id="listItem" runat="server">
							<a class="main-nav-link" id="navLink" runat="server">
								<span class="main-nav-middle">
									<span class="main-nav-inner">
										<sc:fieldrenderer id="navTitle" runat="server" FieldName="Menu Title" />
									</span>
								</span>
							</a>
						</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
			<ul class="main-nav-list reminder">
				<li class="main-nav-item main-nav-last">
					<a class="main-nav-link reminder-link tell-a-friend-modal" href="/Reminder.aspx" runat="server">Tell A Friend</a>
				</li>
			</ul>
		</div>
		<div class="main-ribbon-right"></div>		
	</div>
</div>