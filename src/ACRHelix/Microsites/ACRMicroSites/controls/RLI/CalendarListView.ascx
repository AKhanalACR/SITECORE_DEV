<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarListView.ascx.cs" Inherits="ACR.controls.RLI.CalendarListView" %>
<section>
            <fieldset class="calendarFilter cf">
		        <label>Filter By:</label>							
		        <asp:DropDownList runat="server" id="ddEventTags" cssclass="fltrEvtTag" ClientIDMode="Static"  />
		       <asp:Button runat="server" ID="btnFiltersListView" class="button red event-filter" OnClick="btnFiltersListView_Click" Text="Go &raquo;"></asp:Button>
	        </fieldset>
			<asp:Repeater runat="server" ID="rptMonths" OnItemDataBound="rptMonths_OnItemDataBound">
				<ItemTemplate>
					<div class="month">
						<label><asp:Literal runat="server" ID="litMonth"/></label>
						<fieldset>
							<asp:Repeater runat="server" ID="rptEvents" OnItemDataBound="rptEvents_OnItemDataBound">
								<ItemTemplate>
									<div class="event">
										<span class="title"><asp:Literal runat="server"  ID="litTitle"/></span>
										<p>
											<span class="time"><asp:Literal runat="server" ID="litTime" /></span> <asp:PlaceHolder ID="plcSeparator" runat="server"> - </asp:PlaceHolder><asp:Literal runat="server" ID="litDetails"/><br /><asp:HyperLink runat="server" CssClass="register" ID="hlRegister">Register Now &raquo;</asp:HyperLink>
										</p>
									</div>
								</ItemTemplate>
							</asp:Repeater>
						</fieldset>
					</div>
				</ItemTemplate>
			</asp:Repeater> 
</section>